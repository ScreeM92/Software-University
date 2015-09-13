namespace _03.EverythingVsColumns
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using DbContext;

    public class EverythingVsColumns
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
        // | Non-optimized (ms) |   230 |   239 |   235 |   243 |   233 |   236 |   232 |   233 |   246 |    242 |          237 |
        // | Optimized (ms)     |    20 |    19 |    21 |    20 |    20 |    19 |    19 |    21 |    19 |     19 |           20 |
        // +--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
        }

        private static void GetNonOptimizedQueryExecutionTime(AdsContext context)
        {
            var ads = context.Ads.ToList();
        }

        private static void GetOptimizedQueryExecutionTime(AdsContext context)
        {
            var ads = context.Ads
                .Select(a => a.Title)
                .ToList();
        }

        private static void CleanCache(AdsContext context)
        {
            context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS DBCC FREEPROCCACHE");
        }
    }
}
