using System;
using System.Data.Entity;
using System.Reflection;
using JJ.Framework.Reflection;
using JJ.Framework.Text;

namespace JJ.Framework.Data.EntityFramework5
{
	internal static class UnderlyingEntityFramework5ContextFactory
	{
		// TODO: If model assembly is not required the don't make it a parameter.
		// Also: if it is not required, don't check it for null in the ContextBase class.
		public static DbContext CreateContext(string connectionString, Assembly modelAssembly, Assembly mappingAssembly)
		{
			Type dbContextType = mappingAssembly.GetImplementation<DbContext>();
			string modelName = GetEntityFrameworkModelName(mappingAssembly);
			string specialConnectionString = GetSpecialConnectionString(connectionString, modelName);

			var dbContext = (DbContext)Activator.CreateInstance(dbContextType, specialConnectionString);
			return dbContext;
		}

		private static string GetEntityFrameworkModelName(Assembly mappingAssembly)
		{
			foreach (string resourceName in mappingAssembly.GetManifestResourceNames())
			{
				if (resourceName.EndsWith(".msl"))
				{
					return resourceName.TrimEnd(".msl");
				}
			}

			throw new Exception(
				$"No .msl file found in the embedded resources of the mapping assembly '{mappingAssembly.GetName().Name}'. " + 
				"(The .msl file is a resource generated out of an .edmx file.)");
		}

		private static string GetSpecialConnectionString(string connectionString, string modelName)
		{
			// Add MultipleActiveResultSets or all sorts of stuff will fail for Entity Framework.
			if (!connectionString.Contains("MultipleActiveResultSets="))
			{
				connectionString += ";MultipleActiveResultSets=True";
			}

			string specialConnectionString = string.Format(@"metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string=""{1}""", modelName, connectionString);
			return specialConnectionString;
		}
	}
}
