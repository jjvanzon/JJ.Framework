using JJ.Framework.Text;

namespace JJ.Demos.NuGetTest
{
	public class Class1
	{
		public void Test()
		{
			string str = "Something, something, blah, blah, blah.";
			str.TrimEnd("blah.");
		}
	}
}
