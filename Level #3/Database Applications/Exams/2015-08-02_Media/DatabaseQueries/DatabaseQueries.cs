namespace DatabaseQueries
{
    using System;
    using System.IO;
    using System.Linq;
    using Movies.Data;
    using Movies.Data.Models;
    using Newtonsoft.Json;

    public class DatabaseQueries
    {
        private const string ExportPath = @"..\..\..\Export\";
        private static readonly string Separator = new string('-', 80);

        public static void Main()
        {
            CheckExistingDirectory(ExportPath);
            var context = new MoviesEntities();
            context.Ratings.Count(); // use it execute all migration queries

            Console.WriteLine(Separator);
            Console.WriteLine("01. Adult movies:");
            ExportAdultMovies(context);
            Console.WriteLine(Separator);

            Console.WriteLine("02. Rated Movies by User - \"jmeyery\":");
            MovieRatingByUser(context, "jmeyery");
            Console.WriteLine(Separator);

            Console.WriteLine("03. Top 10 Favourite Movies:");
            TopTenFavouriteMovies(context);
            Console.WriteLine(Separator);
        }

        private static void ExportAdultMovies(MoviesEntities context)
        {
            string fileName = "adult-movies.json";

            var movies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Ratings.Count)
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratings.Count
                });

            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            File.WriteAllText(ExportPath + fileName, json);
            Console.WriteLine("File path: {0}", Path.GetFullPath(ExportPath + fileName));
        }

        private static void MovieRatingByUser(MoviesEntities context, string userName)
        {
            string fileName = string.Format("rated-movies-by-{0}.json", userName);

            var userMovies = context.Movies
                .Where(m => m.Ratings.Any(r => r.User.Username == userName))
                .OrderBy(m => m.Title)
                .Select(m => new
                {
                    userName,
                    m.Title,
                    m.Ratings.FirstOrDefault(u => u.User.Username == userName).Stars,
                    Average = m.Ratings.Average(r => r.Stars)
                })
                .GroupBy(m => m.userName, (k, v) => new
                {
                    userName = k,
                    ratedMovies = v.Select(a => new
                    {
                        a.Title,
                        a.Stars,
                        a.Average
                    })
                });

            var json = JsonConvert.SerializeObject(userMovies, Formatting.Indented);
            File.WriteAllText(ExportPath + fileName, json);

            Console.WriteLine("File path: {0}", Path.GetFullPath(ExportPath + fileName));
        }

        private static void TopTenFavouriteMovies(MoviesEntities context)
        {
            var movies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Teen)
                .OrderByDescending(m => m.Users.Count)
                .ThenBy(m => m.Title)
                .Select(m => new
                {
                    isbn = m.Isbn,
                    title = m.Title,
                    favouritedBy = m.Users.Select(u => u.Username)
                })
                .Take(10);

            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            string fileName = "top-10-favourite-movies.json";
            File.WriteAllText(ExportPath + fileName, json);

            Console.WriteLine("File path: {0}", Path.GetFullPath(ExportPath + fileName));
        }

        private static void CheckExistingDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
