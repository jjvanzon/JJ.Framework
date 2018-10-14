using System;

namespace OneWayAsyncCalls
{
	//some class that will be the target of our async interceptor
	public class SomeAopTarget
	{
		public SomeAopTarget()
		{
		}

		//some function that takes ages to complete
		[OneWay]
		public virtual void DoSomeHeavyWork(int loopCount)
		{
			for (int i=0;i<loopCount;i++)
			{
				Console.WriteLine("work {0}",i) ;
				//simulate some work beeing done
				System.Threading.Thread.Sleep(100) ;
			}
		}


		//some not so heavy function
		public virtual void SayHelloAop()
		{
			Console.WriteLine("Hello Aop!!") ;
		}
	}
}
