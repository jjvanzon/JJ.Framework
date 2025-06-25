using JJ.Framework.Common;
using JJ.Framework.Testing;
using JJ.Framework.Xml.Linq.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Xml.Linq.Tests.Helpers;

namespace JJ.Framework.Xml.Linq.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_ComplicatedExample
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_ComplicatedExample()
        {
            string xml = EmbeddedResourceHelper.GetEmbeddedResourceText(Assembly.GetExecutingAssembly(), "TestResources", "ComplicatedExample.xml"); ;
            var converter = new XmlToObjectConverter<ComplicatedElement>(cultureInfo: TestHelper.FormattingCulture);
            ComplicatedElement destObject = converter.Convert(xml);
        }
    }
}
