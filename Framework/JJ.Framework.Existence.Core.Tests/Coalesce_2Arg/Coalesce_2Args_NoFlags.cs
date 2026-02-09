namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_NoFlags : TestBase
{
    private static readonly Dummy? NullyFilled = NullyFilledObj;
            
    [TestMethod]
    public void Coalesce_2Args_RandomCases()
    {
        NoNullRet("Hello", Coalesce("", "Hello", "World"));
        NoNullRet("Hello", "".Coalesce("Hello", "World"));
        NoNullRet(1, Coalesce(null, 0, 1));
        NoNullRet(0, Coalesce(null, 0, 1, zeroMatters));
    }

    // Text

    [TestMethod]
    public void Coalesce_2Args_Text_Literals()
    {
        NoNullRet("",         Coalesce(NullText,  NullText ));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback"));
        NoNullRet("Fallback", Coalesce("",       "Fallback"));
        NoNullRet("Fallback", Coalesce("   ",    "Fallback"));
        NoNullRet("",         NullText.Coalesce(  NullText ));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback"));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback"));
        NoNullRet("Fallback", "   "   .Coalesce( "Fallback"));
    }

    [TestMethod]
    public void Coalesce_2Args_Text_Vars()
    {
        NoNullRet(Empty, Coalesce(NullText, NullText));
        NoNullRet(Text,  Coalesce(NullText, Text    ));
        NoNullRet(Text,  Coalesce(Empty,    Text    ));
        NoNullRet(Text,  Coalesce(Space,    Text    ));
        NoNullRet(Empty, NullText.Coalesce( NullText));
        NoNullRet(Text,  NullText.Coalesce( Text    ));
        NoNullRet(Text,  Empty   .Coalesce( Text    ));
        NoNullRet(Text,  Space   .Coalesce( Text    ));
    }

    // StringBuilder

    [TestMethod]
    public void Coalesce_2Args_StringBuilder()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB));
        NoNullRet(FilledSB, Coalesce(SpaceSB, FilledSB));
        NoNullRet(          NullSB .Coalesce( NullSB  ));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB));
        NoNullRet(FilledSB, SpaceSB.Coalesce( FilledSB));
        
        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB  )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB)}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB)}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB)}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce( FilledSB)}");
    }
    
    // StringBuilder / Text Combos
    
    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText()
    {
        NoNullRet(Text,       Coalesce(NullSB,       Text));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text));
        NoNullRet(Text,       NullSB       .Coalesce(Text));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder()
    {
        NoNullRet("FilledSB", Coalesce(NullText,        NullyFilledSB));
        NoNullRet("Filled",   Coalesce(NullyFilledText, NullyFilledSB));
        NoNullRet("",         Coalesce(NullText,        NullSB       ));
        NoNullRet("FilledSB", NullText       .Coalesce( NullyFilledSB));
        NoNullRet("Filled",   NullyFilledText.Coalesce( NullyFilledSB));
        NoNullRet("",         NullText       .Coalesce( NullSB       ));
    }

    // Bool

    [TestMethod]
    public void Coalesce_2Args_Bool_VerifyInputs()
    {
        // Assert input states
        IsNull   (       NullBool  );
        NullRet  (false, NullyFalse);
        NullRet  (true,  NullyTrue );
        NoNullRet(false, False     );
        NoNullRet(true,  True      );
        NoNullRet(       false     );
        NoNullRet(       true      );
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Static()
    {
        NoNullRet(false, Coalesce(NullBool,   NullBool  ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool  ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool  ));
        NoNullRet(false, Coalesce(False,      NullBool  ));
        NoNullRet(true,  Coalesce(True,       NullBool  ));
        NoNullRet(false, Coalesce(false,      NullBool  ));
        NoNullRet(true,  Coalesce(true,       NullBool  ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse));
        NoNullRet(false, Coalesce(NullyFalse, NullyFalse));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse));
        NoNullRet(false, Coalesce(False,      NullyFalse));
        NoNullRet(true,  Coalesce(True,       NullyFalse));
        NoNullRet(false, Coalesce(false,      NullyFalse));
        NoNullRet(true,  Coalesce(true,       NullyFalse));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyTrue ));
        NoNullRet(true,  Coalesce(False,      NullyTrue ));
        NoNullRet(true,  Coalesce(True,       NullyTrue ));
        NoNullRet(true,  Coalesce(false,      NullyTrue ));
        NoNullRet(true,  Coalesce(true,       NullyTrue ));
        NoNullRet(false, Coalesce(NullBool,   False     ));
        NoNullRet(false, Coalesce(NullyFalse, False     ));
        NoNullRet(true,  Coalesce(NullyTrue,  False     ));
        NoNullRet(false, Coalesce(False,      False     ));
        NoNullRet(true,  Coalesce(True,       False     ));
        NoNullRet(false, Coalesce(false,      False     ));
        NoNullRet(true,  Coalesce(true,       False     ));
        NoNullRet(true,  Coalesce(NullBool,   True      ));
        NoNullRet(true,  Coalesce(NullyFalse, True      ));
        NoNullRet(true,  Coalesce(NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(False,      True      ));
        NoNullRet(true,  Coalesce(True,       True      ));
        NoNullRet(true,  Coalesce(false,      True      ));
        NoNullRet(true,  Coalesce(true,       True      ));
        NoNullRet(false, Coalesce(NullBool,   false     ));
        NoNullRet(false, Coalesce(NullyFalse, false     ));
        NoNullRet(true,  Coalesce(NullyTrue,  false     ));
        NoNullRet(false, Coalesce(False,      false     ));
        NoNullRet(true,  Coalesce(True,       false     ));
        NoNullRet(false, Coalesce(false,      false     ));
        NoNullRet(true,  Coalesce(true,       false     ));
        NoNullRet(true,  Coalesce(NullBool,   true      ));
        NoNullRet(true,  Coalesce(NullyFalse, true      ));
        NoNullRet(true,  Coalesce(NullyTrue,  true      ));
        NoNullRet(true,  Coalesce(False,      true      ));
        NoNullRet(true,  Coalesce(True,       true      ));
        NoNullRet(true,  Coalesce(false,      true      ));
        NoNullRet(true,  Coalesce(true,       true      ));
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Extensions()
    {
        NoNullRet(false, NullBool  .Coalesce( NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce( NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce( NullBool  ));
        NoNullRet(false, False     .Coalesce( NullBool  ));
        NoNullRet(true,  True      .Coalesce( NullBool  ));
        NoNullRet(false, false     .Coalesce( NullBool  ));
        NoNullRet(true,  true      .Coalesce( NullBool  ));
        NoNullRet(false, NullBool  .Coalesce( NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce( NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce( NullyFalse));
        NoNullRet(false, false     .Coalesce( NullyFalse));
        NoNullRet(true,  true      .Coalesce( NullyFalse));
        NoNullRet(false, False     .Coalesce( NullyFalse));
        NoNullRet(true,  True      .Coalesce( NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce( NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce( NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce( NullyTrue ));
        NoNullRet(true,  False     .Coalesce( NullyTrue ));
        NoNullRet(true,  True      .Coalesce( NullyTrue ));
        NoNullRet(true,  false     .Coalesce( NullyTrue ));
        NoNullRet(true,  true      .Coalesce( NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce( False     ));
        NoNullRet(false, NullyFalse.Coalesce( False     ));
        NoNullRet(true,  NullyTrue .Coalesce( False     ));
        NoNullRet(false, False     .Coalesce( False     ));
        NoNullRet(true,  True      .Coalesce( False     ));
        NoNullRet(false, false     .Coalesce( False     ));
        NoNullRet(true,  true      .Coalesce( False     ));
        NoNullRet(true,  NullBool  .Coalesce( True      ));
        NoNullRet(true,  NullyFalse.Coalesce( True      ));
        NoNullRet(true,  NullyTrue .Coalesce( True      ));
        NoNullRet(true,  False     .Coalesce( True      ));
        NoNullRet(true,  True      .Coalesce( True      ));
        NoNullRet(true,  false     .Coalesce( True      ));
        NoNullRet(true,  true      .Coalesce( True      ));
        NoNullRet(false, NullBool  .Coalesce( false     ));
        NoNullRet(false, NullyFalse.Coalesce( false     ));
        NoNullRet(true,  NullyTrue .Coalesce( false     ));
        NoNullRet(false, False     .Coalesce( false     ));
        NoNullRet(true,  True      .Coalesce( false     ));
        NoNullRet(false, false     .Coalesce( false     ));
        NoNullRet(true,  true      .Coalesce( false     ));
        NoNullRet(true,  NullBool  .Coalesce( true      ));
        NoNullRet(true,  NullyFalse.Coalesce( true      ));
        NoNullRet(true,  NullyTrue .Coalesce( true      ));
        NoNullRet(true,  False     .Coalesce( true      ));
        NoNullRet(true,  True      .Coalesce( true      ));
        NoNullRet(true,  false     .Coalesce( true      ));
        NoNullRet(true,  true      .Coalesce( true      ));
    }

    // Bools to Text

    [TestMethod]
    public void Coalesce_2Args_BoolToText_NoNullies()
    {
        NoNullRet("",           Coalesce(false,  NullText ));
        NoNullRet("peekaboo",   Coalesce(false, "peekaboo"));
        NoNullRet("",           false.Coalesce(  NullText ));
        NoNullRet("peekaboo",   false.Coalesce( "peekaboo"));
        NoNullRet("True",       true. Coalesce(  NullText ));
        NoNullRet("True",       true. Coalesce( "peekaboo"));
    }

    [TestMethod]
    public void Coalesce_2Args_BoolToText_WithNullies()
    {
        NoNullRet("",     Coalesce(NullBool,   NullText ));
        NoNullRet("boo",  Coalesce(NullBool,   "boo"     ));
        NoNullRet("",     Coalesce(NullyFalse, NullText ));
        NoNullRet("boo",  Coalesce(NullyFalse, "boo"     ));
        NoNullRet("True", Coalesce(NullyTrue,  NullText ));
        NoNullRet("True", Coalesce(NullyTrue,  "boo"     ));
        NoNullRet("",     NullBool  .Coalesce( NullText ));
        NoNullRet("boo",  NullBool  .Coalesce( "boo"     ));
        NoNullRet("",     NullyFalse.Coalesce( NullText ));
        NoNullRet("boo",  NullyFalse.Coalesce( "boo"     ));
        NoNullRet("True", NullyTrue .Coalesce( NullText ));
        NoNullRet("True", NullyTrue .Coalesce( "boo"     ));
    }

    // Vals

    [TestMethod]
    public void Coalesce_2Args_Vals_VerifyInputs()
    {
        // Assert input states
        IsNull (   NullNum);
        NullRet(0, Nully0 );
        NullRet(1, Nully1 );
        NullRet(2, Nully2 );
        NoNullRet(0);
        NoNullRet(1);
        NoNullRet(2);
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_Static()
    {
        NoNullRet(0, Coalesce( NullNum, NullNum));
        NoNullRet(0, Coalesce(  Nully0, NullNum));
        NoNullRet(1, Coalesce(  Nully1, NullNum));
        NoNullRet(2, Coalesce(  Nully2, NullNum));
        NoNullRet(0, Coalesce(       0, NullNum));
        NoNullRet(1, Coalesce(       1, NullNum));
        NoNullRet(2, Coalesce(       2, NullNum));
        NoNullRet(0, Coalesce( NullNum,  Nully0));
        NoNullRet(0, Coalesce(  Nully0,  Nully0));
        NoNullRet(1, Coalesce(  Nully1,  Nully0));
        NoNullRet(2, Coalesce(  Nully2,  Nully0));
        NoNullRet(0, Coalesce(       0,  Nully0));
        NoNullRet(1, Coalesce(       1,  Nully0));
        NoNullRet(2, Coalesce(       2,  Nully0));
        NoNullRet(1, Coalesce( NullNum,  Nully1));
        NoNullRet(1, Coalesce(  Nully0,  Nully1));
        NoNullRet(1, Coalesce(  Nully1,  Nully1));
        NoNullRet(2, Coalesce(  Nully2,  Nully1));
        NoNullRet(1, Coalesce(       0,  Nully1));
        NoNullRet(1, Coalesce(       1,  Nully1));
        NoNullRet(2, Coalesce(       2,  Nully1));
        NoNullRet(2, Coalesce( NullNum,  Nully2));
        NoNullRet(2, Coalesce(  Nully0,  Nully2));
        NoNullRet(1, Coalesce(  Nully1,  Nully2));
        NoNullRet(2, Coalesce(  Nully2,  Nully2));
        NoNullRet(2, Coalesce(       0,  Nully2));
        NoNullRet(1, Coalesce(       1,  Nully2));
        NoNullRet(2, Coalesce(       2,  Nully2));
        NoNullRet(0, Coalesce( NullNum,       0));
        NoNullRet(0, Coalesce(  Nully0,       0));
        NoNullRet(1, Coalesce(  Nully1,       0));
        NoNullRet(2, Coalesce(  Nully2,       0));
        NoNullRet(0, Coalesce(       0,       0));
        NoNullRet(1, Coalesce(       1,       0));
        NoNullRet(2, Coalesce(       2,       0));
        NoNullRet(1, Coalesce( NullNum,       1));
        NoNullRet(1, Coalesce(  Nully0,       1));
        NoNullRet(1, Coalesce(  Nully1,       1));
        NoNullRet(2, Coalesce(  Nully2,       1));
        NoNullRet(1, Coalesce(       0,       1));
        NoNullRet(1, Coalesce(       1,       1));
        NoNullRet(2, Coalesce(       2,       1));
        NoNullRet(2, Coalesce( NullNum,       2));
        NoNullRet(2, Coalesce(  Nully0,       2));
        NoNullRet(1, Coalesce(  Nully1,       2));
        NoNullRet(2, Coalesce(  Nully2,       2));
        NoNullRet(2, Coalesce(       0,       2));
        NoNullRet(1, Coalesce(       1,       2));
        NoNullRet(2, Coalesce(       2,       2));
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_Extensions()
    {
        NoNullRet(0,  NullNum.Coalesce( NullNum));
        NoNullRet(0,   Nully0.Coalesce( NullNum));
        NoNullRet(1,   Nully1.Coalesce( NullNum));
        NoNullRet(2,   Nully2.Coalesce( NullNum));
        NoNullRet(0,        0.Coalesce( NullNum));
        NoNullRet(1,        1.Coalesce( NullNum));
        NoNullRet(2,        2.Coalesce( NullNum));
        NoNullRet(0,  NullNum.Coalesce(  Nully0));
        NoNullRet(0,   Nully0.Coalesce(  Nully0));
        NoNullRet(1,   Nully1.Coalesce(  Nully0));
        NoNullRet(2,   Nully2.Coalesce(  Nully0));
        NoNullRet(0,        0.Coalesce(  Nully0));
        NoNullRet(1,        1.Coalesce(  Nully0));
        NoNullRet(2,        2.Coalesce(  Nully0));
        NoNullRet(1,  NullNum.Coalesce(  Nully1));
        NoNullRet(1,   Nully0.Coalesce(  Nully1));
        NoNullRet(1,   Nully1.Coalesce(  Nully1));
        NoNullRet(2,   Nully2.Coalesce(  Nully1));
        NoNullRet(1,        0.Coalesce(  Nully1));
        NoNullRet(1,        1.Coalesce(  Nully1));
        NoNullRet(2,        2.Coalesce(  Nully1));
        NoNullRet(2,  NullNum.Coalesce(  Nully2));
        NoNullRet(2,   Nully0.Coalesce(  Nully2));
        NoNullRet(1,   Nully1.Coalesce(  Nully2));
        NoNullRet(2,   Nully2.Coalesce(  Nully2));
        NoNullRet(2,        0.Coalesce(  Nully2));
        NoNullRet(1,        1.Coalesce(  Nully2));
        NoNullRet(2,        2.Coalesce(  Nully2));
        NoNullRet(0,  NullNum.Coalesce(       0));
        NoNullRet(0,   Nully0.Coalesce(       0));
        NoNullRet(1,   Nully1.Coalesce(       0));
        NoNullRet(2,   Nully2.Coalesce(       0));
        NoNullRet(0,        0.Coalesce(       0));
        NoNullRet(1,        1.Coalesce(       0));
        NoNullRet(2,        2.Coalesce(       0));
        NoNullRet(1,  NullNum.Coalesce(       1));
        NoNullRet(1,   Nully0.Coalesce(       1));
        NoNullRet(1,   Nully1.Coalesce(       1));
        NoNullRet(2,   Nully2.Coalesce(       1));
        NoNullRet(1,        0.Coalesce(       1));
        NoNullRet(1,        1.Coalesce(       1));
        NoNullRet(2,        2.Coalesce(       1));
        NoNullRet(2,  NullNum.Coalesce(       2));
        NoNullRet(2,   Nully0.Coalesce(       2));
        NoNullRet(1,   Nully1.Coalesce(       2));
        NoNullRet(2,   Nully2.Coalesce(       2));
        NoNullRet(2,        0.Coalesce(       2));
        NoNullRet(1,        1.Coalesce(       2));
        NoNullRet(2,        2.Coalesce(       2));
    }

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_ValToText_NoNullies()
    {
        NoNullRet("",           Coalesce(0,  NullText ));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo"));
        NoNullRet("",         0.Coalesce(    NullText ));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo"));
        NoNullRet("1",        1.Coalesce(    NullText ));
        NoNullRet("1",        1.Coalesce(   "peekaboo"));
    }

    [TestMethod]
    public void Coalesce_2Args_ValToText_WithNullies()
    {
        NoNullRet("",    Coalesce(NullNum,   NullText ));
        NoNullRet("boo", Coalesce(NullNum,  "boo"     ));
        NoNullRet("",    Coalesce(Nully0,    NullText ));
        NoNullRet("boo", Coalesce(Nully0,   "boo"     ));
        NoNullRet("1",   Coalesce(Nully1,    NullText ));
        NoNullRet("1",   Coalesce(Nully1,   "boo"     ));
        NoNullRet("",    NullNum.Coalesce(   NullText ));
        NoNullRet("boo", NullNum.Coalesce(  "boo"     ));
        NoNullRet("",    Nully0 .Coalesce(   NullText ));
        NoNullRet("boo", Nully0 .Coalesce(  "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo"     ));
    }

    // Objects

    [TestMethod]
    public void Coalesce_2Args_Objects()
    {
        NoNullRet(              Coalesce(NullObj,     NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullObj    ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NullObj,     NoNullObj  ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NoNullObj  ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NoNullObj  ));
        NoNullRet(NullyFilled!, Coalesce(NullObj,     NullyFilled));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullyFilled));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullyFilled));
        NoNullRet(              NullObj    .Coalesce(NullObj     ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NullObj     ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullObj     ));
        NoNullRet(NoNullObj,    NullObj    .Coalesce(NoNullObj   ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NoNullObj   ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NoNullObj   ));
        NoNullRet(NullyFilled!, NullObj    .Coalesce(NullyFilled ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NullyFilled ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullyFilled ));
    }

    // Objects to Text

    [TestMethod]
    public void Coalesce_2Args_ObjectToText()
    {
        NoNullRet(Text,     Coalesce(NullObj,    Text));
        NoNullRet(Text,     Coalesce(NullObj,    Text));
        NoNullRet("NoNull", Coalesce(NoNullObj,  Text));
        NoNullRet("Filled", Coalesce(NullyFilled,Text));
        NoNullRet(Text,     NullObj    .Coalesce(Text));
        NoNullRet("NoNull", NoNullObj  .Coalesce(Text));
        NoNullRet("Filled", NullyFilled.Coalesce(Text));
    }
}
