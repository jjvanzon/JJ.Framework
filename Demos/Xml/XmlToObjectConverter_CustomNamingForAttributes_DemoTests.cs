using System.Xml.Serialization;
using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_CustomNamingForAttributes_DemoTests
    {
        class MyRoot
        {
            [XmlAttribute("Attr")]
            public int MyAttribute { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_CustomNamingForAttributes()
        {
            const string xml = @"<root Attr=""3"" />";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.AreEqual(3, () => root.MyAttribute);
        }
    }
}
