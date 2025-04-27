using JJ.Framework.Tests.Helpers;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionHelper_Misc_Tests
{
    // ncrunch: no coverage start
    
    public int _field = 1;
    public int Property { get; set; } = 2;
    public int Method() => 3;
    public static int _staticField = 4;
    public static int StaticProperty { get; set; } = 5;
    public static int StaticMethod() => 6;
    public static event EventHandler StaticEvent;
    
    // ncrunch: no coverage end

    // Assemblies
    
    [TestMethod]
    public void GetAssemblyNameTest() 
        => AreEqual("JJ.Framework.Reflection.Core", () => GetAssemblyName<ReflectionHelperCore>());
    
    // Fields
    
    [TestMethod]
    public void Type_GetFieldOrException()
    {
        var synonyms = new Func<string, FieldInfo>[]
        {
            fieldName => GetType().GetFieldOrException(fieldName),
            fieldName => GetFieldOrException(GetType(), fieldName)
        };

        foreach (var getField in synonyms)
        {
            FieldInfo field = getField("_field");

            IsNotNull(() => field);
            AreEqual("_field", () => field.Name);
            AreEqual(1, () => field.GetValue(this));
            AreEqual(typeof(int), () => field.FieldType);

            ThrowsException(
                () => getField("❌"),
                $"Field '❌' not found on type '{GetType().FullName}'.");
        }
    }

    // ItemTypes
    
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
    
    // IsStatic 

    [TestMethod]    
    public void IsStatic_True()
    {
        MemberInfo field = GetType().GetField("_staticField");
        IsNotNull(() => field);
        IsTrue(() => IsStatic(field));
        
        MemberInfo property = GetType().GetProperty("StaticProperty");
        IsNotNull(() => property);
        IsTrue(() => IsStatic(property));
        
        MemberInfo method = GetType().GetMethod("StaticMethod");
        IsNotNull(() => method);
        IsTrue(() => IsStatic(method));
    }
    
    [TestMethod]
    public void IsStatic_False()
    {
        MemberInfo field = GetType().GetField("_field");
        IsNotNull(() => field);
        IsFalse(() => IsStatic(field));
        
        MemberInfo property = GetType().GetProperty("Property");
        IsNotNull(() => property);
        IsFalse(() => IsStatic(property));
        
        MemberInfo method = GetType().GetMethod("Method");
        IsNotNull(() => method);
        IsFalse(() => IsStatic(method));
    }
    
    [TestMethod]
    public void IsStatic_Exceptions()
    {
        EventInfo eventInfo = GetType().GetEvent("StaticEvent");
        IsNotNull(() => eventInfo);
        ThrowsException(() => IsStatic(eventInfo), "IsStatic cannot be obtained from member of type 'Event'.");
        ThrowsException(() => IsStatic(null), "member cannot be null.");
    }
}
