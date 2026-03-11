#pragma warning disable IDE0200

namespace JJ.Framework.Reflection.Legacy.Tests;

using static ReflectionHelper;

[Suppress("Trimmer", "IL2067", Justification = TypeLoaded)]
[TestClass]
public class ItemType_CoreTests
{
    [TestMethod]
    [Suppress("Trimmer", "IL2026", Justification = ObjectGetType)]
    public void ItemTypes_WithCollectionInstance()
    {
        IList<Func<object, Type>> synonyms =
        [
            x => GetItemType(x),
            x => x.GetItemType()
        ];

        foreach (var getItemType in synonyms)
        {
            Type itemType = getItemType(new[] { 1, 2, 3 });
            AreEqual(typeof(int), itemType);
        }
    }

    [TestMethod]
    public void ItemTypes_WithCollectionType()
    {
        IList<Func<Type, Type>> synonyms =
        [
            x =>      GetItemType(x),
            x => x.   GetItemType( ),
            x =>   TryGetItemType(x),
            x => x.TryGetItemType( ) 
        ];

        foreach (var getItemType in synonyms)
        {
            AreEqual(typeof(int), getItemType(typeof(int[])));
            AreEqual(typeof(int), getItemType(typeof(List<int>)));
            AreEqual(typeof(DummyClass), getItemType(typeof(IList<DummyClass>)));
        }
    }

    // Local test properties to avoid interfering with other helpers
    public int[] TestArray { get; set; }
    public List<int> TestList { get; set; }
    public IEnumerable<int> TestEnumerable { get; set; }
    public IList<DummyClass> TestIListDummy { get; set; }
    public List<DummyClass> TestListDummy { get; set; }

    [Suppress("Trimmer", "IL2026", Justification = PropertyType)]
    [TestMethod]
    public void GetItemType_WithPropertyInfo()
    {
        IList<Func<PropertyInfo, Type>> synonyms =
        [
            x => GetItemType(x),
            x => x.GetItemType()
        ];

        var collType = typeof(ItemType_CoreTests);
        PropertyInfo? prop1 = collType.GetProperty(nameof(TestArray));
        ThrowIfNull(prop1);

        PropertyInfo? prop2 = collType.GetProperty(nameof(TestList));
        ThrowIfNull(prop2);

        PropertyInfo? prop3 = collType.GetProperty(nameof(TestEnumerable));
        ThrowIfNull(prop3);

        PropertyInfo? prop4 = collType.GetProperty(nameof(TestIListDummy));
        ThrowIfNull(prop4);

        PropertyInfo? prop5 = collType.GetProperty(nameof(TestListDummy));
        ThrowIfNull(prop5);

        IList<(PropertyInfo itemProp, Type itemType)> props =
        [
            (prop1, typeof(int)),
            (prop2, typeof(int)),
            (prop3, typeof(int)),
            (prop4, typeof(DummyClass)),
            (prop5, typeof(DummyClass)),
        ];

        foreach (var (itemProp, itemType) in props)
        foreach (var getItemType in synonyms)
        {
            AreEqual(itemType, getItemType(itemProp));
        }
    }

    [TestMethod]
    public void GetItemType_NoItemTypeException()
    {
        IList<Func<Type, Type>> funcs =
        [
            x => GetItemType(x),
            x => x.GetItemType()
        ];

        IList<Type> types =
        [
            GetType(),
            typeof(int),
            typeof(ArrayList),
            typeof(DummyClass),
        ];

        foreach (Type type in types)
        foreach (var getItemType in funcs)
        {
            ThrowsExceptionContaining(() => getItemType(type), "has no item type.");
        }
    }

    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    [TestMethod]
    public void TryGetItemType_NoItemType_ReturnsNull()
    {
        IList<Func<Type, Type>> synonyms =
        [
            x => TryGetItemType(x),
            x => x.TryGetItemType()
        ];

        IList<Type> types =
        [
            GetType(),
            typeof(int),
            typeof(ArrayList),
            typeof(DummyClass),
        ];

        foreach (Type type in types)
        foreach (var tryGetItemType in synonyms)
        {
            Type itemType = tryGetItemType(type);
            IsNull(() => itemType);
        }
    }
}
