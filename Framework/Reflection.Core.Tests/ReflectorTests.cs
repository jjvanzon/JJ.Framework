namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectorTests : ReflectorTestBase
{ 
    // ToString
    
    [TestMethod]
    public void Reflector_ToString()
    {
        BindingFlags bindingFlagsMatchCase = ClearFlag(BindingFlagsAll, BindingFlags.IgnoreCase);
        
        foreach (var reflector in _reflectors)
        {
            AreEqual($"Reflector ({BindingFlagsAll})", $"{reflector}");
        }
        
        foreach (var reflector in _reflectorsMatchCase)
        {
            AreEqual($"Reflector ({bindingFlagsMatchCase})", $"{reflector}");
        }        
    }
}

