using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_ParameterlessConstructors_DemoTests
    {
        class MyClass
        {
            // Having this constructor with a constructor parameter causes an exception.
            public MyClass(int myConstructorParameter) { }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_ParameterlessConstructors()
        {
            const string xml = @"<myClass />";

            // Compiler error because there is no parameterless constructor.
            //var converter = new XmlToObjectConverter<MyClass>();
        }
    }
}