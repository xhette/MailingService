using SMSConsumer.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SMSConsumer
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

		public SMSResultEnum PostMessage(SmsModel message)
		{
			var jsonObject = new StringContent(JsonSerializer.Serialize<SmsModel>(message), Encoding.UTF8, "application/json");

			HttpResponseMessage response = _httpClient.PostAsync(_urlParameters, jsonObject).Result;

			if (response.IsSuccessStatusCode)
			{
				int resultCode = 0;

				SMSResultEnum result = int.TryParse(response.Content.ReadAsStringAsync().Result, out resultCode) ? (SMSResultEnum)resultCode : SMSResultEnum.Error;
				return result;
			}
			else
			{
				return SMSResultEnum.Error;
			}
		}
	}
}
