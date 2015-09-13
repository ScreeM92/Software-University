namespace TravelAgency.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AirTicket : Ticket
    {
        public AirTicket(
            string flightNumber,
            string from,
            string to,
            string airline,
            DateTime dateAndTime,
            decimal price)
            : base(
                TicketType.Air,
                from,
                to,
                dateAndTime,
                price)
        {
            this.FlightNumber = flightNumber;
            this.Airline = airline;
        }

        public AirTicket(string flightNumber)
            : this(flightNumber, null, null, null, default(DateTime), 0M)
        {
        }

        public string FlightNumber { get; private set; }

        public string Airline { get; private set; }

        public override string UniqueKey
        {
            get
            {
                return this.Type + ";;" + this.FlightNumber;
            }
        }
    }
}
