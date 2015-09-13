namespace Restaurants.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RateInputModel
    {
        [Required]
        public int Stars { get; set; }
    }
}