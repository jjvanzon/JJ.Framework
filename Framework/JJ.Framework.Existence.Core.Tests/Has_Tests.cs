namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Tests : TestBase
{
    // Objects

    [TestMethod]
    public void Has_Object_True()
    {
        IsTrue(Has(NoNullObj));
        IsTrue(Has(NullyFilledObj));
    }
    
    [TestMethod]
    public void Has_Object_False()
    {
        IsFalse(Has(NullObj));
    }

    // Values

    [TestMethod]
    public void Has_True_Int1()
    {
        // Invariant under zeroMatters
        IsTrue(Has(NoNull1                    ));
        IsTrue(Has(NoNull1, zeroMatters       ));
        IsTrue(Has(NoNull1, zeroMatters: true ));
        IsTrue(Has(NoNull1, zeroMatters: false));
        IsTrue(Has(Nully1                     ));
        IsTrue(Has(Nully1,  zeroMatters       ));
        IsTrue(Has(Nully1,  zeroMatters: true ));
        IsTrue(Has(Nully1,  zeroMatters: false));
    }
    
    [TestMethod]
    public void Has_False_Int0()
    {
        // zeroMatters false
        IsFalse(Has(NoNull0                    ));
        IsFalse(Has(NoNull0, zeroMatters: false));
        IsFalse(Has(NoNull0,              false));
        IsFalse(Has(Nully0                     ));
        IsFalse(Has(Nully0,  zeroMatters: false));
        IsFalse(Has(Nully0,               false));
    }
    
    [TestMethod]
    public void Has_False_IntNull()
    {
        // zeroMatters false
        IsFalse(Has(NullNum                    ));
        IsFalse(Has(NullNum, zeroMatters: false));
        IsFalse(Has(NullNum,              false));
    }

    [TestMethod]
    public void Has_True_Int0_ZeroMatters()
    {
        IsTrue(Has(NoNull0, zeroMatters       ));
        IsTrue(Has(NoNull0, zeroMatters: true ));
        IsTrue(Has(NoNull0,              true ));
        IsTrue(Has(Nully0,  zeroMatters       ));
        IsTrue(Has(Nully0,  zeroMatters: true ));
        IsTrue(Has(Nully0,               true ));
    }

    [TestMethod]
    public void Has_False_IntNull_ZeroMatters()
    {
        IsFalse(Has(NullNum, zeroMatters       ));
        IsFalse(Has(NullNum, zeroMatters: true ));
        IsFalse(Has(NullNum,              true ));
    }

    // Text

    [TestMethod]
    public void Has_Text_True()
    {
        IsTrue(Has(Text));
        IsTrue(Has(NullyFilledText));
    }

    [TestMethod]
    public void Has_Text_False()
    {
        IsFalse(Has(Empty));
        IsFalse(Has(Space));
        IsFalse(Has(NullText));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMatters()
    {
        IsTrue (Has(Space,      spaceMatters: true ));
        IsTrue (Has(Space,      spaceMatters       ));
        IsTrue (Has(Space,                    true ));
        IsTrue (Has(NullySpace, spaceMatters: true ));
        IsTrue (Has(NullySpace, spaceMatters       ));
        IsTrue (Has(NullySpace,               true ));
        IsFalse(Has(Space,      spaceMatters: false));
        IsFalse(Has(Space,                    false));
        IsFalse(Has(NullySpace, spaceMatters: false));
        IsFalse(Has(NullySpace,               false));
    }

    // StringBuilder

    [TestMethod]
    public void Has_StringBuilder_True()
    {
        IsTrue(Has(FilledSB     ));
        IsTrue(Has(NullyFilledSB));
    }

    [TestMethod]
    public void Has_StringBuilder_False()
    {
        IsFalse(Has(EmptySB     ));
        IsFalse(Has(SpaceSB     ));
        IsFalse(Has(NullSB      ));
        IsFalse(Has(NullyEmptySB));
        IsFalse(Has(NullySpaceSB));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMatters()
    {
        IsTrue (Has(SpaceSB,      spaceMatters: true ));
        IsTrue (Has(SpaceSB,      spaceMatters       ));
        IsTrue (Has(SpaceSB,                    true ));
        IsTrue (Has(NullySpaceSB, spaceMatters: true ));
        IsTrue (Has(NullySpaceSB, spaceMatters       ));
        IsTrue (Has(NullySpaceSB,               true ));
        IsFalse(Has(SpaceSB,      spaceMatters: false));
        IsFalse(Has(SpaceSB,                    false));
        IsFalse(Has(NullySpaceSB, spaceMatters: false));
        IsFalse(Has(NullySpaceSB,               false));
    }
}