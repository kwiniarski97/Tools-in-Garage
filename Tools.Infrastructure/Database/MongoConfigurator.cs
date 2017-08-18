using System.Collections.Generic;
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
            RegisterConvention();
        }

        //23.12

        /// <summary>
        /// Register  a new settings of mongo db 
        /// </summary>
        private static void RegisterConvention()
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.PythonLegacy;
            ConventionRegistry.Register("PassangerConventions", new MongoConvention(), x => true);
            _initialized = true;
        }

        /// <summary>
        /// Ads a new conventios. 
        /// 
        /// Add here options
        /// </summary>
        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
               // use camel case
                new CamelCaseElementNameConvention(),
                //enums holds as string
                new EnumRepresentationConvention(BsonType.String)
            };
        }
    }
}