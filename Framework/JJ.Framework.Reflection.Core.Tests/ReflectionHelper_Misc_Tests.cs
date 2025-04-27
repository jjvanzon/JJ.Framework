using JJ.Framework.Tests.Helpers;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionHelper_Misc_Tests
{
    // Assemblies
    
    [TestMethod]
    public void GetAssemblyNameTest() 
        => AreEqual("JJ.Framework.Reflection.Core", () => GetAssemblyName<ReflectionHelperCore>());
    
    // Fields
    
    private string _field = "value";
    
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
}
