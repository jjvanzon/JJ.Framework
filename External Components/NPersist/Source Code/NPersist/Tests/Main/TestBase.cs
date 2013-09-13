using System;
using System.Reflection;
using Puzzle.NPersist.Framework;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for TestBase.
	/// </summary>
	public class TestBase
	{

		public static string ConnectionString = "SERVER=(local);;DATABASE=NPersistNUnitTests;integrated security=true";

		//The npersist xml mapping file has been compiled into the Northwind.Domain dll
		//as an embedded resource with the following name (the namespace appears twice
		//because embedded resources are referenced as [AssemblyName].[FileName] and our
		//filename happens to contain the namespace name as well)
		public static string MapResourceName = "Puzzle.NPersist.Tests.Main.Map.NUnitTests.npersist";

		public virtual IContext GetContext()
		{
			//Get a reference to the Northwind.Domain assembly containing the
			//npersist xml mapping file as an embedded resource.
			//Use any of the classes in the domain to obtain a reference
			//to the assembly.
			Assembly asm = Assembly.GetAssembly(typeof(Book));

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
