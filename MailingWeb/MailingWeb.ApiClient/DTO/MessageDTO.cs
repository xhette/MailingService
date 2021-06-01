using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiClient.DTO
{
	public class MessageDTO
	{
		[JsonPropertyName("receiverId")]
		public int ReceiverId { get; set; }


		[JsonPropertyName("port")]
		public int Port { get; set; }


		[JsonPropertyName("type")]
		public int Type { get; set; }

		[JsonPropertyName("sendingDate")]
		public DateTime Date { get; set; }

	}
}
