using GoblinFreelancer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GoblinFreelancer.ViewModels
{
    public class ProjectViewModelShort
    {
        public static Expression<Func<Project, ProjectViewModelShort>> FromProject
        {
            get
            {
                return project => new ProjectViewModelShort
                {
                    Id = project.Id,
                    Name = project.Name
                };
            }
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}