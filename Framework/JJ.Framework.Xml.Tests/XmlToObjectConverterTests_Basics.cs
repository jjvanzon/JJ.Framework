﻿using JJ.Framework.Testing;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_Basics
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_Basics_SimpleElement()
        {
            string xml = @"
            <root>
                <simpleElement>2</simpleElement>
            </root>";

            var converter = new XmlToObjectConverter<Element_WithSimpleChildElement>();
            Element_WithSimpleChildElement destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.AreEqual(2, () => destObject.SimpleElement);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_Basics_ElementWithExplicitAnnotation()
        {
            string xml = @"
            <root>
                <element_WithExplicitAnnotation>2</element_WithExplicitAnnotation>
            </root>";

            var converter = new XmlToObjectConverter<Element_WithChildElement_WithExplicitAnnotation>();
            Element_WithChildElement_WithExplicitAnnotation destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.AreEqual(2, () => destObject.Element_WithExplicitAnnotation);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_Basics_Attribute()
        {
            string xml = @"<root attribute=""2"" />";

            var converter = new XmlToObjectConverter<Element_WithAttribute<int>>();
            Element_WithAttribute<int> destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.AreEqual(2, () => destObject.Attribute);
        }
    }
}
