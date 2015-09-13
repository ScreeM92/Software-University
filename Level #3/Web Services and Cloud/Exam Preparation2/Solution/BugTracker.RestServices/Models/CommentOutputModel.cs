namespace BugTracker.RestServices.Models
{
    using System;

    public class CommentOutputModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
