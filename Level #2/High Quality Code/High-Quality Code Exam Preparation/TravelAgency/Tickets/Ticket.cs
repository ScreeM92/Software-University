namespace TravelAgency.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelAgency.Utilities;

    public abstract class Ticket : IComparable<Ticket>
    {
        public Ticket(
            TicketType type,
            string from,
            string to,
            DateTime dateAndTime,
            decimal price)
        {
            // TODO: Add validations if needed
            this.Type = type;
            this.From = from;
            this.To = to;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public TicketType Type { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public DateTime DateAndTime { get; private set; }

        public decimal Price { get; private set; }

        public abstract string UniqueKey { get; }

        public string FromToKey
        {
            get
            {
                return CreateFromToKey(this.From, this.To);
            }
        }

        public static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }

        public int CompareTo(Ticket otherTicket)
        {
            int comparisonResult = this.DateAndTime.CompareTo(otherTicket.DateAndTime);

            if (comparisonResult == 0)
            {
                comparisonResult = this.Type.CompareTo(otherTicket.Type);
            }

            if (comparisonResult == 0)
            {
                comparisonResult = this.Price.CompareTo(otherTicket.Price);
            }

            return comparisonResult;
        }

        public override string ToString()
        {
            string ticket =
                "[" + this.DateAndTime.ToDefaultDateTimeString() + "; "
                + this.Type.ToString().ToLower() + "; "
                + this.Price.ToDefaultPriceString() + "]";
            return ticket;
        }
    }
}
