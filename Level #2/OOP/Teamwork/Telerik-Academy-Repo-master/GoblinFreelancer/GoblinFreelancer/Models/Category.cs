using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinFreelancer.Models
{
    public class Category
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
        }

        [Display(Name="Category")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}