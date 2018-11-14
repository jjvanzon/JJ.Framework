using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using JJ.Framework.Business;
using JJ.Framework.Collections;
using JJ.Framework.Common;
using JJ.Framework.Configuration;
using JJ.Framework.Conversion;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.IO;
using JJ.Framework.Mathematics;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Presentation;
using JJ.Framework.Reflection;
using JJ.Framework.Testing;
using JJ.Framework.Text;
using JJ.Framework.Xml;
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
			public Item Parent { get; set; }
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
			string text = ExpressionHelper.GetText(() => item.Parent.Parent);
			Assert.AreEqual("item.Parent.Parent", text);
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Exceptions()
		{
			var item = new Item();
			try
			{
				throw new NullOrWhiteSpaceException(() => item.Parent);
			}
			catch (Exception ex)
			{
				Assert.AreEqual(typeof(NullOrWhiteSpaceException), ex.GetType());
				Assert.AreEqual("item.Parent is null or white space.", ex.Message);

				return;
			}

			Assert.Fail("An exception should have been thrown.");
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Conversion()
		{
			string str = "1234";
			int number = SimpleTypeConverter.ParseValue<int>(str);
			Assert.AreEqual(1234, number);
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_Testing()
		{
			var obj = new object();

			AssertHelper.ThrowsException(() => AssertHelper.IsNull(() => obj), "Assert.IsNull failed. Tested member: 'obj'.");
		}

		[TestMethod]
		public void Test_NuGetReference_JJ_Framework_IO()
		{
			string csvText = "1234,2345,3456,4567,5678" + Environment.NewLine +
			                 "6789,7890,1234,2345,3456";

			using (Stream stream = StreamHelper.StringToStream(csvText, Encoding.UTF8))
			{
				using (var csvReader = new CsvReader(stream))
				{
					while (csvReader.Read())
					{
						string val1 = csvReader[0];
						string val2 = csvReader[1];
						string val3 = csvReader[2];
						string val4 = csvReader[3];
						string val5 = csvReader[4];
					}
				}
			}
		}

	    [TestMethod]
	    public void Test_NuGetReference_JJ_Framework_Collections()
	    {
	        var item = new Item { Parent = new Item() };

	        IList<Item> selfAndAncestors = item.SelfAndAncestors(x => x.Parent).ToArray();
	    }

	    [TestMethod]
	    public void Test_NuGetReference_JJ_Framework_Collections_BinarySearchInexactDeprecated()
	    {
	        var items = new[] { 2, 3, 5, 7, 11, 13, 17, 19 };
	        (int valueBefore, int valueAfter) = items.BinarySearchInexact(3);
	    }

        [TestMethod]
		public void Test_NuGetReference_JJ_Framework_Mathematics()
		{
			double hermite4Pt3oX = Interpolator.Hermite4pt3oX(0, 1, -2, -1, 0.231);
		}

        private class MyClass
        {
            [XmlAttribute]
            public int MyInt { get; set; }
        }

	    [TestMethod]
	    public void Test_NuGetReference_JJ_Framework_Xml()
	    {
	        string xml = @"<root myInt=""3"" />";
	        MyClass myObject = new XmlToObjectConverter<MyClass>().Convert(xml);
	    }

	    [TestMethod]
	    public void Test_NuGetReference_JJ_Framework_Configuration()
	    {
	        int value = AppSettingsReader<IMySettings>.Get(x => x.MySetting);
	        Assert.AreEqual(20, value);
	    }

	    [TestMethod]
	    public void Test_NuGetReference_JJ_Framework_Presentation()
	    {
	        PagerViewModel pagerViewModel = PagerViewModelFactory.Create(2, 10, 100, 5);
	    }

        [TestMethod]
        public void Test_NuGetReference_JJ_Framework_Business()
        {
            var result = new VoidResult();
        }
    }

    interface IMySettings
    {
        int MySetting { get; }
    }
}