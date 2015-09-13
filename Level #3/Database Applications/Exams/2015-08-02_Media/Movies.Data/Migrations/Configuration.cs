namespace Movies.Data.Migrations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.IO;
    using System.Linq;
    using Models;
    using Newtonsoft.Json;
    using ParsenModels;

    internal sealed class Configuration : DbMigrationsConfiguration<Movies.Data.MoviesEntities>
    {
        private const string CountriesImportPath = @"..\..\..\Import\countries.json";
        private const string UsersImportPath = @"..\..\..\Import\users.json";
        private const string MoviesImportPath = @"..\..\..\Import\movies.json";
        private const string UserAndMoviesImportPath = @"..\..\..\Import\users-and-favourite-movies.json";
        private const string MovieRagingsImportPath = @"..\..\..\Import\movie-ratings.json";

        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "Movies.Data.MoviesEntities";
        }
        protected override void Seed(Movies.Data.MoviesEntities context)
        {
            if (!context.Countries.Any())
            {
                SeedCountries(context, CountriesImportPath);
            }

            if (!context.Users.Any())
            {
                SeedUsers(context, UsersImportPath);
            }

            if (!context.Movies.Any())
            {
                SeedMovies(context, MoviesImportPath);
            }

            if (!context.Users.Any(u => u.FavouriteMovies.Any()))
            {
                SeedUsersAndMovies(context, UserAndMoviesImportPath);
            }

            if (!context.Ratings.Any())
            {
                SeedRatings(context, MovieRagingsImportPath);
            }
        }

        private static void SeedCountries(MoviesEntities context, string filePath)
        {
            var json = File.ReadAllText(filePath);

            var countries = JsonConvert.DeserializeObject<IList<Country>>(json);

            countries.ToList().ForEach(c => context.Countries.Add(c));
            context.SaveChanges();
        }

        private static void SeedUsers(MoviesEntities context, string filePath)
        {
            var json = File.ReadAllText(filePath);

            var users = JsonConvert.DeserializeObject<IList<UserModel>>(json);

            foreach (var user in users)
            {
                context.Users.Add(new User
                {
                    Username = user.Username,
                    Age = user.Age,
                    Email = user.Email,
                    Country = user.Country != null ? 
                        context.Countries.FirstOrDefault(c => c.Name == user.Country) : 
                        null
                });
            }

            context.SaveChanges();
        }

        private static void SeedMovies(MoviesEntities context, string filePath)
        {
            var json = File.ReadAllText(filePath);

            var movies = JsonConvert.DeserializeObject<IList<Movie>>(json);

            movies.ToList().ForEach(m => context.Movies.Add(m));

            context.SaveChanges();
        }

        private static void SeedUsersAndMovies(MoviesEntities context, string filePath)
        {
            var json = File.ReadAllText(filePath);

            var usersMovies = JsonConvert.DeserializeObject<IList<UserMovies>>(json);

            foreach (var userMovies in usersMovies)
            {
                var user = context.Users.First(u => u.Username == userMovies.Username);
                foreach (var movie in userMovies.FavouriteMovies)
                {
                    user.FavouriteMovies.Add(context.Movies.First(m => m.Isbn == movie));
                }
            }

            context.SaveChanges();
        }

        private static void SeedRatings(MoviesEntities context, string filePath)
        {
            var json = File.ReadAllText(filePath);

            var ratings = JsonConvert.DeserializeObject<IList<MovieRating>>(json);

            foreach (var rating in ratings)
            {
                var user = context.Users.First(u => u.Username == rating.User);
                var movie = context.Movies.First(m => m.Isbn == rating.Movie);
                context.Ratings.Add(new Rating
                {
                    Stars = rating.Rating,
                    Movie = movie,
                    User = user
                });
            }

            context.SaveChanges();
        }
    }
}