using System;
using Puzzle.NAspect.Framework;


namespace ConsoleApplication1
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Class1
	{
		public virtual void apa([Parameter()] int kalle)
		{
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			IEngine c = ApplicationContext.Configure();
			IMyTestClass t = c.CreateProxy(typeof (MyTestClass)) as IMyTestClass;


			int a = 6666;
			t.DoStuff1(out a);
			Console.WriteLine("a={0}", a);
			t.DoStuff2(1);
			t.DoStuff2(2);
			t.DoStuff2(3);
			t.DoStuff2(100, "hej");
			
			Console.WriteLine("done");
			Console.ReadLine();

		}

		private static void stuff_SomeEvent(object sender, EventArgs e)
		{
			Console.WriteLine("SomeEvent Fired");
		}
	}
}