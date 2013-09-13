using System;
using Puzzle.NAspect.Framework;

namespace CacheSample
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Engine e = ApplicationContext.Configure();

			//create an instance of "SomeAopTarget" through the aop container
<<<<<<< .mine
			SomeAopTarget myObj = e.CreateProxy<SomeAopTarget>();
=======
			SomeAopTarget myObj = e.CreateProxy(typeof (SomeAopTarget)) as SomeAopTarget;
>>>>>>> .r209

			for (int i=0;i<4;i++)
			{
				DateTime start = DateTime.Now;
				Console.WriteLine("starting to do some heavy calculation") ;
				double res= myObj.PerfromSomeReallyHeavyCalculation(50) ; //<-- just a normal call to our method
				Console.WriteLine(res) ;
				Console.WriteLine("heavy calculation done") ;
				DateTime end = DateTime.Now;
				Console.WriteLine("time to complete work: {0}",end.Subtract(start)  ) ;
			}

			Console.WriteLine("press any key to continue") ;
			Console.ReadLine() ;
		}
	}
}
