using System;
using System.Threading.Tasks;

namespace MessageResultConsumer
{
	class Program
	{
		static async Task Main(string[] args)
		{
			RabbitMqConsumer consumer = new RabbitMqConsumer();
			await consumer.MessageWaiting();
		}
	}
}
