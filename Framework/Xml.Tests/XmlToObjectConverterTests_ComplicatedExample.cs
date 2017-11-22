using JJ.Framework.Common;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

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
