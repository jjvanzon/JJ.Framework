namespace JJ.Framework.Reflection.Core.Tests;

using JJ.Framework.Tests.Helpers;
using static ReflectionHelper;

[TestClass] 
public class ItemTypeTests
{
    [TestMethod]
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
