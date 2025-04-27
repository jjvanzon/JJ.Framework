using JJ.Framework.Tests.Helpers;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class GetImplementationsTests
{
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
