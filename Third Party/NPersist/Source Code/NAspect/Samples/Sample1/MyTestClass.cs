using System;
using Puzzle.NAspect.Framework.Aop;

namespace ConsoleApplication1
{
	[Aop()]
	public class MyTestClass : IMyTestClass
	{
		public MyTestClass()
		{
			DoStuff3();
		}

		[Aop()]
		public virtual void DoStuff1(out int a)
		{
			a = 555111;
			Console.WriteLine("inside dostuff1");
			DoStuff3();
		}

		[Aop()]
		public virtual int DoStuff2([Parameter()] int a)
		{
			Console.WriteLine("inside dostuff2 a");
			return 6;
		}

		[Aop()]
		public virtual string DoStuff2(int a, [NotNullParameter()] string b)
		{
			Console.WriteLine("inside dostuff2 a b");
			return b;
		}


		[Aop()]
		protected virtual void DoStuff3()
		{
			Console.WriteLine("inside dostuff3");
		}

		private int someProperty;

		public virtual int SomeProperty
		{
			get { return this.someProperty; }
			set { this.someProperty = value; }
		}
	}

	public interface IEventStuff
	{
		event EventHandler SomeEvent;
		void RaiseSomeEvent();
	}

	public class EventStuffMixin : IEventStuff
	{
		public event EventHandler SomeEvent;

		public void RaiseSomeEvent()
		{
			if (SomeEvent != null)
				SomeEvent(this, EventArgs.Empty);
		}
	}
}