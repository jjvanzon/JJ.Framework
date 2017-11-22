using JJ.Framework.Testing;
using JJ.Framework.Xml.Linq.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Xml.Linq.Tests.Helpers;

namespace JJ.Framework.Xml.Linq.Tests
{
	[TestClass]
	public class XmlToObjectConverterTests_Collections
	{
		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_Array()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<int[]>();
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_ListOfT()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<List<int>>();
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_IListOfT()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<IList<int>>();
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_ICollectionOfT()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<ICollection<int>>();
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_IEnumerableOfT()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<IEnumerable<int>>();
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Array_WithExplicitAnnotation()
		{
			string xml = @"
			<root>
				<array_WithExplicitAnnotation>
					<item>0</item>
					<item>1</item>
				</array_WithExplicitAnnotation>
			</root>";

			var converter = new XmlToObjectConverter<Element_Array_WithExplicitAnnotation>(cultureInfo: TestHelper.FormattingCulture);
			Element_Array_WithExplicitAnnotation destObject = converter.Convert(xml);

			AssertHelper.IsNotNull(() => destObject);
			AssertHelper.IsNotNull(() => destObject.Array_WithExplicitAnnotation);
			AssertHelper.AreEqual(2, () => destObject.Array_WithExplicitAnnotation.Length);
			AssertHelper.AreEqual(0, () => destObject.Array_WithExplicitAnnotation[0]);
			AssertHelper.AreEqual(1, () => destObject.Array_WithExplicitAnnotation[1]);
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_Nullability()
		{
			string xml = @"<root />";

			var converter = new XmlToObjectConverter<Element_WithCollection<int[]>>(cultureInfo: TestHelper.FormattingCulture);
			Element_WithCollection<int[]> destObject = converter.Convert(xml);

			AssertHelper.IsNotNull(() => destObject);
			AssertHelper.IsNull(() => destObject.Collection);
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_WithoutExplicitItemName()
		{
			string xml = @"
			<root>
				<collection>
					<int32>0</int32>
					<int32>1</int32>
				</collection>
			</root>";

			var converter = new XmlToObjectConverter<Element_WithCollection_WithoutExplicitItemName>(cultureInfo: TestHelper.FormattingCulture);
			Element_WithCollection_WithoutExplicitItemName destObject = converter.Convert(xml);

			AssertHelper.IsNotNull(() => destObject);
			AssertHelper.IsNotNull(() => destObject.Collection);
			AssertHelper.AreEqual(2, () => destObject.Collection.Count());
			AssertHelper.AreEqual(0, () => destObject.Collection.ElementAt(0));
			AssertHelper.AreEqual(1, () => destObject.Collection.ElementAt(1));
		}

		// It is not possible to support non-generic collection types,
		// because then you have no idea to which item type the elements map.

		/*
		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_IList()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<IList>();
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_ICollection()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<ICollection>();
		}

		[TestMethod]
		public void Test_XmlToObjectConverter_Collection_IEnumerable()
		{
			TestHelper.Test_XmlToObjectConverter_Collection<IEnumerable>();
		}
		*/
	}
}
