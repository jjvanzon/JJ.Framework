// ReSharper disable ExpressionIsAlwaysNull

namespace JJ.Framework.Mathematics.Tests;

using static Randomizer;

[TestClass]
public class RandomizerTests_TryGetRandomItem
{
    private const int REPEATS = 100;
    
    private static readonly CultureInfo _nlNL = GetCultureInfo("nl-NL");
    private static readonly CultureInfo _enUS = GetCultureInfo("en-US");
    private static readonly CultureInfo _zhCN = GetCultureInfo("zh-CN");

    // Values

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneValue()
    {
        int[] items = [ 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = TryGetRandomItem(items);
            AreEqual(3, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NoValues_ReturnsNull()
    {
        int[] items = [ ];
        int val = TryGetRandomItem(items);
        //AreEqual(null, val);
        AreEqual(0, val);
    }
    
    // Nullables

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNullableFilledValues_Allowed()
    {
        int?[] items = [ 1, 2, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_AllowsNullValues()
    {
        int?[] items = [ 1, null, 2 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNull()
    {
        int?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            AreEqual(null, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNulllyFilled()
    {
        int?[] items = [ 1 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            AreEqual(1, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_Nullables_None_ReturnsNull()
    {
        int?[] items = [ ];
        int? val = TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // Text

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromTexts()
    {
        string[] texts = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? text = TryGetRandomItem(texts);
            IsTrue(texts.Contains(text!));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneText()
    {
        string[] texts = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? text = TryGetRandomItem(texts);
            AreEqual("one", text);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNoTexts_ReturnsNull()
    {
        string[] texts = [];
        string? text = TryGetRandomItem(texts);
        AreEqual(null, text);
    }

    // Nullable Text

    #pragma warning disable CS8631 // Contains-checks gave bogus error: The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match constraint type.
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNullableTexts()
    {
        string?[] texts = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? text = TryGetRandomItem(texts);
            IsTrue(texts.Contains(text));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_AllowsNullText()
    {
        string?[] texts = [ "one", null, "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? text = TryGetRandomItem(texts);
            IsTrue(texts.Contains(text));
        }
    }
    #pragma warning restore CS8631
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullText()
    {
        string?[] texts = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? text = TryGetRandomItem(texts);
            AreEqual(null, text);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullyFilledText()
    {
        string?[] texts = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? text = TryGetRandomItem(texts);
            AreEqual("one", text);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NullableTexts_None_ReturnsNull()
    {
        string?[] texts = [];
        string? text = TryGetRandomItem(texts);
        AreEqual(null, text);
    }

    // Objects

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromObjects()
    {
        CultureInfo[] objects = [ _nlNL, _enUS, _zhCN ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = TryGetRandomItem(objects);
            IsTrue(objects.Contains(obj));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneObject()
    {
        CultureInfo[] objects = [ _nlNL ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = TryGetRandomItem(objects);
            AreEqual(_nlNL, obj);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NoObjects_ReturnsNull()
    {
        CultureInfo[] objects = [];
        CultureInfo? obj = TryGetRandomItem(objects);
        AreEqual(null, obj);
    }

    // Nullable Object

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNullableObjects()
    {
        CultureInfo?[] objects = [ _nlNL, _enUS, _zhCN ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = TryGetRandomItem(objects);
            IsTrue(objects.Contains(obj));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_AllowsNullObject()
    {
        CultureInfo?[] objects = [ _nlNL, null, _zhCN ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = TryGetRandomItem(objects);
            IsTrue(objects.Contains(obj));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullObject()
    {
        CultureInfo?[] objects = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = TryGetRandomItem(objects);
            AreEqual(null, obj);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullyFilledObject()
    {
        CultureInfo?[] objects = [ _nlNL ];

        for (int i = 0; i < REPEATS; i++)
        {
            CultureInfo? obj = TryGetRandomItem(objects);
            AreEqual(_nlNL, obj);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NullableObjects_None_ReturnsNull()
    {
        CultureInfo?[] objects = [];
        CultureInfo? obj = TryGetRandomItem(objects);
        AreEqual(null, obj);
    }

    // Null Collections

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_ValueCollectionNull_ReturnsNull()
    {
        int[]? collection = null;
        //IsNull(TryGetRandomItem(collection));
        AreEqual(0, TryGetRandomItem(collection));
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NullCollectionOfNullables_ReturnsNull()
    {
        int?[]? collection = null;
        IsNull(TryGetRandomItem(collection));
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_ObjectCollectionNull_ReturnsNull()
    {
        CultureInfo[]? collection = null;
        IsNull(TryGetRandomItem(collection));
    }

    // Collection Types

    [TestMethod]
    public void Test_Legacy_GetRandomItem_CollectionTypes()
    {
        {
            IList<int?> list = new List<int?> { 1, null, 3 };
            for (int i = 0; i < REPEATS; i++)
            {
                int? val = TryGetRandomItem(list);
                IsTrue(list.Contains(val));
            }
        }
        {
            List<int?> list = [ 1, null, 3 ];
            for (int i = 0; i < REPEATS; i++)
            {
                int? val = TryGetRandomItem(list);
                IsTrue(list.Contains(val));
            }
        }
        {
            var stack = new Stack<CultureInfo?>([ _nlNL, null, _zhCN ]);
            for (int i = 0; i < REPEATS; i++)
            {
                CultureInfo? item = TryGetRandomItem(stack);
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
            IsTrue(values.Contains(TryGetRandomItem(1, 2, 3)));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItems_Params_Nullable()
    {
        int?[] values = [ 1, null, 3 ];
        for (int i = 0; i < REPEATS; i++)
        {
            IsTrue(values.Contains(TryGetRandomItem<int>(1, null, 3)));
        }
    }
}