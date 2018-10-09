using System;
using System.Reflection;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Samples.Northwind.Domain;

namespace Puzzle.NPersist.Tests.Northwind
{
	/// <summary>
	/// Summary description for ContextFactory.
	/// </summary>
	public class ContextFactory
	{
		public static string ConnectionString = "SERVER=(local);DATABASE=NpNWind;integrated security=true";

		//The npersist xml mapping file has been compiled into the Northwind.Domain dll
		//as an embedded resource with the following name (the namespace appears twice
		//because embedded resources are referenced as [AssemblyName].[FileName] and our
		//filename happens to contain the namespace name as well)
		public static string MapResourceName = "Puzzle.NPersist.Samples.Northwind.Domain.Puzzle.NPersist.Samples.Northwind.Domain.npersist";

		public static IContext CreateContext()
		{
			//Get a reference to the Northwind.Domain assembly containing the
			//npersist xml mapping file as an embedded resource.
			//Use any of the classes in the domain to obtain a reference
			//to the assembly.
			Assembly asm = Assembly.GetAssembly(typeof(Employee));

			//Create an instance of the Context, passing the assembly  
			//and the name of the embedded xml file to the contructor
			IContext context = new Context(asm, MapResourceName);

			//Set the connection string to our database
			context.SetConnectionString(ConnectionString);

			//return the new context
			return context;
		}	
	}
}
