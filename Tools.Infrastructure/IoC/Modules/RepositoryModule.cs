using System.Reflection;
using Autofac;
using Tools.Core.Repositories;
using Module = Autofac.Module;

namespace Tools.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Module
    {
        /// <summary>
        /// Search assembly using reflections to automaticaly add classes that inherit from IRepository to builder
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //reflections 
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            //adds repos
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}