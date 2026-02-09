namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Values_Tests : TestBase
{
    [TestMethod]
    public void IsNully_Values_No()
    {
        IsTrue (IsNully(NullNum));
        IsTrue (IsNully(NoNull0));
        IsTrue (IsNully(Nully0 ));
    }

    [TestMethod]
    public void IsNully_Values_Yes()
    {
        IsFalse(IsNully(NoNull1));
        IsFalse(IsNully(NoNull2));
        IsFalse(IsNully(NoNull3));
        IsFalse(IsNully(Nully1 ));
        IsFalse(IsNully(Nully2 ));
        IsFalse(IsNully(Nully3 ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersNo_Extensions()
    {
        IsTrue (NullNum.IsNully(                  ));
        IsTrue (NullNum.IsNully(zeroMatters: false));
        IsTrue (NullNum.IsNully(             false));
        IsTrue (NoNull0.IsNully(                  ));
        IsTrue (NoNull0.IsNully(zeroMatters: false));
        IsTrue (NoNull0.IsNully(             false));
        IsTrue (Nully0 .IsNully(                  ));
        IsTrue (Nully0 .IsNully(zeroMatters: false));
        IsTrue (Nully0 .IsNully(             false));
        IsFalse(NoNull1.IsNully(                  ));
        IsFalse(NoNull1.IsNully(zeroMatters: false));
        IsFalse(NoNull1.IsNully(             false));
        IsFalse(Nully1 .IsNully(                  ));
        IsFalse(Nully1 .IsNully(zeroMatters: false));
        IsFalse(Nully1 .IsNully(             false));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersNo_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullNum                    ));
        IsTrue (IsNully(NullNum, zeroMatters: false));
        IsTrue (IsNully(NullNum,              false));
        IsTrue (IsNully(NoNull0                    ));
        IsTrue (IsNully(NoNull0, zeroMatters: false));
        IsTrue (IsNully(NoNull0,              false));
        IsTrue (IsNully(Nully0                     ));
        IsTrue (IsNully(Nully0,  zeroMatters: false));
        IsTrue (IsNully(Nully0,               false));
        IsFalse(IsNully(NoNull1                    ));
        IsFalse(IsNully(NoNull1, zeroMatters: false));
        IsFalse(IsNully(NoNull1,              false));
        IsFalse(IsNully(Nully1                     ));
        IsFalse(IsNully(Nully1,  zeroMatters: false));
        IsFalse(IsNully(Nully1,               false));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersNo_StaticFlagsInFront()
    {
        IsTrue (IsNully(                    NullNum));
        IsTrue (IsNully(zeroMatters: false, NullNum));
        IsTrue (IsNully(             false, NullNum));
        IsTrue (IsNully(                    NoNull0));
        IsTrue (IsNully(zeroMatters: false, NoNull0));
        IsTrue (IsNully(             false, NoNull0));
        IsTrue (IsNully(                    Nully0 ));
        IsTrue (IsNully(zeroMatters: false, Nully0 ));
        IsTrue (IsNully(             false, Nully0 ));
        IsFalse(IsNully(                    NoNull1));
        IsFalse(IsNully(zeroMatters: false, NoNull1));
        IsFalse(IsNully(             false, NoNull1));
        IsFalse(IsNully(                    Nully1 ));
        IsFalse(IsNully(zeroMatters: false, Nully1 ));
        IsFalse(IsNully(             false, Nully1 ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersYes_Extensions()
    {
        IsTrue (NullNum.IsNully(zeroMatters       ));
        IsTrue (NullNum.IsNully(zeroMatters: true ));
        IsTrue (NullNum.IsNully(             true ));
        IsFalse(NoNull0.IsNully(zeroMatters       ));
        IsFalse(NoNull0.IsNully(zeroMatters: true ));
        IsFalse(NoNull0.IsNully(             true ));
        IsFalse(Nully0 .IsNully(zeroMatters       ));
        IsFalse(Nully0 .IsNully(zeroMatters: true ));
        IsFalse(Nully0 .IsNully(             true ));
        IsFalse(NoNull1.IsNully(zeroMatters       ));
        IsFalse(NoNull1.IsNully(zeroMatters: true ));
        IsFalse(NoNull1.IsNully(             true ));
        IsFalse(Nully1 .IsNully(zeroMatters       ));
        IsFalse(Nully1 .IsNully(zeroMatters: true ));
        IsFalse(Nully1 .IsNully(             true ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersYes_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullNum, zeroMatters       ));
        IsTrue (IsNully(NullNum, zeroMatters: true ));
        IsTrue (IsNully(NullNum,              true ));
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(NoNull0,              true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
        IsFalse(IsNully(Nully0,               true ));
        IsFalse(IsNully(NoNull1, zeroMatters       ));
        IsFalse(IsNully(NoNull1, zeroMatters: true ));
        IsFalse(IsNully(NoNull1,              true ));
        IsFalse(IsNully(Nully1,  zeroMatters       ));
        IsFalse(IsNully(Nully1,  zeroMatters: true ));
        IsFalse(IsNully(Nully1,               true ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersYes_StaticFlagsInFront()
    {
        IsTrue (IsNully(zeroMatters,       NullNum ));
        IsTrue (IsNully(zeroMatters: true, NullNum ));
        IsTrue (IsNully(             true, NullNum ));
        IsFalse(IsNully(zeroMatters,       NoNull0 ));
        IsFalse(IsNully(zeroMatters: true, NoNull0 ));
        IsFalse(IsNully(             true, NoNull0 ));
        IsFalse(IsNully(zeroMatters,       Nully0  ));
        IsFalse(IsNully(zeroMatters: true, Nully0  ));
        IsFalse(IsNully(             true, Nully0  ));
        IsFalse(IsNully(zeroMatters,       NoNull1 ));
        IsFalse(IsNully(zeroMatters: true, NoNull1 ));
        IsFalse(IsNully(             true, NoNull1 ));
        IsFalse(IsNully(zeroMatters,       Nully1  ));
        IsFalse(IsNully(zeroMatters: true, Nully1  ));
        IsFalse(IsNully(             true, Nully1  ));
    }
}