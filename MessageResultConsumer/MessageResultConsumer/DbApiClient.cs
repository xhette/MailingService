using MessageResultConsumer.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MessageResultConsumer
{
	public class DbApiClient
	{
		private HttpClient _httpClient;

		public DbApiClient(string apiUri)
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri(apiUri);

			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public void PostChanges(int messageId, int deliverResultCode)
		{
			//MessageDTO message;

			string urlParameters = "api/Messages";
			string urlGetParameters = urlParameters + "/" + messageId;

			var getResult = _httpClient.GetAsync(urlGetParameters).Result;
			MessageDTO message = JsonSerializer.Deserialize<MessageDTO>(getResult.Content.ReadAsStringAsync().Result);

			message.Status = deliverResultCode;

			var jsonObject = new StringContent(JsonSerializer.Serialize<MessageDTO>(message), Encoding.UTF8, "application/json");

			_httpClient.PostAsync(urlParameters, jsonObject);
		}
	}
}
