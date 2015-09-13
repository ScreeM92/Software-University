namespace BugTracker.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SubmitBugInputModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
