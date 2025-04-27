namespace JJ.Framework.Reflection.Core.Tests;

using static ReflectionHelper;

[TestClass]
public class ReflectionMiscTests
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
