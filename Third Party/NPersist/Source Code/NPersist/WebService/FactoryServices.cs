using System;
using System.Globalization;
using System.Reflection;
using Puzzle.NCore.Framework.Compression;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Remoting.WebService.Server
{
	/// <summary>
	/// Summary description for ContextFactoryService.
	/// </summary>
	public class FactoryServices
	{
		public FactoryServices()
		{
			
		}

		public static IContextFactory CreateContextFactory()
		{			
			string path = System.Configuration.ConfigurationSettings.AppSettings["ContextFactoryAssembly"];
			string className = System.Configuration.ConfigurationSettings.AppSettings["ContextFactoryClass"];
			string mapPath = System.Configuration.ConfigurationSettings.AppSettings["ContextFactoryDefaultMapPath"];
			string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ContextFactoryDefaultConnectionString"];
			string domainPath = System.Configuration.ConfigurationSettings.AppSettings["ContextFactoryDefaultDomainAssembly"];			

			IContextFactory factory ;

			if (path != null && className != null && path.Length > 0 && className.Length > 0)
			{
				factory = (IContextFactory) Assembly.Load(path).CreateInstance(className);				
			}
			else
			{
				factory = new ContextFactory();				
			}

			if (mapPath != null)
				factory.MapPath = mapPath;

			if (connectionString != null)
				factory.ConnectionString = connectionString;

			if (domainPath != null)
			{
				if (domainPath.Length > 0)
				{
					Assembly asm = Assembly.Load(domainPath);							
				}
			}

			return factory;
		}

		public static IWebServiceCompressor CreateWebServiceCompressor()
		{			
			string path = System.Configuration.ConfigurationSettings.AppSettings["CompressorAssembly"];
			string className = System.Configuration.ConfigurationSettings.AppSettings["CompressorClass"];

			IWebServiceCompressor compressor = null;

			if (className != null && className.ToLower(CultureInfo.InvariantCulture) == "none")
			{
				//					
			}
			else
			{
				if (path != null && className != null && path.Length > 0 && className.Length > 0)
				{
					compressor = (IWebServiceCompressor) Assembly.Load(path).CreateInstance(className);				
				}
				else
				{
					compressor = new DefaultWebServiceCompressor();				
				}				
			}

			return compressor;
		}

	
	}
}
