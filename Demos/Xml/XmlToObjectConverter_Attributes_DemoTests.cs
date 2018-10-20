using System.Xml.Serialization;
using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_Attributes_DemoTests
    {
        class MyRoot
        {
            [XmlAttribute]
            public int MyAttribute { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_Attributes()
        {
            const string xml = @"
                <root 
                  myAttribute=""3"" 
                />";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.AreEqual(3, () => root.MyAttribute);
        }
    }
}
