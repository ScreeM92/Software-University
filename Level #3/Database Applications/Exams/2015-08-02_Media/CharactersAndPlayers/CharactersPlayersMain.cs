namespace CharactersAndPlayers
{
    using System;
    using System.IO;
    using System.Linq;
    using Diablo.Data;
    using Newtonsoft.Json;

    public class CharactersPlayersMain
    {
        private const string ExportPath = @"..\..\..\Export\";
        private const string Filename = "characters.json";

        public static void Main()
        {
            CheckExistingDirectory(ExportPath);
            var context = new DiabloEntities();
            var characters = context.Characters
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Players = context.UsersGames.Where(g => g.CharacterId == c.Id).Select(g => g.User.Username)
                });

            var json = JsonConvert.SerializeObject(characters, Formatting.Indented);

            File.WriteAllText(ExportPath + Filename, json);
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
