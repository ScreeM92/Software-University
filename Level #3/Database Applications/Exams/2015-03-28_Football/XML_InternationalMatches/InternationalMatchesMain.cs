namespace XML_InternationalMatches
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;
    using Football.Data;

    public class InternationalMatchesMain
    {
        private const string ExportPath = @"..\..\..\Export\";
        private const string ExportFilename = "international-matches.xml";

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var context = new FootballEntities();

            var internationalMatches = context.InternationalMatches
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.HomeCountry.CountryName)
                .ThenBy(m => m.AwayCountry.CountryName)
                .Select(m => new InternationalMatch
                {
                    HomeCountryCode = m.HomeCountryCode,
                    HomeCountry = m.HomeCountry.CountryName,
                    HomeGoals = m.HomeGoals,
                    AwayCountryCode = m.AwayCountryCode,
                    AwayCountry = m.AwayCountry.CountryName,
                    AwayGoals = m.AwayGoals,
                    League = m.League.LeagueName,
                    MatchDate = m.MatchDate
                });

            //DateTime myDate;
            //if (DateTime.TryParseExact(inputString, "dd-MM-yyyy hh:mm:ss",
            //    CultureInfo.InvariantCulture, DateTimeStyles.None, out myDate))
            //{
            //    //String has Date and Time
            //}
            //else
            //{
            //    //String has only Date Portion    
            //}


            GenerateXmlWithMatches(internationalMatches);
        }

        private static void CheckExistingFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private static void GenerateXmlWithMatches(IEnumerable<InternationalMatch> internationalMatches)
        {
            CheckExistingFolder(ExportPath);
            var doc = new XDocument();

            var rootNode = new XElement("matches");
            doc.Add(rootNode);

            foreach (var match in internationalMatches)
            {
                var matchNode = new XElement("match");
                matchNode.Add(GenerateElement(
                    "home-country", 
                    match.HomeCountry, 
                    new Dictionary<string, string>{{"code", match.HomeCountryCode}}));
                matchNode.Add(GenerateElement(
                    "away-country",
                    match.AwayCountry,
                    new Dictionary<string, string> { { "code", match.AwayCountryCode } }));

                if (match.MatchDate != null)
                {
                    if (HasTimePart(match.MatchDate))
                    {
                        matchNode.SetAttributeValue("date-time", string.Format("{0:dd-MMM-yyyy HH:mm}", match.MatchDate));
                    }
                    else
                    {
                        matchNode.SetAttributeValue("date", string.Format("{0:dd-MMM-yyyy}", match.MatchDate));
                    }
                }

                if (match.HomeGoals != null && match.AwayGoals != null)
                {
                    matchNode.Add(GenerateElement("score", string.Format("{0}-{1}", match.HomeGoals, match.AwayGoals)));
                }

                if (match.League != null)
                {
                    matchNode.Add(GenerateElement("league", match.League));
                }

                rootNode.Add(matchNode);
            }

            doc.Save(ExportPath + ExportFilename);
            Console.WriteLine("File path: {0}", Path.GetFullPath(ExportPath + ExportFilename));
        }

        private static bool HasTimePart(DateTime? dateTime)
        {
            return dateTime.Value.TimeOfDay.TotalSeconds != 0;
        }

        private static XElement GenerateElement(string name, string value, Dictionary<string, string> attribute = null)
        {
            var element = new XElement(name);
            element.Value = value;
            if (attribute != null)
            {
                element.SetAttributeValue(attribute.Keys.First(), attribute.Values.First());
            }

            return element;
        }
    }
}