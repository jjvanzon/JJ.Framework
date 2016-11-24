using Puzzle.NAspect.Framework.Aop;

namespace ConsoleApplication1
{
	public interface IMyTestClass
	{
		[Aop()]
		void DoStuff1(out int a);

		[Aop()]
		int DoStuff2([Parameter()] int a);

		[Aop()]
		string DoStuff2(int a, [NotNullParameter()] string b);

		int SomeProperty { get; set; }
	}
}