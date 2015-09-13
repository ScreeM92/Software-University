namespace _02.ToList
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using DbContext;

    public class ToList
    {
        public static void Main()
        {
            var context = new AdsContext();
            var sw = new Stopwatch();
            context.Ads.Count();

            CleanCache(context);
            sw.Start();
            GetNonOptimizedQueryExecutionTime(context);
            Console.WriteLine("Non-optimized: {0}", sw.ElapsedMilliseconds);

            CleanCache(context);
            sw = Stopwatch.StartNew();
            GetOptimizedQueryExecutionTime(context);
            Console.WriteLine("Optimized: {0}", sw.ElapsedMilliseconds);
            

        // +--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
        // |                    | Run 1 | Run 2 | Run 3 | Run 4 | Run 5 | Run 6 | Run 7 | Run 8 | Run 9 | Run 10 | Average Time |
        // +--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
        // | Non-optimized (ms) |   461 |   465 |   461 |   480 |   465 |   531 |   469 |   470 |   485 |    463 |          475 |
        // | Optimized (ms)     |   229 |   230 |   247 |   219 |   226 |   274 |   248 |   236 |   242 |    224 |          238 |
        // +--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
        }

        private static void GetNonOptimizedQueryExecutionTime(AdsContext context)
        {
            var ads = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    a.Category,
                    a.Town
                }).ToList();
        }

        private static void GetOptimizedQueryExecutionTime(AdsContext context)
        {
            var ads = context.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    a.Category,
                    a.Town
                }).ToList();
        }

        private static void CleanCache(AdsContext context)
        {
            context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS DBCC FREEPROCCACHE");
        }
    }
}