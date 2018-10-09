using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
	public class IncreaseReturnValueInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			int res = (int)call.Proceed();

			res ++;
			return res;
		}
	}
}