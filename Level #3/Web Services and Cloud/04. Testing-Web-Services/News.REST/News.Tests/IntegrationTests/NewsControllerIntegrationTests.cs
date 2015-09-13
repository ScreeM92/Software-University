namespace News.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Owin;
    using Services;
    using EntityFramework.Extensions;
    using News.Models;
    using Services.Models;

    [TestClass]
    public class NewsControllerIntegrationTests
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Start OWIN testing HTTP server with Web API support
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                var startup = new Startup();
                startup.Configuration(appBuilder);

                appBuilder.UseWebApi(config);
            });
            this.httpClient = this.httpTestServer.HttpClient;

            //Clean Users and News tables from Db
            CleanDatabase();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void ListNews_EmptyDb_ShouldReturn200Ok_EmptyNewsList()
        {
            // Arrange

            // Act
            var httpResponse = this.httpClient.GetAsync("/api/news").Result;
            var bugs = httpResponse.Content.ReadAsAsync<List<News>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(0, bugs.Count);
        }

        [TestMethod]
        public void ListNews_NonEmptyDb_ShouldReturnNewsList()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            this.CreateNews(loginData);

            // Act
            var httpResponse = this.httpClient.GetAsync("/api/news").Result;
            var dbNews = httpResponse.Content.ReadAsAsync<List<News>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(1, dbNews.Count);
            Assert.AreEqual("News title", dbNews[0].Title);
            Assert.AreEqual("some news content", dbNews[0].Content);
        }

        [TestMethod]
        public void RegisterUser_CorrectData_ShouldCreateUser_Return200OK()
        {
            // Arange

            // Act
            var registerContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "stefan"),
                new KeyValuePair<string, string>("confirmPassword", "stefan"),
                new KeyValuePair<string, string>("email", "stefan@email.aa")
            });

            var httpResponse = this.httpClient.PostAsync("api/account/register", registerContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [TestMethod]
        public void RegisterUser_InvalidData_ShouldReturn_400BadRequest()
        {
            // Arange

            // Act
            var registerContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "st"), // The Password must be at least 6 characters long.
                new KeyValuePair<string, string>("confirmPassword", "st"),
                new KeyValuePair<string, string>("email", "stefan@email.aa")
            });

            var httpResponse = this.httpClient.PostAsync("api/account/register", registerContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void LoginUser_ValidData_ShouldReturn_200OK()
        {
            // Arange
            this.Register();

            // Act
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "stefan"),
                new KeyValuePair<string, string>("grant_type", "password")   
            });

            var httpResponse = this.httpClient.PostAsync("api/account/login", content).Result;
            var responseContent = httpResponse.Content.ReadAsAsync<LoginData>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.IsNotNull(responseContent.Access_Token);
        }

        [TestMethod]
        public void LoginUser_InvalidData_ShouldReturn_400BadRequest()
        {
            // Arange
            this.Register();

            // Act
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "stefan12"), // Wrong password
                new KeyValuePair<string, string>("grant_type", "password")   
            });

            var httpResponse = this.httpClient.PostAsync("api/account/login", content).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void CreateNews_CorrectData_ValidAccessToken_ShouldReturn_201Created()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            
            var news = new AddNewsBindingModel
            {
                Title = "News title",
                Content = "some news content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PostAsync("api/news", newsContent).Result;
            var dbNews = httpResponse.Content.ReadAsAsync<NewsViewModel>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(news.Title, dbNews.Title);
            Assert.AreEqual(news.Content, dbNews.Content);
            Assert.AreEqual(loginData.UserName, dbNews.Author.UserName);
        }

        [TestMethod]
        public void CreateNews_CorrectData_NoAccessToken_ShouldReturn_401Unauthorized()
        {
            // Arrange
            var news = new AddNewsBindingModel
            {
                Title = "News title",
                Content = "some news content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            var httpResponse = this.httpClient.PostAsync("api/news", newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        [TestMethod]
        public void CreateNews_CorrectData_DuplicateTitle_ValidAccessToken_ShouldReturn_409Conflict()
        {
            this.Register();
            var loginData = this.Login();
            this.CreateNews(loginData);

            // Arrange
            var news = new AddNewsBindingModel
            {
                Title = "News title",
                Content = "some news content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PostAsync("api/news", newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Conflict, httpResponse.StatusCode);
        }

        [TestMethod]
        public void CreateNews_EmptyBindingModel_ValidAccessToken_ShouldReturn_400BadRequest()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PostAsync("api/news", null).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void CreateNews_InvalidData_ValidAccessToken_ShouldReturn_400BadRequest()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var news = new AddNewsBindingModel
            {
                Title = "News title",
                Content = "some news content",
                PublishDate = DateTime.Now
            };

            // Missing Content
            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PostAsync("api/news", newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
        }

        [TestMethod]
        public void ModifyExistingNews_ValidData_ValidAccessToken_ShouldReturn_200OK()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);
            var news = new EditNewsBindingModel
            {
                Title = "Edited title",
                Content = "Edited content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/news/" + dbNewsId, newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [TestMethod]
        public void ModifyExistingNews_ValidData_NoAccessToken_ShouldReturn_401Unauthorized()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);
            var news = new EditNewsBindingModel
            {
                Title = "Edited title",
                Content = "Edited content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            var httpResponse = this.httpClient.PutAsync("api/news/" + dbNewsId, newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        [TestMethod]
        public void ModifyExistingNews_ValidData_DuplicateTitle_ValidAccessToken_ShouldReturn_409Conflict()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            this.CreateNews(loginData);

            var secondNews = new AddNewsBindingModel
            {
                Title = "Second news title",
                Content = "second news content",
                PublishDate = DateTime.Now
            };

            var secondNewsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", secondNews.Title),
                new KeyValuePair<string, string>("content", secondNews.Content),
                new KeyValuePair<string, string>("publishDate", secondNews.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var secondNewsHttpResponce = this.httpClient.PostAsync("api/news", secondNewsContent).Result;
            Assert.AreEqual(HttpStatusCode.Created, secondNewsHttpResponce.StatusCode);
            var newsId = secondNewsHttpResponce.Content.ReadAsAsync<NewsViewModel>().Result.Id;

            var editedNews = new EditNewsBindingModel
            {
                Title = "News title",
                Content = "Edited content",
                PublishDate = DateTime.Now
            };

            var editedNewsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", editedNews.Title),
                new KeyValuePair<string, string>("content", editedNews.Content),
                new KeyValuePair<string, string>("publishDate", editedNews.PublishDate.ToString())
            });

            // Act
            var httpResponse = this.httpClient.PutAsync("api/news/" + newsId, editedNewsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Conflict, httpResponse.StatusCode);
        }

        [TestMethod]
        public void ModifyExistingNews_EmptyBindingModel_ValidAccessToken_ShouldReturn_400BadRequest()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/news/" + dbNewsId, null).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void ModifyExistingNews_InvalidData_ValidAccessToken_ShouldReturn_400BadRequest()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);
            var news = new EditNewsBindingModel
            {
                Title = "Edited title",
                Content = "Edited content",
                PublishDate = DateTime.Now
            };

            // Missing Content
            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/news/" + dbNewsId, newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void ModifyNonExistingNews_ValidData_ValidAccessToken_ShouldReturn_404NotFound()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var news = new EditNewsBindingModel
            {
                Title = "Edited title",
                Content = "Edited content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/news/100", newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [TestMethod]
        public void ModifyExistingNews_NotNewsOwner_ValidData_ValidAccessToken_ShouldReturn_401Unathorized()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);

            var secondRegistrationContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", "stefan1"),
                new KeyValuePair<string, string>("password", "stefan1"),
                new KeyValuePair<string, string>("confirmPassword", "stefan1"),
                new KeyValuePair<string, string>("email", "stefan1@email.aa")
            });

            var registrationHttpResponse = this.httpClient.PostAsync("api/account/register", secondRegistrationContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, registrationHttpResponse.StatusCode);

            var loginContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan1"),
                new KeyValuePair<string, string>("password", "stefan1"),
                new KeyValuePair<string, string>("grant_type", "password")   
            });

            var loginHttpResponse = this.httpClient.PostAsync("api/account/login", loginContent).Result;
            var newLoginData = loginHttpResponse.Content.ReadAsAsync<LoginData>().Result;
            Assert.AreEqual(HttpStatusCode.OK, loginHttpResponse.StatusCode);

            var news = new EditNewsBindingModel
            {
                Title = "Edited title",
                Content = "Edited content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + newLoginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/news/" + dbNewsId, newsContent).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        [TestMethod]
        public void DeleteExistingNews_ValidAccessToken_ShouldReturn_200OK()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.DeleteAsync("api/news/" + dbNewsId).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [TestMethod]
        public void DeletExistingeNews_NoAccessToken_ShouldReturn_401Unauthorized()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);

            // Act
            var httpResponse = this.httpClient.DeleteAsync("api/news/" + dbNewsId).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        [TestMethod]
        public void DeletenExistingNews_NotNewsOwner_ValidAccessToken_ShouldReturn_401Unauthorized()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();
            var dbNewsId = this.CreateNews(loginData);

            var secondRegistrationContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", "stefan1"),
                new KeyValuePair<string, string>("password", "stefan1"),
                new KeyValuePair<string, string>("confirmPassword", "stefan1"),
                new KeyValuePair<string, string>("email", "stefan1@email.aa")
            });

            var registrationHttpResponse = this.httpClient.PostAsync("api/account/register", secondRegistrationContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, registrationHttpResponse.StatusCode);

            var loginContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan1"),
                new KeyValuePair<string, string>("password", "stefan1"),
                new KeyValuePair<string, string>("grant_type", "password")   
            });

            var loginHttpResponse = this.httpClient.PostAsync("api/account/login", loginContent).Result;
            var newLoginData = loginHttpResponse.Content.ReadAsAsync<LoginData>().Result;
            Assert.AreEqual(HttpStatusCode.OK, loginHttpResponse.StatusCode);


            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + newLoginData.Access_Token);
            var httpResponse = this.httpClient.DeleteAsync("api/news/" + dbNewsId).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        [TestMethod]
        public void DeleteNonExistingNews_ValidAccessToken_ShouldReturn_404NotFound()
        {
            // Arrange
            this.Register();
            var loginData = this.Login();

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.DeleteAsync("api/news/100").Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        private static void CleanDatabase()
        {
            // Clean all data in all database tables
            var dbContext = new NewsContext();
            dbContext.News.Delete();
            dbContext.Users.Delete();
            dbContext.SaveChanges();
        }

        private LoginData Login()
        {
            var loginContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "stefan"),
                new KeyValuePair<string, string>("grant_type", "password")   
            });

            var httpResponse = this.httpClient.PostAsync("api/account/login", loginContent).Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                // Nothing to return, throw a proper exception + message
                throw new HttpRequestException(
                    httpResponse.Content.ReadAsStringAsync().Result);
            }

            return httpResponse.Content.ReadAsAsync<LoginData>().Result;
        }

        private void Register()
        {
            var registerContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "stefan"),
                new KeyValuePair<string, string>("confirmPassword", "stefan"),
                new KeyValuePair<string, string>("email", "stefan@email.aa")
            });

            var httpResponse = this.httpClient.PostAsync("api/account/register", registerContent).Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                // Nothing to return, throw a proper exception + message
                throw new HttpRequestException(
                    httpResponse.Content.ReadAsStringAsync().Result);
            }
        }

        private int CreateNews(LoginData loginData)
        {
            var news = new AddNewsBindingModel
            {
                Title = "News title",
                Content = "some news content",
                PublishDate = DateTime.Now
            };

            var newsContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content),
                new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PostAsync("api/news", newsContent).Result;
            this.httpClient.DefaultRequestHeaders.Remove("Authorization");

            if (!httpResponse.IsSuccessStatusCode)
            {
                // Nothing to return, throw a proper exception + message
                throw new HttpRequestException(
                    httpResponse.Content.ReadAsStringAsync().Result);
            }

            var dbNews = httpResponse.Content.ReadAsAsync<News>().Result;

            return dbNews.Id;
        }
    }
}