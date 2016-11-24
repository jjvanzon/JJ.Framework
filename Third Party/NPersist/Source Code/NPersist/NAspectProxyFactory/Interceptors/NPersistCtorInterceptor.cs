using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NPersist.Framework;

namespace NAspectProxyFactory
{
	public class NPersistCtorInterceptor : IInterceptor
	{
		IContext context;
		public NPersistCtorInterceptor(IContext context)
		{
			this.context = context;
		}

		public object HandleCall(MethodInvokation call)
		{
			
			
			if (context.Interceptor == null)
			{
				call.Proceed();
				return null;
			}
			else
			{
				bool cancel = false;
				context.Interceptor.NotifyInstantiatingObject(call.Target,ref cancel) ;

				if (!cancel)
					call.Proceed() ;

				context.Interceptor.NotifyInstantiatedObject(call.Target) ;

				return null;
			}
		}
	}
}
