using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingWeb.Models.ViewModels
{
	public class SendMessageResponseModel
	{
		public string[] SelectedPorts { get; set; }
		
		public string[] SelectedStudents { get; set; }

		public string MessageTemplate { get; set; }
	}
}
