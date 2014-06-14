using JJ.Framework.Testing;
using JJ.Framework.Xml.Tests.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JJ.Framework.Xml.Tests.Helpers
{
    internal static class TestHelper
    {
        public static void Test_XmlToObjectConverter_SimpleElement_WithChildValue<T>(string textValue, T value)
        {
            string xml = @"
            <root>
                <simpleType>" + textValue + @"</simpleType>
            </root>";

            var converter = new XmlToObjectConverter<Element_WithChildElement_OfSimpleType<T>>();
            Element_WithChildElement_OfSimpleType<T> destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.AreEqual(value, () => destObject.SimpleType);
        }

        /// <summary>
        /// Make sure the items of the collection are int.
        /// </summary>
        public static void Test_XmlToObjectConverter_Collection<TCollection>()
            where TCollection : IEnumerable
        {
            string xml = @"
            <root>
                <collection>
                    <item>0</item>
                    <item>1</item>
                </collection>
            </root>";

            var converter = new XmlToObjectConverter<ElementWithCollection<TCollection>>();
            ElementWithCollection<TCollection> destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.IsNotNull(() => destObject.Collection);
            AssertExtended.AreEqual(2, () => destObject.Collection.Cast<int>().Count());
            AssertExtended.AreEqual(0, () => destObject.Collection.Cast<int>().ElementAt(0));
            AssertExtended.AreEqual(1, () => destObject.Collection.Cast<int>().ElementAt(1));
        }
    }
}
