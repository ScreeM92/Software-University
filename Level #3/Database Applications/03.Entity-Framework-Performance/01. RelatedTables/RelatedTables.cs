namespace _01.RelatedTables
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using DbContext;

    public class RelatedTables
    {
        public static void Main()
        {
            var context = new AdsContext();

            GetAdsNoInclude(context);

            GetAdsWithInclude(context);

            // +--------------------------+------------+--------------+
            // |                          | No Include | With Include |
            // +--------------------------+------------+--------------+
            // | Number of SQL statements |         28 |            1 |
            // +--------------------------+------------+--------------+
        }

        private static void GetAdsNoInclude(AdsContext context)
        {
            var ads = context.Ads;

            PrintAds(ads);
        }

        private static void GetAdsWithInclude(AdsContext context)
        {
            var ads = context.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);

            PrintAds(ads);
        }

        private static void PrintAds(IEnumerable<Ad> ads)
        {
            var adsOutput = new StringBuilder();

            foreach (var ad in ads)
            {
                adsOutput.AppendFormat("Title: {0}{1}", ad.Title, Environment.NewLine);
                adsOutput.AppendFormat("Status: {0}{1}", ad.AdStatus.Status, Environment.NewLine);
                adsOutput.AppendFormat("Category: {0}{1}",
                    ad.Category != null ? ad.Category.Name : "no category",
                    Environment.NewLine);
                adsOutput.AppendFormat("Title: {0}{1}",
                    ad.Town != null ? ad.Town.Name : "no town",
                    Environment.NewLine);
                adsOutput.AppendFormat("User: {0}{1}", ad.AspNetUser.UserName, Environment.NewLine);
                adsOutput.AppendLine(new string('-', 50));
            }

            Console.Write(adsOutput);
            Console.WriteLine("Total ads: {0}{1}{2}{1}", ads.Count(), Environment.NewLine, new string('-', 50));
        }
    }
}
