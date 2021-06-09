using System;
using System.Threading.Tasks;

namespace TelegramConsumer
{
	class Program
	{
		static async Task Main(string[] args)
		{
			QueueConsumer consumer = new QueueConsumer("messages_exchange", "messages.telegram");

			await consumer.MessageWaiting();
		}
	}
}
