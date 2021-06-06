using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SmsServiceSimulator.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsServiceSimulator.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SmsController : ControllerBase
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
		public SmsResultEnum Post(SmsModel sms)
		{
			var rng = new Random();
			return (SmsResultEnum)rng.Next(6);
		}
	}
}
