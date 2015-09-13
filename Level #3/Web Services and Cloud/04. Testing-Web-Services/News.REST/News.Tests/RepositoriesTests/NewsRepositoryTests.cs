namespace News.Tests.RepositoriesTests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data;
    using Data.Contracts;
    using EntityFramework.Extensions;
    using News.Models;


    [TestClass]
    public class NewsRepositoryTests
    {
        private INewsData repo;

        [TestInitialize]
        public void TestInit()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // Start a new temporary transaction
            this.CleanDatabase();
        }

        [TestMethod]
        public void ListAllNews_ShouldReturnThem()
        {
            // Arrange -> prapare the objects

            // Act -> perform some logic
            var news = this.repo.News.All().ToList();

            // Assert -> expect an exception
            Assert.AreEqual(2, news.Count);
            Assert.AreEqual("Seeding repositories", news[0].Title);
            Assert.AreEqual("There won't be any prepared unit tests.", news[1].Content);
            Assert.AreEqual(DateTime.Parse("2000-01-20"), news[0].PublishDate);
        }

        [TestMethod]
        public void AddNews_WhenNewsIsValid_ShouldBeAdded()
        {
            // Arrange -> prapare the objects
            var news = new News
            {
                Title = "Testing repositories",
                Content = "Hope the test will succeed.",
                PublishDate = DateTime.Now,
                AuthorId = this.repo.Users.All().First().Id
            };

            // Act -> perform some logic
            this.repo.News.Add(news);
            this.repo.SaveChanges();

            // Assert -> validate the results
            var newsFromDb = this.repo.News.Find(news.Id);

            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(news.Title, newsFromDb.Title);
            Assert.AreEqual(news.Content, newsFromDb.Content);
            Assert.AreEqual(news.PublishDate, newsFromDb.PublishDate);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddNews_WhenNewsIsInvalid_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            var invalidNews = new News
            {
                Title = "T",
                Content = "Hope the test will succeed.",
                PublishDate = DateTime.Now,
                AuthorId = this.repo.Users.All().First().Id
            };

            // Act -> perform some logic
            this.repo.News.Add(invalidNews);
            this.repo.SaveChanges();

            // Assert -> expect an exception
        }

        [TestMethod]
        public void ModifyExistingNews_WhenNewsIsValid_ShouldEdit()
        {
            const string newTitle = "New title";
            const string newContent = "The content was edited.";

            // Arrange -> prapare the objects
            var news = this.repo.News.All().First();

            // Act -> perform some logic
            news.Title = newTitle;
            news.Content = newContent;
            this.repo.News.Update(news);
            this.repo.SaveChanges();

            // Assert -> validate the results
            var newsFromDb = this.repo.News.Find(news.Id);

            Assert.AreEqual(2, this.repo.News.All().Count());
            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(newTitle, newsFromDb.Title);
            Assert.AreEqual(newContent, newsFromDb.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ModifyExistingNews_WhenNewsIsInvalid_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            var news = this.repo.News.All().First();

            // Act -> perform some logic
            news.Title = "A";
            this.repo.News.Update(news);
            this.repo.SaveChanges();

            // Assert -> validate the results
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void ModifyNonExistingNews_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            var user = new ApplicationUser
            {
                UserName = "ivan",
                Email = "ivan@abv.bg"
            };
            this.repo.Users.Add(user);
            this.repo.SaveChanges();

            var news = new News
            {
                Title = "Seeding repositoriesasd",
                Content = "Some content asdasd.",
                PublishDate = DateTime.Parse("2000-01-19"),
                AuthorId = user.Id,
                Author = user
            };

            // Act -> perform some logic
            this.repo.News.Update(news);
            this.repo.SaveChanges();

            // Assert -> validate the results
        }

        [TestMethod]
        public void DeleteExistingNews__ShouldDelete()
        {
            // Arrange -> prapare the objects

            // Act -> perform some logic
            var news = this.repo.News.All().First();
            this.repo.News.Delete(news);
            this.repo.SaveChanges();

            // Assert -> validate the results
            var newsFromDb = this.repo.News.Find(news.Id);
            Assert.IsNull(newsFromDb);
            Assert.AreEqual(1, this.repo.News.All().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DeleteNonExistingNews_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            var user = new ApplicationUser
            {
                UserName = "ivan",
                Email = "ivan@abv.bg"
            };
            this.repo.Users.Add(user);
            this.repo.SaveChanges();

            var news = new News
            {
                Title = "Seeding repositoriesasd",
                Content = "Some content asdasd.",
                PublishDate = DateTime.Parse("2000-01-19"),
                AuthorId = user.Id,
                Author = user
            };

            // Act -> perform some logic
            this.repo.News.Delete(news);
            this.repo.SaveChanges();

            // Assert -> validate the results
        }
        
        private void CleanDatabase()
        {
            using (var dbContext = new NewsContext())
            {
                dbContext.News.Delete();
                dbContext.Users.Delete();
                dbContext.SaveChanges();
            }

            this.repo = new NewsData(NewsContext.Create());

            var user = new ApplicationUser
            {
                UserName = "petar",
                Email = "petar@abv.bg"
            };

            this.repo.Users.Add(user);

            var news = new List<News>
            {
                new News
                {
                    Title = "Seeding repositories",
                    Content = "Some content.",
                    PublishDate = DateTime.Parse("2000-01-20")
                },
                new News
                {
                    Title = "Web and cloud exam",
                    Content = "There won't be any prepared unit tests.",
                    PublishDate = DateTime.Parse("2015-09-12")
                }
            };
               
            user.News.Add(news[0]);
            user.News.Add(news[1]);

            this.repo.Users.Add(user);
            this.repo.SaveChanges();
        }
    }
}