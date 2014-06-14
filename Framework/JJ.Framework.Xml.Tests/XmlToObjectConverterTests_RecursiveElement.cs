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
    public class XmlToObjectConverterTests_RecursiveElement
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_RecursiveElement()
        {
            string xml = @"
            <root>
                <element>
                    <element />
                </element>
            </root>";

            var converter = new XmlToObjectConverter<RecursiveElement>();
            RecursiveElement destObject = converter.Convert(xml);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.IsNotNull(() => destObject.Element);
            AssertExtended.IsNotNull(() => destObject.Element.Element);
        }
    }
}
