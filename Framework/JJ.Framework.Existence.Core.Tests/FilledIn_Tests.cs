namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Tests
{
    private static readonly Dummy? NullyFilled = NullyFilledObj;

    // Objects

    [TestMethod]
    public void FilledIn_Object_True()
    {
        IsTrue(FilledIn(NoNullObj));
        IsTrue(FilledIn(NullyFilled));
        IsTrue(NoNullObj.FilledIn());
        IsTrue(NullyFilled.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Object_False()
    {
        IsFalse(FilledIn(NullObj));
        IsFalse(NullObj.FilledIn());
    }

    // StringBuilder
    
    [TestMethod]
    public void FilledIn_StringBuilder_True()
    {
        IsTrue(FilledIn(FilledSB      ));
        IsTrue(FilledIn(NullyFilledSB ));
        IsTrue(FilledSB     .FilledIn());
        IsTrue(NullyFilledSB.FilledIn());
    }

    [TestMethod]
    public void FilledIn_StringBuilder_False()
    {
        IsFalse(FilledIn(EmptySB      ));
        IsFalse(FilledIn(SpaceSB      ));
        IsFalse(FilledIn(NullSB       ));
        IsFalse(FilledIn(NullyEmptySB ));
        IsFalse(FilledIn(NullySpaceSB ));
        IsFalse(EmptySB     .FilledIn());
        IsFalse(SpaceSB     .FilledIn());
        IsFalse(NullSB      .FilledIn());
        IsFalse(NullyEmptySB.FilledIn());
        IsFalse(NullySpaceSB.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersYes()
    {
        IsTrue (SpaceSB     .FilledIn( spaceMatters: true ));
        IsTrue (SpaceSB     .FilledIn( spaceMatters       ));
        IsTrue (SpaceSB     .FilledIn(               true ));
        IsTrue (NullySpaceSB.FilledIn( spaceMatters: true ));
        IsTrue (NullySpaceSB.FilledIn( spaceMatters       ));
        IsTrue (NullySpaceSB.FilledIn(               true ));
        IsTrue (FilledIn(SpaceSB,      spaceMatters: true ));
        IsTrue (FilledIn(SpaceSB,      spaceMatters       ));
        IsTrue (FilledIn(SpaceSB,                    true ));
        IsTrue (FilledIn(NullySpaceSB, spaceMatters: true ));
        IsTrue (FilledIn(NullySpaceSB, spaceMatters       ));
        IsTrue (FilledIn(NullySpaceSB,               true ));
        IsTrue (FilledIn(spaceMatters: true, SpaceSB      ));
        IsTrue (FilledIn(spaceMatters,       SpaceSB      ));
        IsTrue (FilledIn(              true, SpaceSB      ));
        IsTrue (FilledIn(spaceMatters: true, NullySpaceSB ));
        IsTrue (FilledIn(spaceMatters,       NullySpaceSB ));
        IsTrue (FilledIn(              true, NullySpaceSB ));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersNo()
    {
        IsFalse(SpaceSB     .FilledIn( spaceMatters: false));
        IsFalse(SpaceSB     .FilledIn(               false));
        IsFalse(NullySpaceSB.FilledIn( spaceMatters: false));
        IsFalse(NullySpaceSB.FilledIn(               false));
        IsFalse(FilledIn(SpaceSB,      spaceMatters: false));
        IsFalse(FilledIn(SpaceSB,                    false));
        IsFalse(FilledIn(NullySpaceSB, spaceMatters: false));
        IsFalse(FilledIn(NullySpaceSB,               false));
        IsFalse(FilledIn(spaceMatters: false, SpaceSB     ));
        IsFalse(FilledIn(              false, SpaceSB     ));
        IsFalse(FilledIn(spaceMatters: false, NullySpaceSB));
        IsFalse(FilledIn(              false, NullySpaceSB));
    }

}