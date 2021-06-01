using ApiClient.DTO;

using MailingWeb.ApiClient.DTO;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MailingWeb.ApiClient
{
	public class MailingClient
	{
		private HttpClient _httpClient;

		public MailingClient(string apiUri)
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri(apiUri);

			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

		}

		public List<MessageFullDTO> GetMessages()
		{
			string urlParameters = "api/Messages";

			HttpResponseMessage response = _httpClient.GetAsync(urlParameters).Result;  

			if (response.IsSuccessStatusCode)
			{
				var dataObjects = JsonSerializer.Deserialize<List<MessageFullDTO>>(response.Content.ReadAsStringAsync().Result);

				return dataObjects;
			}
			else
			{
				return null;
			}
		}

		public List<PortDTO> GetPorts()
		{
			string urlParameters = "api/Ports";

			HttpResponseMessage response = _httpClient.GetAsync(urlParameters).Result;

			if (response.IsSuccessStatusCode)
			{
				var dataObjects = JsonSerializer.Deserialize<List<PortDTO>>(response.Content.ReadAsStringAsync().Result);

				return dataObjects;
			}
			else
			{
				return null;
			}
		}

		public List<TypeDTO> GetTypes()
		{
			string urlParameters = "api/Types";

			HttpResponseMessage response = _httpClient.GetAsync(urlParameters).Result;

			if (response.IsSuccessStatusCode)
			{
				var dataObjects = JsonSerializer.Deserialize<List<TypeDTO>>(response.Content.ReadAsStringAsync().Result);

				return dataObjects;
			}
			else
			{
				return null;
			}
		}

		public void PostMessage(MessageDTO message)
		{
			string urlParameters = "api/Messages";
			var jsonObject = new StringContent(JsonSerializer.Serialize<MessageDTO>(message), Encoding.UTF8, "application/json");

			_httpClient.PostAsync(urlParameters, jsonObject);
		}
	}
}
