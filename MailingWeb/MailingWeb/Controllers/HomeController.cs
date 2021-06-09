using ApiClient.DTO;

using MailingWeb.ApiClient;
using MailingWeb.Models;
using MailingWeb.Models.Data;
using MailingWeb.Models.ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MailingWeb.Controllers
{
	public class HomeController : Controller
	{
		List<StudentViewModel> students;

		private readonly ILogger<HomeController> _logger;
		private MailingClient _mailingClient;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			_mailingClient = new MailingClient("https://localhost:44371/");

			students = new List<StudentViewModel>
			{
				new StudentViewModel {Id = 0, Surname = "Иванов", Name = "Иван", Patronymic = "Иванович"},
				new StudentViewModel {Id = 1, Surname = "Борисов", Name = "Борис", Patronymic = "Борисович"},
				new StudentViewModel {Id = 2, Surname = "Сергеев", Name = "Сергей", Patronymic = "Сергеевич"},
				new StudentViewModel {Id = 3, Surname = "Белов", Name = "Бел", Patronymic = "Белыч"},
			};
		}

		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var messages = _mailingClient.GetMessages();

				var messagesView = from c in messages
				   join s in students
				   on c.ReceiverId equals s.Id
				   select new MessagesViewModel
				   {
					   Id = c.Id,
					   PortId = c.PortId,
					   PortName = c.PortName,
					   Date = c.Date,
					   ReceiverId = c.ReceiverId,
					   Surname = s.Surname,
					   Name = s.Name,
					   Patronymic = s.Patronymic,
					   Status = c.Status,
					   StatusName = c.StatusName,
					   Template = c.Template,
					   MessageType = c.MessageType

				   };

				List<MessagesViewModel> model = messagesView.ToList();

				return View(model);
			}
			else
			{
				return RedirectToAction("Login", "Account");
			}
		}

		[HttpGet]
		public IActionResult SendMessage()
		{
			SendMessageModel model = new SendMessageModel();
			model.Students = new SelectList(students, "Id", "FullName");
			model.Date = DateTime.Today;

			var ports = _mailingClient.GetPorts();
			var types = _mailingClient.GetTypes();

			model.Ports = ports.Select(c => (PortViewModel)c).ToList();
			model.Types = new SelectList(types, "Id", "Template");

			return View(model);
		}

		[Route("Home/SendMessage")]
		[HttpPost]
		public IActionResult SendMessage([FromBody] SendMessageResponseModel responseModel)
		{
			List<int> selectedPorts = new List<int>();
			List<int> selectedStudents = new List<int>();
			int messageType = 0;

			if (int.TryParse(responseModel.MessageTemplate, out messageType))
			{
				for (int i = 0; i < responseModel.SelectedPorts.Length; i++)
				{
					int portId = 0;

					if (int.TryParse(responseModel.SelectedPorts[i], out portId))
					{
						selectedPorts.Add(portId);
					}
				}

				for (int i = 0; i < responseModel.SelectedStudents.Length; i++)
				{
					int studentId = 0;

					if (int.TryParse(responseModel.SelectedStudents[i], out studentId))
					{
						selectedStudents.Add(studentId);
					}
				}

				foreach (var port in selectedPorts)
				{
					foreach (var student in selectedStudents)
					{
						_mailingClient.PostMessage(new MessageDTO
						{
							Date = DateTime.Today,
							Port = port,
							ReceiverId = student,
							Type = messageType
						});
					}
				}

				return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
			}

			ModelState.AddModelError("", "Ошибка при выборе шаблона");
			return View(responseModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
