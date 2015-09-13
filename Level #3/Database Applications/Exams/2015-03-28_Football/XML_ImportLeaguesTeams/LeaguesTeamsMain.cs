namespace XML_ImportLeaguesTeams
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Football.Data;

    public class LeaguesTeamsMain
    {
        private const string ImportFilePath = @"..\..\..\Import\leagues-and-teams.xml";

        public static void Main()
        {
            var context = new FootballEntities();

            var doc = XDocument.Load(ImportFilePath);
            var leagues = doc.Descendants("league");

            var i = 1;

            foreach (XElement league in leagues)
            {
               Console.WriteLine("Processing league #{0} ...", i);
                var leagueName = league.Element("league-name");
                League leagueEntity = leagueName != null ? GetLeagueEntity(context, leagueName) : null;

                foreach (XElement team in league.XPathSelectElements("teams/team"))
                {
                    var name = team.Attribute("name").Value;
                    var countryNode = team.Attribute("country");
                    var country = countryNode != null ? countryNode.Value : null;

                    Team teamEntity = GetTeamEntity(context, name, country);

                    if (leagueName != null)
                    {
                        var existingTeam = leagueEntity.Teams.FirstOrDefault(t => t == teamEntity);
                        if (existingTeam == null)
                        {
                            teamEntity.Leagues.Add(leagueEntity);
                            context.SaveChanges();
                            Console.WriteLine("Added team to league: {0} to league {1}", name, leagueName.Value);
                        }
                        else
                        {
                            Console.WriteLine("Existing team in league: {0} belongs to {1}", name, leagueName.Value);
                        }
                    }
                }

                i++;
                Console.WriteLine();
            }
        }

        private static Team GetTeamEntity(FootballEntities context, string name, string country)
        {
            Team teamEntity = context.Teams.FirstOrDefault(t => t.TeamName == name && t.Country.CountryName == country);

            if (teamEntity == null)
            {
                Team newTeamEntity = new Team {TeamName = name, Country = context.Countries.FirstOrDefault(c => c.CountryName == country)};
                context.Teams.Add(newTeamEntity);
                context.SaveChanges();
                Console.WriteLine("Created team: {0} ({1})", name, country ?? "no country");
            }
            else
            {
                Console.WriteLine("Existing team: {0} ({1})", name, country ?? "no country");
            }

            return teamEntity;
        }

        private static League GetLeagueEntity(FootballEntities context, XElement leagueName)
        {
            League leagueEntity = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName.Value);

            if (leagueEntity == null)
            {
                leagueEntity = new League {LeagueName = leagueName.Value};
                context.Leagues.Add(leagueEntity);
                context.SaveChanges();
                Console.WriteLine("Created league: {0}", leagueName.Value);
            }
            else
            {
                Console.WriteLine("Existing league: {0}", leagueName.Value);
            }

            return leagueEntity;
        }
    }
}