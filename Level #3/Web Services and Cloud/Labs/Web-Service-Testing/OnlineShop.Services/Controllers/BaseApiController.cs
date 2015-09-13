namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data;
    using Infrastructure;

    public class BaseApiController : ApiController
    {
        protected BaseApiController(IOnlineShopData data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        protected IOnlineShopData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}