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
	public class PortsController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<PortDTO>>> Get()
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					return await serviceDbContext.MailingPorts.Select(c => (PortDTO)c).ToListAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PortDTO>> Get(int id)
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					return await serviceDbContext.MailingPorts.Where(c => c.PortId == id).Select(c => ((PortDTO)c)).FirstOrDefaultAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpPost]
		public async Task<ActionResult<MailingPort>> Post(PortDTO port)
		{
			MailingPort mailingPort = (MailingPort)port;

			if (mailingPort == null)
			{
				return BadRequest();
			}

			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					serviceDbContext.MailingPorts.Add(mailingPort);
					await serviceDbContext.SaveChangesAsync();

					return Ok(mailingPort);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<MailingPort>> Put(int id, PortDTO port)
		{
			MailingPort message = (MailingPort)port;

			if (message == null)
			{
				return BadRequest();
			}

			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					var mailingPort = await serviceDbContext.MailingPorts.FindAsync(id);
					mailingPort.PortName = port.Name;

					await serviceDbContext.SaveChangesAsync();

					return Ok(mailingPort);
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
					var mailingPort = await serviceDbContext.MailingPorts.FindAsync(id);
					serviceDbContext.MailingPorts.Remove(mailingPort);
					await serviceDbContext.SaveChangesAsync();

					return Ok(mailingPort);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}
	}
}
