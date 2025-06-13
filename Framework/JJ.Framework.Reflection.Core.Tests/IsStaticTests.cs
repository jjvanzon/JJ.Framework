namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class IsStaticTests
{
    // ncrunch: no coverage start
    public int _field = 1;
    public int Property { get; set; } = 2;
    public int Method() => 3;
    public static int _staticField = 4;
    public static int StaticProperty { get; set; } = 5;
    public static int StaticMethod() => 6;
    public static event EventHandler StaticEvent = (sender, args) => { };
    // ncrunch: no coverage end

    [TestMethod]
    public void IsStatic_True()
    {
        MemberInfo? field = GetType().GetField("_staticField");
        NotNull(field);
        IsTrue(ReflectionHelper.IsStatic(field));
        
        MemberInfo? property = GetType().GetProperty("StaticProperty");
        NotNull(property);
        IsTrue(ReflectionHelper.IsStatic(property));
        
        MemberInfo? method = GetType().GetMethod("StaticMethod");
        NotNull(method);
        IsTrue(ReflectionHelper.IsStatic(method));
    }
    
    [TestMethod]
    public void IsStatic_False()
    {
        MemberInfo? field = GetType().GetField("_field");
        NotNull(field);
        IsFalse(ReflectionHelper.IsStatic(field));
        
        MemberInfo? property = GetType().GetProperty("Property");
        NotNull(property);
        IsFalse(ReflectionHelper.IsStatic(property));
        
        MemberInfo? method = GetType().GetMethod("Method");
        NotNull(method);
        IsFalse(ReflectionHelper.IsStatic(method));
    }
    
    [TestMethod]
    public void IsStatic_Exceptions()
    {
        EventInfo? eventInfo = GetType().GetEvent("StaticEvent");
        NotNull(eventInfo);
        ThrowsException(() => ReflectionHelper.IsStatic(eventInfo), "IsStatic cannot be obtained from member of type 'Event'.");
        ThrowsException(() => ReflectionHelper.IsStatic(null),      "member cannot be null.");
    }
}