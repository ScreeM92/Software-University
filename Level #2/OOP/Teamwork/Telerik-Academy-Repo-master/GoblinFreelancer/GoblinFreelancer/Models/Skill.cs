using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoblinFreelancer.Models
{
    public class Skill
    {
        public Skill()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Projects = new HashSet<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}