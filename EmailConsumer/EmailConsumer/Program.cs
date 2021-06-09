using System;
using System.Threading.Tasks;

namespace EmailConsumer
{
	class Program
	{
		static async Task Main(string[] args)
		{
			QueueConsumer consumer = new QueueConsumer("messages_exchange", "messages.e-mail");

			await consumer.MessageWaiting();
		}
	}
}
