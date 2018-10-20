using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_StandardNaming_DemoTests
    {
        class MyRoot
        {
            public int MyElement { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_StandardNaming()
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
