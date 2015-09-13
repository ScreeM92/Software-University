namespace Football.Data
{
    using System;
    using System.Linq;

    public class FootballMain
    {
        public static void Main()
        {
            var context = new FootballEntities();
            context.Teams.Select(t => t.TeamName).ToList().ForEach(Console.WriteLine);
        }
    }
}
