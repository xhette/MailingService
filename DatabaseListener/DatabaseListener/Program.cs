using DatabaseListener.Classes;

using Npgsql;

using System;
using System.Threading.Tasks;

namespace DatabaseListener
{
	class Program
	{
		static async Task Main(string[] args)
		{
            const string connString = "Host=localhost;Database=MailingServiceDb;Username=postgres;Password=admin";
            QueueProducer queueProducer = new QueueProducer("messages_exchange");

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            conn.Notification += (o, e) => queueProducer.SendMessageToQueue(e.Payload);

            await using (var cmd = new NpgsqlCommand("LISTEN message_added;", conn))
                cmd.ExecuteNonQuery();

            while (true)
                conn.Wait();
        }
	}
}
