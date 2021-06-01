using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimingAPI.DTO
{
	public class MessageFullDTO
	{
		public int Id { get; set; }

		public int ReceiverId { get; set; }

		public int Status { get; set; }

		public string StatusName { get; set; }

		public DateTime Date { get; set; }

		public int PortId { get; set; }

		public string PortName { get; set; }

		public int MessageType { get; set; }

		public string Template { get; set; }
	}
}
