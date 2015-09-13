namespace StudentSystem.Models
{
    using Microsoft.Build.Framework;

    public class License
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Resource Resource { get; set; }
    }
}