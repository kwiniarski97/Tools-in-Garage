using Autofac;
using Tools.Infrastructure.IoC.Modules;
using Tools.Infrastructure.Mappers;

namespace Tools.Infrastructure.IoC
{
    public class ContainerModule : Module
    {
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
            
        }
    }
}