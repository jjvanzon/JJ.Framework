// ReSharper disable ExpressionIsAlwaysNull
namespace JJ.Framework.Mathematics.Legacy.Tests;

using static RandomizerLegacy;

[TestClass]
public class RandomizerLegacyTests_GetRandomItem
{
    private const int REPEATS = 100;
    
    private static readonly CultureInfo _nlNL = GetCultureInfo("nl-NL");
    private static readonly CultureInfo _enUS = GetCultureInfo("en-US");
    private static readonly CultureInfo _zhCN = GetCultureInfo("zh-CN");

    // Values

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneValue()
    {
        int[] items = [ 42 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetRandomItem(items);
            AreEqual(42, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NoValues_NotAllowed()
    {
        int[] items = [ ];
        Throws(() => GetRandomItem(items));
    }

    // Nullables

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNullableFilledValues_Allowed()
    {
        int?[] items = [ 1, 2, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_AllowsNullValues()
    {
        int?[] items = [ 1, null, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNull()
    {
        int?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            AreEqual(null, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNulllyFilled()
    {
        int?[] items = [ 1 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            AreEqual(1, val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_Nullables_None_NotAllowed()
    {
        int?[] items = [ ];
        Throws(() => GetRandomItem(items));
    }

    // Text

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromTexts()
    {
        string[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneText()
    {
        string[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = GetRandomItem(items);
            AreEqual("one", val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNoTexts_Throws()
    {
        string[] items = [];
        Throws(() => GetRandomItem(items));
    }

    // Nullable Text

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNullableTexts()
    {
        string?[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_AllowsNullText()
    {
        string?[] items = [ "one", null, "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullText()
    {
        string?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            AreEqual(null, val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullyFilledText()
    {
        string?[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            AreEqual("one", val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NullableTexts_None_Throws()
    {
        string?[] items = [];
        Throws(() => GetRandomItem(items));
    }

    // Objects

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromObjects()
    {
        CultureInfo[] objects = [ _nlNL, _enUS, _zhCN ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo obj = GetRandomItem(objects);
            IsTrue(objects.Contains(obj));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneObject()
    {
        CultureInfo[] objects = [ _nlNL ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo obj = GetRandomItem(objects);
            AreEqual(_nlNL, obj);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NoObjects_Throws()
    {
        CultureInfo[] objects = [];
        Throws(() => GetRandomItem(objects));
    }

    // Nullable Object

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNullableObjects()
    {
        CultureInfo?[] objects = [ _nlNL, _enUS, _zhCN ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = GetRandomItem(objects);
            IsTrue(objects.Contains(obj));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_AllowsNullObject()
    {
        CultureInfo?[] objects = [ _nlNL, null, _zhCN ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = GetRandomItem(objects);
            IsTrue(objects.Contains(obj));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullObject()
    {
        CultureInfo?[] objects = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = GetRandomItem(objects);
            AreEqual(null, obj);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullyFilledObject()
    {
        CultureInfo?[] objects = [ _nlNL ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = GetRandomItem(objects);
            AreEqual(_nlNL, obj);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NullableObjects_None_Throws()
    {
        CultureInfo?[] objects = [];
        Throws(() => GetRandomItem(objects));
    }

    // Null Collections

    [TestMethod]
    public void Test_Legacy_GetRandomItem_ValueCollectionNull_Throws()
    {
        int[]? collection = null;
        Throws(() => GetRandomItem(collection));
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NullCollectionOfNullables_Throws()
    {
        int?[]? collection = null;
        Throws(() => GetRandomItem(collection));
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_ObjectCollectionNull_Throws()
    {
        CultureInfo[]? collection = null;
        Throws(() => GetRandomItem(collection));
    }

    // Collection Types

    [TestMethod]
    public void Test_Legacy_GetRandomItem_CollectionTypes()
    {
        {
            IList<int> list = new List<int> { 1, 2, 3 };
            for (int i = 0; i < REPEATS; i++)
            {
                int val = GetRandomItem(list);
                IsTrue(list.Contains(val));
            }
        }
        {
            List<int?> list = [ 1, 2, 3 ];
            for (int i = 0; i < REPEATS; i++)
            {
                int? val = GetRandomItem(list);
                IsTrue(list.Contains(val));
            }
        }
        {
            var stack = new Stack<CultureInfo?>([ _nlNL, null, _zhCN ]);
            for (int i = 0; i < REPEATS; i++)
            {
                CultureInfo? item = GetRandomItem(stack);
                IsTrue(stack.Contains(item));
            }
        }
    }

    // Params

    [TestMethod]
    public void Test_Legacy_GetRandomItems_Params()
    {
        int[] values = [ 1, 2, 3 ];
        for (int i = 0; i < REPEATS; i++)
        {
            IsTrue(values.Contains(GetRandomItem(1, 2, 3)));
        }
    }

    // TODO: Only differentiate between get and tryget tests where behavior is different, not where it is synonymous?}
}