namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        private const string ImportPath = @"..\..\..\SeedData\";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShopSystem.Data.BookShopContext";
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookShopContext context)
        {
            if (!context.Authors.Any())
            {
                this.SeedAuthors(context);
            }

            if (!context.Books.Any())
            {
                this.SeedBooks(context);
            }

            if (!context.Categories.Any())
            {
                this.SeedCategories(context);
            }
        }

        private void SeedAuthors(BookShopContext context)
        {
            using (var reader = new StreamReader(ImportPath + "authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var firstName = data[0];
                    var lastName = data[1];

                    context.Authors.Add(new Author
                    {
                       FirstName = firstName,
                       LastName = lastName
                    });

                    line = reader.ReadLine();
                }

                context.SaveChanges();
            }
        }

        private void SeedBooks(BookShopContext context)
        {
            using (var reader = new StreamReader(ImportPath + "books.txt"))
            {
                var random = new Random();
                var line = reader.ReadLine();
                line = reader.ReadLine();
                var authors = context.Authors.Select(a => a.Id).ToList();

                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var authorId = authors[authorIndex];
                    var author = context.Authors.First(a => a.Id == authorId);
                    var edition = (EditionType)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        Edition = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    });

                    line = reader.ReadLine();
                }

                context.SaveChanges();
            }
        }

        private void SeedCategories(BookShopContext context)
        {
            using (var reader = new StreamReader(ImportPath + "categories.txt"))
            {
                var random = new Random();
                var line = reader.ReadLine();
                var books = context.Books.Select(a => a.Id).ToList();

                while (line != null)
                {
                    var randomBooksCount = random.Next(0, books.Count);
                    
                    var category = new Category
                    {
                        Name = line
                    };

                    for (int i = 0; i <= randomBooksCount - 1; i++)
                    {
                        var bookIndex = random.Next(0, books.Count);
                        var bookId = books[bookIndex];
                        category.Books.Add(context.Books.First(b => b.Id == bookId));
                        books.RemoveAt(bookIndex);
                    }

                    context.Categories.Add(category);

                    line = reader.ReadLine();
                }

                context.SaveChanges();
            }
        }
    }
}
