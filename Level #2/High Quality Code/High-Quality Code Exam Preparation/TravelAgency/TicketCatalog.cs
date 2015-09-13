namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using TravelAgency.Tickets;
    using TravelAgency.Utilities;
    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private Dictionary<string, Ticket> ticketsByUniqueKey =
            new Dictionary<string, Ticket>();

        private MultiDictionary<string, Ticket> ticketsByFromToKey =
            new MultiDictionary<string, Ticket>(true);

        private OrderedMultiDictionary<DateTime, Ticket> ticketsByDepartureTime =
            new OrderedMultiDictionary<DateTime, Ticket>(true);

        private Dictionary<TicketType, int> ticketsCount =
            new Dictionary<TicketType, int>();

        public TicketCatalog()
        {
            this.ticketsCount[TicketType.Air] = 0;
            this.ticketsCount[TicketType.Train] = 0;
            this.ticketsCount[TicketType.Bus] = 0;
        }

        public int GetTicketsCount(TicketType type)
        {
            if (!this.ticketsCount.ContainsKey(type))
            {
                throw new InvalidOperationException("Invalid ticket type");
            }
            else
            {
                return this.ticketsCount[type];
            }
        }

        [ExcludeFromCodeCoverage]
        public string ParseCommand(string line)
        {
            string[] commandParts = CommandUtilities.ParseCommandWithParameters(line);
            string commandName = commandParts[0];
            string[] commandParameters = new string[commandParts.Length - 1];
            for (int i = 1; i < commandParts.Length; i++)
            {
                commandParameters[i - 1] = commandParts[i];
            }

            string commandResult = "Invalid command!";
            switch (commandName)
            {
                case "AddAir":
                    commandResult = this.AddAirTicket(
                        flightNumber: commandParameters[0],
                        from: commandParameters[1],
                        to: commandParameters[2],
                        airline: commandParameters[3],
                        dateTime: Parser.ParseDateTime(commandParameters[4]),
                        price: decimal.Parse(commandParameters[5]));
                    break;
                case "DeleteAir":
                    commandResult = this.DeleteAirTicket(
                        commandParameters[0]);
                    break;
                case "AddTrain":
                    commandResult = this.AddTrainTicket(
                        commandParameters[0],
                        commandParameters[1],
                        Parser.ParseDateTime(commandParameters[2]),
                        decimal.Parse(commandParameters[3]),
                        decimal.Parse(commandParameters[4]));
                    break;
                case "DeleteTrain":
                    commandResult = this.DeleteTrainTicket(
                        commandParameters[0],
                        commandParameters[1],
                        Parser.ParseDateTime(commandParameters[2]));
                    break;
                case "AddBus":
                    commandResult = this.AddBusTicket(
                        commandParameters[0],
                        commandParameters[1],
                        commandParameters[2],
                        Parser.ParseDateTime(commandParameters[3]),
                        decimal.Parse(commandParameters[4]));
                    break;
                case "DeleteBus":
                    commandResult = this.DeleteBusTicket(
                        commandParameters[0],
                        commandParameters[1],
                        commandParameters[2],
                        Parser.ParseDateTime(commandParameters[3]));
                    break;
                case "FindTickets":
                    commandResult = this.FindTickets(
                        commandParameters[0],
                        commandParameters[1]);
                    break;
                case "FindTicketsInInterval":
                    commandResult = this.FindTicketsInInterval(
                        Parser.ParseDateTime(commandParameters[0]),
                        Parser.ParseDateTime(commandParameters[1]));
                    break;
            }

            return commandResult;
        }

        public string AddAirTicket(
            string flightNumber,
            string from,
            string to,
            string airline,
            DateTime dateTime,
            decimal price)
        {
            var ticket = new AirTicket(
                flightNumber,
                from,
                to,
                airline,
                dateTime,
                price);
            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            var ticket = new AirTicket(flightNumber);
            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string AddTrainTicket(
            string from,
            string to,
            DateTime dateAndTime,
            decimal price,
            decimal studentPrice)
        {
            var ticket = new TrainTicket(from, to, dateAndTime, price, studentPrice);
            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateAndTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime);
            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string AddBusTicket(
            string from,
            string to,
            string company,
            DateTime dateAndTime,
            decimal price)
        {
            BusTicket ticket = new BusTicket(from, to, company, dateAndTime, price);
            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteBusTicket(
            string from,
            string to,
            string company,
            DateTime dateAndTime)
        {
            BusTicket ticket = new BusTicket(from, to, company, dateAndTime);
            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = Ticket.CreateFromToKey(from, to);
            if (this.ticketsByFromToKey.ContainsKey(fromToKey))
            {
                string ticketsAsString = this.FormatTicketsForPrinting(this.ticketsByFromToKey[fromToKey]);
                return ticketsAsString;
            }
            else
            {
                return "Not found";
            }
        }

        public string FindTicketsInInterval(
            DateTime startDateTime,
            DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDepartureTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = this.FormatTicketsForPrinting(ticketsFound);
                return ticketsAsString;
            }
            else
            {
                return "Not found";
            }
        }

        private string AddTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;
            if (this.ticketsByUniqueKey.ContainsKey(key))
            {
                return "Duplicate ticket";
            }
            else
            {
                this.ticketsByUniqueKey.Add(
                    key,
                    ticket);
                string fromToKey = ticket.FromToKey;
                this.ticketsByFromToKey.Add(
                    fromToKey,
                    ticket);
                this.ticketsByDepartureTime.Add(
                    ticket.DateAndTime,
                    ticket);
                this.ticketsCount[ticket.Type]++;
                return "Ticket added";
            }
        }

        private string DeleteTicketByUniqueKey(string uniqueKey)
        {
            if (this.ticketsByUniqueKey.ContainsKey(uniqueKey))
            {
                var ticket = this.ticketsByUniqueKey[uniqueKey];
                this.ticketsByUniqueKey.Remove(uniqueKey);

                string fromToKey = ticket.FromToKey;
                this.ticketsByFromToKey.Remove(fromToKey, ticket);
                this.ticketsByDepartureTime.Remove(ticket.DateAndTime, ticket);
                this.ticketsCount[ticket.Type]--;
                return "Ticket deleted";
            }
            else
            {
                return "Ticket does not exist";
            }
        }

        private string FormatTicketsForPrinting(ICollection<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);
            sortedTickets.Sort();
            string result = string.Join(
                " ",
                sortedTickets.Select(t => t.ToString()));
            return result;
        }
    }
}