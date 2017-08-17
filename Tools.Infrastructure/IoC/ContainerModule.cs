using Autofac;
using Microsoft.Extensions.Configuration;
using Tools.Infrastructure.IoC.Modules;
using Tools.Infrastructure.Mappers;

namespace Tools.Infrastructure.IoC
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            //adds automapper as singleton
            builder.RegisterInstance(AutoMapperConfig.InitMapper())
                .SingleInstance();
            //adds repository module
            builder.RegisterModule<RepositoryModule>();
            //adds service module
            builder.RegisterModule<ServiceModule>();
            //adds command module
            builder.RegisterModule<CommandModule>();
            //adds settings module
            builder.RegisterModule(new SettingModule(_configuration));
        }
    }
}