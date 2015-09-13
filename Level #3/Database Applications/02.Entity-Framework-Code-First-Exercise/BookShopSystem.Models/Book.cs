namespace BookShopSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Category> categories;
        private ICollection<Book> relatedBooks; 

        public Book()
        {
            this.categories = new HashSet<Category>();
            this.relatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public EditionType Edition { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }
        
        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Book> RelatedBooks
        {
            get { return this.relatedBooks; }
            set { this.relatedBooks = value; }
        }
    }
}
