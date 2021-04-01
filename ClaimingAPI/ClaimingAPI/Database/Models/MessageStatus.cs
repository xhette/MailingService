using System;
using System.Collections.Generic;

#nullable disable

namespace ClaimingAPI.Database.Models
{
    public partial class MessageStatus
    {
        public int MessageStatusId { get; set; }
        public string StatusName { get; set; }
    }
}
