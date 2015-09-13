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

namespace GoblinFreelancer.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class SkillsController : Controller
    {
        private IUowData Database { get; set; }

        public SkillsController()
            : this(new UowData())
        {
        }

        public SkillsController(IUowData database)
        {
            this.Database = database;
        }

        public ActionResult EditSkills()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SkillAdministrationModel model)
        {
            if (ModelState.IsValid)
            {
                Skill dbSkill = new Skill
                {
                    Name = model.Name
                };

                this.Database.Skills.Add(dbSkill);
                this.Database.SaveChanges();
            }

            return RedirectToAction("EditSkills");
        }

        [HttpPost]
        public ActionResult Edit(SkillAdministrationModel model)
        {
            if (ModelState.IsValid)
            {
                var dbSkill = this.Database.Skills.GetById(model.Id);
                dbSkill.Name = model.Name;
                this.Database.SaveChanges();
            }

            return RedirectToAction("EditSkills");
        }

        [HttpPost]
        public ActionResult Delete(SkillAdministrationModel model)
        {
            this.Database.Skills.Delete(model.Id);
            this.Database.SaveChanges();

            return RedirectToAction("EditSkills");
        }

        public JsonResult Get(DataSourceRequest request)
        {
            var skills = (from skill in this.Database.Skills.All()
                          orderby skill.Name
                          select new SkillAdministrationModel
                          {
                              Id = skill.Id,
                              Name = skill.Name
                          }).AsQueryable();

            return Json(skills.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
