using DatabaseListener.Models;

using Newtonsoft.Json.Linq;

using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DatabaseListener.Classes
{
	public class QueueProducer
	{
		private IConnection _rabbitConnection;

		private string _exchangeName;

		public QueueProducer( string exchangeName) 
		{
			ConnectionFactory factory = new ConnectionFactory
			{
				UserName = "guest",
				Password = "guest",
				VirtualHost = "/",
				HostName = "localhost"
			};

			_exchangeName = exchangeName;

			_rabbitConnection = factory.CreateConnection();
		}

		public void SendMessageToQueue(string jsonString)
		{
			string routingKey = String.Format("messages.{0}", JObject.Parse(jsonString)["port_name"].ToString().ToLower());

			IModel model = _rabbitConnection.CreateModel();
			model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, true);
			//model.QueueDeclare(_queueName, true, false, false, null);
			//model.QueueBind(_queueName, _exchangeName, routingKey, null);

			byte[] messageBodyBytes = Encoding.UTF8.GetBytes(jsonString);

			model.BasicPublish(_exchangeName, routingKey, null, messageBodyBytes);
		}
	}
}
