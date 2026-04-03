namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionMiscTests
{
    public int _field = 1; // ncrunch: no coverage

    // Assemblies

    [TestMethod]
    public void GetAssemblyNameTest() 
        => AreEqual("JJ.Framework.Reflection.Core", () => GetAssemblyName<Reflector>());
    
    // Fields
    
    [TestMethod]
    public void Type_GetFieldOrException()
    {
        var synonyms = new Func<string, FieldInfo>[]
        {
            fieldName => GetType().Field(fieldName),
            fieldName => Field(GetType(), fieldName)
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
                $"Field ❌ not found in {GetType().Name}.");
        }
    }
}