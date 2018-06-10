using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
// ReSharper disable UnusedVariable

namespace JJ.Framework.Xml.Linq.Tests
{
	[TestClass]
	public class XContainerTests
	{
		[TestMethod]
		public void Test_XContainer_Element_None_ReturnsNull()
		{
			var xml = @"
				<root>
				</root>";

			XElement root = XElement.Parse(xml);

			XElement element = root.Element("x");
		}

		[TestMethod]
		public void Test_XContainer_Element_Single_ReturnsOne()
		{
			var xml = @"
				<root>
					<x />
				</root>";

			XElement root = XElement.Parse(xml);

			XElement element = root.Element("x");
		}

		[TestMethod]
		public void Test_XContainer_Element_Multiple_ReturnsOne()
		{
			var xml = @"
				<root>
					<x />
					<x />
				</root>";

			XElement root = XElement.Parse(xml);

			XElement element = root.Element("x");
		}
	}
}
