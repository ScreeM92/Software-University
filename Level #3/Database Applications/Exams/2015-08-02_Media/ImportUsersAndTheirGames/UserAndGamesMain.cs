namespace ImportUsersAndTheirGames
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Xml.Linq;
    using Diablo.Data;

    public class UserAndGamesMain
    {
        private const string ImportFilePath = @"..\..\..\Import\users-and-games.xml";
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var context = new DiabloEntities();
            ParseXmlDocument(context, ImportFilePath);
        }

        private static void ParseXmlDocument(DiabloEntities context, string filePath)
        {
            var doc = XDocument.Load(filePath);
            var users = doc.Descendants("user");
            
            foreach (var user in users)
            {
                try
                {
                    var username = user.Attribute("username").Value;

                    if (context.Users.Any(u => u.Username == username))
                    {
                        throw new InvalidOperationException(string.Format("User {0} already exists", username));
                    }

                    var output = new StringBuilder();
                    User newUser = ParseUserData(user, username, output);
                    output.AppendFormat("Successfully added user {0}", username).AppendLine();

                    foreach (var game in user.Descendants("game"))
                    {
                        var newUserGame = ParseGameData(context, game);
                        newUser.UsersGames.Add(newUserGame);
                        output.AppendFormat("User {0} successfully added to game {1}", username, newUserGame.Game.Name)
                            .AppendLine();
                    }

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Console.WriteLine(output);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static UsersGame ParseGameData(DiabloEntities context, XElement game)
        {
            var gameName = game.Element("game-name").Value;
            var character = game.Element("character");
            var characterName = character.Attribute("name").Value;
            var cash = decimal.Parse(character.Attribute("cash").Value);
            var level = int.Parse(character.Attribute("level").Value);
            var joinedOn = DateTime.ParseExact(game.Element("joined-on").Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var newGame = new UsersGame
            {
                Game = context.Games.First(g => g.Name == gameName),
                Character = context.Characters.First(c => c.Name == characterName),
                Cash = cash,
                Level = level,
                JoinedOn = joinedOn
            };

            return newGame;
        }

        private static User ParseUserData(XElement user, string username, StringBuilder output)
        {
            var isDeleted = int.Parse(user.Attribute("is-deleted").Value);
            var ipAddress = user.Attribute("ip-address").Value;
            var dateString = user.Attribute("registration-date").Value;
            var registrationDate = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string firstName = null;
            string lastName = null;
            string email = null;

            if (user.Attribute("first-name") != null)
            {
                firstName = user.Attribute("first-name").Value;
            }

            if (user.Attribute("last-name") != null)
            {
                lastName = user.Attribute("last-name").Value;
            }

            if (user.Attribute("email") != null)
            {
                email = user.Attribute("email").Value;
            }

            var newUser = new User
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                IpAddress = ipAddress,
                IsDeleted = isDeleted == 1,
                RegistrationDate = registrationDate
            };
            
            return newUser;
        }
    }
}