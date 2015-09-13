namespace BookShopSystem.WebApi.Models.Authors
{
    using System.ComponentModel.DataAnnotations;

    public class AddAuthorBindingModel
    {
        [Required]
        [Display(Name = "Author First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Author Last Name")]
        public string LastName { get; set; }
    }
}