namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_Tests : TestBase
{
    // Text

    [TestMethod]
    public void Coalesce_2Args_Text_Literals()
    {
        NoNullRet("",         Coalesce(NullText,  NullText                   ));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback"                  ));
        NoNullRet("Fallback", Coalesce("",       "Fallback"                  ));
        NoNullRet("Fallback", Coalesce("   ",    "Fallback"                  ));
        NoNullRet("",         Coalesce(NullText,  NullText,  trimSpace: true ));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback", trimSpace: true ));
        NoNullRet("Fallback", Coalesce("",       "Fallback", trimSpace: true ));
        NoNullRet("Fallback", Coalesce("   ",    "Fallback", trimSpace: true ));
        NoNullRet("",         Coalesce(NullText,  NullText,  trimSpace: false));
        NoNullRet("Fallback", Coalesce(NullText, "Fallback", trimSpace: false));
        NoNullRet("Fallback", Coalesce("",       "Fallback", trimSpace: false));
        NoNullRet("   ",      Coalesce("   ",    "Fallback", trimSpace: false));
        NoNullRet("",         NullText.Coalesce(  NullText                   ));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback"                  ));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback"                  ));
        NoNullRet("Fallback", "   "   .Coalesce( "Fallback"                  ));
        NoNullRet("",         NullText.Coalesce(  NullText,  trimSpace: true ));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback", trimSpace: true ));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback", trimSpace: true ));
        NoNullRet("Fallback", "   "   .Coalesce( "Fallback", trimSpace: true ));
        NoNullRet("",         NullText.Coalesce(  NullText,  trimSpace: false));
        NoNullRet("Fallback", NullText.Coalesce( "Fallback", trimSpace: false));
        NoNullRet("Fallback", ""      .Coalesce( "Fallback", trimSpace: false));
        NoNullRet("   ",      "   "   .Coalesce( "Fallback", trimSpace: false));
    }

    [TestMethod]
    public void Coalesce_2Args_Text_Vars()
    {
        NoNullRet(Empty, Coalesce(NullText, NullText                  ));
        NoNullRet(Text,  Coalesce(NullText, Text                      ));
        NoNullRet(Text,  Coalesce(Empty,    Text                      ));
        NoNullRet(Text,  Coalesce(Space,    Text                      ));
        NoNullRet(Empty, Coalesce(NullText, NullText, trimSpace: true ));
        NoNullRet(Text,  Coalesce(NullText, Text,     trimSpace: true ));
        NoNullRet(Text,  Coalesce(Empty,    Text,     trimSpace: true ));
        NoNullRet(Text,  Coalesce(Space,    Text,     trimSpace: true ));
        NoNullRet(Empty, Coalesce(NullText, NullText, trimSpace: false));
        NoNullRet(Text,  Coalesce(NullText, Text,     trimSpace: false));
        NoNullRet(Text,  Coalesce(Empty,    Text,     trimSpace: false));
        NoNullRet(Space, Coalesce(Space,    Text,     trimSpace: false));
        NoNullRet(Empty, NullText.Coalesce( NullText                  ));
        NoNullRet(Text,  NullText.Coalesce( Text                      ));
        NoNullRet(Text,  Empty   .Coalesce( Text                      ));
        NoNullRet(Text,  Space   .Coalesce( Text                      ));
        NoNullRet(Empty, NullText.Coalesce( NullText, trimSpace: true ));
        NoNullRet(Text,  NullText.Coalesce( Text,     trimSpace: true ));
        NoNullRet(Text,  Empty   .Coalesce( Text,     trimSpace: true ));
        NoNullRet(Text,  Space   .Coalesce( Text,     trimSpace: true ));
        NoNullRet(Empty, NullText.Coalesce( NullText, trimSpace: false));
        NoNullRet(Text,  NullText.Coalesce( Text,     trimSpace: false));
        NoNullRet(Text,  Empty   .Coalesce( Text,     trimSpace: false));
        NoNullRet(Space, Space   .Coalesce( Text,     trimSpace: false));
    }

    // StringBuilder

    [TestMethod]
    public void Coalesce_2Args_StringBuilder_Vars()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(NullSB,  NullSB                    )  );
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB                  )  );
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB                  )  );
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB                  )  );
        NoNullRet(FilledSB, Coalesce(SpaceSB, FilledSB                  )  );
        NoNullRet(          Coalesce(NullSB,  NullSB,   trimSpace: true )  );
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, trimSpace: true )  );
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, trimSpace: true )  );
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, trimSpace: true )  );
        NoNullRet(FilledSB, Coalesce(SpaceSB, FilledSB, trimSpace: true )  );
        NoNullRet(          Coalesce(NullSB,  NullSB,   trimSpace: false)  );
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, trimSpace: false)  );
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, trimSpace: false)  );
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, trimSpace: false)  );
        NoNullRet(SpaceSB,  Coalesce(SpaceSB, FilledSB, trimSpace: false)  );
        NoNullRet(          NullSB .Coalesce( NullSB                    )  );
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB                  )  );
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB                  )  );
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB                  )  );
        NoNullRet(FilledSB, SpaceSB.Coalesce( FilledSB                  )  );
        NoNullRet(          NullSB .Coalesce( NullSB,   trimSpace: true )  );
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, trimSpace: true )  );
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, trimSpace: true )  );
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, trimSpace: true )  );
        NoNullRet(FilledSB, SpaceSB.Coalesce( FilledSB, trimSpace: true )  );
        NoNullRet(          NullSB .Coalesce( NullSB,   trimSpace: false)  );
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, trimSpace: false)  );
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, trimSpace: false)  );
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, trimSpace: false)  );
        NoNullRet(SpaceSB,  SpaceSB.Coalesce( FilledSB, trimSpace: false)  );
        
        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB                    )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB                  )}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB                  )}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB                  )}");
        NoNullRet("FilledSB", $"{Coalesce(SpaceSB, FilledSB                  )}");
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   trimSpace: true )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, trimSpace: true )}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, trimSpace: true )}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, trimSpace: true )}");
        NoNullRet("FilledSB", $"{Coalesce(SpaceSB, FilledSB, trimSpace: true )}");
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   trimSpace: false)}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, trimSpace: false)}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, trimSpace: false)}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, trimSpace: false)}");
        NoNullRet(Space,      $"{Coalesce(SpaceSB, FilledSB, trimSpace: false)}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB                    )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB                  )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB                  )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB                  )}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce( FilledSB                  )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   trimSpace: true )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, trimSpace: true )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, trimSpace: true )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, trimSpace: true )}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce( FilledSB, trimSpace: true )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   trimSpace: false)}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, trimSpace: false)}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, trimSpace: false)}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, trimSpace: false)}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce( FilledSB, trimSpace: false)}");
    }
    
    // StringBuilder to Text
    
    [TestMethod]
    public void Coalesce_2Args_StringBuilderToText()
    {
        NoNullRet(Text,       Coalesce(NullSB,       Text));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text));
        NoNullRet(Text,       NullSB       .Coalesce(Text));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text));
    }

    // Objects to Text

    [TestMethod]
    public void Coalesce_2Args_ObjectToText()
    {
        NoNullRet(Text,     Coalesce(NullObj,    Text));
        NoNullRet("NoNull", Coalesce(NoNullObj,  Text));
        NoNullRet("Filled", Coalesce(NullyFilled,Text));
        NoNullRet(Text,     NullObj    .Coalesce(Text));
        NoNullRet("NoNull", NoNullObj  .Coalesce(Text));
        NoNullRet("Filled", NullyFilled.Coalesce(Text));
    }

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_ValToText()
    {
        // With `T`
        NoNullRet("",           Coalesce(0,  NullText ));
        NoNullRet("",           Coalesce(0,  NullText ));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo"));
        NoNullRet("",         0.Coalesce(    NullText ));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo"));
        NoNullRet("1",        1.Coalesce(    NullText ));
        NoNullRet("1",        1.Coalesce(   "peekaboo"));
        // With `T?`
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

    // Vals

    [TestMethod]
    public void Coalesce_2Args_Vals()
    {
        // Assert input state
        IsNull (   NullNum);
        NullRet(0, Nully0 );
        NullRet(1, Nully1 );
        NullRet(2, Nully2 );
        NoNullRet(0);
        NoNullRet(1);
        NoNullRet(2);
        
        // Assert results
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
}
