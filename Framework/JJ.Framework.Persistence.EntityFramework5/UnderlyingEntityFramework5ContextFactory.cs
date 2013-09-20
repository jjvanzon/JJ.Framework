using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence.EntityFramework5
{
    internal static class UnderlyingEntityFramework5ContextFactory
    {
        public static DbContext CreateContext(string connectionString, params Assembly[] modelAssemblies)
        {
            Type dbContextType = GetDbContextType(modelAssemblies);
            string modelName = GetModelName(modelAssemblies);
            string specialConnectionString = GetSpecialConnectionString(connectionString, modelName);

            return (DbContext)Activator.CreateInstance(dbContextType, specialConnectionString);
        }

        private static Type GetDbContextType(Assembly[] modelAssemblies)
        {
            Type[] types = ReflectionHelper.GetImplementations<DbContext>(modelAssemblies);

            if (types.Length == 0)
            {
                throw new Exception(String.Format("No implementation of type '{0}' found in model assemblies.", typeof(DbContext).Name));
            }

            if (types.Length > 1)
            {
                throw new Exception(String.Format("Multiple implementations of type '{0}' found in model assemblies.", typeof(DbContext).Name));
            }

            return types[0];
        }

        private static string GetModelName(Assembly[] modelAssemblies)
        {
            foreach (Assembly assembly in modelAssemblies)
            {
                foreach (string resourceName in assembly.GetManifestResourceNames())
                {
                    if (resourceName.EndsWith(".msl"))
                    {
                        return resourceName.CutRight(".msl");
                    }
                }
            }

            throw new Exception("No .msl file found in the embedded resources of the model assemblies. (The .msl file is a resource generated out of an .edmx file.)");
        }

        private static string GetSpecialConnectionString(string connectionString, string modelName)
        {
            return String.Format(@"metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string=""{1}""", modelName, connectionString);
        }
    }
}
