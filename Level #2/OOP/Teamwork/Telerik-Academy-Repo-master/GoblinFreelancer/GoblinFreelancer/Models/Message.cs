using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinFreelancer.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Body { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public DateTime DateSend { get; set; }

        public virtual Project Project { get; set; }
    }
}