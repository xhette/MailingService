using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Text;
using System.Threading.Tasks;

namespace SMSConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                HostName = "localhost",
                DispatchConsumersAsync = true
            };

            using (var connection = factory.CreateConnection())
            {

                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "messages_exchange", type: "topic", true);
                    var queueName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queue: queueName,
                                 exchange: "messages_exchange",
                                 routingKey: "messages.sms");

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
    }
