using System;
using System.EnterpriseServices;
using System.Reflection;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.TransactionalCache
{
	/// <summary>
	/// Summary description for TransactionalContextFactory.
	/// </summary>
	[Transaction(TransactionOption.Required)]
	public class TransactionalContextFactory : ServicedComponent
	{

		public IContext GetContext(IDomainMap domainMap)
		{
			IContext context = new Context(domainMap); 
			SetupTransactionalContext(context);
			return context;
		}

		public IContext GetContext(string mapFilePath) 
		{
			IContext context = new Context(mapFilePath); 
			SetupTransactionalContext(context);
			return context;
		}

		public IContext GetContext(Assembly asm, string mapFileResourceName) 
		{
			IContext context = new Context(asm, mapFileResourceName); 
			SetupTransactionalContext(context);
			return context;
		}

		public IContext GetContext(IContext rootContext) 
		{
			IContext context = new Context(rootContext); 
			SetupTransactionalContext(context);
			return context;
		}

		public IContext GetContext(string url, string domainKey) 
		{			
			IContext context = new Context(url, domainKey); 
			SetupTransactionalContext(context);
			return context;
		}
		
		public IContext GetContext(string url, string domainKey, bool useCompression) 
		{
			IContext context = new Context(url, domainKey, useCompression); 
			SetupTransactionalContext(context);
			return context;
		}

		protected void SetupTransactionalContext(IContext context)
		{
			context.ObjectCacheManager = new TransactionalObjectCacheManager() ;
			context.AutoTransactions = false;
		}

	}
}
