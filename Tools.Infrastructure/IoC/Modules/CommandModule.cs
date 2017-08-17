using System.Reflection;
using Autofac;
using Tools.Infrastructure.Commands;
using Transporter.Infrastructure.Commends;
using Module = Autofac.Module;

namespace Tools.Infrastructure.IoC.Modules
{
    public class CommandModule : Module
    {
        /// <summary>
        /// Adds ICommandhandler implementations and ICommandDispatcher to ioc. 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}