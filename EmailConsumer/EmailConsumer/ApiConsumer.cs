using EmailConsumer.Models;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EmailConsumer
{
	public class ApiConsumer
	{
		private HttpClient _httpClient;
		private string _urlParameters;

		public ApiConsumer(string apiUri, string controllerName)
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri(apiUri);
			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			_urlParameters = "/" + controllerName;
		}

		public string GetEmail(int id)
		{
			string urlParameters = _urlParameters;

			HttpResponseMessage response = _httpClient.GetAsync(urlParameters).Result;
			if (response.IsSuccessStatusCode)
			{
				return response.Content.ReadAsStringAsync().Result;
			}
			else
			{
				return String.Empty;
			}
		}

		public int PostMessage(EmailModel message)
		{
			var jsonObject = new StringContent(JsonSerializer.Serialize<EmailModel>(message), Encoding.UTF8, "application/json");

			HttpResponseMessage response = _httpClient.PostAsync(_urlParameters, jsonObject).Result;

			if (response.IsSuccessStatusCode)
			{
				int result = int.TryParse(response.Content.ReadAsStringAsync().Result, out result) ? result : -1;
				return result;
			}
			else
			{
				return -1;
			}
		}
	}
}
