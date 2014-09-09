using System;
using System.Net.Http;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Application.Http
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;

        public HttpClientWrapper()
        {
            _client = new HttpClient();
        }

        public Uri BaseAddress
        {
            get { return _client.BaseAddress; }
            set { _client.BaseAddress = value; }
        }

        public string GetResponse(string address)
        {
            var response = _client.GetAsync(address).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

    }
}