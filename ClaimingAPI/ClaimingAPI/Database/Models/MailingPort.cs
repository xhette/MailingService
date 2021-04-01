using System;
using System.Collections.Generic;

#nullable disable

namespace ClaimingAPI.Database.Models
{
    public partial class MailingPort
    {
        public MailingPort()
        {
            MessagePortNavigations = new HashSet<Message>();
            MessageStatusNavigations = new HashSet<Message>();
        }

        public int PortId { get; set; }
        public string PortName { get; set; }

        public virtual ICollection<Message> MessagePortNavigations { get; set; }
        public virtual ICollection<Message> MessageStatusNavigations { get; set; }
    }
}
