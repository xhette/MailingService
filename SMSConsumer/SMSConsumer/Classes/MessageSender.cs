using RabbitMQ.Client;

using SMSConsumer.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SMSConsumer
{
	public class MessageSender
	{
		private ApiConsumer _apiConsumer;

		public MessageSender (string apiUri, string controllerName)
		{
			_apiConsumer = new ApiConsumer(apiUri, controllerName);
		}

		public void SendMessage(string message)
		{
			MessageModel messageModel = JsonSerializer.Deserialize<MessageModel>(message);
			SMSResultEnum resultEnum;

			string phone = _apiConsumer.GetPhone(messageModel.ReceiverId);

			if (!String.IsNullOrEmpty(phone))
			{
				SmsModel sms = new SmsModel
				{
					Phone = phone,
					Text = messageModel.Template
				};

				resultEnum = _apiConsumer.PostMessage(sms);
			}
			else
			{
				resultEnum = SMSResultEnum.Error;
			}


			int resultDbCode = 0;

			switch (resultEnum)
			{
				case SMSResultEnum.Delivered: resultDbCode = 1;
					break;
				case SMSResultEnum.Expired: resultDbCode = 3;
					break;
				case SMSResultEnum.NotDelivered: resultDbCode = 3;
					break;
				case SMSResultEnum.Unknown: resultDbCode = 4;
					break;
				case SMSResultEnum.Error: resultDbCode = 4;
					break;
				default: break;
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
