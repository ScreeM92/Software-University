namespace News.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}