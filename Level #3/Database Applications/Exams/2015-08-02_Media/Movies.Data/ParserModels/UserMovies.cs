namespace Movies.Data.ParsenModels
{
    using System.Collections.Generic;

    public class UserMovies
    {
        public string Username { get; set; }

        public IList<string> FavouriteMovies { get; set; }
    }
}