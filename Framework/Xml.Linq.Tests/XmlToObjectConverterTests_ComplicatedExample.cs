using JJ.Framework.Common;
using JJ.Framework.Xml.Linq.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
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
