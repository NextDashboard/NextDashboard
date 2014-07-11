using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace NextDashboard.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Dashboard API started");
                Console.ReadLine(); 
            }

            Console.ReadLine(); 
        }
    }
}
