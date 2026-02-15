namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_StaticCaseOrSpaceMattersNoNo : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_StaticFlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ]                                         ));
        IsTrue (In("B \t", [ "A", "B", "C" ]                                         ));
        IsTrue (In("b"   , [ "A", "B", "C" ]                                         ));
        IsTrue (In("b \t", [ "A", "B", "C" ]                                         ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false, spaceMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                   false)); // Assigns wrong parameter
      //IsTrue (In("B \t", [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],                                   false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false,               false));
    }
        
    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_StaticFlagsInBackSwapped()
    {
      //IsTrue (In("B"   , [ "A", "B", "C" ]                                         )); // Not a swap
      //IsTrue (In("B \t", [ "A", "B", "C" ]                                         ));
      //IsTrue (In("b"   , [ "A", "B", "C" ]                                         ));
      //IsTrue (In("b \t", [ "A", "B", "C" ]                                         ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("B \t", [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                   false));
      //IsTrue (In("B \t", [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],                                   false));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false                    ));
      //IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false                    ));
      //IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false                    ));
      //IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false                    ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false                    )); // Assigns wrong parameter
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false                    ));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               false                    ));
      //IsTrue (In("b \t", [ "A", "B", "C" ],               false                    ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false,              false)); // Not a swap
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false,              false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               false,              false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],               false,              false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_StaticCollectionFlagsInFront()
    {
        IsTrue (In("B"   ,                                          [ "A", "B", "C" ]));
        IsTrue (In("B \t",                                          [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                                          [ "A", "B", "C" ]));
        IsTrue (In("b \t",                                          [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",                     spaceMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,                                   false, [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue (In("B \t",                                   false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,                                   false, [ "A", "B", "C" ]));
      //IsTrue (In("b \t",                                   false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false,                      [ "A", "B", "C" ]));
        IsTrue (In("B \t",              false,                      [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false,                      [ "A", "B", "C" ]));
        IsTrue (In("b \t",              false,                      [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",              false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",              false,               false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_StaticCollectionFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   ,                                          [ "A", "B", "C" ])); // Not a swap
      //IsTrue (In("B \t",                                          [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,                                          [ "A", "B", "C" ]));
      //IsTrue (In("b \t",                                          [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: false,                     [ "A", "B", "C" ]));
      //IsTrue (In("B \t", spaceMatters: false,                     [ "A", "B", "C" ]));
      //IsTrue (In("b"   , spaceMatters: false,                     [ "A", "B", "C" ]));
      //IsTrue (In("b \t", spaceMatters: false,                     [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               false,                     [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue (In("B \t",               false,                     [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,               false,                     [ "A", "B", "C" ]));
      //IsTrue (In("b \t",               false,                     [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,                      caseMatters: false, [ "A", "B", "C" ])); // Not a swap
      //IsTrue (In("B \t",                      caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,                      caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b \t",                      caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",               false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,               false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",               false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,                                   false, [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue (In("B \t",                                   false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,                                   false, [ "A", "B", "C" ]));
      //IsTrue (In("b \t",                                   false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: false,              false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", spaceMatters: false,              false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters: false,              false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", spaceMatters: false,              false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false,              false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",               false,              false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,               false,              false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",               false,              false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_StaticParamsFlagsInFront()
    {
        IsTrue (In("B"   ,                                            "A", "B", "C"  ));
        IsTrue (In("B \t",                                            "A", "B", "C"  ));
        IsTrue (In("b"   ,                                            "A", "B", "C"  ));
        IsTrue (In("b \t",                                            "A", "B", "C"  ));
      //IsTrue (In("B"   ,                     spaceMatters: false,   "A", "B", "C"  )); // TODO: Does not work
      //IsTrue (In("B \t",                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b"   ,                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b \t",                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("B"   ,                                   false,   "A", "B", "C"  )); // Assigns wrong parameter
      //IsTrue (In("B \t",                                   false,   "A", "B", "C"  )); 
      //IsTrue (In("b"   ,                                   false,   "A", "B", "C"  )); 
      //IsTrue (In("b \t",                                   false,   "A", "B", "C"  )); 
        IsTrue (In("B"   , caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              false,                        "A", "B", "C"  ));
        IsTrue (In("B \t",              false,                        "A", "B", "C"  ));
        IsTrue (In("b"   ,              false,                        "A", "B", "C"  ));
        IsTrue (In("b \t",              false,                        "A", "B", "C"  ));
        IsTrue (In("B"   ,              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t",              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   ,              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b \t",              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              false,               false,   "A", "B", "C"  ));
        IsTrue (In("B \t",              false,               false,   "A", "B", "C"  ));
        IsTrue (In("b"   ,              false,               false,   "A", "B", "C"  ));
        IsTrue (In("b \t",              false,               false,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_StaticParamsFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   ,                                             "A", "B", "C"  )); // Not a swap 
      //IsTrue (In("B \t",                                             "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                             "A", "B", "C"  ));
      //IsTrue (In("b \t",                                             "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false,                        "A", "B", "C"  )); 
      //IsTrue (In("B \t", spaceMatters: false,                        "A", "B", "C"  )); 
      //IsTrue (In("b"   , spaceMatters: false,                        "A", "B", "C"  )); 
      //IsTrue (In("b \t", spaceMatters: false,                        "A", "B", "C"  )); 
      //IsTrue (In("B"   ,               false,                        "A", "B", "C"  )); 
      //IsTrue (In("B \t",               false,                        "A", "B", "C"  )); 
      //IsTrue (In("b"   ,               false,                        "A", "B", "C"  )); 
      //IsTrue (In("b \t",               false,                        "A", "B", "C"  )); 
      //IsTrue (In("B"   ,                      caseMatters: false,    "A", "B", "C"  )); // Not a swap
      //IsTrue (In("B \t",                      caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("b"   ,                      caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("b \t",                      caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false, caseMatters: false,    "A", "B", "C"  )); // TODO: Does not work
      //IsTrue (In("B \t", spaceMatters: false, caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: false, caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("b \t", spaceMatters: false, caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,               false, caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("B \t",               false, caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("b"   ,               false, caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("b \t",               false, caseMatters: false,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,                                   false,    "A", "B", "C"  )); // Assigns wrong variable
      //IsTrue (In("B \t",                                   false,    "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                   false,    "A", "B", "C"  ));
      //IsTrue (In("b \t",                                   false,    "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false,              false,    "A", "B", "C"  )); // TODO: Does not work
      //IsTrue (In("B \t", spaceMatters: false,              false,    "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: false,              false,    "A", "B", "C"  ));
      //IsTrue (In("b \t", spaceMatters: false,              false,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,               false,              false,    "A", "B", "C"  )); // Not a swap
      //IsTrue (In("B \t",               false,              false,    "A", "B", "C"  ));
      //IsTrue (In("b"   ,               false,              false,    "A", "B", "C"  ));
      //IsTrue (In("b \t",               false,              false,    "A", "B", "C"  ));
   }
}