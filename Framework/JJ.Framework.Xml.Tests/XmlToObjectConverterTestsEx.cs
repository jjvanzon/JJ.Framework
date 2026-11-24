namespace JJ.Framework.Xml.Legacy.Tests;

/// <inheritdoc cref="_xmltoobjectconvertertests_ex" />
[TestClass]
public class XmlToObjectConverterTestsEx
{
    // TODO: Check that it's culture insensitive.
    // TODO: Check that it's case sensitive.

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

    private class WithElementMarkedAsArray
    {
        [XmlElement]
        [XmlArray]
        public string ElementMarkedAsArray { get; set; } // ncrunch: no coverage
    }

    [TestMethod]
    public void Test_XmlToObjectConverter_Exception_ElementMarkedAsArray()
    {
        const string xml =
        """
        <root>
          <elementMarkedAsArray>Hello</elementMarkedAsArray>
        </root>
        """;
        
        var converter = new XmlToObjectConverter<WithElementMarkedAsArray>();
        
        Throws(() => converter.Convert(xml), "is an XML element", "cannot be marked with", "XmlArray");
    }

    private class WithRequiredAttribute
    {
        [XmlAttribute]
        public decimal RequiredAttribute { get; set; }
    }

    [TestMethod]
    public void Test_XmlToObjectConverter_Exception_RequiredAttributeMissing()
    {
        // Happy case
        {
            const string xml =
            """
            <root requiredAttribute="1.23" />
            """;
            
            var converter = new XmlToObjectConverter<WithRequiredAttribute>();
            
            WithRequiredAttribute obj = converter.Convert(xml);
            IsNotNull(obj);
            AreEqual(1.23m, obj.RequiredAttribute);
        }

        // Missing value
        {
            const string xml =
            """
            <root requiredAttribute="" />
            """;
            
            var converter = new XmlToObjectConverter<WithRequiredAttribute>();
            
            Throws(() => converter.Convert(xml), "required attribute");
        }

        // Missing attribute node
        {
            const string xml =
            """
            <root />
            """;
            
            var converter = new XmlToObjectConverter<WithRequiredAttribute>();
            
            Throws(() => converter.Convert(xml), "required attribute");
        }
    }

    private class WithRequiredElement
    {
        [XmlElement]
        public TimeSpan RequiredElement { get; set; }
    }
    
    [TestMethod]
    public void Test_XmlToObjectConverter_Exception_RequiredElementMissing()
    {
        // Happy case
        {
            const string xml =
            """
            <root>
              <requiredElement>7:30</requiredElement>
            </root>
            """;
            
            var converter = new XmlToObjectConverter<WithRequiredElement>();
            
            WithRequiredElement obj = converter.Convert(xml);
            IsNotNull(obj);
            AreEqual(7, obj.RequiredElement.Hours);
            AreEqual(30, obj.RequiredElement.Minutes);
        }

        // Missing value
        {
            const string xml =
            """
            <root>
              <requiredElement />
            </root>
            """;
            
            var converter = new XmlToObjectConverter<WithRequiredElement>();
            
            Throws(() => converter.Convert(xml), "not recognized as a valid TimeSpan");
        }

        // Missing element
        {
            const string xml =
            """
            <root />
            """;
            
            var converter = new XmlToObjectConverter<WithRequiredElement>();
            
            Throws(() => converter.Convert(xml), "does not have the required child element");
        }
    }

    private class WithUnsupportedCollectionType
    {
        [XmlArray]
        public int UnsupportedCollectionType { get; set; }
    }

    [TestMethod]
    public void Test_XmlToObjectConverter_Exception_UnsupportedCollectionType()
    { 
        const string xml =
        """
        <root>
          <unsupportedCollectionType>8</unsupportedCollectionType>
        </root>
        """;
            
        var converter = new XmlToObjectConverter<WithUnsupportedCollectionType>();
            
        Throws(() => converter.Convert(xml), "is an XML element");

    }
}