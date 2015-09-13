namespace Movies.Data
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var context = new MoviesEntities();

            Console.WriteLine("Users: {0}", context.Users.Count());
            Console.WriteLine("Countries: {0}", context.Countries.Count());
            Console.WriteLine("Movies: {0}", context.Movies.Count());
            Console.WriteLine("Ratings: {0}", context.Ratings.Count());
            Console.WriteLine("MoviesUsers: {0}", context.Users.Sum(u => u.FavouriteMovies.Count));
        }
    }
}
