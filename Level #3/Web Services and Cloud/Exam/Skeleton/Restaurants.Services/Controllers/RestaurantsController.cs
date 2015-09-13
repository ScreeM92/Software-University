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
    [RoutePrefix("api/restaurants")]
    public class RestaurantsController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        // GET: api/Restaurants/townId=5
        [ResponseType(typeof(Restaurant))]
        [HttpGet]
        [Route("townId={townId}")]
        public IHttpActionResult GetRestaurant(int townId)
        {
            var restaurantsByTownId = db.Restaurants
                .Where(r => r.TownId == townId)
                .OrderByDescending(ra => ra.Ratings
                    .Average(r => r.Stars))
                .ThenBy(r => r.Name)
                .Select(r => new
                {
                    id = r.Id,
                    name = r.Name,
                    rating = r.Ratings.Average(rat => rat.Stars),
                    town = new
                    {
                        id = r.Town.Id,
                        name = r.Town.Name
                    }
                });

            if (restaurantsByTownId == null)
            {
                return NotFound();
            }

            return Ok(restaurantsByTownId);
        }

        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = User.Identity.IsAuthenticated;

            if(!currentUser)
            {
                return this.Unauthorized();
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Restaurants
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult PostRestaurant(RestaurantBindingModel restaurantData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var townName = db.Towns
                .Where(t => t.Id == restaurantData.TownId)
                .Select(t => t.Name).FirstOrDefault();

            if(townName == null || string.IsNullOrEmpty(restaurantData.Name))
            {
                this.BadRequest();
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

            var restaurant = new Restaurant()
            {
                Name = restaurantData.Name,
                TownId = restaurantData.TownId,
                OwnerId = userId
            };

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            Rating ratingRestaurant = null;

            return this.CreatedAtRoute(
                    "DefaultApi",
                    new { id = restaurant.Id },
                    new { id = restaurant.Id, name = restaurant.Name, rating = ratingRestaurant,
                        town = new
                        {
                            id = restaurantData.TownId, name = townName
                        }
                    });
        }

        // POST: api/restaurants/{id}/rate
        [HttpPost]
        [Route("{id}/rate")]
        public IHttpActionResult AddRating(int id, RateInputModel ratingData)
        {
            if (ratingData == null)
            {
                return BadRequest("Missing rating data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(ratingData.Stars < 1 || ratingData.Stars > 10)
            {
                return this.BadRequest("Incorrect stars");
            }

            var restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
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

            var ownerRestaurantId = db.Restaurants
                .Where(r => r.OwnerId == userId && r.Id == id)
                .Select(r => r.Id).FirstOrDefault();            

            
            if(ownerRestaurantId == id)
            {
                return this.BadRequest("The restaurant owner can not rates his own restaurant!!!");
            }

            var rating = new Rating()
            {
                UserId = userId,
                RestaurantId = id,
                Stars = ratingData.Stars
            };
            db.Ratings.Add(rating);
            db.SaveChanges();

            return this.Ok();
        }

        // GET: /api/restaurants/{id}/meals
        [ResponseType(typeof(Restaurant))]
        [HttpGet]
        [Route("{id}/meals")]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            var restaurant = db.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = db.Restaurants
                .Where(r => r.Id == id)
                .Select(r => r.Meals
                .Select(m => new
                    {
                        id = m.Id,
                        name = m.Name,
                        price = m.Price,
                        type = m.Type.Name
                    })
                    .OrderBy(m => m.type)
                    .ThenBy(m => m.name)
                );

            return this.Ok(meals);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.Id == id) > 0;
        }
    }
}