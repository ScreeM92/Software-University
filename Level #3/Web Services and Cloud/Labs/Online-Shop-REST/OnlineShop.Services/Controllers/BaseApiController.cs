namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        protected BaseApiController()
            : this(new OnlineShopContext())
        {
            
        }

        protected BaseApiController(OnlineShopContext data)
        {
            this.Data = data;
        }

        protected OnlineShopContext Data { get; set; }
    }
}