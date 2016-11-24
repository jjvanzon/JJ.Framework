using System;
using System.Collections;
using System.Reflection;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Mapping;

namespace NAspectProxyFactory
{
	public class NPersistPropertyPointcut : IPointcut
	{
		private IContext context; 
		public NPersistPropertyPointcut(IContext context)
		{
			this.context = context;
		}

		public IList Interceptors
		{
			get 
			{
				IList arr = new ArrayList();
				arr.Add(new NPersistPropertyInterceptor (context));
				return arr;
			}
		}

		public bool IsMatch(MethodBase method)
		{
			string methodName = method.Name;
			if (!(methodName.StartsWith("get_") || methodName.StartsWith("set_")))
				return false;

			methodName = methodName.Substring(4);

			IClassMap classmap = context.DomainMap.GetClassMap(method.DeclaringType);
			if (classmap == null) 
				return false;
			return (classmap.GetPropertyMap(methodName) != null);
		}
	}
}
