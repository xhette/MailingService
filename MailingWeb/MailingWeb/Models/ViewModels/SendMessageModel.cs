using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailingWeb.Models.ViewModels
{
	public class SendMessageModel
	{
		public SelectList Students { get; set; }

		public SelectList Types { get; set; }

		public List<PortViewModel> Ports { get; set; }

		[Required(ErrorMessage ="Необходимо выбрать хотя бы одного студента")]
		public List<string> SelectedStudents { get; set; }

		public int TemplateId { get; set; }

		[Required(ErrorMessage = "Необходимо выбрать хотя бы один канал")]
		public List<int> SelectedPorts { get; set; }

		public DateTime Date { get; set; }
	}
}
