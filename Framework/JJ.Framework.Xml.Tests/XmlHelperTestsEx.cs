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
        XmlElement el = GetElement(_root, "simpleElement");
        IsNotNull(el);
        AreEqual("simpleElement", el.Name);
    }

    [TestMethod]
    public void Test_XmlHelper_GetElement_NotFound_Exception()
    {
        Throws(() => GetElement(_root, "nonExistent"), "does not contain");
    }

    [TestMethod]
    public void Test_XmlHelper_GetElement_NotUnique_Exception()
    {
        Throws(() => GetElement(_root, "nonUniqueElement"), "found multiple times");
    }

    // Other

    [TestMethod]
    public void Test_XmlHelper_TryGetElement()
    {
    }

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