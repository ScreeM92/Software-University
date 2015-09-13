using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinFreelancer.Areas.Admin.Models
{
    public class CategoryAdministrationModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}