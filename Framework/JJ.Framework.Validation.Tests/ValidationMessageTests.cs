namespace JJ.Framework.Validation.Legacy.Tests;

[TestClass]
public class ValidationMessageTests
{
    [TestMethod]
    public void Constructor_StoresProperties()
    {
        var msg = new ValidationMessage("MyKey", "MyText");
        AreEqual("MyKey", msg.PropertyKey);
        AreEqual("MyText", msg.Text);
    }

    [TestMethod]
    public void Constructor_Throws_WhenPropertyKeyIsNull()
        => Throws(() => new ValidationMessage(null, "text"), "propertyKey");

    [TestMethod]
    public void Constructor_Throws_WhenPropertyKeyIsEmpty()
        => Throws(() => new ValidationMessage("", "text"), "propertyKey");

    [TestMethod]
    public void Constructor_Throws_WhenTextIsNull()
        => Throws(() => new ValidationMessage("key", null), "text");

    [TestMethod]
    public void Constructor_Throws_WhenTextIsEmpty()
        => Throws(() => new ValidationMessage("key", ""), "text");
}
