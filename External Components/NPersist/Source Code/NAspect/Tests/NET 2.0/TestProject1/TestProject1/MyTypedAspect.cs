using System;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Interception;

namespace KumoUnitTests
{
    [Mixin(typeof(MyTypedSayHelloMixin))]       //mixins needed by this aspect
    [AspectTarget(TargetType = typeof(Foo))]    //target of this aspect
    public class MyTypedAspect : ITypedAspect
    {

        //interceptor with index 1 , intercepting * 
        [Interceptor(Index = 3,TargetSignature="*")]
        public object MyAroundInterceptor(MethodInvocation call)
        {
            Console.WriteLine("before");
            object res = call.Proceed();
            Console.WriteLine("after");
            return res;
        }

        [Interceptor(Index = 2, TargetSignature = "*")]
        public void MyAfterInterceptor(AfterMethodInvocation call)
        {
            Console.WriteLine("after");
        }

        [Interceptor(Index = 1, TargetSignature = "*")]
        public void MyBeforeIntercepto(BeforeMethodInvocation call)
        {
            Console.WriteLine("before");           
        }
    }

    public class MyTypedSayHelloMixin : ISayHello, IProxyAware
    {
        public string SayHello()
        {
            return "Hello";
        }

        private IAopProxy target;
        public void SetProxy(IAopProxy target)
        {
            this.target = target;
        }
    }
    
    [AspectTarget(TargetType = typeof(Foo))]    //target of this aspect
    public class ReturnValueChangerAspect : ITypedAspect
    {
        [Interceptor(Index = 1, TargetSignature = "MyInt*")]
        public object ChangeReturnValue(MethodInvocation call)
        {
            int res = (int)call.Proceed();

            res++;
            return res;
        }
    }
}
