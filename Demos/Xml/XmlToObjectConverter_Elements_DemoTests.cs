using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_Elements_DemoTests
    {
        class MyRoot
        {
            public int MyElement { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_Elements()
        {
            const string xml = @"
                <root>
                  <myElement>3</myElement>
                </root>";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.AreEqual(3, () => root.MyElement);
        }
    }
}
