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
}
