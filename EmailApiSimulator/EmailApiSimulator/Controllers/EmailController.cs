using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using EmailApiSimulator.Models;

namespace EmailApiSimulator.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmailController : ControllerBase
	{
		private static readonly string[] Emails = new[]
		{
			"test1@gmail.com", "test2@gmail.com","test3@gmail.com","test4@gmail.com","test5@gmail.com","test6@gmail.com",
		};

		[HttpGet]
		public string Get()
		{
			var rng = new Random();
			return Emails[rng.Next(Emails.Length)];
		}

		[HttpPost]
		public SmtpStatusCode Post(EmailModel email)
		{
			Array values = Enum.GetValues(typeof(SmtpStatusCode));
			Random random = new Random();
			SmtpStatusCode randomBar = (SmtpStatusCode)values.GetValue(random.Next(values.Length));

			return randomBar;
		}
	}
}
