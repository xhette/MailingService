using MessageResultConsumer.Models;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessageResultConsumer
{
	class RabbitMqConsumer
	{
		private IConnection _connection;
		DbApiClient _dbClient;

		public RabbitMqConsumer()
		{
			var factory = new ConnectionFactory()
			{
				UserName = "guest",
				Password = "guest",
				VirtualHost = "/",
				HostName = "localhost",
				DispatchConsumersAsync = true
			};

			_connection = factory.CreateConnection();
			_dbClient = new DbApiClient("https://localhost:44371/");
		}

		public async Task MessageWaiting()
		{
			using (var channel = _connection.CreateModel())
			{
				channel.ExchangeDeclare(exchange: "messages_result", type: "direct", true);
				var queueName = channel.QueueDeclare().QueueName;

				channel.QueueBind(queue: queueName,
							 exchange: "messages_result",
							 routingKey: "messages_result");

				var consumer = new AsyncEventingBasicConsumer(channel);

				channel.BasicConsume(queueName,
									 autoAck: true,
									 consumer: consumer);

				consumer.Received += async (o, a) =>
				{
					string queueResult = Encoding.UTF8.GetString(a.Body.ToArray());
					Console.WriteLine(Encoding.UTF8.GetString(a.Body.ToArray()));

					MessageResultModel messageResult = JsonSerializer.Deserialize<MessageResultModel>(queueResult);

					_dbClient.PostChanges(messageResult.Id, messageResult.Status);

					await Task.Yield();
				};

				while (true)
				{
					await Task.Delay(1000);
				}
			}
		}
	}
}
