namespace BookShopSystem.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Microsoft.AspNet.Identity;
    using Models.Books;
    using Models.Purchases;
    using UserSessionUtils;

    [SessionAuthorize]
    [RoutePrefix("api/books")]
    public class BooksController : BaseApiController
    {
        // GET api/books/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = this.BookShopData.Books
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }
            
            return this.Ok(BookViewModel.Create(book));
        }

        // GET api/books
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTopTenBooksContaining([FromUri]string search)
        {
            var books = this.BookShopData.Books
                .Where(b => b.Title.Contains(search))
                .OrderBy(b => b.Title)
                .Take(10)
                .Select(b => new TopBooksViewModel
                {
                    Id = b.Id,
                    Title = b.Title
                });

            if (!books.Any())
            {
                return this.NotFound();
            }

            return this.Ok(books);
        }

        // POST api/books
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddBook([FromBody] AddBookBindingModel book)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.BookShopData.Books.Any(b => b.Title == book.Title))
            {
                return this.BadRequest("Duplicate Title.");
            }

            var newBook = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Copies = book.Copies,
                Edition = book.Edition,
                AgeRestriction = book.AgeRestriction,
                ReleaseDate = book.ReleaseDate
            };

            if (string.IsNullOrEmpty(book.Categories))
            {
                return this.BadRequest("Categories cannot be empty.");
            }

            var bookCategories = book.Categories.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var bookCategory in bookCategories)
            {
                var category = this.BookShopData.Categories.FirstOrDefault(c => c.Name == bookCategory) ?? new Category
                {
                    Name = bookCategory
                };

                newBook.Categories.Add(category);
            }

            this.BookShopData.Books.Add(newBook);
            this.BookShopData.SaveChanges();

            return this.Ok(BookViewModel.Create(newBook));
        }

        // DELETE api/books/{id}
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBookById(int id)
        {
            var book = this.BookShopData.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            this.BookShopData.Books.Remove(book);
            this.BookShopData.SaveChanges();

            return this.Ok("Book deleted.");
        }

        // PUT api/books/{id}
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditBookById(int id, [FromBody] EditBookBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var book = this.BookShopData.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            if (this.BookShopData.Books.Any(b => b.Title == model.Title) && book.Title != model.Title)
            {
                return this.BadRequest("Duplicate book title.");
            }

            book.Title = model.Title ?? book.Title;
            book.Description = model.Description ?? book.Description;
            book.Price = model.Price ?? book.Price;
            book.Copies = model.Copies ?? book.Copies;
            book.Edition = model.Edition ?? book.Edition;
            book.AgeRestriction = model.AgeRestriction ?? book.AgeRestriction;
            book.ReleaseDate = model.ReleaseDate ?? book.ReleaseDate;
            book.AuthorId = model.AuthorId ?? book.AuthorId;

            this.BookShopData.SaveChanges();

            return this.Ok("Book edited.");
        }

        // PUT api/books/{id}
        [HttpPut]
        [Route("buy/{id}")]
        public IHttpActionResult BuyBook(int id)
        {
            var book = this.BookShopData.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            if (--book.Copies <= 0)
            {
                return this.BadRequest("There is not enough book copies.");
            }
            
            var loggedUserId = this.User.Identity.GetUserId();
            if (loggedUserId == null)
            {
                return this.BadRequest("Invalid session token.");
            }

            var user = this.BookShopData.Users.Find(loggedUserId);

            var purchase = new Purchase
            {
                Book = book,
                User = user,
                Price = book.Price,
                DateOfPurchase = DateTime.Now,
                IsRecalled = false
            };

            this.BookShopData.Purchases.Add(purchase);
            this.BookShopData.SaveChanges();

            return this.Ok(PurchaseViewModel.Create(purchase));
        }

        // PUT api/books/ecall/{id}
        [HttpPut]
        [Route("recall/{id}")]
        public IHttpActionResult RecallBook(int id)
        {
            var purchase = this.BookShopData.Purchases.FirstOrDefault(p => p.Id == id);

            if (purchase == null)
            {
                return this.NotFound();
            }

            if (purchase.IsRecalled)
            {
                return this.BadRequest("Purchase already recalled.");
            }

            var dateDiff = purchase.DateOfPurchase.Date.AddDays(30) <= DateTime.Today;

            if (dateDiff)
            {
                return this.BadRequest("More than than 30 days passed since the purchase.");
            }

            purchase.Book.Copies += 1;
            purchase.IsRecalled = true;

            this.BookShopData.SaveChanges();

            return this.Ok("Purchase recalled");
        }
    }
}