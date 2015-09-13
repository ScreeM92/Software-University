using GoblinFreelancer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoblinFreelancer.ViewModels;

namespace GoblinFreelancer.Controllers
{
    public class HomeController : Controller
    {
        IUowData db;

        public HomeController(IUowData db)
        {
            this.db = db;
        }

        public HomeController()
        {
            this.db = new UowData();
        }

        public ViewResult Index()
        {
            var result = db.Projects
                .All()
                .OrderByDescending(project => project.CreatedOn)
                .Take(9)
                .Select(ProjectViewModelFull.FromProject);

            return View(result);
        }

        public ActionResult UserBanned()
        {
            return View();
        }
    }
}