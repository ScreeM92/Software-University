namespace BookShopSystem.WebApi.Models.Authors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BookShopSystem.Models;

    public class AuthorBooksViewModel
    {
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

        public ICollection<string> Categories { get; set; }

        public static AuthorBooksViewModel Create(Book book)
        {
            var bookView = new AuthorBooksViewModel
            {
                Title = book.Title,
                Description = book.Description,
                Edition = book.Edition,
                Price = book.Price,
                Copies = book.Copies,
                ReleaseDate = book.ReleaseDate,
                AgeRestriction = book.AgeRestriction,
                Categories = new List<string>(),

            };

            AddCategories(bookView, book.Categories);

            return bookView;
        }

        private static void AddCategories(AuthorBooksViewModel book, ICollection<Category> categories)
        {
            foreach (var category in categories)
            {
                book.Categories.Add(category.Name);
            }
        }
    } 
}