namespace BookShopSystem.WebApi.Models.Books
{
    using System.ComponentModel.DataAnnotations;

    public class TopBooksViewModel
    {
        [Display(Name = "Book Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        public static TopBooksViewModel Create(int id, string title)
        {
            return new TopBooksViewModel
            {
                Id = id,
                Title = title
            };
        }
    }
}