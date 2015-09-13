namespace BookShopSystem.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Script.Serialization;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Testing;
    using Microsoft.Owin.Security;
    using BookShopSystem.Models;
    using Models.Purchases;
    using Models.Users;
    using UserSessionUtils;

    [SessionAuthorize]
    [RoutePrefix("api/users")]
    public class UsersController : BaseApiController
    {
        private ApplicationUserManager userManager;

        public UsersController()
        {
        }

        public UsersController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            this.UserManager = userManager;
            this.AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this.userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // POST api/users/register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> RegisterUser(RegisterBindingModel model)
        {
            if (this.User.Identity.GetUserId() != null)
            {
                return this.BadRequest("User is already logged in.");
            }

            if (model == null)
            {
                return this.BadRequest("Invalid user data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var emailExists = this.BookShopData.Users
                .Any(x => x.Email == model.Email);
            if (emailExists)
            {
                return this.BadRequest("Email is already taken.");
            }

            var user = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email
            };

            var identityResult = await this.UserManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                return this.GetErrorResult(identityResult);
            }

            var loginResult = await this.LoginUser(new LoginUserBindingModel()
            {
                Username = model.Username,
                Password = model.Password
            });

            return loginResult;
        }

        // POST api/users/login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> LoginUser(LoginUserBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Invalid user data");
            }

            // Invoke the "token" OWIN service to perform the login (POST /api/token)
            // Use Microsoft.Owin.Testing.TestServer to perform in-memory HTTP POST request
            var testServer = TestServer.Create<Startup>();
            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.Username),
                new KeyValuePair<string, string>("password", model.Password)
            };
            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
            var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                Startup.TokenEndpointPath, requestParamsFormUrlEncoded);

            if (tokenServiceResponse.StatusCode == HttpStatusCode.OK)
            {
                // Sucessful login --> create user session in the database
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                var jsSerializer = new JavaScriptSerializer();
                var responseData =
                    jsSerializer.Deserialize<Dictionary<string, string>>(responseString);
                var authToken = responseData["access_token"];
                var username = responseData["userName"];
                var owinContext = this.Request.GetOwinContext();
                var userSessionManager = new UserSessionManager(owinContext);
                userSessionManager.CreateUserSession(username, authToken);

                // Cleanup: delete expired sessions from the database
                userSessionManager.DeleteExpiredSessions();
            }

            return this.ResponseMessage(tokenServiceResponse);
        }

        // POST api/users/logout
        [HttpPost]
        [Route("logout")]
        public IHttpActionResult Logout()
        {
            // This does not actually perform logout! The OWIN OAuth implementation
            // does not support "revoke OAuth token" (logout) by design.
            this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalBearer);

            // Delete the user's session from the database (revoke its bearer token)
            var owinContext = this.Request.GetOwinContext();
            var userSessionManager = new UserSessionManager(owinContext);
            userSessionManager.InvalidateUserSession();

            return this.Ok(new
            {
                message = "Logout successful."
            });
        }
        
        // POST api/users/changePassword
        [HttpPost]
        [Route("changePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            IdentityResult result = await this.UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);
            
            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }

            return this.Ok(new
            {
                Message = "Password changed"   
            });
        }

        // GET api/users/{username}/purchases
        [HttpGet]
        [Route("{username}/purchases")]
        public IHttpActionResult GetUserPurchases(string username)
        {
            var user = this.BookShopData.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return this.NotFound();
            }

            var purchases = this.BookShopData.Purchases
                .Where(p => p.User.UserName == user.UserName)
                .OrderBy(p => p.DateOfPurchase)
                .Select(p => new PurchaseViewModel
                {
                    Id = p.Id,
                    BookTitle = p.Book.Title,
                    Price = p.Price,
                    DateOfPurchase = p.DateOfPurchase,
                    IsRecalled = p.IsRecalled
                });

            return this.Ok(new
            {
                Username = user.UserName,
                Books = purchases
            });
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return this.Request.GetOwinContext().Authentication; }
        }
        #endregion
    }
}