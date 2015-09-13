namespace StudentSystem.Models
{
    using System.Collections.Generic;

    public class Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}