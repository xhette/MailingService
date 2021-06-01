using System;
using System.Collections.Generic;

#nullable disable

namespace ClaimingAPI.Database.Models
{
    public partial class Message
    {
        /// <summary>
        /// Id сообщения в бд
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Id полуателя в бд
        /// </summary>
        public int ReceiverId { get; set; }

        /// <summary>
        /// Id типа сообщения
        /// </summary>
        public int MessageType { get; set; }

        /// <summary>
        /// Id статуса сообщения в бд
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Дата отправления
        /// </summary>
        public DateTime SendingDate { get; set; }

        /// <summary>
        /// Id порта в бд
        /// </summary>
        public int Port { get; set; }

        public virtual MessageType MessageTypeNavigation { get; set; }
        public virtual MailingPort PortNavigation { get; set; }
        public virtual MailingPort StatusNavigation { get; set; }
    }
}
