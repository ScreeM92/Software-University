namespace Movies.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        private ICollection<Rating> ratings;

        private ICollection<User> users; 

        public Movie()
        {
            this.ratings = new HashSet<Rating>();
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [StringLength(100), MinLength(2)]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Rating> Ratings {
            get
            {
                return this.ratings;
            }

            set
            {
                this.ratings = value;
            }
        }

        public virtual ICollection<User> Users {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }
    }
}