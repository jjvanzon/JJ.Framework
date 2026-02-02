namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Tests : TestBase
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
    
    // Values

    // Text
        
    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue(FilledIn(Text));
        IsTrue(FilledIn(NullyFilled));
        IsTrue(Text.FilledIn());
        IsTrue(NullyFilled.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(FilledIn( Empty     ));
        IsFalse(FilledIn( Space     ));
        IsFalse(FilledIn( NullText  ));
        IsFalse(FilledIn( NullyEmpty));
        IsFalse(FilledIn( NullySpace));
        IsFalse(Empty     .FilledIn());
        IsFalse(Space     .FilledIn());
        IsFalse(NullText  .FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes()
    {
        IsTrue (Space     .FilledIn( spaceMatters: true ));
        IsTrue (Space     .FilledIn( spaceMatters       ));
        IsTrue (Space     .FilledIn(               true ));
        IsTrue (NullySpace.FilledIn( spaceMatters: true ));
        IsTrue (NullySpace.FilledIn( spaceMatters       ));
        IsTrue (NullySpace.FilledIn(               true ));
        IsTrue (FilledIn(Space,      spaceMatters: true ));
        IsTrue (FilledIn(Space,      spaceMatters       ));
        IsTrue (FilledIn(Space,                    true ));
        IsTrue (FilledIn(NullySpace, spaceMatters: true ));
        IsTrue (FilledIn(NullySpace, spaceMatters       ));
        IsTrue (FilledIn(NullySpace,               true ));
        IsTrue (FilledIn(spaceMatters: true,  Space     ));
        IsTrue (FilledIn(spaceMatters,        Space     ));
        IsTrue (FilledIn(              true,  Space     ));
        IsTrue (FilledIn(spaceMatters: true,  NullySpace));
        IsTrue (FilledIn(spaceMatters,        NullySpace));
        IsTrue (FilledIn(              true,  NullySpace));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo()
    {
        IsFalse(Space     .FilledIn( spaceMatters: false));
        IsFalse(Space     .FilledIn(               false));
        IsFalse(NullySpace.FilledIn( spaceMatters: false));
        IsFalse(NullySpace.FilledIn(               false));
        IsFalse(FilledIn(Space,      spaceMatters: false));
        IsFalse(FilledIn(Space,                    false));
        IsFalse(FilledIn(NullySpace, spaceMatters: false));
        IsFalse(FilledIn(NullySpace,               false));
        IsFalse(FilledIn(spaceMatters: false, Space     ));
        IsFalse(FilledIn(              false, Space     ));
        IsFalse(FilledIn(spaceMatters: false, NullySpace));
        IsFalse(FilledIn(              false, NullySpace));
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