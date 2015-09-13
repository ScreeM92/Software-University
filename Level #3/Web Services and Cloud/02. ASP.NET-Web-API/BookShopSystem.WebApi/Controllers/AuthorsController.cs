namespace BookShopSystem.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Models.Authors;
    using Models.BindingModels;
    using UserSessionUtils;

    [SessionAuthorize]
    [RoutePrefix("api/authors")]
    public class AuthorsController : BaseApiController
    {
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetAuthorById(int id)
        {
            var author = this.BookShopData.Authors
                .FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return this.NotFound();
            }

            return this.Ok(AuthorViewModel.Create(author));
        }

        [HttpGet]
        [Route("{id}/books")]
        public IHttpActionResult GetAuthorBooksById(int id)
        {
            var author = this.BookShopData.Authors
                .FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return this.NotFound();
            }

            var books = author.Books.Select(AuthorBooksViewModel.Create);

            return this.Ok(books);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddNewAuthor([FromBody] AddAuthorBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.BookShopData.Authors.Any(a => a.FirstName == model.FirstName && a.LastName == model.LastName))
            {
                return this.BadRequest("Duplicate author.");
            }

            var author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            this.BookShopData.Authors.Add(author);
            this.BookShopData.SaveChanges();

            return this.Ok(author);
        }
    }
}