namespace JJ.Framework.Validation.Legacy.Tests;

[TestClass]
public class ValidationMessagesTests
{
    private class MyModel { public string Name { get; } = "Value"; }

    [TestMethod]
    public void Add_ByKey_IncrementsCount()
    {
        var messages = new ValidationMessages();
        messages.Add("key", "text");
        AreEqual(1, messages.Count);
    }

    [TestMethod]
    public void Add_ByExpression_ExtractsPropertyKey()
    {
        var messages = new ValidationMessages();
        var model = new MyModel();
        messages.Add(() => model.Name, "error");
        AreEqual("Name", messages[0].PropertyKey);
        AreEqual("error", messages[0].Text);
    }

    [TestMethod]
    public void Indexer_ReturnsCorrectMessage()
    {
        var messages = new ValidationMessages();
        messages.Add("k", "t");
        AreEqual("k", messages[0].PropertyKey);
        AreEqual("t", messages[0].Text);
    }

    [TestMethod]
    public void GetEnumerator_IteratesAllMessages()
    {
        var messages = new ValidationMessages();
        messages.Add("k1", "t1");
        messages.Add("k2", "t2");
        AreEqual(2, messages.ToList().Count);
    }

    [TestMethod]
    public void AddRange_AddsAllMessages()
    {
        var target = new ValidationMessages();
        var source = new ValidationMessages();
        source.Add("k1", "t1");
        source.Add("k2", "t2");
        target.AddRange(source);
        AreEqual(2, target.Count);
    }
}
