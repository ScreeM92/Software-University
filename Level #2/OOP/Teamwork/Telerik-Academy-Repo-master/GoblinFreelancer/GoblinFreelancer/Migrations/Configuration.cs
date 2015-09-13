namespace GoblinFreelancer.Migrations
{
    using GoblinFreelancer.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.Owin.Security;
    using System.Data.Entity.Validation;
    using GoblinFreelancer.Controllers;
    using System.Threading;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<GoblinFreelancer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GoblinFreelancer.Models.ApplicationDbContext context)
        {
            var dbContext = new ApplicationDbContext();

            if (dbContext.Categories.Count() > 0)
            {
                return;
            }

            var user = dbContext.Users.FirstOrDefault(u => u.UserName == "testuser");
            if (user == null)
	        {
		        user = new ApplicationUser()
                {
                    UserName = "testuser",
                    Email = "testuser@test.com",
                    Skills = new List<Skill>() 
                            { 
                                new Skill { Name = "C#" },
                                new Skill { Name = "Javascript#" },
                                new Skill { Name = "ASP.NET MVC" }
                            }
                };
	        }

            dbContext.Users.Add(user);

            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                var category = new Category()
                {
                    Name = "Test Category " + i
                };

                for (int j = 0; j < 10; j++)
                {
                    var project = new Project()
                    {
                        Category = category,
                        CreatedOn = DateTime.Now,
                        Deadline = DateTime.Now.AddDays(j),
                        Name = "Test project" + j,
                        Owner = user,
                        Salary = rand.Next(100, 10000),
                        Summary = "Very cool project. With super awesome collaborators and stuff. 'Nuff said.",
                        Skills = new List<Skill>() 
                            { 
                                new Skill { Name = "C#" },
                                new Skill { Name = "Javascript#" },
                                new Skill { Name = "ASP.NET MVC" }
                            }
                    };
                    category.Projects.Add(project);
                }
                dbContext.Categories.Add(category);
            }
            dbContext.SaveChanges();

            base.Seed(dbContext);
        }
    }
}
