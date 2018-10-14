using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace OneWayAsyncCalls.Interceptors
{
	public class OneWayInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			//
			AsyncCallWrapper oneWay = new AsyncCallWrapper(call) ;
			oneWay.CallAsync() ;

			//since the method hasnt finished yet , we have to pass some return value
			return null;
		}
	}
}
