using System.Xml.Serialization;
using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_CustomNamingForElements_DemoTests
    {
        private class MyRoot
        {
            [XmlElement("Elm")]
            public int MyElement { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_CustomNamingForElements()
        {
            const string xml = @"
                <root>
	              <Elm>3</Elm>
                </root>";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.AreEqual(3, () => root.MyElement);
        }
    }
}
