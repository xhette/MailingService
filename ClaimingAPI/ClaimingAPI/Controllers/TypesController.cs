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
	public class TypesController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TypeDTO>>> Get()
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					return await serviceDbContext.MessageTypes.Select(c => (TypeDTO)c).ToListAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TypeDTO>> Get(int id)
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					return await serviceDbContext.MessageTypes.Where(c => c.MessageTypeId == id).Select(c => ((TypeDTO)c)).FirstOrDefaultAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpPost]
		public async Task<ActionResult<MessageStatus>> Post(TypeDTO type)
		{
			MessageType typeDb = (MessageType)type;

			if (typeDb == null)
			{
				return BadRequest();
			}

			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					serviceDbContext.MessageTypes.Add(typeDb);
					await serviceDbContext.SaveChangesAsync();

					return Ok(typeDb);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<MessageType>> Put(int id, TypeDTO type)
		{
			MessageType typeDb = (MessageType)type;

			if (typeDb == null)
			{
				return BadRequest();
			}

			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					var typeDbLast = await serviceDbContext.MessageTypes.FindAsync(id);
					typeDbLast.MessageTemplate = type.Template;

					await serviceDbContext.SaveChangesAsync();

					return Ok(typeDbLast);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<MessageType>> Delete(int id)
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					var type = await serviceDbContext.MessageTypes.FindAsync(id);
					serviceDbContext.MessageTypes.Remove(type);
					await serviceDbContext.SaveChangesAsync();

					return Ok(type);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}
	}
}
