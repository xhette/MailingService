using ClaimingAPI.Database.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimingAPI.DTO
{
	public class StatusDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public static explicit operator StatusDTO (MessageStatus dbStatus)
		{
			if (dbStatus == null) return null;
			else
			{
				return new StatusDTO
				{
					Id = dbStatus.MessageStatusId,
					Name = dbStatus.StatusName
				};
			}
		}

		public static explicit operator MessageStatus (StatusDTO statusDTO)
		{
			if (statusDTO == null) return null;
			else return new MessageStatus
			{
				MessageStatusId = statusDTO.Id,
				StatusName = statusDTO.Name
			};
		}
	}
}
