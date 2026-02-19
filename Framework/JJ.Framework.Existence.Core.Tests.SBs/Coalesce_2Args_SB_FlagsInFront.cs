namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_SB_FlagsInFront : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_StringBuilder_VarsFlagsInBack()
    {
        // Compare StringBuilder Instances
        NoNullRet(          Coalesce(spaceMatters: false, NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, EmptySB, FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: false, SpaceSB, FilledSB));
        NoNullRet(          Coalesce(spaceMatters: true,  NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(spaceMatters: true,  NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: true,  NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters: true,  EmptySB, FilledSB));
        NoNullRet(SpaceSB,  Coalesce(spaceMatters: true,  SpaceSB, FilledSB));
        NoNullRet(          Coalesce(spaceMatters,        NullSB,  NullSB  ));
        NoNullRet(FilledSB, Coalesce(spaceMatters,        NullSB,  FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters,        NewSB,   FilledSB));
        NoNullRet(FilledSB, Coalesce(spaceMatters,        EmptySB, FilledSB));
        NoNullRet(SpaceSB,  Coalesce(spaceMatters,        SpaceSB, FilledSB));
        NoNullRet(          NullSB .Coalesce(spaceMatters: false, NullSB   ));
        NoNullRet(FilledSB, NullSB .Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(FilledSB, NewSB  .Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(FilledSB, EmptySB.Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(FilledSB, SpaceSB.Coalesce(spaceMatters: false, FilledSB ));
        NoNullRet(          NullSB .Coalesce(spaceMatters: true,  NullSB   ));
        NoNullRet(FilledSB, NullSB .Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(FilledSB, NewSB  .Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(FilledSB, EmptySB.Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce(spaceMatters: true,  FilledSB ));
        NoNullRet(          NullSB .Coalesce(spaceMatters,        NullSB   ));
        NoNullRet(FilledSB, NullSB .Coalesce(spaceMatters,        FilledSB ));
        NoNullRet(FilledSB, NewSB  .Coalesce(spaceMatters,        FilledSB ));
        NoNullRet(FilledSB, EmptySB.Coalesce(spaceMatters,        FilledSB ));
        NoNullRet(SpaceSB,  SpaceSB.Coalesce(spaceMatters,        FilledSB ));
        
        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{Coalesce(spaceMatters: false, NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, EmptySB, FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: false, SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{Coalesce(spaceMatters: true,  NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: true,  NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: true,  NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters: true,  EmptySB, FilledSB)}");
        NoNullRet(Space,      $"{Coalesce(spaceMatters: true,  SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{Coalesce(spaceMatters,        NullSB,  NullSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters,        NullSB,  FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters,        NewSB,   FilledSB)}");
        NoNullRet("FilledSB", $"{Coalesce(spaceMatters,        EmptySB, FilledSB)}");
        NoNullRet(Space,      $"{Coalesce(spaceMatters,        SpaceSB, FilledSB)}");
        NoNullRet(Empty,      $"{NullSB .Coalesce(spaceMatters: false, NullSB   )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet("FilledSB", $"{SpaceSB.Coalesce(spaceMatters: false, FilledSB )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce(spaceMatters: true,  NullSB   )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce(spaceMatters: true,  FilledSB )}");
        NoNullRet(Empty,      $"{NullSB .Coalesce(spaceMatters,        NullSB   )}");
        NoNullRet("FilledSB", $"{NullSB .Coalesce(spaceMatters,        FilledSB )}");
        NoNullRet("FilledSB", $"{NewSB  .Coalesce(spaceMatters,        FilledSB )}");
        NoNullRet("FilledSB", $"{EmptySB.Coalesce(spaceMatters,        FilledSB )}");
        NoNullRet(Space,      $"{SpaceSB.Coalesce(spaceMatters,        FilledSB )}");
    }
}