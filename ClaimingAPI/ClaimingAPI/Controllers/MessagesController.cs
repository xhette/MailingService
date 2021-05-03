using ClaimingAPI.Database;
using ClaimingAPI.Database.Models;
using ClaimingAPI.DTO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClaimingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		// GET: api/<MessagesController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MessageDTO>>> Get()
		{
			using(MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				return await serviceDbContext.Messages.Select(c => (MessageDTO)c).ToListAsync();
			}
		}

		//// GET api/<MessagesController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		// POST api/<MessagesController>
		[HttpPost]
		public async Task<ActionResult<Message>> Post(MessageDTO messageRequest)
		{
			Message message = (Message)messageRequest;

			if (message == null)
			{
				return BadRequest();
			}

			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					serviceDbContext.Messages.Add(message);
					await serviceDbContext.SaveChangesAsync();

					return Ok(message);
				}
				catch (Exception ex) 
				{
					return BadRequest(ex.Message);
				}
			}
		}

		//// PUT api/<MessagesController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<MessagesController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
