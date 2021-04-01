using System;
using System.Collections.Generic;

#nullable disable

namespace ClaimingAPI.Database.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int ReceiverId { get; set; }
        public int MessageType { get; set; }
        public int Status { get; set; }
        public DateTime SendingDate { get; set; }
        public int Port { get; set; }

        public virtual MessageType MessageTypeNavigation { get; set; }
        public virtual MailingPort PortNavigation { get; set; }
        public virtual MailingPort StatusNavigation { get; set; }
    }
}
