using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable ClassNeverInstantiated.Local

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_NullabilityForValueTypes_IsNull_DemoTests
    {
        class MyRoot
        {
            // The '?' makes it OK to leave out the XML element.
            public int? MyElement { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_NullabilityForValueTypes_IsNull()
        {
            const string xml = @"
	            <myRoot>
	              <!-- myElement van be left out. Then MyElement in the C# code will be null. -->
	            </myRoot>
                ";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.IsNull(() => root.MyElement);
        }
    }
}
