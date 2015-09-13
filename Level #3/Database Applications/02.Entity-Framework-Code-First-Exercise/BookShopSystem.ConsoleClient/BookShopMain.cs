namespace BookShopSystem.ConsoleClient
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;

    public class BookShopMain
    {
        private static readonly string Separator = new string('-', 70);

        public static void Main()
        {
            var context = new BookShopContext();
            var bookCount = context.Books.Count();
            
            GetAllBooksAfterYear(context, 2000);
            GetAuthorsWithAtLeastOneBookBefore(context, 1990);
            GetAuthorsOrderedByBooksCount(context);
            GetAllBooksByAuthor(context, "George", "Powell");
            GetMostRecentBooksByCategories(context);
            
            RelatedBooks(context);
        }

        private static void GetAllBooksAfterYear(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year >= year)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            Console.WriteLine("{0}\nTask 1:\n{0}", Separator);
            books.ToList().ForEach(Console.WriteLine);
        }

        private static void GetAuthorsWithAtLeastOneBookBefore(BookShopContext context, int year)
        {
            var authors = context.Authors
                .Where(a => a.Books.Any(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year < year))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                });

            Console.WriteLine("\nTask 2:\n{0}", Separator);
            authors.ToList().ForEach(a => { Console.WriteLine("{0} {1}", a.FirstName, a.LastName); });
        }

        private static void GetAuthorsOrderedByBooksCount(BookShopContext context)
        {
            var authors = context.Authors
                .OrderByDescending(a => a.Books.Count)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    booksCount = a.Books.Count
                });

            Console.WriteLine("\nTask 3:\n{0}", Separator);
            authors.ToList().ForEach(a => { Console.WriteLine("{0} {1} - {2} book/s", a.FirstName, a.LastName, a.booksCount); });
        }

        private static void GetAllBooksByAuthor(BookShopContext context, string firstName, string lastName)
        {
            var books = context.Books
                .Where(b => b.Author.FirstName == firstName && b.Author.LastName == lastName)
                .OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.Title)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate,
                    b.Copies
                });

            Console.WriteLine("\nTask 4:\n{0}", Separator);
            books.ToList().ForEach(b =>
            {
                Console.WriteLine("{0} : {1} - {2} copy/s",
                    b.Title, 
                    b.ReleaseDate != null ? b.ReleaseDate.Value.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) : "no release date", 
                b.Copies);
            });
        }

        private static void GetMostRecentBooksByCategories(BookShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.Books.Count)
                .Select(c => new
                {
                    c.Name,
                    c.Books.Count,
                    Books = c.Books
                        .OrderByDescending(b => b.ReleaseDate)
                        .ThenBy(b => b.Title)
                        .Take(3)
                        .Select(b => new
                        {
                            b.Title,
                            b.ReleaseDate
                        })
                });

            Console.WriteLine("\nTask 5:\n{0}", Separator);
            categories.ToList().ForEach(c =>
            {
                Console.WriteLine("--{0}: {1} books", c.Name, c.Count);
                c.Books.ToList().ForEach(b =>
                {
                    Console.WriteLine("{0} ({1})", b.Title, b.ReleaseDate != null ? b.ReleaseDate.Value.Year.ToString() : "no release date");
                });
            });
        }

        private static void RelatedBooks(BookShopContext context)
        {
            var books = context.Books
                .Take(3)
                .ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();

            var booksFromQuery = context.Books
                .Take(3)
                .Select(b => new
                {
                    b.Title,
                    RelatedBooks = b.RelatedBooks.Select(rb => rb.Title)
                });

            Console.WriteLine(Separator);

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook);
                }
            }

            Console.WriteLine(Separator);
        }
    }
}