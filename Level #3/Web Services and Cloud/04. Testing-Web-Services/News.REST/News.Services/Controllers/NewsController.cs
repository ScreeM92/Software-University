namespace News.Services.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Data.Contracts;
    using Infrastructure;
    using Models;
    using News.Models;

    [Authorize]
    public class NewsController : BaseApiController
    {
        public NewsController()
        {
        }

        public NewsController(INewsData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }

        // GET api/news
        [HttpGet]
        [AllowAnonymous]
        [Route("api/news")]
        public IHttpActionResult GetAllNews()
        {
            var news = this.NewsData.News.All()
                .OrderByDescending(n => n.PublishDate)
                .Select(NewsViewModel.Create);

            return this.Ok(news);
        }

        // POST api/news
        [HttpPost]
        [Route("api/news")]
        public IHttpActionResult CreateNews(AddNewsBindingModel model)
        {
            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.NewsData.Users.Find(loggedUserId);
            if (loggedUser == null)
            {
                return this.CreateResponseMessage(HttpStatusCode.Unauthorized, "InvalidAccessToken");
            }

            if (model == null)
            {
                return this.BadRequest("No data provided.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.NewsData.News.All().Any(n => n.Title == model.Title))
            {
                return this.CreateResponseMessage(HttpStatusCode.Conflict, "There is already a News with this Content.");
            }

            var news = new News
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = model.PublishDate,
                AuthorId = loggedUserId,
                Author = loggedUser
            };

            this.NewsData.News.Add(news);
            this.NewsData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { controller = "news", id = news.Id }, NewsViewModel.CreateView(news));
        }

        // PUT api/news/{newsID}
        [HttpPut]
        [Route("api/news/{newsId}")]
        public IHttpActionResult EditNews(int newsId, EditNewsBindingModel model)
        {
            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.NewsData.Users.Find(loggedUserId);

            if (loggedUser == null)
            {
                return this.CreateResponseMessage(HttpStatusCode.Unauthorized, "InvalidAccessToken");
            }

            if (model == null)
            {
                return this.BadRequest("No data provided.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = this.NewsData.News.Find(newsId);

            if (news == null)
            {
                return this.CreateResponseMessage(HttpStatusCode.NotFound, "There is no News with this id.");
            }

            if (news.AuthorId != loggedUserId)
            {
                return this.CreateResponseMessage(HttpStatusCode.Unauthorized, "Can edit only own News.");
            }

            if (this.NewsData.News.All().Any(n => n.Title == model.Title && n.Id != news.Id))
            {
                return this.CreateResponseMessage(HttpStatusCode.Conflict, "Theres is already News with this Title");
            }
            
            news.Title = model.Title;
            news.Content = model.Content;
            news.PublishDate = model.PublishDate;

            this.NewsData.News.Update(news);
            this.NewsData.SaveChanges();
            
            return this.Ok();
        }

        // DELETE api/news/{newsID}
        [HttpDelete]
        [Route("api/news/{newsId}")]
        public IHttpActionResult DeleteNews(int newsId)
        {
            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.NewsData.Users.Find(loggedUserId);

            if (loggedUser == null)
            {
                return this.CreateResponseMessage(HttpStatusCode.Unauthorized, "InvalidAccessToken");
            }

            var news = this.NewsData.News.Find(newsId);

            if (news == null)
            {
                return this.CreateResponseMessage(HttpStatusCode.NotFound, "There is no News with this id.");
            }

            if (news.AuthorId != loggedUserId)
            {
                return this.CreateResponseMessage(HttpStatusCode.Unauthorized, "Can delete only own News.");
            }

            this.NewsData.News.Delete(news);
            this.NewsData.SaveChanges();

            return this.Ok();
        }
    }
}