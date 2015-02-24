using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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


        public void SetHeaderUserNameAndPassword(string username,string password)
        {
            _client.DefaultRequestHeaders.Authorization  = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", username, password))));
        }
        public string GetResponse(string address)
        {
            HttpResponseMessage response = _client.GetAsync(address).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}