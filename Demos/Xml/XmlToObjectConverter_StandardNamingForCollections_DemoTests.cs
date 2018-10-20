using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_StandardNamingForCollections_DemoTests
    {
        class MyRoot
        {
            public int[] MyArray { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_StandardNamingForCollections()
        {
            const string xml = @"
                <root>
	              <myArray>
	                <int32>2</int32>
	                <int32>3</int32>
	                <int32>5</int32>
	              </myArray>
                </root>";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot root = converter.Convert(xml);

            AssertHelper.IsNotNull(() => root);
            AssertHelper.IsNotNull(() => root.MyArray);
            AssertHelper.AreEqual(3, () => root.MyArray.Length);
            AssertHelper.AreEqual(2, () => root.MyArray[0]);
            AssertHelper.AreEqual(3, () => root.MyArray[1]);
            AssertHelper.AreEqual(5, () => root.MyArray[2]);
        }
    }
}
