using System;
using Microsoft.Owin.Hosting;

namespace UI.Host
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Dashboard WebServer running. Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}