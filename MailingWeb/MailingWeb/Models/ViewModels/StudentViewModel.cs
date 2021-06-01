using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingWeb.Models.ViewModels
{
	public class StudentViewModel
	{
		public int Id { get; set; }
		public string Surname { get; set; }

		public string Name { get; set; }

		public string Patronymic { get; set; }

		public string FullName
		{
			get
			{
				return String.Format("{0} {1} {2}", Surname, Name, Patronymic);
			}
		}
	}
}
