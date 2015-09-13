namespace XmlFinished_Games
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Diablo.Data;

    public class FinishedGamesMain
    {
        private const string ExportPath = @"..\..\..\Export\";
        private const string Filename = "finished-games.xml";

        public static void Main()
        {
            CheckExistingDirectory(ExportPath);
            var context = new DiabloEntities();

            var games = context.Games
                .Where(g => g.IsFinished)
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Select(g => new FinishedGame
                {
                    Name = g.Name,
                    Duration = g.Duration,
                    Users = context.UsersGames
                            .Where(ug => ug.GameId == g.Id).Select(ug => new User
                            {
                                Username = ug.User.Username,
                                IpAddress = ug.User.IpAddress
                            })
                });

            ExportGamesToXml(games);
        }

        private static void ExportGamesToXml(IEnumerable<FinishedGame> games)
        {
            var doc = new XDocument();
            var rootNode = new XElement("games");
            doc.Add(rootNode);
            foreach (var game in games)
            {
                var gameNode = new XElement("game");
                gameNode.SetAttributeValue("name", game.Name);
                if (game.Duration != null)
                {
                    gameNode.SetAttributeValue("duration", game.Duration);
                }

                var usersNode = new XElement("users");
                gameNode.Add(usersNode);

                foreach (var user in game.Users)
                {
                    var userNode = new XElement("user");
                    userNode.SetAttributeValue("username", user.Username);
                    userNode.SetAttributeValue("ip-address", user.IpAddress);
                    usersNode.Add(userNode);
                }

                rootNode.Add(gameNode);
            }

            doc.Save(ExportPath + Filename);
            Console.WriteLine("File path: {0}", Path.GetFullPath(ExportPath + Filename));
        }

        private static void CheckExistingDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
