namespace JJ.Framework.Xml.Legacy.Tests;

[TestClass]
public class XmlHelperTestsEx
{
    [TestMethod]
    public void Test_XmlHelper_SelectNode()
    {
    }

    [TestMethod]
    public void Test_XmlHelper_TrySelectNode()
    {
    }

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
        => Throws(() => GetElement(_root, "nonExistent"), "does not contain");

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
        XmlElement? element = TryGetElement(_root, "nonExistent");
        IsNull(element);
    }

    [TestMethod]
    public void Test_XmlHelper_TryGetElement_NotUnique_Exception() 
        => Throws(() => TryGetElement(_root, "nonUniqueElement"), "found multiple times");

    // GetElements

    [TestMethod]
    public void Test_XmlHelper_GetElements_None()
    {
        IList<XmlElement> elements = GetElements(_root, "nonExistent");
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

    // Other

    [TestMethod]
    public void Test_XmlHelper_GetAttribute()
    {
    }

    [TestMethod]
    public void Test_XmlHelper_TryGetAttribute()
    {
    }

    [TestMethod]
    public void Test_XmlHelper_GetAttributeValue()
    {
    }

    [TestMethod]
    public void Test_XmlHelper_TryGetAttributeValue()
    {
    }

    [TestMethod]
    public void Test_XmlHelper_SetAttributeValue()
    {
    }

    private static readonly XmlElement _root = GetRootElement();
    private static XmlElement GetRootElement()
    {
        string xml = GetEmbeddedResourceText(GetExecutingAssembly(), "TestResources", "ComplicatedExample.xml"); ;
        XmlDocument doc = new();
        doc.LoadXml(xml);
        return doc.DocumentElement;
    }

}