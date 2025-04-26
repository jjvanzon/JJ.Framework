using System.ComponentModel;
using JJ.Framework.Tests.Helpers;
using static JJ.Framework.Reflection.ReflectionHelper;
// ReSharper disable UnusedMember.Local

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionHelper_Misc_Tests
{
    // Assemblies
    
    [TestMethod]
    public void GetAssemblyNameTest()
    {
        AreEqual("JJ.Framework.Reflection.Core", () => GetAssemblyName<ReflectionHelperCore>());
    }

    // Fields
    
    private string _field = "value";
    
    [TestMethod]
    public void GetFieldOrExceptionTest()
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
            AreEqual("value", () => field.GetValue(this));
            AreEqual(typeof(string), () => field.FieldType);

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
    
    // TODO: Odd exception messages
    
    [TestMethod]
    public void GetItemType_Exception_NotACollection() 
        => ThrowsException(() => GetItemType(this)/*, 
            "Type 'ReflectionHelper_Misc_Tests' has no item type."*/);
    
    [TestMethod]
    public void GetItemType_Exception_NonGenericCollection() 
        => ThrowsException(() => GetItemType(typeof(ArrayList))/*, 
            "Type 'ArrayList' has no item type."*/);
    
    // IsIndexerMethod

    // ncrunch: no coverage start
    
    private class WithIndexer
    {
        public string this[int i] { get => ""; set { } }
    }

    private class WithItemProperty 
    {
        public int Item { get; set; }
    }

    [DefaultProperty("Item")]
    private class WithDefaultProperty
    {
        public int Item { get; set; }
    }

    private class WithGetterPrefix
    {
        public int get_Item() => 1;
    }

    private class NoIndexer
    {
        public int Property { get; set; }
        public void Method() { }
    }

    private class WithEvent
    {
        public event EventHandler Event { add { } remove { } }
    }
 
    // We can't fool the compiler this much, so we can't test this case.
    /*
    [DefaultMember("SomethingElse")]
    private class IndexerNameMismatch
    {
        public int this[int i] { get => 0; set { } }
    }
    */
    
    // ncrunch: no coverage end
    
    [TestMethod]
    public void IsIndexerMethod_IndexerGetter_ReturnsTrue()
        => IsTrue(IsIndexerMethod(typeof(WithIndexer).GetMethod("get_Item", BINDING_FLAGS_ALL)));

    [TestMethod]
    public void IsIndexerMethod_IndexersSetter_Returns_True()
        => IsTrue(IsIndexerMethod(typeof(WithIndexer).GetMethod("set_Item", BINDING_FLAGS_ALL)));
    
    [TestMethod] 
    public void IsIndexerMethod_Property_ExplicitDefaultMember_ReturnsFalse()
        => IsFalse(IsIndexerMethod(typeof(WithDefaultProperty).GetMethod("get_Item", BINDING_FLAGS_ALL)));
    
    [TestMethod] 
    public void IsIndexerMethod_Property_NoDefaultMember_ReturnsFalse()
        => IsFalse(IsIndexerMethod(typeof(WithItemProperty).GetMethod("get_Item", BINDING_FLAGS_ALL)));

    [TestMethod] 
    public void IsIndexerMethod_Method_ReturnsFalse()
        => IsFalse(IsIndexerMethod(typeof(NoIndexer).GetMethod("Method", BINDING_FLAGS_ALL)));
    
    [TestMethod]
    public void IsIndexerMethod_EventIsSpecialName_ButNotAGeterOrSetter()
        => IsFalse(IsIndexerMethod(typeof(WithEvent).GetMethod("add_Event", BINDING_FLAGS_ALL)));
    
    [TestMethod] 
    public void IsIndexerMethod_Method_WithGetterPrefix_ReturnsFalse()
        => IsFalse(IsIndexerMethod(typeof(WithGetterPrefix).GetMethod("get_Item", BINDING_FLAGS_ALL)));

    [TestMethod]
    public void IsIndexerMethod_NonDefaultProperty_ReturnsFalse()
        => IsFalse(IsIndexerMethod(typeof(NoIndexer).GetMethod("get_Property", BINDING_FLAGS_ALL)));
    
    // Implementations

    private interface IInterfaceNone;
    private interface IInterface1;
    private interface IInterface2 : IDummy;
    private class SingleImplementation : IInterface1, IDummy;
    private class MultipleImplementations1 : IInterface2;
    private class MultipleImplementations2 : IInterface2;

    private Assembly Assembly => GetType().Assembly;
        
    // TryGetImplementation
    
    [TestMethod]
    public void TryGetImplementation_NotFound()
    {
        Type implementation = TryGetImplementation<IInterfaceNone>(Assembly);
        IsNull(() => implementation);
    }
    
    [TestMethod]
    public void TryGetImplementationTest_Single()
    {
        Type implementation = TryGetImplementation<IInterface1>(Assembly);
        IsNotNull(() => implementation);
        AreEqual(typeof(SingleImplementation), () => implementation);
    }
             
    [TestMethod]
    public void TryGetImplementation_Multiple_Exception() 
        => ThrowsExceptionContaining(
            () => GetImplementation<IInterface2>(Assembly),
            "Multiple implementations", "found");
    
    // GetImplementation
    
    [TestMethod]
    public void GetImplementation_NotFound_Exception() 
        => ThrowsExceptionContaining(
            () => GetImplementation<IInterfaceNone>(Assembly),
            "No implementation", "found");
    
    [TestMethod]
    public void GetImplementation_Single()
    {
        Type implementation = GetImplementation<IInterface1>(Assembly);
        IsNotNull(() => implementation);
        AreEqual(typeof(SingleImplementation), () => implementation);
    }
        
    [TestMethod]
    public void GetImplementation_Multiple_Exception() 
        => ThrowsExceptionContaining(
            () => GetImplementation<IInterface2>(Assembly),
            "Multiple implementations", "found");
    
    // GetImplementations
    
    [TestMethod]
    public void GetImplementations_None()
    {
        IList<Type> implementations = GetImplementations<IInterfaceNone>(Assembly);
        IsNotNull( () => implementations);
        AreEqual(0,() => implementations.Count);
    }
    
    [TestMethod]
    public void GetImplementations_Single()
    {
        IList<Type> implementations = GetImplementations<IInterface1>(Assembly);
        IsNotNull( () => implementations);
        AreEqual(1,() => implementations.Count);
        IsNotNull( () => implementations[0]);
        AreEqual(typeof(SingleImplementation), () => implementations[0]);
    }
    
    [TestMethod]
    public void GetImplementations_Multiple()
    {
        IList<Type> implementations = GetImplementations<IInterface2>(Assembly);
        IsNotNull( () => implementations);
        AreEqual(2,() => implementations.Count);
        IsTrue(() => implementations.Contains(typeof(MultipleImplementations1)));
        IsTrue(() => implementations.Contains(typeof(MultipleImplementations2)));
    }
    
    [TestMethod]
    public void GetImplementations_MultipleAssemblies()
    {
        IList<Assembly> assemblies = [ Assembly, typeof(IDummy).Assembly ];
        IList<Type> implementations = GetImplementations<IDummy>(assemblies);
        IsNotNull(() => implementations);
        AreEqual(5, () => implementations.Count);
        // NOTE: Very particular that it includes interface types. Correcting it would be too invasive to the code freeze.
        IsTrue(() => implementations.Contains(typeof(IInterface2)));
        IsTrue(() => implementations.Contains(typeof(DummyClass)));
        IsTrue(() => implementations.Contains(typeof(SingleImplementation)));
        IsTrue(() => implementations.Contains(typeof(MultipleImplementations1)));
        IsTrue(() => implementations.Contains(typeof(MultipleImplementations2)));
    }
}
