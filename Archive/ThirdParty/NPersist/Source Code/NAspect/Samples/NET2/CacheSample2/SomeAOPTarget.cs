using System;

namespace CacheSample
{
	//some class that will be the target of our caching interceptor
	public class SomeAopTarget
	{
		public SomeAopTarget()
		{
		}

		//some function that takes ages to complete
		public virtual double PerfromSomeReallyHeavyCalculation(int loopCount)
		{
			string result = "";
			for (int i=0;i<loopCount;i++)
			{
				result += i.ToString();
				//simulate some work beeing done
				System.Threading.Thread.Sleep(100) ;
			}
			return 12345.44;
		}
	}
}
