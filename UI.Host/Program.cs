using System;
using Microsoft.Owin.Hosting;
using UI.Host.Owin;

namespace UI.Host
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Dashboard WebServer running. Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}