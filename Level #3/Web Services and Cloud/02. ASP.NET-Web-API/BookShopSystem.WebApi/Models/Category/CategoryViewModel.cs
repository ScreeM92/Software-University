namespace BookShopSystem.WebApi.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using BookShopSystem.Models;

    public class CategoryViewModel
    {
        [Display(Name = "Category Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public static CategoryViewModel Create(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    } 
}