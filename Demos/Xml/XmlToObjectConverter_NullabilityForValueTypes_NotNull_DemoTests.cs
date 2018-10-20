using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable ClassNeverInstantiated.Local

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_NullabilityForValueTypes_NotNull_DemoTests
    {
        class MyRoot
        {
            // Without the '?' the XML element is required.
            public int MyElement { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_NullabilityForValueTypes_NotNull()
        {
            const string xml = @"
	            <myRoot>
	              <!-- myElement is required, otherwise you will get an exception. -->
	              <myElement>3</myElement>
	            </myRoot>
                ";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.AreEqual(3, () => root.MyElement);
        }
    }
}
