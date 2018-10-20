using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_NullabilityForCollections_DemoTests
    {
        class MyRoot
        {
            public int[] MyArray { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_NullabilityForCollections_IsNull()
        {
            const string xml = @"
	            <myRoot>
	              <!-- myArray can be left out, but then MyArray in the C# code will be null. -->
	            </myRoot>
                ";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.IsNull(() => root.MyArray);
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_NullabilityForCollections_NotNull()
        {
            const string xml = @"
	            <myRoot>
	              <!-- MyArray in the C# code will not be null, but an empty collection. -->
	              <myArray />
	            </myRoot>
                ";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.IsNotNull(() => root.MyArray);
        }
    }
}
