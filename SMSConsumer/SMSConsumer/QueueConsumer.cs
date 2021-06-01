using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMSConsumer
{
	public class QueueConsumer
	{
		private IConnection _connection;
		string _exchangeName;
		string _routingKey;

		public QueueConsumer(string exchangeName, string routingKey)
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

			_exchangeName = exchangeName;
			_routingKey = routingKey;
		}

		public async Task MessageWaiting()
		{
			using (var channel = _connection.CreateModel())
			{
				channel.ExchangeDeclare(exchange: _exchangeName, type: "topic", true);
				var queueName = channel.QueueDeclare().QueueName;

				channel.QueueBind(queue: queueName,
							 exchange: _exchangeName,
							 routingKey: _routingKey);

				var consumer = new AsyncEventingBasicConsumer(channel);

				channel.BasicConsume(queueName,
									 autoAck: true,
									 consumer: consumer);

				consumer.Received += async (o, a) =>
				{
					Console.WriteLine(Encoding.UTF8.GetString(a.Body.ToArray()));
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
