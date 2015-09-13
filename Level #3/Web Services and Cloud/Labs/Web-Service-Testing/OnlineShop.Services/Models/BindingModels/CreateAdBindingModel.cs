namespace OnlineShop.Services.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CustomAttributes;

    public class CreateAdBindingModel
    {
        [Required]
        [StringLength(100), MinLength(1)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }

        [EnsureMinimumElements(1, ErrorMessage = "At least 1 category required")]
        [EnsureMaximumElements(3, ErrorMessage = "No more than 3 categories required")]
        public IEnumerable<int> Categories { get; set; }
    }
}