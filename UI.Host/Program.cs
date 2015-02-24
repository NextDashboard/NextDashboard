using System;
using Microsoft.Owin.Hosting;
using NLog;
using NLog.Interface;

namespace UI.Host
{
    internal class Program
    {
        private static readonly ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());
        static readonly IConfigurationManager _configurationManager = new ConfigurationManagerWrapper();
        private static void Main(string[] args)
        {
            var baseAddress = _configurationManager.GetSetting("OwinEndPoint");

            using (WebApp.Start<Startup>(baseAddress))
            {
                _logger.Info("Dashboard WebServer running. Press any key to exit");
                _logger.Info("Url: {0}",baseAddress);
                Console.ReadLine();
            }
        }


    }
}