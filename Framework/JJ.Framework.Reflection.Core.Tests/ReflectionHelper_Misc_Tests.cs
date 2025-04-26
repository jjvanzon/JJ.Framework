using static JJ.Framework.Reflection.ReflectionHelper;

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
    
    
    // TODO: Test GetImplementation, TryGetImplementation and GetImplementations with none-single-multiple test variants. Use them to retrieve (multiple) implementations of an interface type from an assembly. Add helper types here too.

    // Implementations
    
    interface IInterfaceNone;
    interface IInterface1;
    interface IInterface2;
    class SingleImplementation : IInterface1;
    class MultipleImplementations1 : IInterface2;
    class MultipleImplementations2 : IInterface2;
        
    // TryGetImplementation
    
    [TestMethod]
    public void TryGetImplementation_NotFound()
    {
        Type implementation = TryGetImplementation<IInterfaceNone>(GetType().Assembly);
        IsNull(() => implementation);
    }
    
    [TestMethod]
    public void TryGetImplementationTest_Single()
    {
        Type implementation = TryGetImplementation<IInterface1>(GetType().Assembly);
        IsNotNull(() => implementation);
        AreEqual(typeof(SingleImplementation), () => implementation);
    }
             
    [TestMethod]
    public void TryGetImplementation_Multiple_Exception() 
        => ThrowsException(() => GetImplementation<IInterface2>(GetType().Assembly));
    
    // GetImplementation
    
    [TestMethod]
    public void GetImplementation_NotFound_Exception() 
        => ThrowsException(() => GetImplementation<IInterfaceNone>(GetType().Assembly));
    
    [TestMethod]
    public void GetImplementation_Single()
    {
        Type implementation = GetImplementation<IInterface1>(GetType().Assembly);
        IsNotNull(() => implementation);
        AreEqual(typeof(SingleImplementation), () => implementation);
    }
        
    [TestMethod]
    public void GetImplementation_Multiple_Exception() 
        => ThrowsException(() => GetImplementation<IInterface2>(GetType().Assembly));
    
    // GetImplementations
    
    [TestMethod]
    public void GetImplementations_None()
    {
        IList<Type> implementations = GetImplementations<IInterfaceNone>(GetType().Assembly);
        IsNotNull( () => implementations);
        AreEqual(0,() => implementations.Count);
    }
    
    [TestMethod]
    public void GetImplementations_Single()
    {
        IList<Type> implementations = GetImplementations<IInterface1>(GetType().Assembly);
        IsNotNull( () => implementations);
        AreEqual(1,() => implementations.Count);
        IsNotNull( () => implementations[0]);
        AreEqual(typeof(SingleImplementation), () => implementations[0]);
    }
    
    [TestMethod]
    public void GetImplementations_Multiple()
    {
        IList<Type> implementations = GetImplementations<IInterface2>(GetType().Assembly);
        IsNotNull( () => implementations);
        AreEqual(2,() => implementations.Count);
        IsTrue(() => implementations.Contains(typeof(MultipleImplementations1)));
        IsTrue(() => implementations.Contains(typeof(MultipleImplementations2)));
    }
}
