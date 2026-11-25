namespace JJ.Framework.Xml.Legacy.Tests;

[TestClass]
public class XmlHelperTestsEx
{
    // SelectNode

    [TestMethod]
    public void Test_XmlHelper_SelectNode()
    {
        XmlNode elementNode = SelectNode(_root, "/root/simpleElement");
        IsNotNull(elementNode);
        AreEqual(typeof(XmlElement), elementNode.GetType());
    }

    [TestMethod]
    public void Test_XmlHelper_SelectNode_NonExistent_Throws() 
        => Throws(() => SelectNode(_root, "//nonExistent"), "does not exist");

    [TestMethod]
    public void Test_XmlHelper_SelectNode_Multiple_Throws() 
        => Throws(() => SelectNode(_root, "//nonUniqueElement"), "not unique");

    // TrySelectNode

    [TestMethod]
    public void Test_XmlHelper_TrySelectNode()
    {
        XmlNode elementNode = TrySelectNode(_root, "//simpleElement");
        IsNotNull(elementNode);
        AreEqual(typeof(XmlElement), elementNode.GetType());
    }

    [TestMethod]
    public void Test_XmlHelper_SelectNode_NonExistent_ReturnsNull()
    {
        XmlNode node = TrySelectNode(_root, "//@nonExistentAttribute");
        IsNull(node);
    }
    
    [TestMethod]
    public void Test_XmlHelper_TrySelectNode_Multiple_Throws() 
        => Throws(() => TrySelectNode(_root, "//nonUniqueElement"), "not unique");

    // GetElement

    [TestMethod]
    public void Test_XmlHelper_GetElement()
    {
        XmlElement element = GetElement(_root, "simpleElement");
        IsNotNull(element);
        AreEqual("simpleElement", element.Name);
    }

    [TestMethod]
    public void Test_XmlHelper_GetElement_NotFound_Exception() 
        => Throws(() => GetElement(_root, "nonExistentElement"), "does not contain");

    [TestMethod]
    public void Test_XmlHelper_GetElement_NotUnique_Exception()
        => Throws(() => GetElement(_root, "nonUniqueElement"), "found multiple times");

    // TryGetElement

    [TestMethod]
    public void Test_XmlHelper_TryGetElement()
    {
        XmlElement? element = TryGetElement(_root, "simpleElement");
        IsNotNull(element);
        AreEqual("simpleElement", element.Name);
    }

    [TestMethod]
    public void Test_XmlHelper_TryGetElement_NotFound_ReturnsNull()
    {
        XmlElement? element = TryGetElement(_root, "nonExistentElement");
        IsNull(element);
    }

    [TestMethod]
    public void Test_XmlHelper_TryGetElement_NotUnique_Exception() 
        => Throws(() => TryGetElement(_root, "nonUniqueElement"), "found multiple times");

    // GetElements

    [TestMethod]
    public void Test_XmlHelper_GetElements_None()
    {
        IList<XmlElement> elements = GetElements(_root, "nonExistentElement");
        IsNotNull(elements);
        AreEqual(0, elements.Count);
    }

    [TestMethod]
    public void Test_XmlHelper_GetElements_Single()
    {
        IList<XmlElement> elements = GetElements(_root, "simpleElement");
        IsNotNull(elements);
        AreEqual(1, elements.Count);
        IsNotNull(elements[0]);
        AreEqual("simpleElement", elements[0].Name);
    }

    [TestMethod]
    public void Test_XmlHelper_GetElements_Multiple()
    {
        IList<XmlElement> elements = GetElements(_root, "nonUniqueElement");
        IsNotNull(elements);
        AreEqual(2, elements.Count);
        IsNotNull(elements[0]);
        AreEqual("nonUniqueElement", elements[0].Name);
        IsNotNull(elements[1]);
        AreEqual("nonUniqueElement", elements[1].Name);
    }

    // GetAttribute

    [TestMethod]
    public void Test_XmlHelper_GetAttribute()
    {
        XmlAttribute attribute = GetAttribute(_root, "attribute");
        IsNotNull(attribute);
        AreEqual("attribute", attribute.Name);
    }

    [TestMethod]
    public void Test_XmlHelper_GetAttribute_NotFound_Exception() 
        => Throws(() => GetAttribute(_root, "nonExistentAttribute"), "does not contain");

    // TryGetAttribute
    
    [TestMethod]
    public void Test_XmlHelper_TryGetAttribute()
    {
        XmlAttribute attribute = TryGetAttribute(_root, "attribute");
        IsNotNull(attribute);
        AreEqual("attribute", attribute.Name);
    }

    [TestMethod]
    public void Test_XmlHelper_TryGetAttribute_NotFound_ReturnsNull()
    {
        XmlAttribute? attribute = TryGetAttribute(_root, "nonExistentAttribute");
        IsNull(attribute);
    }

    // GetAttributeValue

    [TestMethod]
    public void Test_XmlHelper_GetAttributeValue()
    {
        string value = GetAttributeValue(_root, "attribute");
        AreEqual("2", value);
    }

    [TestMethod]
    public void Test_XmlHelper_GetAttributeValue_NonExistent_Exception() 
        => Throws(() => GetAttributeValue(_root, "nonExistentAttribute"), "does not specify attribute");

    // TryGetAttributeValue

    [TestMethod]
    public void Test_XmlHelper_TryGetAttributeValue()
    {
        string value = TryGetAttributeValue(_root, "attribute");
        AreEqual("2", value);
    }

    [TestMethod]
    public void Test_XmlHelper_TryGetAttributeValue_NonExistent_Exception()
    {
        string value = TryGetAttributeValue(_root, "nonExistentAttribute");
        IsNullOrEmpty(value);
    }

    // SetAttributeValue

    [TestMethod]
    public void Test_XmlHelper_SetAttributeValue_AttributeExists()
    {
        XmlElement root = CreateRoot();
        {
            string value = TryGetAttributeValue(root, "attribute");
            AreEqual("2", value);
        }

        SetAttributeValue(root, "attribute", "3");
        {
            string value = TryGetAttributeValue(root, "attribute");
            AreEqual("3", value);
        }
    }

    [TestMethod]
    public void Test_XmlHelper_SetAttributeValue_AttributeDoesNotExist_Throws()
    {
        XmlElement root = CreateRoot();
        XmlElement element = GetElement(root, "simpleElement");
        string value = TryGetAttributeValue(element, "attribute");
        IsNullOrEmpty(value);
        Throws(() => SetAttributeValue(element, "attribute", "val"));
    }

    // Case Sensitivity

    [TestMethod]
    public void Test_XmlHelper_IsCaseSensitive()
    {
        Throws(() => GetElement(_root, "SIMPLEELEMENT"), "does not contain");

        XmlElement element = GetElement(_root, "simpleElement");
        IsNotNull(element);
    }

    // Helpers

    private static readonly XmlElement _root = CreateRoot();
    private static XmlElement CreateRoot()
    {
        string xml = EmbeddedResourceHelper.GetEmbeddedResourceText(Assembly.GetExecutingAssembly(), "TestResources", "ComplicatedExample.xml"); ;
        XmlDocument doc = new();
        doc.LoadXml(xml);
        return doc.DocumentElement;
    }
}