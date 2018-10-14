using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
    public class ExplicitIFaceClonableInterceptor : IAroundInterceptor
	{
		public object HandleCall(MethodInvocation call)
		{
			object res = call.Proceed() ;
			SomeClassWithExplicitIFace some = (SomeClassWithExplicitIFace) res;
			some.SomeLongProp = 1234;
			return some;
		}
	}
}