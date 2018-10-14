using System;
using Puzzle.NCore.Framework.Logging;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Persistence;

namespace ODMappingTests
{
	/// <summary>
	/// Summary description for ContextFactory.
	/// </summary>
	public class ContextFactory
	{
		public ContextFactory()
		{
		}

		public static IContext GetContext(object test, string fileName)
		{
			IContext context = new Context(test.GetType().Assembly, "ODMappingTests." + fileName + ".npersist" );

//			context.PersistenceEngine = new DocumentPersistenceEngine();
//			context.PersistenceEngine.Context = context;

			context.LogManager.Loggers.Add(new ConsoleLogger(LoggingLevel.Debug));
			return context;
		}
	}
}
