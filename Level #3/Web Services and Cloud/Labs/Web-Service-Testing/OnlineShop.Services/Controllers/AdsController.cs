namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using OnlineShop.Models;

    [Authorize]
    public class AdsController : BaseApiController
    {
        public AdsController(IOnlineShopData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }

        [HttpGet]
        [Route("api/ads")]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads.All()
                .Where(a => a.Status == AdStatus.Open)
                .OrderByDescending(a => a.TypeId)
                .ThenBy(a => a.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(ads);
        }
        
        [HttpPost]
        [Route("api/ads")]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            var userId = this.UserIdProvider.GetUserId();
            if (userId == null)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest("model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.AdTypes.All().All(t => t.Id != model.TypeId))
            {
                return this.BadRequest("there is no type with the provided id in the database");
            }

            var ad = new Ad
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                PostedOn = DateTime.Now,
                Status = AdStatus.Open,
                OwnerId = userId,
                TypeId = model.TypeId
            };

            foreach (var categoryId in model.Categories)
            {
                var category = this.Data.Categories.Find(categoryId);
                if (category == null)
                {
                    return this.BadRequest("Non existing category");
                }

                ad.Categories.Add(category);
            }

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();
            var result = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        [HttpPut]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads.Find(id);
            if (ad == null)
            {
                return this.NotFound();
            }

            var userId = this.UserIdProvider.GetUserId();
            if (ad.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            if (ad.Status == AdStatus.Closed)
            {
                return this.BadRequest("Ad already closed");
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();
            
            return this.Ok();
        }
    }
}