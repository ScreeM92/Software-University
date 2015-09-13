using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GoblinFreelancer.Models;
using GoblinFreelancer.Repository;
using Moq;
using System.Web.Mvc;
using System.Data.Entity;
using GoblinFreelancer.Controllers;
using System.Linq;
using GoblinFreelancer.ViewModels;

namespace GoblinFreelancer.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexMethodShouldReturnProperNumberOfProjects()
        {
            var list = new List<Project>();
            list.Add(new Project()
            {
                Id = 1,
                Salary = 500,
                CreatedOn = DateTime.Now,
                Deadline = DateTime.Now,
                Name = "Name",
                Summary = "Summary",
                Category = new Category { Name = "Cat" },
                Owner = new ApplicationUser(),
                Skills = new List<Skill>() { new Skill() { Name = "Skill" } },
                Collaborators = new List<ApplicationUser>() { new ApplicationUser() }
            });
            list.Add(new Project()
            {
                Id = 2,
                Salary = 600,
                CreatedOn = DateTime.Now,
                Deadline = DateTime.Now,
                Name = "Name2",
                Summary = "Summary2",
                Category = new Category { Name = "Cat2" },
                Owner = new ApplicationUser(),
                Skills = new List<Skill>() { new Skill() { Name = "Skill" } },
                Collaborators = new List<ApplicationUser>() { new ApplicationUser() }
            });

            var projectRepoMock = new Mock<IRepository<Project>>();
            projectRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUowData>();
            uofMock.Setup(x => x.Projects).Returns(projectRepoMock.Object);

            var controller = new HomeController(uofMock.Object);
            var viewResult = controller.Index();
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<ProjectViewModelFull>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }
    }
}
