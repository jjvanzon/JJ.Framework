using System.Collections;
using System.Globalization;
using System.Linq;
using JJ.Framework.Testing;
using JJ.Framework.Xml.Linq.Tests.Mocks;

namespace JJ.Framework.Xml.Linq.Tests.Helpers
{
    internal static class TestHelper
    {
        public static CultureInfo FormattingCulture { get; } = new CultureInfo("en-US");

        public static void Test_XmlToObjectConverter_SimpleElement_WithChildValue<T>(string textValue, T value)
        {
            string xml = @"
			<root>
				<simpleType>" +
                         textValue +
                         @"</simpleType>
			</root>";

            var converter = new XmlToObjectConverter<Element_WithChildElement_OfSimpleType<T>>(cultureInfo: FormattingCulture);
            Element_WithChildElement_OfSimpleType<T> destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.AreEqual(value, () => destObject.SimpleType);
        }

        /// <summary>
        /// Make sure the items of the collection are int.
        /// </summary>
        public static void Test_XmlToObjectConverter_Collection<TCollection>()
            where TCollection : IEnumerable
        {
            var xml = @"
			<root>
				<collection>
					<item>0</item>
					<item>1</item>
				</collection>
			</root>";

            var converter = new XmlToObjectConverter<Element_WithCollection<TCollection>>(cultureInfo: FormattingCulture);
            Element_WithCollection<TCollection> destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.IsNotNull(() => destObject.Collection);
            AssertHelper.AreEqual(2, () => destObject.Collection.Cast<int>().Count());
            AssertHelper.AreEqual(0, () => destObject.Collection.Cast<int>().ElementAt(0));
            AssertHelper.AreEqual(1, () => destObject.Collection.Cast<int>().ElementAt(1));
        }
    }
}