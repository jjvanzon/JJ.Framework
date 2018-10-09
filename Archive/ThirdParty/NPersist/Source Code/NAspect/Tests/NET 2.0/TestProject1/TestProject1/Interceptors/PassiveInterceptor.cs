using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
    public class PassiveInterceptor : IAroundInterceptor
    {
        public object HandleCall(MethodInvocation call)
        {
            object res = call.Proceed();
            return res;
        }
    }
}