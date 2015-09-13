using GoblinFreelancer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GoblinFreelancer.ViewModels
{
    public class ProjectViewModelFull
    {
        public static Func<Project, ProjectViewModelFull> FromProject
        {
            get
            {
                return project => new ProjectViewModelFull
                {
                    Id = project.Id,
                    Name = project.Name,
                    CategoryName = project.Category != null ? project.Category.Name : null,
                    CreatedOn = project.CreatedOn,
                    Deadline = project.Deadline,
                    Owner = project.Owner.UserName,
                    Salary = project.Salary,
                    Summary = project.Summary,
                    Skills = String.Join(" ", project.Skills.Select(p => p.Name).ToList())
                    
                };
            }
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

        
        public string CategoryName { get; set; }
        public string Owner { get; set; }

        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Deadline { get; set; }
        public decimal Salary { get; set; }
        public string Skills { get; set; }
    }
}