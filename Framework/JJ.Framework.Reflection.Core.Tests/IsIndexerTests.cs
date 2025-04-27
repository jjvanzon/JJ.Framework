using System.ComponentModel;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;
internal class IsIndexerTests
{
    
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
    
}
