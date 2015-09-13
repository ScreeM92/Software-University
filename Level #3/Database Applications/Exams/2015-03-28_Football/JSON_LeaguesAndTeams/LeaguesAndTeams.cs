namespace JSON_LeaguesAndTeams
{
    using System;
    using System.IO;
    using System.Linq;
    using Football.Data;
    using Newtonsoft.Json;

    public class LeaguesAndTeams
    {
        private const string ExportPath = @"..\..\..\Export\";
        private const string ExportFilename = "leagues-and-teams.json";

        public static void Main()
        {
            CheckExistingFolder(ExportPath);

            var context = new FootballEntities();
            var leagues = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    l.LeagueName,
                    teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
                });

            var json = JsonConvert.SerializeObject(leagues, Formatting.Indented);
            //var json = JsonConvert.SerializeObject(leagues); // Use this line for non-indented output

            File.WriteAllText(ExportPath + ExportFilename, json);
            Console.WriteLine("File path: {0}", Path.GetFullPath(ExportPath + ExportFilename));
        }

        private static void CheckExistingFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}