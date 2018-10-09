using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
    public class ChangeRefParamValueInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			object res = call.Proceed();

			InterceptedParameter param = (InterceptedParameter) call.Parameters[0];
			param.Value = "some changed value";

			return res;
		}
	}
}