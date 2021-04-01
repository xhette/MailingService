using System;
using System.Collections.Generic;

#nullable disable

namespace ClaimingAPI.Database.Models
{
    public partial class MessageType
    {
        public MessageType()
        {
            Messages = new HashSet<Message>();
        }

        public int MessageTypeId { get; set; }
        public string MessageTemplate { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
