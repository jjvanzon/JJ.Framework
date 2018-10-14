using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Interception;

namespace Puzzle.NAspect.Standard
{

    public class LogInterceptor : IAroundInterceptor
    {
        public object HandleCall(Puzzle.NAspect.Framework.MethodInvocation call)
        {
            Console.WriteLine("Entering : " + call.ValueSignature);
            return call.Proceed();
            Console.WriteLine("Returning from : " + call.ValueSignature);
        }
    }
}
