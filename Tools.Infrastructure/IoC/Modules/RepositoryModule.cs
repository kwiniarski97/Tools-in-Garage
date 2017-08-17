using System.Reflection;
using Autofac;
using MongoDB.Driver;
using Tools.Core.Repositories;
using Tools.Infrastructure.Database;
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
            builder.Register((x,y) =>
            {
                var settings = x.Resolve<MongoSettings>();
                return new MongoClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((x, y) =>
            {
                var client = x.Resolve<MongoClient>();
                var settings = x.Resolve<MongoSettings>();
                var database = client.GetDatabase(settings.Database);

                return database;
            }).As<IMongoDatabase>();
            
            //reflections 
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}