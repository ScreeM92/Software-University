namespace News.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using Data.Contracts;
    using News.Models;

    public class MockContainer
    {
        public int InitialNewsCount { get; private set; }

        public Mock<IRepository<News>> NewsRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public IList<News> NewsFakeRepo { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeUsers();
            this.SetupFakeNews();
            this.InitialNewsCount = this.NewsFakeRepo.Count;
        }

        private void SetupFakeNews()
        {
            this.NewsFakeRepo = new List<News>
            {
                new News
                {
                    Id = 1,
                    Title = "Testing with moq",
                    Content = "Cool!",
                    PublishDate = DateTime.Now.AddDays(-6),
                    AuthorId = this.UserRepositoryMock.Object.All().First().Id,
                    Author = this.UserRepositoryMock.Object.All().First()
                },
                new News
                {
                    Id = 2,
                    Title = "Testing with fake repositories",
                    Content = "I don't like it at all.",
                    PublishDate = DateTime.Now.AddDays(-10),
                    AuthorId = this.UserRepositoryMock.Object.All().First().Id,
                    Author = this.UserRepositoryMock.Object.All().FirstOrDefault()
                }
            };

            this.NewsRepositoryMock = new Mock<IRepository<News>>();
            this.NewsRepositoryMock.Setup(r => r.All())
                .Returns(this.NewsFakeRepo.AsQueryable());

            this.NewsRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = this.NewsFakeRepo.FirstOrDefault(a => a.Id == id);
                    return ad;
                });

            this.NewsRepositoryMock
                .Setup(r => r.Add(It.IsAny<News>()))
                .Callback((News news) =>
                {
                    news.Author = this.UserRepositoryMock.Object.All().FirstOrDefault();
                    this.NewsFakeRepo.Add(news);
                });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>
            {
                new ApplicationUser() {UserName = "vanko1", Email = "vanko1@abv.bg"},
                new ApplicationUser() {UserName = "ivan", Email = "ivan@abv.bg"},
                new ApplicationUser() {UserName = "stefan", Email = "stefan@abv.bg"},
                new ApplicationUser() {UserName = "petar", Email = "petar@abv.bg"}
            };

            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();

            this.UserRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());
        }
    }
}