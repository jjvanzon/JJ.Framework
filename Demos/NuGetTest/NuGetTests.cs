using System;
using System.Globalization;
using JJ.Framework.Common;
using JJ.Framework.Exceptions;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;
using JJ.Framework.Testing;
using JJ.Framework.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable UnusedVariable
#pragma warning disable 162
#pragma warning disable S1481 // Unused local variables should be removed

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
			CultureInfo result = CultureInfo_PlatformSafe.GetCultureInfo("nl-NL");
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Common()
		{
			string cultureName = CultureHelper.GetCurrentCultureName();
			Assert.IsNotNull(cultureName);
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Reflection()
		{
			var item = new Item();
			string text = ExpressionHelper.GetText(() => item.Child.Child);
			Assert.AreEqual("item.Child.Child", text);
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Exceptions()
		{
			var item = new Item();
			try
			{
				throw new NullOrWhiteSpaceException(() => item.Child);
			}
			catch (Exception ex)
			{
				Assert.AreEqual(typeof(NullOrWhiteSpaceException), ex.GetType());
				Assert.AreEqual("item.Child is null or white space.", ex.Message);

				return;
			}

			Assert.Fail("An exception should have been thrown.");
		}

		//[TestMethod]
		//public void Test_NuGetReference_JJ_Framework_Conversion()
		//{
		//	string str = "1234";
		//	int number = SimpleTypeConverter.ParseValue<int>(str);
		//	Assert.AreEqual(1234, number);
		//}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Testing()
		{
			var obj = new object();

			AssertHelper.ThrowsException(() => AssertHelper.IsNull(() => obj), "Assert.IsNull failed. Tested member: 'obj'.");
		}
	}
}