namespace News.Services.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Results;
    using Data;
    using Data.Contracts;
    using Infrastructure;

    public abstract class BaseApiController : ApiController
    {

        protected BaseApiController()
            : this(new NewsData(NewsContext.Create()), new AspNetUserProvider())
        {
        }

        protected BaseApiController(INewsData data, IUserProvider userProvider)
        {
            this.NewsData = data;
            this.UserProvider = userProvider;
        }

        public INewsData NewsData { get; set; }

        protected IUserProvider UserProvider { get; set; }

        protected ResponseMessageResult CreateResponseMessage(HttpStatusCode statusCode, string message)
        {
            return this.ResponseMessage(this.Request.CreateResponse(statusCode,
                new
                {
                    Message = message
                }));
        } 
    }
}