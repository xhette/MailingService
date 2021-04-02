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

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            //e.Payload is string representation of JSON we constructed in NotifyOnDataChange() function
            conn.Notification += (o, e) => Console.WriteLine("Received notification: " + e.Payload);

            await using (var cmd = new NpgsqlCommand("LISTEN message_added;", conn))
                cmd.ExecuteNonQuery();

            while (true)
                conn.Wait();
        }
	}
}
