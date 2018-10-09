using System;
using System.Collections;
using System.Reflection;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NPersist.Framework;
using Puzzle.NPersist.Framework.Mapping;

namespace NAspectProxyFactory
{
	public class NPersistCtorPointcut : IPointcut
	{
		private IContext context; 
		public NPersistCtorPointcut(IContext context)
		{
			this.context = context;
		}

		public IList Interceptors
		{
			get 
			{
				IList arr = new ArrayList();
				arr.Add(new NPersistCtorInterceptor (context));
				return arr;
			}
		}

		public bool IsMatch(MethodBase method)
		{
			return (method.Name.StartsWith(".ctor"));
		}
	}
}
