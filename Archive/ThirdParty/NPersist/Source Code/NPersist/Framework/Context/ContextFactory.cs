using System.Reflection;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping.Serialization;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.BaseClasses
{
	/// <summary>
	/// Summary description for ContextFactory.
	/// </summary>
	public class ContextFactory : IContextFactory 
	{

		private string mapPath = "";
		private string connectionString = "";

		public ContextFactory()
		{
		}
		
		public ContextFactory(string mapPath) => this.mapPath = mapPath;

	    public string MapPath
		{
			get => this.mapPath;
	        set => this.mapPath = value;
	    }

		public string ConnectionString
		{
			get => this.connectionString;
		    set => this.connectionString = value;
		}

		public IContext GetContext() => GetContext("");

	    public IContext GetContext(string domainKey)
		{
			string useMapPath = this.mapPath;
			string useConnectionString = this.connectionString;

			if (domainKey != null)
			{
				if (domainKey.Length > 0)
				{
#if NET2
					useMapPath = System.Configuration.ConfigurationManager.AppSettings["MapPathForKey-" + domainKey];
                    useConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionStringForKey-" + domainKey];
                    string domainPath = System.Configuration.ConfigurationManager.AppSettings["DomainAssemblyForKey-" + domainKey];
#else
					useMapPath = System.Configuration.ConfigurationSettings.AppSettings["MapPathForKey-" + domainKey];
                    useConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionStringForKey-" + domainKey];
					string domainPath = System.Configuration.ConfigurationSettings.AppSettings["DomainAssemblyForKey-" + domainKey];
#endif



                    if (domainPath != null && domainPath.Length > 0)
					{
						Assembly asm = Assembly.Load(domainPath);							
					}
					else
					{
						throw new NPathException("Could not find Domain Assembly for key '" + domainKey + "' in application configuration!");
					}

				}
			}
			IContext ctx = new Context(useMapPath);
			if (useConnectionString != "")
			{
				ctx.SetConnectionString(useConnectionString);				
			}
			return ctx;
		}

	}
}
