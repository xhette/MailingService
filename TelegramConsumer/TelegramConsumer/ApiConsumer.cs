using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

using TelegramConsumer.Models;

namespace TelegramConsumer
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

		public string GetPhone(int id)
		{
			string urlParameters = _urlParameters/* + "/" + id*/;

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

		public int PostMessage(TelegramMsgModel message)
		{
			var jsonObject = new StringContent(JsonSerializer.Serialize<TelegramMsgModel>(message), Encoding.UTF8, "application/json");

			HttpResponseMessage response = _httpClient.PostAsync(_urlParameters, jsonObject).Result;

			if (response.IsSuccessStatusCode)
			{
				int resultCode = 0;

				int result = int.TryParse(response.Content.ReadAsStringAsync().Result, out resultCode) ? resultCode : 500;
				return result;
			}
			else
			{
				return 500;
			}
		}
	}
}
