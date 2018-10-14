using System;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.Interfaces
{
	public interface IProxyFactory : IContextChild
	{
		object CreateEntityProxy( Type baseType,IObjectFactory objectFactory,IClassMap classMap,object[] ctorArgs);
		Type GetEntityProxyType(Type baseType, IClassMap classMap);
		IInterceptableList CreateListProxy(Type baseType, IObjectFactory objectFactory,params object[] ctorArgs);

	}
}
