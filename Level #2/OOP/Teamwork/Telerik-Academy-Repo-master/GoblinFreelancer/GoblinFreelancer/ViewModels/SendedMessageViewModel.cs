using GoblinFreelancer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GoblinFreelancer.ViewModels
{
    public class SendedMessageViewModel
    {
        public static Func<Message, SendedMessageViewModel> FromMessage
        {
            get 
            {
                return message => new SendedMessageViewModel()
                {
                    SenderName = message.Sender.UserName,
                    PostDate = message.DateSend.ToShortTimeString() +
                                "-" + new DateTimeFormatInfo().GetAbbreviatedMonthName(message.DateSend.Month) +
                                "," + message.DateSend.Day,
                    Message = message.Body
                };
            }
        }
        public string SenderName { get; set; }
        public string PostDate { get; set; }
        public string Message { get; set; }
    }
}