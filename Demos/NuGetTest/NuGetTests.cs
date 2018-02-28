using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;
using JJ.Framework.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S1481 // Unused local variables should be removed
// ReSharper disable UnusedVariable

namespace JJ.Demos.NuGetTest
{
	[TestClass]
	public class NuGetTests
	{
		private class Item
		{
			public Item Child { get; set; }
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Text()
		{
			const string str = "Something, something, blah, blah, blah.";
			string right = str.Right(3);
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_PlatformCompatibility()
		{
			string[] strings = { "Something", "something", "blah", "blah", "blah." };
			string joined = String_PlatformSupport.Join(", ", strings);
		}

		[TestMethod]
		public void Test_NuGetReferences_JJ_Framework_Reflection()
		{
			var item = new Item();
			string text = ExpressionHelper.GetText(() => item.Child.Child);
			Assert.AreEqual("item.Child.Child", text);
		}
	}
}
