namespace BookShopSystem.WebApi.Models.Books
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BookShopSystem.Models;

    public class AddBookBindingModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        [Required]
        public EditionType Edition { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Categories { get; set; }
    }
}