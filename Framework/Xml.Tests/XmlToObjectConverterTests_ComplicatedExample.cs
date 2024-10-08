﻿using JJ.Framework.Common;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
// ReSharper disable UnusedVariable

namespace JJ.Framework.Xml.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_ComplicatedExample
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_ComplicatedExample()
        {
            string xml = EmbeddedResourceReader.GetText(Assembly.GetExecutingAssembly(), "TestResources", "ComplicatedExample.xml");
            var converter = new XmlToObjectConverter<ComplicatedElement>();
            ComplicatedElement destObject = converter.Convert(xml);
        }
    }
}
