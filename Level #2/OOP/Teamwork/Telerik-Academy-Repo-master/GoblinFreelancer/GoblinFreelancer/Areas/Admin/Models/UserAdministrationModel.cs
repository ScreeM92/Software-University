using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GoblinFreelancer.Areas.Admin.Models
{
    public class UserAdministrationModel
    {
        public string UserName { get; set; }

        public bool IsBanned { get; set; }

        [ScaffoldColumn(false)]
        public string Id { get; set; }
    }
}
