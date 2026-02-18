namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_SB_NoFlags : TestBase
{
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
}