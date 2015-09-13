using GoblinFreelancer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoblinFreelancer.Models.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using GoblinFreelancer.Models;
using GoblinFreelancer.ViewModels;

namespace GoblinFreelancer.Controllers
{   
    public class CategoriesController : Controller
    {
        public CategoriesController()
        {
            this.UnitOfWork = new UowData();
        }

        private UowData UnitOfWork { get; set; }
        //
        // GET: /Category/
        public ActionResult Index()
        {
            var result = this.UnitOfWork
                .Categories
                .All()
                .OrderBy(category => category.Name)
                .Select(CategoryViewModel.FromCategory);

            return View(result);
        }

        public ActionResult Projects(string category)
        {
            ViewBag.Category = category;
            //var projects = this.UnitOfWork
            //    .Projects
            //    .All()
            //    .Where(project => project.Category.Name == category)
            //    .Select(ProjectViewModelFull.FromProject);
            return View();
        }

        //public JsonResult GetCategories([DataSourceRequest]DataSourceRequest request)
        //{
        //    var result = this.UnitOfWork
        //        .Categories
        //        .All()
        //        .OrderBy(category => category.Name)
        //        .Select(CategoryViewModel.FromCategory);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        //TODO: REMOVE LATER
        //public JsonResult GetProjects([DataSourceRequest]DataSourceRequest request)
        //{
        //    var a = Request.Params["name"];
        //    var projects = this.UnitOfWork.Projects.All().Select(ProjectViewModelFull.FromProject);
        //    return Json(projects.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        //}
	}
}