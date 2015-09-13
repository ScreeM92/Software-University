namespace BugTracker.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [Required]
        public string Text { get; set; }
    }
}
