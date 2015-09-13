using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GoblinFreelancer.Models.ViewModels
{
    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    //Projects = category.Projects
                    CountOfProjects = category.Projects.Count
                };
            }
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CountOfProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}