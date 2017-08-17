using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Tools.Infrastructure.Database
{
    public class MongoConfigurator
    {
        private static bool _initialized;

        public static void _Init()
        {
            if (_initialized)
            {
                return;
            }
            _initialized = true;
        }
        
        //23.12

        /// <summary>
        /// Register  a new settings of mongo db 
        /// </summary>
        private static void RegisterConvention()
        {
            ConventionRegistry.Register("PassangerConventions",new MongoConvention(), x=>true );
        }
        
        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                //ignore not serializable objecst
                new IgnoreExtraElementsConvention(true),
                // use camel case
                new CamelCaseElementNameConvention(),
                //enums holds as string
                new EnumRepresentationConvention(BsonType.String)
            };
        }
    }
}