using System.Reflection;
using Autofac;
using Tools.Infrastructure.Services;
using Module = Autofac.Module;

namespace Tools.Infrastructure.IoC.Modules
{
    
    public class ServiceModule : Module
    {
        /// <summary>
        /// Adds a IService implementation's to IoC 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}