using System;
using DesignByContract1.DbC;

namespace DesignByContract1
{
	public class SomeAopTarget
	{
		[NotNull]
		public virtual string ReturnAString(int i)
		{
			Console.WriteLine("ReturnAString was called") ;

			if (i==0)
				return "hello";
			else
				return null; //this will fail
		}

		public virtual void ReceiveAString(int abc,[NotNull]string def)
		{
			Console.WriteLine("ReceiveAString was called") ;
		}
	}
}
