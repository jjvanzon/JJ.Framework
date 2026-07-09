#pragma warning disable IDE0028 // Use collection initializer
// ReSharper disable UseObjectOrCollectionInitializer

namespace JJ.Framework.Validation.Legacy.Tests;

#if !NET9_0_OR_GREATER
[Suppress("Trimmer", "IL2026", Justification = WhenShowIndexerValues)]
#endif
[TestClass]
public class ValidationMessagesTests
{
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
        var model = new SimpleModel();
        messages.Add(() => model.Name, "error");
        AreEqual("Name", messages[0].PropertyKey);
        AreEqual("error", messages[0].Text);
    }

    [TestMethod]
    public void Indexer_ReturnsCorrectMessage()
    {
        var messages = new ValidationMessages();
        messages.Add("key", "text");
        AreEqual("key", messages[0].PropertyKey);
        AreEqual("text", messages[0].Text);
    }

    [TestMethod]
    public void GetEnumerator_IteratesAllMessages()
    {
        var messages = new ValidationMessages();
        messages.Add("key1", "text1");
        messages.Add("key2", "text2");
        AreEqual(2, messages.ToList().Count);
    }

    [TestMethod]
    public void AddRange_AddsAllMessages()
    {
        var target = new ValidationMessages();
        var source = new ValidationMessages();
        source.Add("key1", "text1");
        source.Add("key2", "text2");
        target.AddRange(source);
        AreEqual(2, target.Count);
    }

    [TestMethod]
    public void GetEnumerator_Untyped()
    {
        var messages = new ValidationMessages();
        messages.Add("key1", "text1");
        messages.Add("key2", "text2");

        IEnumerable untypedEnumerable = messages;

        var count = 0;
        foreach (object item in untypedEnumerable) 
        {
            IsNotNull(item);
            AreEqual(typeof(ValidationMessage), item.GetType());
            count++;
        }
        AreEqual(2, count);
    }

    [TestMethod]
    public void GetEnumerator_Typed()
    {
        var messages = new ValidationMessages();
        messages.Add("key1", "text1");
        messages.Add("key2", "text2");

        IEnumerable<ValidationMessage> typedEnumerable = messages;

        var count = 0;
        foreach (ValidationMessage item in typedEnumerable) 
        { 
            IsNotNull(item);
            count++;
        }
        AreEqual(2, count);
    }

    [TestMethod]
    public void DebuggerDisplay_ReturnsCorrectString()
    {
        var messages = new ValidationMessages();
        messages.Add("key1", "text1");
        messages.Add("key2", "text2");

        var accessor = new Accessor(messages, typeof(ValidationMessages));
        var debuggerDisplay = accessor.GetPropertyValue("DebuggerDisplay");

        var expected = "key1: text1" + NewLine + "key2: text2";
        AreEqual(expected, debuggerDisplay);
    }
}
