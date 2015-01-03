using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using JJ.Framework.Xml.Tests.Mocks;
using JJ.Framework.Testing;

namespace JJ.Framework.Xml.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_Other
    {
        /*
        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleElement()
        {
            string xml = @"
            <root>
                <simpleElement>2</simpleElement>
            </root>";

            var sourceDoc = new XmlDocument();
            sourceDoc.LoadXml(xml);

            var converter = new XmlToObjectConverter<ComplicatedElement>();
            ComplicatedElement destObject = converter.Convert(sourceDoc);

            AssertExtended.IsNotNull(() => destObject);
            AssertExtended.AreEqual(2, () => destObject.SimpleElement);
        }
        */
    }
}
