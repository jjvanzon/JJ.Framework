namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_SB_FlagsInBack : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_StringBuilder_VarsFlagsInBack()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(NullSB,  NullSB,   spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, Coalesce(SpaceSB, FilledSB, spaceMatters: false));
        NoNullRet(          Coalesce(NullSB,  NullSB,   spaceMatters: true ));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, spaceMatters: true ));
        NoNullRet(SpaceSB,  Coalesce(SpaceSB, FilledSB, spaceMatters: true ));
        NoNullRet(          Coalesce(NullSB,  NullSB,   spaceMatters       ));
        NoNullRet(FilledSB, Coalesce(NullSB,  FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, Coalesce(NewSB,   FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, Coalesce(EmptySB, FilledSB, spaceMatters       ));
        NoNullRet(SpaceSB,  Coalesce(SpaceSB, FilledSB, spaceMatters       ));
        NoNullRet(          NullSB .Coalesce( NullSB,   spaceMatters: false));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(FilledSB, SpaceSB.Coalesce( FilledSB, spaceMatters: false));
        NoNullRet(          NullSB .Coalesce( NullSB,   spaceMatters: true ));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce( FilledSB, spaceMatters: true ));
        NoNullRet(          NullSB .Coalesce( NullSB,   spaceMatters       ));
        NoNullRet(FilledSB, NullSB .Coalesce( FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, NewSB  .Coalesce( FilledSB, spaceMatters       ));
        NoNullRet(FilledSB, EmptySB.Coalesce( FilledSB, spaceMatters       ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce( FilledSB, spaceMatters       ));
        
        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{Coalesce(SpaceSB, FilledSB, spaceMatters: false)}");
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   spaceMatters: true )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, spaceMatters: true )}");
        NoNullRet(Space,      $"{Coalesce(SpaceSB, FilledSB, spaceMatters: true )}");
        NoNullRet(Empty,      $"{Coalesce(NullSB,  NullSB,   spaceMatters       )}");
        NoNullRet("FilledSB", $"{Coalesce(NullSB,  FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{Coalesce(NewSB,   FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{Coalesce(EmptySB, FilledSB, spaceMatters       )}");
        NoNullRet(Space,      $"{Coalesce(SpaceSB, FilledSB, spaceMatters       )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   spaceMatters: false)}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce( FilledSB, spaceMatters: false)}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   spaceMatters: true )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce( FilledSB, spaceMatters: true )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce( NullSB,   spaceMatters       )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce( FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce( FilledSB, spaceMatters       )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce( FilledSB, spaceMatters       )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce( FilledSB, spaceMatters       )}");
    }
}