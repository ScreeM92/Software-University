using GoblinFreelancer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GoblinFreelancer.Models.ViewModels
{
    public class ProjectViewModelShort
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }
    }
}