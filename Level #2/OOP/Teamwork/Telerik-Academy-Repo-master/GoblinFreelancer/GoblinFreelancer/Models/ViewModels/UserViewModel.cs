using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace GoblinFreelancer.Models.ViewModels
{
    public class UserViewModel
    {
        public static Func<ApplicationUser, UserViewModel> FromUser
        {
            get
            {
                return user => new UserViewModel()
                {
                    Id = user.Id,
                    Skills = user.Skills.Count != 0 ? 
                        String.Join(", ", user.Skills.Select(skill => skill.Name)) : "None",
                    Roles = user.Roles.Count != 0 ?
                    String.Join(", ", user.Roles.Select(role => role.Role.Name)) : "None",
                    UserName = user.UserName,
                    Rating = (user.TimesRated> 0 && user.Rating > 0) ? String.Format("{0:F1}", user.Rating/user.TimesRated) : "0",
                    Email = user.Email
                };
            }
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Skills { get; set; }
        public string Email { get; set; }
        public string Rating { get; set; }
        public string Roles { get; set; }
    }

    
}