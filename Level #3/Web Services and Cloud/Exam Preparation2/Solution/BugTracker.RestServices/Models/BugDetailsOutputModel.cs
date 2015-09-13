namespace BugTracker.RestServices.Models
{
    using System;
    using System.Collections.Generic;

    public class BugDetailsOutputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CommentOutputModel> Comments { get; set; }
    }
}
