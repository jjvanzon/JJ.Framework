// ReSharper disable VariableCanBeNotNullable
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Contains_Nullable_Tests
{
    // Nullables / CaseMatters No

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersNo_Implicit()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains("Red"   ));
       IsTrue (coll.Contains("RED"   ));
       IsTrue (coll.Contains("Green" ));
       IsTrue (coll.Contains("GREEN" ));
       IsTrue (coll.Contains("Blue"  ));
       IsTrue (coll.Contains("BLUE"  ));
       IsFalse(coll.Contains("Yellow"));
       IsFalse(coll.Contains("YELLOW"));
       IsTrue (coll.Contains(null    ));
    }
    
    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersNo_ExplicitNamedFlagInBack()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains("Red"   , caseMatters: false));
       IsTrue (coll.Contains("RED"   , caseMatters: false));
       IsTrue (coll.Contains("Green" , caseMatters: false));
       IsTrue (coll.Contains("GREEN" , caseMatters: false));
       IsTrue (coll.Contains("Blue"  , caseMatters: false));
       IsTrue (coll.Contains("BLUE"  , caseMatters: false));
       IsFalse(coll.Contains("Yellow", caseMatters: false));
       IsFalse(coll.Contains("YELLOW", caseMatters: false));
       IsTrue (coll.Contains(null                        ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersNo_ExplicitNamedFlagInFront()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains(caseMatters: false, "Red"   ));
       IsTrue (coll.Contains(caseMatters: false, "RED"   ));
       IsTrue (coll.Contains(caseMatters: false, "Green" ));
       IsTrue (coll.Contains(caseMatters: false, "GREEN" ));
       IsTrue (coll.Contains(caseMatters: false, "Blue"  ));
       IsTrue (coll.Contains(caseMatters: false, "BLUE"  ));
       IsFalse(coll.Contains(caseMatters: false, "Yellow"));
       IsFalse(coll.Contains(caseMatters: false, "YELLOW"));
       IsTrue (coll.Contains(null                        ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersNo_ExplicitUnnamedFlagInBack()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains("Red"   , false));
       IsTrue (coll.Contains("RED"   , false));
       IsTrue (coll.Contains("Green" , false));
       IsTrue (coll.Contains("GREEN" , false));
       IsTrue (coll.Contains("Blue"  , false));
       IsTrue (coll.Contains("BLUE"  , false));
       IsFalse(coll.Contains("Yellow", false));
       IsFalse(coll.Contains("YELLOW", false));
       IsTrue (coll.Contains(null           ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersNo_ExplicitUnnamedFlagInFront()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains(false, "Red"   ));
       IsTrue (coll.Contains(false, "RED"   ));
       IsTrue (coll.Contains(false, "Green" ));
       IsTrue (coll.Contains(false, "GREEN" ));
       IsTrue (coll.Contains(false, "Blue"  ));
       IsTrue (coll.Contains(false, "BLUE"  ));
       IsFalse(coll.Contains(false, "Yellow"));
       IsFalse(coll.Contains(false, "YELLOW"));
       IsTrue (coll.Contains(null           ));
    }

    // Nullables / CaseMatters Yes

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersYes_MagicBoolFlagInBack()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains("Red"   , caseMatters));
       IsFalse(coll.Contains("RED"   , caseMatters));
       IsTrue (coll.Contains("Green" , caseMatters));
       IsFalse(coll.Contains("GREEN" , caseMatters));
       IsTrue (coll.Contains("Blue"  , caseMatters));
       IsFalse(coll.Contains("BLUE"  , caseMatters));
       IsFalse(coll.Contains("Yellow", caseMatters));
       IsFalse(coll.Contains("YELLOW", caseMatters));
       IsTrue (coll.Contains(null                 ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersYes_MagicBoolFlagInFront()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains(caseMatters, "Red"   ));
       IsFalse(coll.Contains(caseMatters, "RED"   ));
       IsTrue (coll.Contains(caseMatters, "Green" ));
       IsFalse(coll.Contains(caseMatters, "GREEN" ));
       IsTrue (coll.Contains(caseMatters, "Blue"  ));
       IsFalse(coll.Contains(caseMatters, "BLUE"  ));
       IsFalse(coll.Contains(caseMatters, "Yellow"));
       IsFalse(coll.Contains(caseMatters, "YELLOW"));
       IsTrue (coll.Contains(null                 ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersYes_ExplicitBoolNamedBoolFlagInBack()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains("Red"   , caseMatters: true));
       IsFalse(coll.Contains("RED"   , caseMatters: true));
       IsTrue (coll.Contains("Green" , caseMatters: true));
       IsFalse(coll.Contains("GREEN" , caseMatters: true));
       IsTrue (coll.Contains("Blue"  , caseMatters: true));
       IsFalse(coll.Contains("BLUE"  , caseMatters: true));
       IsFalse(coll.Contains("Yellow", caseMatters: true));
       IsFalse(coll.Contains("YELLOW", caseMatters: true));
       IsTrue (coll.Contains(null                       ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersYes_ExplicitNamedBoolFlagInFront()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains(caseMatters: true, "Red"   ));
       IsFalse(coll.Contains(caseMatters: true, "RED"   ));
       IsTrue (coll.Contains(caseMatters: true, "Green" ));
       IsFalse(coll.Contains(caseMatters: true, "GREEN" ));
       IsTrue (coll.Contains(caseMatters: true, "Blue"  ));
       IsFalse(coll.Contains(caseMatters: true, "BLUE"  ));
       IsFalse(coll.Contains(caseMatters: true, "Yellow"));
       IsFalse(coll.Contains(caseMatters: true, "YELLOW"));
       IsTrue (coll.Contains(null                       ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersYes_ExplicitBoolUnnamedBoolFlagInBack()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains("Red"   , true));
       IsFalse(coll.Contains("RED"   , true));
       IsTrue (coll.Contains("Green" , true));
       IsFalse(coll.Contains("GREEN" , true));
       IsTrue (coll.Contains("Blue"  , true));
       IsFalse(coll.Contains("BLUE"  , true));
       IsFalse(coll.Contains("Yellow", true));
       IsFalse(coll.Contains("YELLOW", true));
       IsTrue (coll.Contains(null          ));
    }

    [TestMethod]
    public void Test_Contains_Nullables_CaseMattersYes_ExplicitUnnamedBoolFlagInFront()
    {
       string?[]? coll = [ "Red", "Green", "Blue", null ];
       IsTrue (coll.Contains(true, "Red"   ));
       IsFalse(coll.Contains(true, "RED"   ));
       IsTrue (coll.Contains(true, "Green" ));
       IsFalse(coll.Contains(true, "GREEN" ));
       IsTrue (coll.Contains(true, "Blue"  ));
       IsFalse(coll.Contains(true, "BLUE"  ));
       IsFalse(coll.Contains(true, "Yellow"));
       IsFalse(coll.Contains(true, "YELLOW"));
       IsTrue (coll.Contains(null          ));
    }
}