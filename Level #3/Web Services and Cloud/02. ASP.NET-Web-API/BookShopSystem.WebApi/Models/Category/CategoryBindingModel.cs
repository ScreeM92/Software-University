namespace BookShopSystem.WebApi.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class CategoryBindingModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}