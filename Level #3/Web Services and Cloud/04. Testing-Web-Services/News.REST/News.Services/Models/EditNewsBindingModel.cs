namespace News.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditNewsBindingModel
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}