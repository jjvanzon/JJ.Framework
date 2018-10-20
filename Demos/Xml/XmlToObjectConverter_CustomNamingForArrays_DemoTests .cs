using System.Xml.Serialization;
using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_CustomNamingForArrays_DemoTests
    {
        class MyRoot
        {
            [XmlArray("Arr")]
            [XmlArrayItem("Item")]
            public int[] MyArray { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_CustomNamingForArrays()
        {
            const string xml = @"
                <root>
	              <Arr>
	                <Item>2</Item>
	                <Item>3</Item>
	                <Item>5</Item>
	              </Arr>
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
