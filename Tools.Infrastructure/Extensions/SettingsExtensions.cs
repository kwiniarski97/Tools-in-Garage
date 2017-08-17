using Microsoft.Extensions.Configuration;

namespace Tools.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        /// <summary>
        /// Get section from appsettings and delete setttings from header
        /// Also binds setting to configuration value.
        /// </summary>
        /// <param name="configuration">For every IConfiguration that has contructor</param>
        /// <returns>Configuration</returns>
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);
            var configurationValue = new T();
            configuration.GetSection(section).Bind(configurationValue);

            return configurationValue;
        }
    }
}