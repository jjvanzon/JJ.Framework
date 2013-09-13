using System;
using Puzzle.NPersist.Framework.Interfaces;

namespace NAspectProxyFactory
{
	public class NPersistProxyMixin : IProxy
	{
		private IInterceptor interceptor;
		public NPersistProxyMixin(object target)
		{
		}

		public NPersistProxyMixin()
		{
		}

		public IInterceptor GetInterceptor()
		{
			return interceptor;
		}

		public void SetInterceptor(IInterceptor value)
		{
			interceptor = value;
		}
	}
}
