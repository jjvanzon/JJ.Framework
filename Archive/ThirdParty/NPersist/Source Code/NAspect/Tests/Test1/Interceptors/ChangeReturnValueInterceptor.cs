using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
	public class ChangeReturnValueInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			object res = call.Proceed();
			res = 1000;
			return res;
		}
	}
}