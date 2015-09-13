namespace Restaurants.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MealInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
    }
}