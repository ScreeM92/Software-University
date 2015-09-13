using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Restaurants.Data;
using Restaurants.Models;
using Restaurants.Services.Models;

namespace Restaurants.Services.Controllers
{
    [RoutePrefix("api/meals")]
    public class MealsController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        // POST: api/Meals
        [ResponseType(typeof(MealInputModel))]
        public IHttpActionResult createMeal(MealInputModel meal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (meal == null)
            {
                return BadRequest("Missing meal data.");
            }

            var currentUser = User.Identity.IsAuthenticated;
            var userName = User.Identity.Name;

            if (!currentUser)
            {
                return this.Unauthorized();
            }

            var userId = db.Users
              .Where(u => u.UserName == userName)
              .Select(u => u.Id).FirstOrDefault();

            var ownerId = db.Restaurants
                .Where(r => r.OwnerId == userId && r.Id == meal.RestaurantId)
                .Select(r => r.OwnerId).FirstOrDefault();

            if (ownerId != userId)
            {
                return this.Unauthorized();
            }

            var restaurant = db.Restaurants.Find(meal.RestaurantId);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var type = db.MealTypes.Find(meal.TypeId);
            if (type == null)
            {
                return this.NotFound();
            }

            var mealAdd = new Meal()
            {
                Name = meal.Name,
                Price = meal.Price,
                TypeId = meal.TypeId,
                RestaurantId = meal.RestaurantId
            };

            db.Meals.Add(mealAdd);
            db.SaveChanges();

            return this.CreatedAtRoute(
                   "DefaultApi",
                   new { id = mealAdd.Id },
                   new
                   {
                       id = mealAdd.Id,
                       name = mealAdd.Name,
                       price = mealAdd.Price,
                       type = mealAdd.Type.Name
                   });
        }

        // DELETE: api/Meals/5
        [ResponseType(typeof(Meal))]
        [Route("{id}")]
        public IHttpActionResult DeleteMeal(int id)
        {
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            var currentUser = User.Identity.IsAuthenticated;
            var userName = User.Identity.Name;

            if (!currentUser)
            {
                return this.Unauthorized();
            }

            var userId = db.Users
              .Where(u => u.UserName == userName)
              .Select(u => u.Id).FirstOrDefault();

            var ownerId = db.Restaurants
                .Where(r => r.OwnerId == userId && r.Id == meal.RestaurantId)
                .Select(r => r.OwnerId).FirstOrDefault();

            if (ownerId != userId)
            {
                return this.Unauthorized();
            }

            db.Meals.Remove(meal);
            db.SaveChanges();

            return Ok(new
            {
                message = "Meal #" + meal.Id + " deleted." 
            });
        }

        // PUT: api/Meals/5
        [ResponseType(typeof(MealInputModel))]
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult EditMeal(int id, MealInputModel mealInput)
        {
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            var type = db.MealTypes.Find(meal.TypeId);
            if (type == null)
            {
                return this.NotFound();
            }

            var currentUser = User.Identity.IsAuthenticated;
            var userName = User.Identity.Name;

            if (!currentUser)
            {
                return this.Unauthorized();
            }

            var userId = db.Users
              .Where(u => u.UserName == userName)
              .Select(u => u.Id).FirstOrDefault();

            var ownerId = db.Restaurants
                .Where(r => r.OwnerId == userId && r.Id == meal.RestaurantId)
                .Select(r => r.OwnerId).FirstOrDefault();

            if (ownerId != userId)
            {
                return this.Unauthorized();
            }

            meal.Name = mealInput.Name;
            meal.TypeId = mealInput.TypeId;
            meal.Price = mealInput.Price;

            //db.Meals.Update(meal);
            db.SaveChanges();

            return this.Ok(new
            {
                id = meal.Id,
                name = meal.Name,
                price = meal.Price,
                type = meal.Type.Name
            });
        }

        //private void ChangeState(Meal entity, EntityState state)
        //{
        //    var entry = this.db.Entry(entity);
        //    if (entry.State == EntityState.Detached)
        //    {
        //        this.ControllerContext.Attach(entity);
        //    }

        //    entry.State = state;
        //}

        //private void Update(Meal entity)
        //{
        //    this.ChangeState(entity, EntityState.Modified);
        //}

        private bool MealExists(int id)
        {
            return db.Meals.Count(e => e.Id == id) > 0;
        }
    }
}