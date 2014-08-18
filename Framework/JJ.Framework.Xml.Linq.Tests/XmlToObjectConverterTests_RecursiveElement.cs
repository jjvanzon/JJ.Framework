using JJ.Framework.Testing;
using JJ.Framework.Xml.Linq.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Xml.Linq.Tests.Helpers;

namespace JJ.Framework.Xml.Linq.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_RecursiveElement
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_RecursiveElement()
        {
            string xml = @"
            <root>
                <element>
                    <element />
                </element>
            </root>";

            var converter = new XmlToObjectConverter<RecursiveElement>(cultureInfo: TestHelper.FormattingCulture);
            RecursiveElement destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.IsNotNull(() => destObject.Element);
            AssertHelper.IsNotNull(() => destObject.Element.Element);
        }
    }
}
