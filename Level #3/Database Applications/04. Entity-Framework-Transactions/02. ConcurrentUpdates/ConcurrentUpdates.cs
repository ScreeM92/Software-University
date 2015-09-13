using System;
using NewsDb.Models;

namespace _02.ConcurrentUpdates
{
    using NewsDb;
    using System.Linq;

    class ConcurrentUpdates
    {
        private static readonly string Separator = new string('-', 20);

        public static void Main()
        {
            var firstUserContext = new NewsContext();
            var secondUserContext = new NewsContext();

            ProcessUserEntry(secondUserContext, firstUserContext);
        }

        public static void ProcessUserEntry(NewsContext secondUserContext, NewsContext firstUserContext = null)
        {
            try
            {
                if (firstUserContext != null)
                {
                    Console.WriteLine("{0}\nUser 1:\nApplication started.", Separator);
                    var firstUserNews = firstUserContext.News.FirstOrDefault();
                    ChangeContent(firstUserNews, firstUserContext);

                    Console.WriteLine("{0}\nUser 2:\nApplication started.", Separator);
                    var secondUserNews = secondUserContext.News.FirstOrDefault();
                    ChangeContent(secondUserNews, secondUserContext);
                    Console.WriteLine(Separator);

                    firstUserContext.SaveChanges();
                    Console.WriteLine("User 1 changes successfully saved in the DB.");
                    secondUserContext.SaveChanges();
                }
                else
                {
                    var secondUserNews = secondUserContext.News.FirstOrDefault();
                    ChangeContent(secondUserNews, secondUserContext);
                    secondUserContext.SaveChanges();
                    Console.WriteLine("User 2 changes successfully saved in the DB.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("User 2: Db Conflict!\n{0}", Separator);
                Console.WriteLine("User 2:");
                ProcessUserEntry(new NewsContext());
            }
        }

        public static void ChangeContent(News news, NewsContext context)
        {
            Console.WriteLine("Text from DB: {0}", news.Content);
            Console.Write("Enter the corrected text: ");
            news.Content = Console.ReadLine();
        }
    }
}