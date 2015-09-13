namespace BugTracker.RestServices.Models
{
    using BugTracker.Data.Models;

    public class EditBugInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus? Status { get; set; }
    }
}
