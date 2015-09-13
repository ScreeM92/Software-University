namespace News.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using News.Models;

    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public AuthorViewModel Author { get; set; }

        public static Expression<Func<News, NewsViewModel>> Create
        {
            get
            {
                return n => new NewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    PublishDate = n.PublishDate,
                    Author = new AuthorViewModel
                    {
                        Id = n.Author.Id,
                        UserName = n.Author.UserName,
                        Email = n.Author.Email
                    }

                };
            }
        }

        public static NewsViewModel CreateView(News n)
        {
            return  new NewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                PublishDate = n.PublishDate,
                Author = new AuthorViewModel
                {
                    Id = n.Author.Id,
                    UserName = n.Author.UserName,
                    Email = n.Author.Email
                }
            };
        }
    }
}