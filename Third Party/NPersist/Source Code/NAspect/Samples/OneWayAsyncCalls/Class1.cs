using System;
using Puzzle.NAspect.Framework;

namespace OneWayAsyncCalls
{
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
			IEngine c = ApplicationContext.Configure();

			//create an instance of "SomeAopTarget" through the aop container
			SomeAopTarget myObj = c.CreateProxy(typeof (SomeAopTarget)) as SomeAopTarget;

			//this method will be called async , because of the async interceptor
			myObj.DoSomeHeavyWork(100) ;

			//this method will finish BEFORE the above method!
			myObj.SayHelloAop() ;
			Console.WriteLine("press any key to continue") ;
			Console.ReadLine() ;
		}
	}
}
