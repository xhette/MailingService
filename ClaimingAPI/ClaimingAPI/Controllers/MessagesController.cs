using ClaimingAPI.Database;
using ClaimingAPI.Database.Models;
using ClaimingAPI.DTO;

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
	public class MessagesController : ControllerBase
	{
		// GET: api/<MessagesController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MessageFullDTO>>> Get()
		{
			using(MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					//return await serviceDbContext.Messages.Select(c => (MessageDTO)c).ToListAsync();
					var result = from message in serviceDbContext.Messages
								 join status in serviceDbContext.MessageStatuses
								 on message.Status equals status.MessageStatusId
								 join port in serviceDbContext.MailingPorts
								 on message.Port equals port.PortId
								 join type in serviceDbContext.MessageTypes
								 on message.MessageType equals type.MessageTypeId
								 select new MessageFullDTO
								 {
									 Id = message.MessageId,
									 ReceiverId = message.ReceiverId,
									 Date = message.SendingDate,
									 MessageType = message.MessageType,
									 Template = type.MessageTemplate,
									 PortId = port.PortId,
									 PortName = port.PortName,
									 Status = status.MessageStatusId,
									 StatusName = status.StatusName
								 };

					return await result.ToListAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		//// GET api/<MessagesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MessageDTO>> Get(int id)
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					return await serviceDbContext.Messages.Where(c => c.MessageId == id).Select(c => ((MessageDTO)c)).FirstOrDefaultAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

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
		[HttpPut("{id}")]
		public async Task<ActionResult<Message>> Put(int id, MessageDTO messageRequest)
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
					var dbMessage = await serviceDbContext.Messages.FindAsync(id);

					dbMessage.ReceiverId = messageRequest.ReceiverId;
					dbMessage.SendingDate = messageRequest.SendingDate;
					dbMessage.Status = messageRequest.Status;
					dbMessage.Port = messageRequest.Port;
					dbMessage.MessageType = messageRequest.Type;

					await serviceDbContext.SaveChangesAsync();

					return Ok(message);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}

		//// DELETE api/<MessagesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Message>> Delete(int id)
		{
			using (MailingServiceDbContext serviceDbContext = new MailingServiceDbContext())
			{
				try
				{
					var message = await serviceDbContext.Messages.FindAsync(id);
					serviceDbContext.Messages.Remove(message);
					await serviceDbContext.SaveChangesAsync();

					return Ok(message);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
		}
	}
}
