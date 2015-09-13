namespace Movies.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Movie> favouriteMovies;

        public User()
        {
            this.favouriteMovies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(255)]
        public string Username { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Movie> FavouriteMovies {
            get
            {
                return this.favouriteMovies;
            }

            set
            {
                this.favouriteMovies = value;
            }
        }
    }
}