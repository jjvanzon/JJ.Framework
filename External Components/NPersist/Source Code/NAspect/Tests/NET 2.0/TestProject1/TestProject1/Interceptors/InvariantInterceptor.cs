using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
    [Throws(typeof(NullReferenceException))]
    [Throws(typeof(ArgumentException))]
    public class InvariantInterceptor : IAfterInterceptor
    {
        public void AfterCall(AfterMethodInvocation call)
        {
            Console.WriteLine("after");
        }
    }
}
