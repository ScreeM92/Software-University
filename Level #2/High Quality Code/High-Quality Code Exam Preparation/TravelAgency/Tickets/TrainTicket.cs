namespace TravelAgency.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, DateTime dateAndTime, decimal price, decimal studentPrice)
            : base(TicketType.Train, from, to, dateAndTime, price)
        {
            this.StudentPrice = studentPrice;
        }

        public TrainTicket(string from, string to, DateTime dateAndTime)
            : this(from, to, dateAndTime, 0M, 0M)
        {
        }

        public decimal StudentPrice { get; set; }

        public override string UniqueKey
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
            }
        }
    }
}
