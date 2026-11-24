namespace JJ.Framework.Xml.Legacy.Tests;

/// <inheritdoc cref="_xmltoobjectconvertertestsex" />
[TestClass]
public class XmlToObjectConverterTestsEx
{
    [TestMethod]
    public void Test_XmlToObjectConverter_WithBytes_ImplicitUTF8()
    {
        var converter = new XmlToObjectConverter<Element_WithAttribute<string>>();
        byte[] bytes = StringToBytes("<root attribute=\"Hi!\"/>", UTF8);
        var obj = converter.Convert(bytes);
        IsNotNull(obj);
        AreEqual("Hi!", obj.Attribute);
    }

    private class WithArrayMarkedAsElement
    {
        [XmlElement]
        public int[] ArrayNotElement { get; set; } // ncrunch: no coverage
    }

    [TestMethod]
    public void Test_XmlToObjectConverter_Exception_ArrayMarkedAsElement()
    {
        const string xml =
        """
        <root>
          <arrayNotElement>
            <int>1</int>
            <int>2</int>
          </arrayNotElement>
        </root>
        """;

        var converter = new XmlToObjectConverter<WithArrayMarkedAsElement>();

        Throws(() => converter.Convert(xml), "is an array", "cannot be marked with", "XmlElement", "Use XmlArray and XmlArrayItem instead.");
    }

    private class WithArrayMarkedAsAttribute
    {
        [XmlAttribute]
        public IList<int> ArrayNotAttribute { get; set; } // ncrunch: no coverage
    }

    [TestMethod]
    public void Test_XmlToObjectConverter_Exception_ArrayMarkedAsAttribute()
    {
        const string xml =
        """
        <root>
          <arrayNotAttribute>
            <int>3</int>
            <int>4</int>
          </arrayNotAttribute>
        </root>
        """;

        var converter = new XmlToObjectConverter<WithArrayMarkedAsAttribute>();

        Throws(() => converter.Convert(xml), "is an array", "cannot be marked with", "XmlAttribute", "Use XmlArray and XmlArrayItem instead.");
    }

    private class WithAttributeMarkedAsElement
    {
        [XmlElement]
        [XmlAttribute]
        public long AttributeMarkedAsElement { get; set; } // ncrunch: no coverage
    }

    [TestMethod]
    public void Test_XmlToObjectConverter_Exception_AttributeMarkedAsElement()
    {
        const string xml =
        """
        <root attributeMarkedAsElement="5">
          <attributeMarkedAsElement>6</attributeMarkedAsElement>
        </root>
        """;

        var converter = new XmlToObjectConverter<WithAttributeMarkedAsElement>();

        Throws(() => converter.Convert(xml), "is an XML attribute", "cannot be marked with XmlElement");
    }
}