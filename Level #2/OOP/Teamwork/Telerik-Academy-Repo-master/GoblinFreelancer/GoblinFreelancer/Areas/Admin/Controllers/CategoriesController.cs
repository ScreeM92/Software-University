using GoblinFreelancer.Areas.Admin.Models;
using GoblinFreelancer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.Extensions;
using System.Web.Mvc;
using System.Net;
using GoblinFreelancer.Models;
using Kendo.Mvc.UI;

namespace GoblinFreelancer.Areas.Admin.Controllers
{
    //[Authorize]
    //[Authorize(Roles="Admin")]
    public class CategoriesController : Controller
    {
        IUowData database;

        public CategoriesController()
        {
            this.database = new UowData();
        }

        public CategoriesController(IUowData database)
        {
            this.database = database;
        }

        public ActionResult DeleteCategory(string Id)
        {
            if (Id == null)
            {
                return this.RedirectToAction("EditCategories");
            }

            var convertedId = Convert.ToInt32(Id);

            var selectedCategory = (from category in this.database.Categories.All()
                                    where category.Id == convertedId
                                    select category).FirstOrDefault();

            selectedCategory.Projects.Clear();
            this.database.Categories.Delete(selectedCategory);
            this.database.SaveChanges();

            return this.RedirectToAction("EditCategories");

        }

        public ActionResult UpdateCategory(CategoryAdministrationModel model)
        {
            if (ModelState.IsValid)
            {
                var selectedCategory = (from category in this.database.Categories.All()
                                        where category.Id == model.Id
                                        select category).FirstOrDefault();

                selectedCategory.Name = model.Name;
                this.database.SaveChanges();

                var routeValues = this.GridRouteValues();
                return this.RedirectToAction("EditCategories", routeValues);
            }

            return this.RedirectToAction("EditCategories");
        }

        //
        // GET: /Admin/Categories/
        public ActionResult EditCategories()
        {
            return View();
        }

        public JsonResult GetCategories([DataSourceRequest]DataSourceRequest request)
        {
            var categories = (from category in this.database.Categories.All()
                              select new CategoryAdministrationModel()
                              {
                                  Name = category.Name,
                                  Id = category.Id
                              });

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest]DataSourceRequest request, Category category)
        {
            if (category != null && ModelState.IsValid)
            {
                database.Categories.Add(new Category()
                {
                    Name = category.Name
                });
                database.SaveChanges();
            }

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }
    }
}