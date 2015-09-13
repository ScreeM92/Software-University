namespace BookShopSystem.WebApi.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BookShopSystem.Models;

    public class AuthorViewModel
    {
        [Required]
        [Display(Name = "Author Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Author First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Author Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Author Books Titles")]
        public ICollection<string> BookTitles { get; set; }

        public static AuthorViewModel Create(Author author)
        {
            var authorView = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BookTitles = new List<string>(),
                
            };

            AddBookTitles(authorView, author.Books);

            return authorView;
        }

        private static void AddBookTitles(AuthorViewModel authorView, IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                authorView.BookTitles.Add(book.Title);
            }
        }
    }
}