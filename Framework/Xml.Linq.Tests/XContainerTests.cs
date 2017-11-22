using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace JJ.Framework.Xml.Linq.Tests
{
	[TestClass]
	public class XContainerTests
	{
		[TestMethod]
		public void Test_XContainer_Element_None_ReturnsNull()
		{
			string xml = @"
				<root>
				</root>";

			XElement root = XElement.Parse(xml);

			XElement element = root.Element("x");
		}

		[TestMethod]
		public void Test_XContainer_Element_Single_ReturnsOne()
		{
			string xml = @"
				<root>
					<x />
				</root>";

			XElement root = XElement.Parse(xml);

			XElement element = root.Element("x");
		}

		[TestMethod]
		public void Test_XContainer_Element_Multiple_ReturnsOne()
		{
			string xml = @"
				<root>
					<x />
					<x />
				</root>";

			XElement root = XElement.Parse(xml);

			XElement element = root.Element("x");
		}
	}
}
