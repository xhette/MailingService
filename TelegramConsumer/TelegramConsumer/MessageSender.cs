using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using TelegramConsumer.Models;

namespace TelegramConsumer
{
	public class MessageSender
	{
		private ApiConsumer _apiConsumer;

		public MessageSender(string apiUri, string controllerName)
		{
			_apiConsumer = new ApiConsumer(apiUri, controllerName);
		}

		public void SendMessage(string message)
		{
			MessageModel messageModel = JsonSerializer.Deserialize<MessageModel>(message);
			int resultEnum;

			string phone = _apiConsumer.GetPhone(messageModel.ReceiverId);

			if (!String.IsNullOrEmpty(phone))
			{
				TelegramMsgModel sms = new TelegramMsgModel
				{
					Phone = phone,
					Text = messageModel.Template
				};

				resultEnum = _apiConsumer.PostMessage(sms);
			}
			else
			{
				resultEnum = 500;
			}


			int resultDbCode = 0;

			if (resultEnum > 200 && resultEnum < 300)
			{
				resultDbCode = 1;
			}
			else if (resultEnum > 400 && resultEnum < 500)
			{
				resultDbCode = 3;
			}
			else if (resultEnum > 500)
			{
				resultDbCode = 4;
			}
			else
			{
				resultDbCode = 4;
			}


			MessageResultModel resultModel = new MessageResultModel
			{
				Id = messageModel.Id,
				Status = resultDbCode
			};

			ConnectionFactory factory = new ConnectionFactory
			{
				UserName = "guest",
				Password = "guest",
				VirtualHost = "/",
				HostName = "localhost"
			};

			string result = JsonSerializer.Serialize<MessageResultModel>(resultModel);

			var rabbitConnection = factory.CreateConnection();

			IModel model = rabbitConnection.CreateModel();
			model.ExchangeDeclare("messages_result", ExchangeType.Direct, true);

			byte[] messageBodyBytes = Encoding.UTF8.GetBytes(result);

			model.BasicPublish("messages_result", "messages_result", null, messageBodyBytes);
		}
	}
}
