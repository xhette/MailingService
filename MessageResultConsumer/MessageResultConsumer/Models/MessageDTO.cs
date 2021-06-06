using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MessageResultConsumer.Models
{
	public class MessageDTO
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("receiverId")]
		public int ReceiverId { get; set; }

		[JsonPropertyName("status")]
		public int Status { get; set; }

		[JsonPropertyName("type")]
		public int Type { get; set; }

		[JsonPropertyName("sendingDate")]
		public DateTime SendingDate { get; set; }

		[JsonPropertyName("port")]
		public int Port { get; set; }
	}
}
