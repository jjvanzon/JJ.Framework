using JJ.Framework.Testing;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_ExplicitNames
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_ExplicitNames_Element()
        {
            string xml = @"
            <root>
                <Element_WithExplicitName>2</Element_WithExplicitName>
            </root>";

            var converter = new XmlToObjectConverter<Element_WithChildElement_WithExplicitName>();
            Element_WithChildElement_WithExplicitName destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.AreEqual(2, () => destObject.Element_WithExplicitName);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_ExplicitNames_Attribute()
        {
            string xml = @"<root Attribute_WithExplicitName=""2"" />";

            var converter = new XmlToObjectConverter<Element_WithAttribute_WithExplicitName>();
            Element_WithAttribute_WithExplicitName destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.AreEqual(2, () => destObject.Attribute_WithExplicitName);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_ExplicitNames_Array()
        {
            string xml = @"
            <root>
                <Array_WithExplicitName>
                    <item>0</item>
                    <item>1</item>
                </Array_WithExplicitName>
            </root>";

            var converter = new XmlToObjectConverter<Element_WithArray_WithExplicitName>();
            Element_WithArray_WithExplicitName destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.IsNotNull(() => destObject.Array_WithExplicitName);
            AssertExtended.AreEqual(2, () => destObject.Array_WithExplicitName.Length);
            AssertExtended.AreEqual(0, () => destObject.Array_WithExplicitName[0]);
            AssertExtended.AreEqual(1, () => destObject.Array_WithExplicitName[1]);
        }
    }
}
