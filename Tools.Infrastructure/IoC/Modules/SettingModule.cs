using Autofac;
using Microsoft.Extensions.Configuration;
using Tools.Infrastructure.Database;
using Tools.Infrastructure.Extensions;

namespace Tools.Infrastructure.IoC.Modules
{
    public class SettingModule : Module
    {
        private readonly IConfiguration _configuration;

        public SettingModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Adds Settings to IOC as singleton.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //singleton of settings
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                .SingleInstance();
        }
    }
}