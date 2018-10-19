using System.Xml.Serialization;
using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_CompositeTypes_DemoTests
    {
        class MyRoot
        {
            public MyClass MyObject1 { get; set; }
            public MyClass MyObject2 { get; set; }
        }

        class MyClass
        {
            [XmlAttribute]
            public string Name { get; set; }

            [XmlAttribute]
            public int? Value { get; set; }

            [XmlArrayItem("item")]
            public MyClass[] MyArray { get; set; }

            public MyClass ChildItem { get; set; }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_CompositeTypes()
        {
            const string xml = @"
		        <myRoot>
	              <myObject1 value=""3"" />
	              <myObject2>
		            <myArray>
		              <item name=""Name1"" value=""1"" />
		              <item name=""Name2"" value=""2"" >
		                <childItem name=""Child"" value=""3"" />
		              </item>
		            </myArray>
	              </myObject2>
	            </myRoot>
                ";

            var converter = new XmlToObjectConverter<MyRoot>();
            MyRoot myRoot = converter.Convert(xml);

            AssertHelper.IsNotNull(() => myRoot);
            AssertHelper.IsNotNull(() => myRoot.MyObject1);
            AssertHelper.AreEqual(3, () => myRoot.MyObject1.Value);
            AssertHelper.IsNotNull(() => myRoot.MyObject2);
            AssertHelper.IsNotNull(() => myRoot.MyObject2.MyArray);
            AssertHelper.AreEqual(2, () => myRoot.MyObject2.MyArray.Length);

            AssertHelper.IsNotNull(() => myRoot.MyObject2.MyArray[0]);
            AssertHelper.AreEqual("Name1", () => myRoot.MyObject2.MyArray[0].Name);
            AssertHelper.AreEqual(1, () => myRoot.MyObject2.MyArray[0].Value);

            AssertHelper.IsNotNull(() => myRoot.MyObject2.MyArray[1]);
            AssertHelper.AreEqual("Name2", () => myRoot.MyObject2.MyArray[1].Name);
            AssertHelper.AreEqual(2, () => myRoot.MyObject2.MyArray[1].Value);

            AssertHelper.IsNotNull(() => myRoot.MyObject2.MyArray[1].ChildItem);
            AssertHelper.AreEqual("Child",  () => myRoot.MyObject2.MyArray[1].ChildItem.Name);
            AssertHelper.AreEqual(3,  () => myRoot.MyObject2.MyArray[1].ChildItem.Value);
        }
    }
}
