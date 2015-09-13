namespace TravelAgency.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string company, DateTime dateAndTime, decimal price)
            : base(TicketType.Bus, from, to, dateAndTime, price)
        {
            this.Company = company;
        }

        public BusTicket(string from, string to, string company, DateTime dateAndTime)
            : this(from, to, company, dateAndTime, 0M)
        {
        }

        public string Company { get; private set; }

        public override string UniqueKey
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" +
                    this.Company + this.DateAndTime + ";";
            }
        }
    }
}
