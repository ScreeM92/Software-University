namespace TravelAgency
{
    using System;
    using TravelAgency.Tickets;

    public interface ITicketCatalog
    {
        /// <summary>
        /// Adds an air ticket with the specified properties to the ticket database.
        /// </summary>
        /// <param name="flightNumber">The flight number of the ticket</param>
        /// <param name="from">The starting airport of the ticket</param>
        /// <param name="to">The destination airport of the ticket</param>
        /// <param name="airline">The airline of the ticket</param>
        /// <param name="dateTime">The departure date and time of the ticket</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>Returns a success message ("Ticket added") if the ticket
        /// has been added successfully added, and an error message ("Duplicate ticket")
        /// if the ticket already exists.</returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        // TODO: document this method
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        // TODO: document this method
        string FindTickets(string from, string to);

        // TODO: document this method
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}
