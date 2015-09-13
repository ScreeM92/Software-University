namespace News.Tests.UnitTestsWithMoq
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using News.Models;
    using Services.Controllers;
    using Services.Infrastructure;
    using Services.Models;

    [TestClass]
    public class NewsControllerTests
    {
        private MockContainer mocks;

        private Mock<INewsData> mockContext;

        private Mock<IUserProvider> mockUserProvider;

        private NewsController controller;

        [TestInitialize]
        public void InitTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
            this.mockContext = new Mock<INewsData>();
            this.PrepareMockContext();
            this.mockUserProvider = new Mock<IUserProvider>();
            this.PrepareMockUserProvider();
            
            this.controller = new NewsController(this.mockContext.Object, this.mockUserProvider.Object);
            this.SetupController(this.controller);
        }

        [TestMethod]
        public void GetAllNews_Should_Return_Total_News_Sorted_By_PublishDate_Descending()
        {
            var fakeNews = this.mockContext.Object.News.All();
            var response = this.controller.GetAllNews()
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var newsResponse = response.Content.ReadAsAsync<IEnumerable<NewsViewModel>>()
                .Result.Select(a => a.Id)
                .ToList();

            var orderedFakeNews = fakeNews
                .OrderByDescending(n => n.PublishDate)
                .Select(n => n.Id)
                .ToList();

            CollectionAssert.AreEqual(orderedFakeNews, newsResponse);
        }
        
        [TestMethod]
        public void CreateSingleNews_Should_Successfully_Add_To_Repository()
        {
            var fakeUser = this.mocks.UserRepositoryMock.Object.All()
                .FirstOrDefault();
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no user available.");
            }

            var randomTitle = Guid.NewGuid().ToString();
            var randomContent = Guid.NewGuid().ToString();
            var publisDate = DateTime.Now;
            var newAd = new AddNewsBindingModel
            {
                Title = randomTitle,
                Content = randomContent,
                PublishDate = publisDate
            };

            var response = this.controller.CreateNews(newAd)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreEqual(this.mocks.InitialNewsCount + 1, this.mocks.NewsFakeRepo.Count);
            Assert.AreEqual(newAd.Title, this.mocks.NewsFakeRepo.Last().Title);
            Assert.AreEqual(newAd.Title, this.mocks.NewsFakeRepo.Last().Title);
            Assert.AreEqual(fakeUser, this.mocks.NewsFakeRepo.Last().Author);
        }

        [TestMethod]
        public void CreateSomeNews_Should_Successfully_Add_To_Repository()
        {
            var newsToCreate = 5;
            var fakeUser = this.mocks.UserRepositoryMock.Object.All()
                .FirstOrDefault();
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no user available.");
            }

            for (int i = 0; i < newsToCreate; i++)
            {
                var randomTitle = Guid.NewGuid().ToString();
                var randomContent = Guid.NewGuid().ToString();
                var publisDate = DateTime.Now;

                var newAd = new AddNewsBindingModel
                {
                    Title = randomTitle ,
                    Content = randomContent,
                    PublishDate = publisDate
                };

                var response = this.controller.CreateNews(newAd)
                    .ExecuteAsync(CancellationToken.None).Result;

                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

                Assert.AreEqual(this.mocks.InitialNewsCount + i + 1, this.mocks.NewsFakeRepo.Count);
                Assert.AreEqual(newAd.Title, this.mocks.NewsFakeRepo.Last().Title);
                Assert.AreEqual(newAd.Title, this.mocks.NewsFakeRepo.Last().Title);
                Assert.AreEqual(fakeUser, this.mocks.NewsFakeRepo.Last().Author);
            }

            this.mockContext.Verify(c => c.SaveChanges(), Times.Exactly(newsToCreate));
        }

        [TestMethod]
        public void CreateNews_InvalidModel_Should_Return_400BadRequest()
        {
            if (!this.mocks.UserRepositoryMock.Object.All().Any())
            {
                Assert.Fail("Cannot perform test - no user available.");
            }

            this.controller.ModelState.AddModelError("PublishDate", "A value is required.");

            var randomTitle = Guid.NewGuid().ToString();
            var randomContent = Guid.NewGuid().ToString();

            var newAd = new AddNewsBindingModel
            {
                Title = randomTitle,
                Content = randomContent
            };

            var response = this.controller.CreateNews(newAd)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Never);
            Assert.AreEqual(this.mocks.InitialNewsCount, this.mocks.NewsFakeRepo.Count);
        }

        [TestMethod]
        public void EditNews_CorrectData_Should_Successfully_Add_To_Repository()
        {
            const string newTitle = "New title";
            const string newContent = "New content";

            var fakeNew = this.mocks.NewsRepositoryMock.Object.All().FirstOrDefault();
            if (fakeNew == null)
            {
                Assert.Fail("Cannot perform test - no news available");
            }
            
            var editNewsBindingModel = new EditNewsBindingModel
            {
                Title = newTitle,
                Content = newContent,
                PublishDate = fakeNew.PublishDate
            };

            var response = this.controller.EditNews(fakeNew.Id, editNewsBindingModel)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Exactly(1));
            Assert.AreEqual(this.mocks.InitialNewsCount, this.mocks.NewsFakeRepo.Count);
            Assert.AreEqual(newTitle, this.mocks.NewsFakeRepo.First().Title);
            Assert.AreEqual(newContent, this.mocks.NewsFakeRepo.First().Content);
        }

        [TestMethod]
        public void EditNews_IncorrectData_Should_Return_400BadRequest()
        {
            var fakeNew = this.mocks.NewsRepositoryMock.Object.All().FirstOrDefault();
            if (fakeNew == null)
            {
                Assert.Fail("Cannot perform test - no news available");
            }

            var newTitle = "N";
            var newContent = "New content";
            var editNewsBindingModel = new EditNewsBindingModel
            {
                Title = newTitle,
                Content = newContent,
                PublishDate = DateTime.Now
            };

            this.controller.ModelState.AddModelError("Title", "The field Title must be a string or array type with a minimum length of '2'.");
            var response = this.controller.EditNews(fakeNew.Id, editNewsBindingModel)
                .ExecuteAsync(CancellationToken.None).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Exactly(0));
            Assert.AreEqual(this.mocks.InitialNewsCount, this.mocks.NewsFakeRepo.Count);
            Assert.AreEqual(fakeNew.Title, this.mocks.NewsFakeRepo.First().Title);
            Assert.AreEqual(fakeNew.Content, this.mocks.NewsFakeRepo.First().Content);
            Assert.AreEqual(fakeNew.PublishDate, this.mocks.NewsFakeRepo.First().PublishDate);
        }

        [TestMethod]
        public void EditNews_NonExistingId_Should_Return_404NotFound()
        {
            this.mocks.NewsRepositoryMock
                .Setup(r => r.Find(It.IsAny<int>()))
                .Returns((News)null);

            var editNewsBindingModel = new EditNewsBindingModel
            {
                Title = "New title",
                Content = "New content",
                PublishDate = DateTime.Now
            };

            var response = this.controller.EditNews(0, editNewsBindingModel)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Exactly(0));
            Assert.AreEqual(this.mocks.InitialNewsCount, this.mocks.NewsFakeRepo.Count);
        }

        [TestMethod]
        public void DeleteNews_ExistingId_Should_Return_200OK()
        {
            var fakeNew = this.mocks.NewsRepositoryMock.Object.All().FirstOrDefault();
            if (fakeNew == null)
            {
                Assert.Fail("Cannot perform test - no news available");
            }

            var response = this.controller.DeleteNews(fakeNew.Id)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Exactly(1));
            Assert.AreEqual(this.mocks.InitialNewsCount, this.mocks.NewsFakeRepo.Count);
        }

        [TestMethod]
        public void DeleteNews_NonExistingId_Should_Return_404NotFound()
        {
            this.mocks.NewsRepositoryMock
                .Setup(r => r.Find(It.IsAny<int>()))
                .Returns((News)null);

            var response = this.controller.DeleteNews(0)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Never);
            Assert.AreEqual(this.mocks.InitialNewsCount, this.mocks.NewsFakeRepo.Count);
        }

        private void PrepareMockContext()
        {
            this.mockContext.Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users)
                .Returns(this.mocks.UserRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users.Find(It.IsAny<string>()))
                .Returns(this.mocks.UserRepositoryMock.Object.All().FirstOrDefault());
        }

        private void PrepareMockUserProvider()
        {
            this.mockUserProvider.SetupGet(ip => ip.IsAuthenticated)
                .Returns(true);
            this.mockUserProvider.Setup(ip => ip.GetUserId())
                .Returns(this.mocks.UserRepositoryMock.Object.All().First().Id);
        }

        private void SetupController(NewsController newsController)
        {
            string serverUrl = "http://sample-url.com";

            newsController.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(serverUrl)
            };

            newsController.Configuration = new HttpConfiguration();
            newsController.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller =  RouteParameter.Optional, id = RouteParameter.Optional });
        }
    }
}
