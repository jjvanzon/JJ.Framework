using System;
using JJ.Framework.Testing;
using JJ.Framework.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Local
// ReSharper disable ArrangeTypeMemberModifiers

namespace JJ.Demos.Xml
{
    [TestClass]
    public class XmlToObjectConverter_ParameterlessConstructors_DemoTests
    {
        class MyRoot
        {
            public MyClass MyObject { get; set; }
        }

        class MyClass
        {
            // Having this constructor with a parameter causes an exception.
            public MyClass(int myConstructorParameter) { }
        }

        [TestMethod]
        public void Demo_XmlToObjectConverter_ParameterlessConstructors()
        {
            const string xml = @"
                <root>
                    <myObject />
                </root>";

            var converter = new XmlToObjectConverter<MyRoot>();

            AssertHelper.ThrowsException<MissingMethodException>(
                () => converter.Convert(xml),
                "No parameterless constructor defined for this object.");
        }
    }
}