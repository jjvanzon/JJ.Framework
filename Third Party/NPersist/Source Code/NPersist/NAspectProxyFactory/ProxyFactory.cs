using System;
using Puzzle.NAspect.Framework;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Interfaces;

namespace NAspectProxyFactory
{
	public class AopProxyFactory : IProxyFactory , IContextChild
	{
		private Engine aopEngine;
		private IContext context;

		public AopProxyFactory()
		{
			aopEngine = new Engine();
			
		}

		public Puzzle.NPersist.Framework.Interfaces.IInterceptableList CreateListProxy(Type baseType, Puzzle.NPersist.Framework.Persistence.IObjectFactory objectFactory, params object[] ctorArgs)
		{
			return Puzzle.NPersist.Framework.Proxy.ListProxyFactory.CreateProxy(baseType,objectFactory,ctorArgs) ;
		}

		public object CreateEntityProxy(Type baseType, Puzzle.NPersist.Framework.Persistence.IObjectFactory objectFactory, Puzzle.NPersist.Framework.Mapping.IClassMap classMap, object[] ctorArgs)
		{			
			return aopEngine.CreateProxy(baseType,ctorArgs) ;
		}

		public Type GetEntityProxyType(Type baseType, Puzzle.NPersist.Framework.Mapping.IClassMap classMap)
		{
			return aopEngine.CreateProxyType(baseType);
		}

		public IContext Context
		{
			get { return context; }
			set 
			{ 
				context = value;
				aopEngine.Aspects.Clear() ;
				aopEngine.Aspects.Add(new NPersistAspect(Context));			
			}
		}
	}
}
