namespace Messages.Data.Models
{
    using System;

    public class ChannelMessage
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public int SenderId { get; set; }

        public virtual User Sender { get; set; }
    }
}
