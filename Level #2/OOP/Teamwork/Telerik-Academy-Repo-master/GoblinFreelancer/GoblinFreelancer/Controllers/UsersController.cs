using GoblinFreelancer.Models;
using GoblinFreelancer.Models.ViewModels;
using GoblinFreelancer.Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GoblinFreelancer.ViewModels;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Data.Entity.Validation;

namespace GoblinFreelancer.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        public UsersController()
        {
            this.UnitOfWork = new UowData();
        }

        private UowData UnitOfWork { get; set; }

        //
        // GET: /Users/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var user = this.UnitOfWork
                    .Users
                    .All()
                    .Where(u => u.UserName == username)
                    .ToList()
                    .Select(UserViewModel.FromUser)
                    .First();

                return View(user);
            }
            return View("Error");
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult ByUser(string username)
        {
            if (string.IsNullOrEmpty(username) ||
                username != User.Identity.Name)
            {
                return View("Error");
            }
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            ViewBag.isWork = (bool)user.Roles.Any(x => x.Role.Name == "Work");
            if (user == null)
            {
                return View("Error");
            }
            return View(user);
        }

        public JsonResult GetUserProjects([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.UnitOfWork
                .Projects
                .All()
                .OrderBy(project => project.CreatedOn)
                .Where(project => (project.Owner.UserName  == User.Identity.Name || project.Collaborators.Any(x => x.UserName == User.Identity.Name)))
                .ToList()
                .Select(ProjectViewModelFull.FromProject);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUsers([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.UnitOfWork
                .Users
                .All()
                .OrderByDescending(user => user.Rating)
                .ThenBy(user => user.UserName)
                .ToList()
                .Select(UserViewModel.FromUser);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AvailableSkills(string text)
        {
            var currentUser = this.User.Identity.Name;

            var skills = this.UnitOfWork.Users.All()
                .FirstOrDefault(x => x.UserName == currentUser)
                .Skills.ToList();

            var filteredSkills = this.UnitOfWork.Skills.All().ToList()
                .Where(x => x.Name.ToLower().Contains(text.ToLower()) && (skills.Where(y => y.Name == x.Name).Count() == 0)).ToList()
                .Select(x => 
                    new { Name = x.Name, Id = x.Id });

            return Json(filteredSkills, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSkill(string name)
        {
            var skill = this.UnitOfWork.Skills.All().FirstOrDefault(x => x.Name == name);

            if (skill == null)
            {
                return Content("This Skill Does Not Exist !");
            }

            var user = this.UnitOfWork.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            user.Skills.Add(skill);
            this.UnitOfWork.Users.Update(user);
            this.UnitOfWork.SaveChanges();

            return Content("Success !");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ByUser(UserCreateModel model, HttpPostedFileBase picture)
        {
            var user = this.UnitOfWork.Users.All()
                   .Where(x => x.UserName == this.User.Identity.Name)
                   .First();

            if (this.ModelState.IsValid)
            {
                user.Email = model.Email;

                //var bytes = new byte[picture.ContentLength];
                //picture.InputStream.Read(bytes,0,picture.ContentLength);
                //user.ProfilePicture = bytes;

                if (picture != null)
                {
                    var picStream = new MemoryStream(picture.ContentLength);
                    var img = new Bitmap(picture.InputStream);
                    var resized = new Bitmap(img, 200, 200);
                    resized.Save(picStream, ImageFormat.Jpeg);
                    user.ProfilePicture = picStream.ToArray();
                }

                this.UnitOfWork.Users.Update(user);
                this.UnitOfWork.SaveChanges();
            }
            else
            {
                this.ModelState.AddModelError("","There Is Error In The Data You Entered. Please Fix This ...");
            }

            ViewBag.isWork = (bool)user.Roles.Any(x => x.Role.Name == "Work");

            return View(user);
        }

        public ActionResult GetImage(string id)
        {
            var userImgAsByteArr = this.UnitOfWork
                .Users
                .All()
                .First(u => u.Id == id)
                .ProfilePicture;

            if (userImgAsByteArr != null)
            {
                return File(userImgAsByteArr, "image/png");
            }
            else
            {
                var path = this.Request.MapPath("~/img/profile-icon-default.png");
                var bytes = System.IO.File.ReadAllBytes(path);
                return File(bytes, "image/png");
            }       
        }

        public ActionResult GetSkillList()
        {
            var currentUser = this.User.Identity.Name;

            var skills = this.UnitOfWork.Users.All()
                .FirstOrDefault(x => x.UserName == currentUser)
                .Skills;

            return PartialView("_UserSkills", skills);
        }

        [HttpPost]
        public ActionResult RemoveSkill(int id)
        {
            System.Threading.Thread.Sleep(1000);
            var currentUser = this.User.Identity.Name;
            var user = this.UnitOfWork.Users.All()
               .FirstOrDefault(x => x.UserName == currentUser);

            user.Skills.Remove(user.Skills.FirstOrDefault(x => x.Id == id));
            this.UnitOfWork.Users.Update(user);
            this.UnitOfWork.SaveChanges();

            return PartialView("_UserSkills", user.Skills);
        }

        [Authorize]
        public ActionResult ProfileInfo()
        {
            return RedirectToAction("ByUser", new { username = this.User.Identity.Name });
        }

        public ActionResult Vote(int voteValue, string userToVote)
        {
            if (!string.IsNullOrEmpty(userToVote))
            {
                var user = this.UnitOfWork.Users.All().FirstOrDefault(u => u.UserName == userToVote);
                if (user.UserName != User.Identity.Name)
                {
                    user.Rating = user.Rating + voteValue;
                    user.TimesRated++;
                    this.UnitOfWork.SaveChanges();
                }
            }
            return RedirectToAction("UserProfile", new { username = userToVote });
        }

    }
}
