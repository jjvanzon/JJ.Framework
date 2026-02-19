namespace JJ.Framework.Existence.Core.SBs.Tests;

[TestClass]
public class Coalesce_1Arg_SB_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_1Arg_StringBuilder()
    {
        // Compare StringBuilder Instances
        NoNullRet(          NullSB       .Coalesce()  );
        NoNullRet(NewSB,    NewSB        .Coalesce()  );
        NoNullRet(NewSB,    NullyNewSB   .Coalesce()  );
        NoNullRet(EmptySB,  EmptySB      .Coalesce()  );
        NoNullRet(EmptySB,  NullyEmptySB .Coalesce()  );
        NoNullRet(SpaceSB,  SpaceSB      .Coalesce()  );
        NoNullRet(SpaceSB,  NullySpaceSB .Coalesce()  );
        NoNullRet(FilledSB, FilledSB     .Coalesce()  );
        NoNullRet(FilledSB, NullyFilledSB.Coalesce()  );
        NoNullRet(          Coalesce(NullSB        )  );
        NoNullRet(EmptySB,  Coalesce(EmptySB       )  );
        NoNullRet(EmptySB,  Coalesce(NullyEmptySB  )  );
        NoNullRet(SpaceSB,  Coalesce(SpaceSB       )  );
        NoNullRet(SpaceSB,  Coalesce(NullySpaceSB  )  );
        NoNullRet(FilledSB, Coalesce(FilledSB      )  );
        NoNullRet(FilledSB, Coalesce(NullyFilledSB )  );

        // Compare StringBuilder Text
        NoNullRet(Empty,      $"{NullSB       .Coalesce()}");
        NoNullRet(Empty,      $"{NewSB        .Coalesce()}");
        NoNullRet(Empty,      $"{NullyNewSB   .Coalesce()}");
        NoNullRet(Empty,      $"{EmptySB      .Coalesce()}");
        NoNullRet(Empty,      $"{NullyEmptySB .Coalesce()}");
        NoNullRet(Space,      $"{SpaceSB      .Coalesce()}");
        NoNullRet(Space,      $"{NullySpaceSB .Coalesce()}");
        NoNullRet("FilledSB", $"{FilledSB     .Coalesce()}");
        NoNullRet("FilledSB", $"{NullyFilledSB.Coalesce()}");
        NoNullRet(Empty,      $"{Coalesce(NullSB        )}");
        NoNullRet(Empty,      $"{Coalesce(EmptySB       )}");
        NoNullRet(Empty,      $"{Coalesce(NullyEmptySB  )}");
        NoNullRet(Space,      $"{Coalesce(SpaceSB       )}");
        NoNullRet(Space,      $"{Coalesce(NullySpaceSB  )}");
        NoNullRet("FilledSB", $"{Coalesce(FilledSB      )}");
        NoNullRet("FilledSB", $"{Coalesce(NullyFilledSB )}");
    }
}