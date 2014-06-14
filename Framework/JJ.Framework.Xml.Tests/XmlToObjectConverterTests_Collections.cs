using JJ.Framework.Testing;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Xml.Tests.Helpers;
using System.Collections;

namespace JJ.Framework.Xml.Tests
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

            var converter = new XmlToObjectConverter<Element_Array_WithExplicitAnnotation>();
            Element_Array_WithExplicitAnnotation destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.IsNotNull(() => destObject.Array_WithExplicitAnnotation);
            AssertExtended.AreEqual(2, () => destObject.Array_WithExplicitAnnotation.Length);
            AssertExtended.AreEqual(0, () => destObject.Array_WithExplicitAnnotation[0]);
            AssertExtended.AreEqual(1, () => destObject.Array_WithExplicitAnnotation[1]);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_Collection_Nullability()
        {
            string xml = @"<root />";

            var converter = new XmlToObjectConverter<ElementWithCollection<int[]>>();
            ElementWithCollection<int[]> destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.IsNull(() => destObject.Collection);
        }
    }
}
