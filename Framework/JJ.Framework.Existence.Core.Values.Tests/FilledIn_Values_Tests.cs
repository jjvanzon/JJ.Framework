// ReSharper disable RedundantAssignment

namespace JJ.Framework.Existence.Core.Values.Tests;

[TestClass]
public class FilledIn_Values_Tests : TestBase
{
    [TestMethod]
    public void FilledIn_Values_No()
    {
        IsFalse(FilledIn(NullNum));
        IsFalse(FilledIn(NoNull0));
        IsFalse(FilledIn(Nully0 ));
    }

    [TestMethod]
    public void FilledIn_Values_Yes()
    {
        IsTrue (FilledIn(NoNull1));
        IsTrue (FilledIn(NoNull2));
        IsTrue (FilledIn(NoNull3));
        IsTrue (FilledIn(Nully1 ));
        IsTrue (FilledIn(Nully2 ));
        IsTrue (FilledIn(Nully3 ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersNo_Extensions()
    {
        IsFalse(NullNum.FilledIn(                  ));
        IsFalse(NullNum.FilledIn(zeroMatters: false));
        IsFalse(NullNum.FilledIn(             false));
        IsFalse(NoNull0.FilledIn(                  ));
        IsFalse(NoNull0.FilledIn(zeroMatters: false));
        IsFalse(NoNull0.FilledIn(             false));
        IsFalse(Nully0 .FilledIn(                  ));
        IsFalse(Nully0 .FilledIn(zeroMatters: false));
        IsFalse(Nully0 .FilledIn(             false));
        IsTrue (NoNull1.FilledIn(                  ));
        IsTrue (NoNull1.FilledIn(zeroMatters: false));
        IsTrue (NoNull1.FilledIn(             false));
        IsTrue (Nully1 .FilledIn(                  ));
        IsTrue (Nully1 .FilledIn(zeroMatters: false));
        IsTrue (Nully1 .FilledIn(             false));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersNo_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullNum                    ));
        IsFalse(FilledIn(NullNum, zeroMatters: false));
        IsFalse(FilledIn(NullNum,              false));
        IsFalse(FilledIn(NoNull0                    ));
        IsFalse(FilledIn(NoNull0, zeroMatters: false));
        IsFalse(FilledIn(NoNull0,              false));
        IsFalse(FilledIn(Nully0                     ));
        IsFalse(FilledIn(Nully0,  zeroMatters: false));
        IsFalse(FilledIn(Nully0,               false));
        IsTrue (FilledIn(NoNull1                    ));
        IsTrue (FilledIn(NoNull1, zeroMatters: false));
        IsTrue (FilledIn(NoNull1,              false));
        IsTrue (FilledIn(Nully1                     ));
        IsTrue (FilledIn(Nully1,  zeroMatters: false));
        IsTrue (FilledIn(Nully1,               false));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersNo_StaticFlagsInFront()
    {
        IsFalse(FilledIn(                    NullNum));
        IsFalse(FilledIn(zeroMatters: false, NullNum));
        IsFalse(FilledIn(             false, NullNum));
        IsFalse(FilledIn(                    NoNull0));
        IsFalse(FilledIn(zeroMatters: false, NoNull0));
        IsFalse(FilledIn(             false, NoNull0));
        IsFalse(FilledIn(                    Nully0 ));
        IsFalse(FilledIn(zeroMatters: false, Nully0 ));
        IsFalse(FilledIn(             false, Nully0 ));
        IsTrue (FilledIn(                    NoNull1));
        IsTrue (FilledIn(zeroMatters: false, NoNull1));
        IsTrue (FilledIn(             false, NoNull1));
        IsTrue (FilledIn(                    Nully1 ));
        IsTrue (FilledIn(zeroMatters: false, Nully1 ));
        IsTrue (FilledIn(             false, Nully1 ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersYes_Extensions()
    {
        IsFalse(NullNum.FilledIn(zeroMatters       ));
        IsFalse(NullNum.FilledIn(zeroMatters: true ));
        IsFalse(NullNum.FilledIn(             true ));
        IsTrue (NoNull0.FilledIn(zeroMatters       ));
        IsTrue (NoNull0.FilledIn(zeroMatters: true ));
        IsTrue (NoNull0.FilledIn(             true ));
        IsTrue (Nully0 .FilledIn(zeroMatters       ));
        IsTrue (Nully0 .FilledIn(zeroMatters: true ));
        IsTrue (Nully0 .FilledIn(             true ));
        IsTrue (NoNull1.FilledIn(zeroMatters       ));
        IsTrue (NoNull1.FilledIn(zeroMatters: true ));
        IsTrue (NoNull1.FilledIn(             true ));
        IsTrue (Nully1 .FilledIn(zeroMatters       ));
        IsTrue (Nully1 .FilledIn(zeroMatters: true ));
        IsTrue (Nully1 .FilledIn(             true ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersYes_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullNum, zeroMatters       ));
        IsFalse(FilledIn(NullNum, zeroMatters: true ));
        IsFalse(FilledIn(NullNum,              true ));
        IsTrue (FilledIn(NoNull0, zeroMatters       ));
        IsTrue (FilledIn(NoNull0, zeroMatters: true ));
        IsTrue (FilledIn(NoNull0,              true ));
        IsTrue (FilledIn(Nully0,  zeroMatters       ));
        IsTrue (FilledIn(Nully0,  zeroMatters: true ));
        IsTrue (FilledIn(Nully0,               true ));
        IsTrue (FilledIn(NoNull1, zeroMatters       ));
        IsTrue (FilledIn(NoNull1, zeroMatters: true ));
        IsTrue (FilledIn(NoNull1,              true ));
        IsTrue (FilledIn(Nully1,  zeroMatters       ));
        IsTrue (FilledIn(Nully1,  zeroMatters: true ));
        IsTrue (FilledIn(Nully1,               true ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersYes_StaticFlagsInFront()
    {
        IsFalse(FilledIn(zeroMatters,       NullNum ));
        IsFalse(FilledIn(zeroMatters: true, NullNum ));
        IsFalse(FilledIn(             true, NullNum ));
        IsTrue (FilledIn(zeroMatters,       NoNull0 ));
        IsTrue (FilledIn(zeroMatters: true, NoNull0 ));
        IsTrue (FilledIn(             true, NoNull0 ));
        IsTrue (FilledIn(zeroMatters,       Nully0  ));
        IsTrue (FilledIn(zeroMatters: true, Nully0  ));
        IsTrue (FilledIn(             true, Nully0  ));
        IsTrue (FilledIn(zeroMatters,       NoNull1 ));
        IsTrue (FilledIn(zeroMatters: true, NoNull1 ));
        IsTrue (FilledIn(             true, NoNull1 ));
        IsTrue (FilledIn(zeroMatters,       Nully1  ));
        IsTrue (FilledIn(zeroMatters: true, Nully1  ));
        IsTrue (FilledIn(             true, Nully1  ));
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void FilledIn_Values_NotNullWhen()
    {
        int? Num() => Nully1;

        { int? num = Num(); if (FilledIn(num             )) num = num.Value; }
        { int? num = Num(); if (FilledIn(num, true       )) num = num.Value; }
        { int? num = Num(); if (FilledIn(num, zeroMatters)) num = num.Value; }
        { int? num = Num(); if (FilledIn(             num)) num = num.Value; }
        { int? num = Num(); if (FilledIn(true,        num)) num = num.Value; }
        { int? num = Num(); if (FilledIn(zeroMatters, num)) num = num.Value; }
        { int? num = Num(); if (num .FilledIn(           )) num = num.Value; }
        { int? num = Num(); if (num .FilledIn(true       )) num = num.Value; }
        { int? num = Num(); if (num .FilledIn(zeroMatters)) num = num.Value; }
    }
}