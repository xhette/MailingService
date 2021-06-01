using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MailingWeb.ApiClient.DTO
{
	public class MessageFullDTO
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("receiverId")]
		public int ReceiverId { get; set; }

		[JsonPropertyName("status")]
		public int Status { get; set; }

		[JsonPropertyName("statusName")]
		public string StatusName { get; set; }

		[JsonPropertyName("date")]
		public DateTime Date { get; set; }

		[JsonPropertyName("portId")]
		public int PortId { get; set; }

		[JsonPropertyName("portName")]
		public string PortName { get; set; }

		[JsonPropertyName("messageType")]
		public int MessageType { get; set; }

		[JsonPropertyName("template")]
		public string Template { get; set; }
	}
}
