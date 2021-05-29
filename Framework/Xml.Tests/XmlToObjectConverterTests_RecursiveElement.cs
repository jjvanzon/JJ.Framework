using JJ.Framework.Testing;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.IsNotNull(() => destObject.Element);
            AssertHelper.IsNotNull(() => destObject.Element.Element);
        }
    }
}
