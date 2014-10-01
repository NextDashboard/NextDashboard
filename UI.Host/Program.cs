using System;
using Microsoft.Owin.Hosting;
using NLog;
using NLog.Interface;

namespace UI.Host
{
    internal class Program
    {
        private static readonly ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());
        private static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                _logger.Info("Dashboard WebServer running. Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}