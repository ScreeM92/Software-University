using GoblinFreelancer.Repository;
using GoblinFreelancer.ViewModels;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using GoblinFreelancer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GoblinFreelancer.Controllers
{
    public class ProjectsController : Controller
    {
        IUowData db;

        public ProjectsController(IUowData db)
        {
            this.db = db;
        }

        public ProjectsController()
        {
            db = new UowData();
        }
        //
        // GET: /Projects/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProjects()
        {
            var projects = db.Projects.All()
                .Where(project => project.Owner.UserName == User.Identity.Name)
                .Select(project => new ProjectViewModelShort { Id = project.Id, Name = project.Name });
            var c = projects.Count();
            return View("MyProjects", projects);
        }

        public JsonResult ReadProjects([DataSourceRequest]DataSourceRequest request)
        {
            var projects = db.Projects.All().ToList().Select(ProjectViewModelFull.FromProject);
            return Json(projects.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadProjectsCategory([DataSourceRequest]DataSourceRequest request, string category)
        {
            var projects = db.Projects.All().Where(p => p.Category.Name == category).ToList().Select(ProjectViewModelFull.FromProject);
            return Json(projects.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult ReadProjectsSearch([DataSourceRequest]DataSourceRequest request, string query)
        {
            
            if (String.IsNullOrEmpty(query))
            {
                var projects = db.Projects.All().Select(ProjectViewModelFull.FromProject);
                return Json(projects.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (query.Length >= 50)
                {
                    return View("Error");
                }
                var projects = db.Projects.All().Where(p => p.Name.Contains(query)).ToList().Select(ProjectViewModelFull.FromProject);
                return Json(projects.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Search(string query)
        {
            ViewBag.Query = query;
            return View();
        }

        [Authorize]
        public ActionResult CreateProject()
        {
            ViewBag.Categories = db.Categories.All().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return PartialView("_CreateProjectForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CreateProject(Project project)
        {
            var userHireRole = db.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name).Roles.FirstOrDefault(r => r.Role.Name == "Hire");
            if (userHireRole != null)
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Categories = db.Categories.All().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                    return PartialView("_CreateProjectForm", project);
                }

                project.Owner = db.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name);
                project.Category = db.Categories.All().FirstOrDefault(c => c.Id == project.Category.Id);
                project.CreatedOn = DateTime.Now;
                project.Deadline = DateTime.Now;
                db.Projects.Add(project);
                db.SaveChanges();
                return null;
            }
            else
            {
                ModelState.AddModelError("User role", "You are not hire");
                ViewBag.Categories = db.Categories.All().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                return PartialView("_CreateProjectForm", project);
            }
        }

        public ActionResult ViewProject(int? id)
        {
            if(id == null)
            {
                return View("Error");
            }
            else
            {
                var project = db.Projects.GetById(Convert.ToInt32(id));
                return View(project);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewProject(Project project)
        {
            if (ModelState.IsValid)
            {
                var oldProject = db.Projects.GetById(project.Id);
                oldProject.Name = project.Name;
                oldProject.Salary = project.Salary;
                oldProject.Summary = project.Summary;
                oldProject.Deadline = project.Deadline;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        public JsonResult GetProjectsNames(string text)
        {
            var projects = db.Projects.All().Where(p => p.Name.ToLower().Contains(text.ToLower())).Select(ProjectViewModelShort.FromProject);
            return Json(projects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AvailableSkills(string text, int? projectId)
        {
            if (projectId != null)
            {
                var project = db.Projects.All().FirstOrDefault(p => p.Id == projectId);
                var skills = db.Skills.All().Where(s => s.Name.Contains(text)).ToList();
                var filteredSkills = (from skill in skills
                                      where !project.Skills.Contains(skill)
                                      select new { Name = skill.Name, Id = skill.Id });
                return Json(filteredSkills, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult AddSkill(int? projectId, string name)
        {
            Skill skill = null;
            if (name != null)
            {
                skill = db.Skills.All().FirstOrDefault(x => x.Name == name);

                if (skill == null)
                {
                    return Content("This Skill Does Not Exist !");
                }
            }

            if(projectId == null)
            {
                return Content("This Project Does Not Exist !");
            }

            var project = db.Projects.All().FirstOrDefault(p => p.Id == projectId);
            project.Skills.Add(skill);
            db.Projects.Update(project);
            db.SaveChanges();

            return Content("Success !");
        }

        public ActionResult RemoveSkill(int projectId, string skillName)
        {
            var skill = db.Skills.All().FirstOrDefault(s => s.Name == skillName);
            var project = db.Projects.GetById(projectId);
            if(skill != null && project != null)
            {
                project.Skills.Remove(skill);
                db.SaveChanges();
            }

            return RedirectToAction("ViewProject", new { id = projectId });
        }

        public JsonResult AvailableCollaborators(string text, int? projectId)
        {
            if(projectId != null)
            {
                var project = db.Projects.All().FirstOrDefault(p => p.Id == projectId);
                var user = db.Users.All().FirstOrDefault(u => u.UserName == text);
                var filteredCollaborators = db.Users.All().Where(
                    u => u.UserName.Contains(text) && u.UserName != User.Identity.Name
                        && !project.Collaborators.Contains(user))
                .Select(u => new { UserName = u.UserName, Id = u.Id});

            return Json(filteredCollaborators, JsonRequestBehavior.AllowGet);
            }

            return null;
            
        }

        public ActionResult AddCollaborator(int? projectId, string name)
        {
            var col = db.Users.All().FirstOrDefault(x => x.UserName == name);

            if (col == null)
            {
                return Content("This Collaborator Does Not Exist !");
            }

            if (projectId == null)
            {
                return Content("This Project Does Not Exist !");
            }

            var project = db.Projects.All().FirstOrDefault(p => p.Id == projectId);
            project.Collaborators.Add(col);
            db.Projects.Update(project);
            db.SaveChanges();
            return Content("Success !");
        }

        public ActionResult RemoveCollaborator(int projectId, string colId)
        {
            var col = db.Users.All().FirstOrDefault(u => u.Id == colId);
            var project = db.Projects.GetById(projectId);
            if (col != null && project != null)
            {
                project.Collaborators.Remove(col);
                db.SaveChanges();
            }

            return RedirectToAction("ViewProject", new { id = projectId });
        }
	}
}