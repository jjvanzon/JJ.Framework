namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Values_Tests : TestBase
{
    [TestMethod]
    public void Has_Values_No()
    {
        IsFalse(Has(NullNum));
        IsFalse(Has(NoNull0));
        IsFalse(Has(Nully0 ));
    }

    [TestMethod]
    public void Has_Values_Yes()
    {
        IsTrue (Has(NoNull1));
        IsTrue (Has(NoNull2));
        IsTrue (Has(NoNull3));
        IsTrue (Has(Nully1 ));
        IsTrue (Has(Nully2 ));
        IsTrue (Has(Nully3 ));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersNo_FlagsInBack()
    {
        IsFalse(Has(NullNum                    ));
        IsFalse(Has(NullNum, zeroMatters: false));
        IsFalse(Has(NullNum,              false));
        IsFalse(Has(NoNull0                    ));
        IsFalse(Has(NoNull0, zeroMatters: false));
        IsFalse(Has(NoNull0,              false));
        IsFalse(Has(Nully0                     ));
        IsFalse(Has(Nully0,  zeroMatters: false));
        IsFalse(Has(Nully0,               false));
        IsTrue (Has(NoNull1                    ));
        IsTrue (Has(NoNull1, zeroMatters: false));
        IsTrue (Has(NoNull1,              false));
        IsTrue (Has(Nully1                     ));
        IsTrue (Has(Nully1,  zeroMatters: false));
        IsTrue (Has(Nully1,               false));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersNo_FlagsInFront()
    {
        IsFalse(Has(                    NullNum));
        IsFalse(Has(zeroMatters: false, NullNum));
        IsFalse(Has(             false, NullNum));
        IsFalse(Has(                    NoNull0));
        IsFalse(Has(zeroMatters: false, NoNull0));
        IsFalse(Has(             false, NoNull0));
        IsFalse(Has(                    Nully0 ));
        IsFalse(Has(zeroMatters: false, Nully0 ));
        IsFalse(Has(             false, Nully0 ));
        IsTrue (Has(                    NoNull1));
        IsTrue (Has(zeroMatters: false, NoNull1));
        IsTrue (Has(             false, NoNull1));
        IsTrue (Has(                    Nully1 ));
        IsTrue (Has(zeroMatters: false, Nully1 ));
        IsTrue (Has(             false, Nully1 ));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersYes_FlagsInBack()
    {
        IsFalse(Has(NullNum, zeroMatters       ));
        IsFalse(Has(NullNum, zeroMatters: true ));
        IsFalse(Has(NullNum,              true ));
        IsTrue (Has(NoNull0, zeroMatters       ));
        IsTrue (Has(NoNull0, zeroMatters: true ));
        IsTrue (Has(NoNull0,              true ));
        IsTrue (Has(Nully0,  zeroMatters       ));
        IsTrue (Has(Nully0,  zeroMatters: true ));
        IsTrue (Has(Nully0,               true ));
        IsTrue (Has(NoNull1, zeroMatters       ));
        IsTrue (Has(NoNull1, zeroMatters: true ));
        IsTrue (Has(NoNull1,              true ));
        IsTrue (Has(Nully1,  zeroMatters       ));
        IsTrue (Has(Nully1,  zeroMatters: true ));
        IsTrue (Has(Nully1,               true ));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersYes_FlagsInFront()
    {
        IsFalse(Has(zeroMatters,       NullNum ));
        IsFalse(Has(zeroMatters: true, NullNum ));
        IsFalse(Has(             true, NullNum ));
        IsTrue (Has(zeroMatters,       NoNull0 ));
        IsTrue (Has(zeroMatters: true, NoNull0 ));
        IsTrue (Has(             true, NoNull0 ));
        IsTrue (Has(zeroMatters,       Nully0  ));
        IsTrue (Has(zeroMatters: true, Nully0  ));
        IsTrue (Has(             true, Nully0  ));
        IsTrue (Has(zeroMatters,       NoNull1 ));
        IsTrue (Has(zeroMatters: true, NoNull1 ));
        IsTrue (Has(             true, NoNull1 ));
        IsTrue (Has(zeroMatters,       Nully1  ));
        IsTrue (Has(zeroMatters: true, Nully1  ));
        IsTrue (Has(             true, Nully1  ));
    }
}