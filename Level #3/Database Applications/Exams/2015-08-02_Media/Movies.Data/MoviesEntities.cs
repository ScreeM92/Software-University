namespace Movies.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class MoviesEntities : DbContext
    {
        public MoviesEntities()
            : base("name=MoviesEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesEntities, Configuration>());
        }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }
    }
}