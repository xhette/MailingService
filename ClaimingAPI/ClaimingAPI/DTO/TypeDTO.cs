using ClaimingAPI.Database.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimingAPI.DTO
{
	public class TypeDTO
	{
		public int Id { get; set; }

		public string Template { get; set; }

		public static explicit operator TypeDTO (MessageType dbType)
		{
			if (dbType == null) return null;
			else return new TypeDTO
			{
				Id = dbType.MessageTypeId,
				Template = dbType.MessageTemplate
			};
		}

		public static explicit operator MessageType(TypeDTO typeDTO)
		{
			if (typeDTO == null) return null;
			else return new MessageType
			{
				MessageTypeId = typeDTO.Id,
				MessageTemplate = typeDTO.Template
			};
		}
	}
}
