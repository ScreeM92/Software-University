namespace BookShopSystem.WebApi.Models.Books
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BookShopSystem.Models;

    public class BookViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType Edition { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public ICollection<string> Categories { get; set; }

        public static BookViewModel Create(Book book)
        {
            var bookView = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Edition = book.Edition,
                Price = book.Price,
                Copies = book.Copies,
                ReleaseDate = book.ReleaseDate,
                AgeRestriction = book.AgeRestriction,
                Author = book.Author != null ? book.Author.FirstName + " " + book.Author.LastName : "",
                Categories = new List<string>()
            };

            AddCategories(bookView, book.Categories);

            return bookView;
        }

        private static void AddCategories(BookViewModel bookView, ICollection<Category> categories)
        {
            foreach (var category in categories)
            {
                bookView.Categories.Add(category.Name);
            }
        }
    }
}