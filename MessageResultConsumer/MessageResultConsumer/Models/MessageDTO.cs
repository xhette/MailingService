using System;
using System.Collections.Generic;
using System.Text;

namespace MessageResultConsumer.Models
{
	public class MessageDTO
	{
		public int Id { get; set; }

		public int ReceiverId { get; set; }

		public int Status { get; set; }

		public int Type { get; set; }

		public DateTime SendingDate { get; set; }

		public int Port { get; set; }
	}
}
