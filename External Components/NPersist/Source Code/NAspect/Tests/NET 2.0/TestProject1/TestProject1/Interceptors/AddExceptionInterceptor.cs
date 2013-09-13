using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
    [IsRequired]
    [MayBreakFlow]
    [ReplaceException(typeof(Exception),typeof(NullReferenceException))]
    public class AddExceptionInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			Type returnType = call.ReturnType;
			object res = null;
			try
			{
				res = call.Proceed();
			}
			catch (Exception x)
			{
				throw new NullReferenceException("added exception", x);
			}

			return res;
		}
	}
}