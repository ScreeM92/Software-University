namespace BookShopSystem.WebApi.Controllers
{
    using System.Web.Http;
    using Data;
    using Microsoft.AspNet.Identity;

    public class BaseApiController : ApiController
    {
        private BookShopContext bookShopData;

        public BaseApiController()
            : this(new BookShopContext())
        {
        }

        public BaseApiController(BookShopContext bookShopData)
        {
            this.BookShopData = bookShopData;
        }

        protected BookShopContext BookShopData
        {
            get
            {
                return this.bookShopData;
            }
            private set
            {
                this.bookShopData = value;
            }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (this.ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }
    }
}