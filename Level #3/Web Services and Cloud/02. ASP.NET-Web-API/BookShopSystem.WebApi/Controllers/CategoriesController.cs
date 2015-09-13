namespace BookShopSystem.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Data;
    using Models.BindingModels;
    using Models.ViewModels;
    using UserSessionUtils;

    [SessionAuthorize]
    [RoutePrefix("api/categories")]
    public class CategoriesController : BaseApiController
    {
        // GET api/categories
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllCategories()
        {
            var categories = this.BookShopData.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            if (!categories.Any())
            {
                return this.NotFound();
            }
            
            return this.Ok(categories);
        }

        // GET api/categories/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            var category = this.BookShopData.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(CategoryViewModel.Create(category));
        }

        // PUT api/categories/{id}
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditCategoryById(int id, [FromBody] CategoryBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No information provided.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            
            var category = this.BookShopData.Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            if (this.BookShopData.Categories.Any(c => c.Name == model.Name) && category.Name != model.Name)
            {
                return this.BadRequest("Duplicate category name.");
            }

            category.Name = model.Name;
            this.BookShopData.SaveChanges();

            return this.Ok(CategoryViewModel.Create(category));
        }

        // POST api/categories
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCategory([FromBody] CategoryBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No information provided.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.BookShopData.Categories.Any(c => c.Name == model.Name))
            {
                return this.BadRequest("Duplicate category name");
            }

            var category = new Category
            {
                Name = model.Name
            };

            this.BookShopData.Categories.Add(category);

            this.BookShopData.SaveChanges();

            return this.Ok(CategoryViewModel.Create(category));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = this.BookShopData.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            this.BookShopData.Categories.Remove(category);
            this.BookShopData.SaveChanges();

            return this.Ok("Category deleted");
        }
    }
}