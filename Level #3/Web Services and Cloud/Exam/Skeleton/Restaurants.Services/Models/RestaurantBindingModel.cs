namespace Restaurants.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RestaurantBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int TownId { get; set; }
    }
}