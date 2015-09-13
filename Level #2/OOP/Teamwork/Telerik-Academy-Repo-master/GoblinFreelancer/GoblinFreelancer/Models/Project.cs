using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinFreelancer.Models
{
    public class Project
    {
        public Project()
        {
            this.Collaborators = new HashSet<ApplicationUser>();
            this.Skills = new HashSet<Skill>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Summary { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<ApplicationUser> Collaborators { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime Deadline { get; set; }
        public decimal Salary { get; set; }
    }
}