using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable ClassNeverInstantiated.Local

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_NullabilityForReferenceTypes_DemoTests
    {
        class MyRoot
        {
            // Can be null
            public MyClass MyObject { get; set; }
        }

        class MyClass
        {
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_NullabilityForReferenceTypes()
        {
            const string xml = @"
	            <myRoot>
	              <!-- No myObject element here, so the MyObject property in C# will be null. -->
	            </myRoot>
                ";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.IsNull(() => root.MyObject);
        }
    }
}
