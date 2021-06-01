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
            QueueConsumer consumer = new QueueConsumer("messages_exchange", "messages.sms");

            await consumer.MessageWaiting();
        }
    }
}
    
