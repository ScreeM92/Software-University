using GoblinFreelancer.Areas.Admin.Models;
using GoblinFreelancer.Repository;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using GoblinFreelancer.Models;
using System.Web.Routing;

namespace GoblinFreelancer.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private IUowData database;
        public UsersController()
        {
            this.database = new UowData();
        }

        public UsersController(IUowData db)
        {
            this.database = db;
        }

        public ActionResult EditUser(UserAdministrationModel model)
        {
            if (ModelState.IsValid)
            {
                var selectedUser = (from user in database.Users.All()
                            where user.Id == model.Id
                            select user).FirstOrDefault();

                selectedUser.IsDisalbed = model.IsBanned;
                database.SaveChanges();

                RouteValueDictionary routeValues = this.GridRouteValues();

                return RedirectToAction("EditUsers", routeValues);
            }

            return View("EditUsers");
        }

        //
        // GET: /Admin/Users/
        public ActionResult EditUsers()
        {
            return View();
        }

        public JsonResult GetUsers(DataSourceRequest request)
        {
            var users = (from user in this.database.Users.All()
                         select new UserAdministrationModel()
                         {
                             UserName = user.UserName,
                             IsBanned = user.IsDisalbed,
                             Id = user.Id
                         }).AsQueryable();

            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
	}
}