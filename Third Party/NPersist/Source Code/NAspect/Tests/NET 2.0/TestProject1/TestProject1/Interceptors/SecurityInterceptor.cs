using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests.Interceptors
{
    [Throws(typeof(SecurityException))]
    public class SecurityInterceptor : IBeforeInterceptor
    {
        public void BeforeCall(BeforeMethodInvocation call)
        {
            Console.WriteLine("before");
        }
    }

    public class SecurityException : Exception
    {
    }
}
