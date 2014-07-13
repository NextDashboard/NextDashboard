using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using NLog;

namespace NextDashboard.Api
{
    class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var baseAddress = "http://localhost:9000/";

            _logger.Info("Starting API service");
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                _logger.Info("Dashboard API started");
                PingApiForSampleData(baseAddress);

                _logger.Info("Press Any Key to stop API service");
                Console.ReadLine(); 
            }

        }

        private static void PingApiForSampleData(string baseAddress)
        {
            var client = new HttpClient();
            _logger.Trace("Retrieving sample Jobs");
            var response = client.GetAsync(baseAddress + "api/Jobs").Result;
            _logger.Trace(response);
            _logger.Trace(response.Content.ReadAsStringAsync().Result);
        }
    }
}
