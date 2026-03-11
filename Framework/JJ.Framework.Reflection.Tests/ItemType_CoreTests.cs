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

    // ncrunch: no coverage start
    public int[] TestIntArray { get; set; }
    public List<int> TestIntList { get; set; }
    public IEnumerable<int> TestIntEnumerable { get; set; }
    public IList<DummyClass> TestDummyIList { get; set; }
    public List<DummyClass> TestDummyList { get; set; }
    // ncrunch: no coverage end

    [Suppress("Trimmer", "IL2026", Justification = PropertyType)]
    [TestMethod]
    public void GetItemType_FromCollectionProperty()
    {
        IList<Func<PropertyInfo, Type>> synonyms =
        [
            x => GetItemType(x),
            x => x.GetItemType()
        ];

        var collType = typeof(ItemType_CoreTests);

        IList<(PropertyInfo itemProp, Type itemType)> props =
        [
            ( collType.GetProperty("TestIntArray"     ), typeof(int       ) ),
            ( collType.GetProperty("TestIntList"      ), typeof(int       ) ),
            ( collType.GetProperty("TestIntEnumerable"), typeof(int       ) ),
            ( collType.GetProperty("TestDummyIList"   ), typeof(DummyClass) ),
            ( collType.GetProperty("TestDummyList"    ), typeof(DummyClass) ),
        ];

        foreach (var (itemProp, itemTypeExpected) in props)
        foreach (var getItemType in synonyms)
        {
            ThrowIfNull(itemProp);
            AreEqual(itemTypeExpected, getItemType(itemProp));
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
