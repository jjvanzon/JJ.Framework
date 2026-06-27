namespace JJ.Framework.Mathematics.Legacy.Tests;

[TestClass]
public class RandomizerLegacyTests_TryGetRandomItem
{
    private const int REPEATS = 1000;

    // TryGetRandomItem (Values)

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromMultipleValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneValue()
    {
        int[] items = [ 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual(3, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNoValues_ReturnsDefault()
    {
        int[] items = [ ];
        // One might expect null, but it is 0.
        // Inconsistent with text types or reference types.
        int val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(0, val);
    }
    
    // TryGetRandomItem (Nullables)

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNullables()
    {
        int?[] items = [ 1, null, 2 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullable()
    {
        int?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual(null, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NullablesNone_ReturnsNull()
    {
        int?[] items = [ ];
        int? val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // TryGetRandomItem (Text)

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromMultipleTexts()
    {
        string[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneText()
    {
        string[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual("one", val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNoTexts_ReturnsNull()
    {
        string[] items = [];
        string? val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // TODO: From Ref Type (non-string): one set with nullable syntax, one without.
    // TODO: Test support for some different collection types.
    // TODO: Test params works everywhere it's declared.
    // TODO: Test null coll not allowed.
    // TODO: Try should probably be reworked and not return 0 and allow more nulls (e.g. null coll) for developer sanity.
    // TODO: (No)NullRet checks.
    // TODO: Split over multiple files.
}