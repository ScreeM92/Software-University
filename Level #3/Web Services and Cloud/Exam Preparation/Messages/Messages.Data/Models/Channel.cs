namespace Messages.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Channel
    {
        private ICollection<ChannelMessage> channelMessages;

        public Channel()
        {
            ChannelMessages = new List<ChannelMessage>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ChannelMessage> ChannelMessages
        {
            get { return this.channelMessages; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }

                this.channelMessages = value;
            }
        }
    }
}
