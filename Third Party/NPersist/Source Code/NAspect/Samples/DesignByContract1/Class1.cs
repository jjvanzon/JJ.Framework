using System;
using Puzzle.NAspect.Framework;

namespace DesignByContract1
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
			IEngine c = ApplicationContext.Configure();
			SomeAopTarget target = (SomeAopTarget)c.CreateProxy(typeof(SomeAopTarget));
			target.ReturnAString(0) ; 
			target.ReturnAString(1) ; //fails since method tries to return null
			target.ReceiveAString(10,"hello") ;
			target.ReceiveAString(10,null) ; //fails since "def" may not be null

		}
	}
}
