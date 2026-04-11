```cs

        /*
        ThrowIfNull(objFunc);
        object obj = objFunc();
        ThrowIfNull(obj);
        Type actual = obj.GetType();
        */

        //Type actual = objFunc?.Invoke()?.GetType();
        //ThrowIfNull(prop);
        //ThrowIfNull(method);
        //ThrowIfNull(parameters);
        //ThrowIfNull(method);
        //ThrowIfNull(method.Name);
        //string typeName = func?.Invoke()?.GetType().Name ?? "<null>";

        /*
        private static void LogEmptyLine()
        { 
            Trace.WriteLine("");
        }
        */
            //Trace.WriteLine(@$"Prop {prop.Name} = ""{text}""");
            //Trace.WriteLine(@$"Prop {prop.Name} = ""{text}""");


    // Direct Instantiation (Base Class Usage Without Inheritance)

    /*
    [TestMethod]
    public void ResourceStringTester_DirectInstance_MethodsWork()
    {
        var tester = new ResourceStringTester(typeof(Stub_ZeroParams), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }

    [TestMethod]
    public void ResourceStringTester_DirectInstance_WithParameters_ContainmentWorks()
    {
        var tester = new ResourceStringTester(typeof(Stub_OneParam), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }

    [TestMethod]
    public void ResourceStringTester_DirectInstance_ExcludesDefaultMembers()
    {
        var tester = new ResourceStringTester(typeof(Stub_PropertyBased), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }

    [TestMethod]
    public void ResourceStringTester_DirectInstance_MixedMembersWork()
    {
        var tester = new ResourceStringTester(typeof(Stub_MixedMembers), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }
    */

    private static class Stub_PropertyBased
    {
        public static string Title { get; } = "Main Title";
        public static string Description { get; } = "A description";
    }

```

```xml
    <type fullname="JJ.Framework.ResourceStrings.Legacy.Tests.Untrimmer" preserve="all">
      <method name="Untrim" />
    </type>
```

```cs
namespace JJ.Framework.ResourceStrings.Legacy.Tests;

internal class Untrimmer
{
    public static void Untrim()
    {
        
    }
}


    [TestMethod]
    public void StringResourceTester_Inheritance_CustomSelection_SelectsSpecificMembers() 
        => new InheritedTester_WithCustomSelection().AssertAllMembers();

    private class InheritedTester_WithCustomSelection()
        : StringResourceTester(
            typeof(ResourceClass_WithProblematic), 
            known: ["nl-NL", ""], unknown: "de-DE", @default: "en-US")
    {
        protected override IList<MemberInfo> SelectMembersToTest([Dyn(PubProps|PubMethods)] Type resourceClass)
            => base.SelectMembersToTest(resourceClass)
                   .Where(x => x.Name.StartsWith("Good"))
                   .ToArray();
    }


    if (string.Equals(memberToTest.Name, "Equals", OrdinalIgnoreCase))
    {
        return false;
    }

    /// <inheritdoc cref="_portedstubs" />
    public static object GetValue(this PropertyInfo prop)
    {
        return prop.GetValue(null);
    }

    /// <inheritdoc cref="_portedstubs" />
    public static object Invoke(this MethodBase method, object[] parameters)
    {
        return method.Invoke(null, parameters);
    }


    [TestMethod]
    public void StringResourceTester_NoLog_WithResourceObject_SuppressesTraceOutput()
    {
        IResources resourceObject = new InstanceResources();

        var tester = new StringResourceTester(
            typeof(InstanceResources), resourceObject,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog);

        string trace = CaptureTrace(tester.AssertAllMembers);

        AreEqual("", trace);
    }
```