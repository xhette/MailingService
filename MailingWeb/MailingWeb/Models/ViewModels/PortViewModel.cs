using ApiClient.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingWeb.Models.ViewModels
{
	public class PortViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public static explicit operator PortViewModel(PortDTO dto)
		{
			if (dto == null) return null;
			else return new PortViewModel
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}
	}
}
