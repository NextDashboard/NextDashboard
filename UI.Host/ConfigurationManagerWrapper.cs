using NLog.Internal;

namespace UI.Host
{
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        readonly ConfigurationManager _configurationManager = new ConfigurationManager();
      
        public string GetSetting(string key)
        {
          
            return _configurationManager.AppSettings[key];
        }
    }
}