using ClaimingAPI.Database.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimingAPI.DTO
{
	public class MessageDTO
	{
		public int Id { get; set; }

		public int ReceiverId { get; set; }

		public int Status { get; set; }

		public int Type { get; set; }

		public DateTime SendingDate { get; set; }

		public int Port { get; set; }

		public static explicit operator MessageDTO(Message dbMessage)
		{
			if (dbMessage == null) return null;
			else
			{
				return new MessageDTO
				{
					Id = dbMessage.MessageId,
					ReceiverId = dbMessage.ReceiverId,
					Type = dbMessage.MessageType,
					Port = dbMessage.Port,
					SendingDate = dbMessage.SendingDate,
					Status = dbMessage.Status
				};
			}
		}

		public static explicit operator Message(MessageDTO messageDTO)
		{
			if (messageDTO == null) return null;
			else
			{
				return new Message
				{
					MessageId = messageDTO.Id,
					MessageType = messageDTO.Type,
					SendingDate = messageDTO.SendingDate,
					Port = messageDTO.Port,
					ReceiverId = messageDTO.ReceiverId,
					Status = messageDTO.Status
				};
			}
		}
	}
}
