using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MessageResultConsumer.Models
{
	public class MessageResultModel
	{
		[JsonPropertyName("message_id")]
		public int Id { get; set; }

		[JsonPropertyName("status")]
		public int Status { get; set; }
	}
}
