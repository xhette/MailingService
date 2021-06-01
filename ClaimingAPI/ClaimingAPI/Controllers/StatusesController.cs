using ClaimingAPI.Database;
using ClaimingAPI.Database.Models;
using ClaimingAPI.DTO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatusesController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<StatusDTO>>> Get()
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					return await serviceDbContext.MessageStatuses.Select(c => (StatusDTO)c).ToListAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<StatusDTO>> Get(int id)
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					return await serviceDbContext.MessageStatuses.Where(c => c.MessageStatusId == id).Select(c => ((StatusDTO)c)).FirstOrDefaultAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpPost]
		public async Task<ActionResult<MessageStatus>> Post(StatusDTO status)
		{
			MessageStatus statusDb = (MessageStatus)status;

			if (statusDb == null)
			{
				return BadRequest();
			}

			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					serviceDbContext.MessageStatuses.Add(statusDb);
					await serviceDbContext.SaveChangesAsync();

					return Ok(statusDb);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<MessageStatus>> Put(int id, StatusDTO status)
		{
			MessageStatus statusDb = (MessageStatus)status;

			if (statusDb == null)
			{
				return BadRequest();
			}

			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					var statusDbLast = await serviceDbContext.MessageStatuses.FindAsync(id);
					statusDbLast.StatusName = status.Name;

					await serviceDbContext.SaveChangesAsync();

					return Ok(statusDbLast);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Message>> Delete(int id)
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					var status = await serviceDbContext.MessageStatuses.FindAsync(id);
					serviceDbContext.MessageStatuses.Remove(status);
					await serviceDbContext.SaveChangesAsync();

					return Ok(status);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}
	}
}
