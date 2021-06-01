using ClaimingAPI.Database.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimingAPI.DTO
{
	public class PortDTO
	{
		/// <summary>
		/// Id порта рассылки
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название порта рассылки
		/// </summary>
		public string Name { get; set; }

		public static explicit operator PortDTO(MailingPort dbPort)
		{
			if (dbPort == null) return null;
			else
			{
				return new PortDTO
				{
					Id = dbPort.PortId,
					Name = dbPort.PortName
				};
			}
		}

		public static explicit operator MailingPort (PortDTO portDTO)
		{
			if (portDTO == null) return null;
			else
			{
				return new MailingPort
				{
					PortId = portDTO.Id,
					PortName = portDTO.Name
				};
			}
		}
	}
}
