using GoblinFreelancer.Areas.Admin.Models;
using GoblinFreelancer.Repository;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Net;

namespace GoblinFreelancer.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ProjectsController : Controller
    {
        private IUowData database;
        public ProjectsController()
        {
            this.database = new UowData();
        }

        public ProjectsController(IUowData database)
        {
            this.database = database;
        }

        [HttpPost]
        public ActionResult UpdateProject(ProjectAdministrationModel project)
        {
            if (ModelState.IsValid)
            {
                var selectedProject = (from dbProject in this.database.Projects.All()
                                       where project.Id == dbProject.Id
                                       select dbProject).FirstOrDefault();

                selectedProject.Name = project.Name;
                selectedProject.Deadline = project.Deadline;
                selectedProject.Salary = project.Salary;
                selectedProject.Summary = project.Summary;

                var selectedCategory = (from category in this.database.Categories.All()
                                        where category.Name == project.CategoryName
                                        select category).FirstOrDefault();

                selectedProject.Category = selectedCategory;
                this.database.SaveChanges();

                var routeValues = this.GridRouteValues();
                return this.RedirectToAction("EditProjects", routeValues);
            }

            return RedirectToAction("EditProjects");
        }

        public JsonResult GetUsernames(String text)
        {
            var selected = (from user in this.database.Users.All()
                            where user.UserName.Contains(text)
                            select user.UserName);

            return Json(selected, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories()
        {
            var allCategories = (from category in this.database.Categories.All()
                                 select category.Name).AsQueryable();

            return Json(allCategories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSkill(string name, string projectId)
        {
            var selectedSkill = (from skill in this.database.Skills.All()
                                 where skill.Name == name
                                 select skill).FirstOrDefault();

            if (selectedSkill == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid skill name.");
            }

            if (projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid project.");
            }

            var convertedProjectId = Convert.ToInt32(projectId);

            var selectedProject = (from project in this.database.Projects.All()
                                   where project.Id == convertedProjectId
                                   select project).FirstOrDefault();

            if (selectedProject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid project.");
            }

            if (selectedProject.Skills.Contains(selectedSkill))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Skill already included in the project.");
            }

            selectedProject.Skills.Add(selectedSkill);
            this.database.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        public ActionResult RemoveSkill(string skillName, string projectId)
        {
            var selectedSkill = (from skill in this.database.Skills.All()
                                 where skill.Name == skillName
                                 select skill).FirstOrDefault();

            if (selectedSkill == null || projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var convertedProjectId = Convert.ToInt32(projectId);

            var selectedProject = (from project in this.database.Projects.All()
                                   where project.Id == convertedProjectId
                                   select project).FirstOrDefault();

            selectedProject.Skills.Remove(selectedSkill);
            this.database.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        public ActionResult RemoveCollaborator(string collaborator, string projectId)
        {
            var selectedUser = (from user in this.database.Users.All()
                                where user.UserName == collaborator
                                select user).FirstOrDefault();

            if (selectedUser == null || projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var convertedProjectId = Convert.ToInt32(projectId);

            var selectedProject = (from project in this.database.Projects.All()
                                   where project.Id == convertedProjectId
                                   select project).FirstOrDefault();

            if (selectedProject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            selectedProject.Collaborators.Remove(selectedUser);
            this.database.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult AddCollaborator(string name, string projectId)
        {
            var selected = (from user in this.database.Users.All()
                            where user.UserName == name
                            select user).FirstOrDefault();

            if (selected == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid user name.");
            }

            if (projectId == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid project.");
            }

            var convertedProjectId = Convert.ToInt32(projectId);

            var dbProject = (from project in this.database.Projects.All()
                             where project.Id == convertedProjectId
                             select project).FirstOrDefault();

            if (dbProject.Collaborators.Contains(selected))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User is already a collaborator in this project.");
            }

            if (dbProject == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid project.");
            }

            dbProject.Collaborators.Add(selected);
            this.database.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        public ActionResult GetSkills(string text)
        {
            var skills = (from skill in this.database.Skills.All()
                          where skill.Name.Contains(text)
                          select skill.Name);

            return Json(skills, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Projects/
        public ActionResult EditProjects()
        {
            var projects = (from project in this.database.Projects.All()
                            select new ProjectAdministrationModel()
                            {
                                CategoryName = project.Category.Name,
                                CreatedOn = project.CreatedOn,
                                Deadline = project.Deadline,
                                Id = project.Id,
                                Name = project.Name,
                                OwnerUserName = project.Owner.UserName,
                                Salary = project.Salary,
                                Summary = project.Summary,
                                Collaborators = (from collaborator in project.Collaborators
                                                 select collaborator.UserName).ToList(),
                                RequiredSkills = (from skills in project.Skills
                                                  select skills.Name).ToList()
                            }).AsQueryable();

            return View(projects);
        }
    }
}