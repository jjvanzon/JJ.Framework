using JJ.Framework.Common;
using JJ.Framework.Testing;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Xml.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_ComplicatedExample
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_ComplicatedExample()
        {
            string xml = EmbeddedResourceHelper.GetEmbeddedResourceText(Assembly.GetExecutingAssembly(), "TestResources", "ComplicatedExample.xml"); ;
            var converter = new XmlToObjectConverter<ComplicatedElement>();
            ComplicatedElement destObject = converter.Convert(xml);
        }
    }
}
