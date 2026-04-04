namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Literals_Tests
{
    [TestMethod]
    public void Coalesce_Literals_Support()
    {
        // These can get messy if you mess with the generic constraints in the main code.
        // TODO: Include literals and keywords in the main tests for structural coverage. (Work in progress.)
        NoNullRet(1, 0.Coalesce(1, 2));
        NoNullRet(0, 0.Coalesce(NullNum, NullNum, NullNum));
        NoNullRet(0, Coalesce(0, NullNum, NullNum, NullNum));
        NoNullRet(1, Nully0.Coalesce(0, NullNum, 1));
    }
}