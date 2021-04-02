using Npgsql;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseListener
{
	public static class MessagesAddedListener
	{
		public async static void Start()
		{
            const string connString = "Host=localhost;Database=MailingServiceDb;Username=postgres;Password=admin";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            //e.Payload is string representation of JSON we constructed in NotifyOnDataChange() function
            conn.Notification += (o, e) => Console.WriteLine("Received notification: " + e.Payload);

            await using (var cmd = new NpgsqlCommand("LISTEN notify_messages_added;", conn))
                cmd.ExecuteNonQuery();

            while (true)
                conn.Wait();
        }
	}
}
