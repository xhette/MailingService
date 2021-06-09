using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TelegramApiSimulator.Models;

namespace TelegramApiSimulator.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TelegramController : ControllerBase
	{
		private static readonly string[] Phones = new[]
		{
			"+79284567898", "+79184563214", "+79285496321", "+79638521474", "+79652356352", "+72568596365", "+79284731562"
		};

		[HttpGet]
		public string Get()
		{
			var rng = new Random();
			return Phones[rng.Next(Phones.Length)];
		}

		[HttpPost]
		public TgStatusEnum Post(TelegramMsgModel sms)
		{
			Array values = Enum.GetValues(typeof(TgStatusEnum));
			Random random = new Random();
			TgStatusEnum randomBar = (TgStatusEnum)values.GetValue(random.Next(values.Length));

			return randomBar;
		}
	}
}
