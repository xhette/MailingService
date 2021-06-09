using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EmailConsumer.Models
{
	public class MessageModel
	{
		[JsonPropertyName("message_id")]
		public int Id { get; set; }

		[JsonPropertyName("receiver_id")]
		public int ReceiverId { get; set; }

		[JsonPropertyName("status")]
		public int Status { get; set; }

		[JsonPropertyName("sending_date")]
		public DateTime Date { get; set; }

		[JsonPropertyName("port")]
		public int PortId { get; set; }

		[JsonPropertyName("port_name")]
		public string PortName { get; set; }

		[JsonPropertyName("message_type")]
		public int MessageType { get; set; }

		[JsonPropertyName("message_template")]
		public string Template { get; set; }
	}
}
