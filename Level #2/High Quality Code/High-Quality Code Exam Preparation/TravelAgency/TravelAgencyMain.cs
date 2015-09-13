namespace TravelAgency
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class TravelAgencyMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var catalog = new TicketCatalog();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                if (commandLine != string.Empty)
                {
                    commandLine = commandLine.Trim();
                    string commandResult = catalog.ParseCommand(commandLine);
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}