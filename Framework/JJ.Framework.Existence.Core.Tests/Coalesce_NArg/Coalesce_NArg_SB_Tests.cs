namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArg_SB_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_StringBuilders_StaticParams()
    {
        NoNullRet(NullyFilledSB, Coalesce(                       NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB  ));
        NoNullRet(NullyFilledSB, Coalesce(                       NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB   ));
        NoNullRet(NullyFilledSB, Coalesce(spaceMatters: false,   NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB   ));
        NoNullRet(NullyFilledSB, Coalesce(spaceMatters: false,   NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB     ));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters,          NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB         ));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters,          NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB  ));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters: true,    NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB   ));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters: true,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB     ));
    }

    [TestMethod]
    public void Coalesce_StringBuilders_StaticCollExpress_FlagsInFront()
    {
        NoNullRet(NullyFilledSB, Coalesce(                     [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullyFilledSB, Coalesce(                     [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]));
        NoNullRet(NullyFilledSB, Coalesce(spaceMatters: false, [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullyFilledSB, Coalesce(spaceMatters: false, [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters,        [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters,        [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters: true,  [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters: true,  [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));
    }

    [TestMethod]
    public void Coalesce_StringBuilders_ExtensionsParams()
    {
        NoNullRet(NullyFilledSB, NullSB       .Coalesce(                        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB  ));
        NoNullRet(NullyFilledSB, NullyFilledSB.Coalesce(                        NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB   ));
        NoNullRet(NullyFilledSB, NullySpaceSB .Coalesce(spaceMatters: false,    NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB   ));
        NoNullRet(NullyFilledSB, NullyEmptySB .Coalesce(spaceMatters: false,    NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB     ));
        NoNullRet(NullySpaceSB,  NullyNewSB   .Coalesce(spaceMatters,           NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB         ));
        NoNullRet(NullySpaceSB,  NullSB       .Coalesce(spaceMatters,           NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB  ));
        NoNullRet(NullySpaceSB,  NullySpaceSB .Coalesce(spaceMatters: true,     NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB   ));
        NoNullRet(NullySpaceSB,  NullyEmptySB .Coalesce(spaceMatters: true,     NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB     ));
    }

    [TestMethod]
    public void Coalesce_StringBuilders_ExtensionsCollExpress_FlagsInFront()
    {
        NoNullRet(NullyFilledSB, NullSB       .Coalesce(                      [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullyFilledSB, NullyFilledSB.Coalesce(                      [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]));
        NoNullRet(NullyFilledSB, NullySpaceSB .Coalesce(spaceMatters: false,  [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullyFilledSB, NullyEmptySB .Coalesce(spaceMatters: false,  [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));
        NoNullRet(NullySpaceSB,  NullyNewSB   .Coalesce(spaceMatters,         [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ]));
        NoNullRet(NullySpaceSB,  NullSB       .Coalesce(spaceMatters,         [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullySpaceSB,  NullySpaceSB .Coalesce(spaceMatters: true,   [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullySpaceSB,  NullyEmptySB .Coalesce(spaceMatters: true,   [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));
    }

    [TestMethod]
    public void Coalesce_StringBuilders_StaticCollExpress_FlagsInBack()
    {
        NoNullRet(NullyFilledSB, Coalesce([ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]                     ));
        NoNullRet(NullyFilledSB, Coalesce([ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]                     ));
        NoNullRet(NullyFilledSB, Coalesce([ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: false));
        NoNullRet(NullyFilledSB, Coalesce([ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: false));
        NoNullRet(NullySpaceSB,  Coalesce([ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  Coalesce([ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  Coalesce([ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: true ));
        NoNullRet(NullySpaceSB,  Coalesce([ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: true ));
    }

    [TestMethod]
    public void Coalesce_StringBuilders_ExtensionOnColl_FlagsInBack()
    {
        NoNullRet(NullyFilledSB, new []   { NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB }.Coalesce(                   ));
        NoNullRet(NullyFilledSB, new []   { NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  }.Coalesce(                   ));
        NoNullRet(NullyFilledSB, new []   { NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  }.Coalesce(spaceMatters: false));
        NoNullRet(NullyFilledSB, new []   { NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    }.Coalesce(spaceMatters: false));
        NoNullRet(NullySpaceSB,  new []   { NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        }.Coalesce(spaceMatters       ));
        NoNullRet(NullySpaceSB,  new []   { NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB }.Coalesce(spaceMatters       ));
        NoNullRet(NullySpaceSB,  new []   { NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  }.Coalesce(spaceMatters: true ));
        NoNullRet(NullySpaceSB,  new []   { NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    }.Coalesce(spaceMatters: true ));
    }

    [TestMethod]
    public void Coalesce_StringBuilders_ExtensionCollExpress_FlagsInBack()
    {
        NoNullRet(NullyFilledSB, NullSB       .Coalesce( [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]                     ));
        NoNullRet(NullyFilledSB, NullyFilledSB.Coalesce( [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]                     ));
        NoNullRet(NullyFilledSB, NullySpaceSB .Coalesce( [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: false));
        NoNullRet(NullyFilledSB, NullyEmptySB .Coalesce( [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: false));
        NoNullRet(NullySpaceSB,  NullyNewSB   .Coalesce( [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  NullSB       .Coalesce( [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  NullySpaceSB .Coalesce( [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: true ));
        NoNullRet(NullySpaceSB,  NullyEmptySB .Coalesce( [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: true ));
    }

    [TestMethod]
    public void Coalesce_StringBuilders_StaticParams_ReturnsNew()
    {
        NoNullRet(Coalesce(                     NullyEmptySB, NullyNewSB,   NewSB,        NullSB));
        NoNullRet(Coalesce(                     NewSB,        NullyEmptySB, NullyNewSB,   NullSB));
        NoNullRet(Coalesce(spaceMatters: false, NullyEmptySB, NullyNewSB,   NewSB,        NullSB));
        NoNullRet(Coalesce(spaceMatters: false, NewSB,        NullyEmptySB, NullyNewSB,   NullSB));
        NoNullRet(Coalesce(spaceMatters,        NullyNewSB,   NewSB,        NullyEmptySB, NullSB));
        NoNullRet(Coalesce(spaceMatters,        NullyEmptySB, NullyNewSB,   NewSB,        NullSB));
        NoNullRet(Coalesce(spaceMatters: true,  NewSB,        NullyEmptySB, NullyNewSB,   NullSB));
        NoNullRet(Coalesce(spaceMatters: true,  NullyNewSB,   NewSB,        NullyEmptySB, NullSB));
    }
}