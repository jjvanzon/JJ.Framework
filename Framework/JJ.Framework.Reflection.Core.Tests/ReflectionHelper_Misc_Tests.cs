using System.Reflection;
using JJ.Framework.Tests.Helpers;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionHelper_Misc_Tests
{
    public int _field = 1;
    public int Property { get; set; } = 2;
    public int Method() => 3;
    public static int _staticField = 4;
    public static int StaticProperty { get; set; } = 5;
    public static int StaticMethod() => 6;
    public static event EventHandler StaticEvent;

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

        foreach (var synonym in synonyms)
        {
            FieldInfo field = synonym("_field");

            IsNotNull(() => field);
            AreEqual("_field", () => field.Name);
            AreEqual(1, () => field.GetValue(this));
            AreEqual(typeof(int), () => field.FieldType);

            ThrowsException(
                () => synonym("❌"),
                $"Field '❌' not found on type '{GetType().FullName}'.");
        }
    }

    // GetItemType Edge Cases
    
    [TestMethod]
    public void GetItemType_BaseLine()
    {
        AreEqual(typeof(int), () => GetItemType(new[] { 1, 2, 3 }));
        AreEqual(typeof(int), () => GetItemType(typeof(int[])));
        AreEqual(typeof(int), () => GetItemType(typeof(List<int>)));
        AreEqual(typeof(DummyClass), () => GetItemType(typeof(IList<DummyClass>)));
    }

    [TestMethod]
    public void GetItemType_Exception_NotACollection() 
        => ThrowsException(() => GetItemType(this), 
            "Type 'ReflectionHelper_Misc_Tests' has no item type.");
    
    [TestMethod]
    public void GetItemType_Exception_NonGenericCollection() 
        => ThrowsException(() => GetItemType(typeof(ArrayList)), 
            "Type 'ArrayList' has no item type.");

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
