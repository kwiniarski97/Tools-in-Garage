using Autofac;
using Microsoft.Extensions.Configuration;

namespace Tools.Infrastructure.IoC.Modules
{
    public class SettingModule : Module
    {
        private readonly IConfiguration _configuration;

        public SettingModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            
        }
    }
}