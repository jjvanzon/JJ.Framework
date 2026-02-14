namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArg_Bool_Tests : TestBase
{
    // TODO: static params is only hit with arity 5 for flag-free syntax
    // NOTE: Nullability variance matters less for params/collection based. It does for the this arguments though. And possibly confusing that with flags.

    private readonly bool? Null = null;
    private const bool Default = default;

    // Static Params

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      Null,       Null,       Null,       Null      ));
        NoNullRet(false, Coalesce(zeroMatters: false,   Null,       Null,       Null,       Null      ));
        NoNullRet(false, Coalesce(             false,   Null,       Null,       Null,       Null      ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,          Null,       Null,       Null,       Null      ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       Null,       Null,       Null      ));
        NoNullRet(true,  Coalesce(             true,    Null,       Null,       Null,       Null      )); // Not a flag
    }

    // Checker pattern of nulls and falses, going by permutations of nullable/non-nullable, 

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      Null,       NullyFalse, Null,       NullyFalse));
        NoNullRet(false, Coalesce(zeroMatters: false,   NullyFalse, Null,       NullyFalse, Default   ));
        NoNullRet(false, Coalesce(             false,   Null,       NullyFalse, Default,    NullyFalse));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,          NullyFalse, Null,       False,      Default   ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       False,      Null,       NullyFalse));
        NoNullRet(true,  Coalesce(             true,    NullyFalse, Null,       False,      Default   )); // Not a flag
    }

    // Now checker-pattern true and null, continuing to follow permutations of nullable/non-nullable.

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      NullyTrue,  Default,    NullyTrue,  Null      ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   Null,       True,       Null,       True      ));
        NoNullRet(true,  Coalesce(             false,   NullyTrue,  Default,    True,       Null      ));
        // ZeroMatters Yes
        NoNullRet(true,  Coalesce(zeroMatters,          Null,       True,       Default,    True      ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       Null,       NullyTrue,  Null      ));
        NoNullRet(true,  Coalesce(             true,    Default,    NullyTrue,  Null,       True      )); // Not a flag
    }

    // Checker-pattern true and false now, continued permutations of nullable/non-nullable

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      True,       NullyFalse, True,       NullyFalse));
        NoNullRet(true,  Coalesce(zeroMatters: false,   False,      NullyTrue,  False,      True      ));
        NoNullRet(true,  Coalesce(             false,   True,       False,      NullyTrue,  NullyFalse));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,          False,      True,       NullyFalse, True      ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       False,      True,       NullyFalse)); // Starts with true
        NoNullRet(true,  Coalesce(             true,    False,      True,       False,      True      )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      Null,       False,      False,      NullyTrue ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   Null,       False,      True,       NullyFalse));
        NoNullRet(true,  Coalesce(             false,   Null,       True,       False,      Null      ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,          Null,       NullyFalse, False,      NullyTrue ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       NullyFalse, True,       NullyFalse));
        NoNullRet(true,  Coalesce(             true,    Null,       NullyTrue,  False,      Null      )); // Not a flag
    }

    // Coll Express / Flags in Front

    /*
    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpress_FlagsInFront_Old()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ Null,     NullyFalse, NullyFalse, NullyTrue ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ Null,     NullyFalse, NullyFalse, NullyTrue ] ));
        NoNullRet(true,  Coalesce(             false, [ Null,     NullyFalse, NullyFalse, NullyTrue ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ Null,     NullyFalse, NullyFalse, NullyTrue ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,     NullyFalse, NullyFalse, NullyTrue ] ));
        NoNullRet(false, Coalesce(             true,  [ Null,     NullyFalse, NullyFalse, NullyTrue ] ));
    }
    */

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(zeroMatters: false, [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(             false, [ Null,       Null,       Null,       Null       ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(             true,  [ Null,       Null,       Null,       Null       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ Null,       NullyFalse, Null,       NullyFalse ] ));
        NoNullRet(false, Coalesce(zeroMatters: false, [ NullyFalse, Null,       NullyFalse, Default    ] ));
        NoNullRet(false, Coalesce(             false, [ Null,       NullyFalse, Default,    NullyFalse ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ NullyFalse, Null,       False,      Default    ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,       False,      Null,       NullyFalse ] ));
        NoNullRet(false, Coalesce(             true,  [ NullyFalse, Null,       False,      Default    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ NullyTrue,  Default,    NullyTrue,  Null       ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ Null,       True,       Null,       True       ] ));
        NoNullRet(true,  Coalesce(             false, [ NullyTrue,  Default,    True,       Null       ] ));
        // ZeroMatters Yes
        NoNullRet(true,  Coalesce(zeroMatters,        [ Null,       True,       Default,    True       ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ True,       Null,       NullyTrue,  Null       ] ));
        NoNullRet(false, Coalesce(             true,  [ Default,    NullyTrue,  Null,       True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ True,       NullyFalse, True,       NullyFalse ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ False,      NullyTrue,  False,      True       ] ));
        NoNullRet(true,  Coalesce(             false, [ True,       False,      NullyTrue,  NullyFalse ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ False,      True,       NullyFalse, True       ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ True,       False,      True,       NullyFalse ] )); // Starts with true
        NoNullRet(false, Coalesce(             true,  [ False,      True,       False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ Null,       False,      False,      NullyTrue  ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ Null,       False,      True,       NullyFalse ] ));
        NoNullRet(true,  Coalesce(             false, [ Null,       True,       False,      Null       ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ Null,       NullyFalse, False,      NullyTrue  ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,       NullyFalse, True,       NullyFalse ] ));
        NoNullRet(true,  Coalesce(             true,  [ Null,       NullyTrue,  False,      Null       ] )); // Starts with true
    }

    // TODO: Structure value variations same as above.

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpress_FlagsInBack()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce([ Null,     NullyFalse, NullyFalse, NullyTrue ]                    ));
        NoNullRet(true,  Coalesce([ Null,     NullyFalse, NullyFalse, NullyTrue ], zeroMatters: false));
        NoNullRet(true,  Coalesce([ Null,     NullyFalse, NullyFalse, NullyTrue ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce([ Null,     NullyFalse, NullyFalse, NullyTrue ], zeroMatters       ));
        NoNullRet(false, Coalesce([ Null,     NullyFalse, NullyFalse, NullyTrue ], zeroMatters: true ));
        NoNullRet(false, Coalesce([ Null,     NullyFalse, NullyFalse, NullyTrue ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpress_AllNull_FlagsInFront()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ Null,     Null,       Null,       Null      ]));
        NoNullRet(false, Coalesce(zeroMatters: false, [ Null,     Null,       Null,       Null      ]));
        NoNullRet(false, Coalesce(             false, [ Null,     Null,       Null,       Null      ]));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ Null,     Null,       Null,       Null      ]));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,     Null,       Null,       Null      ]));
        NoNullRet(false, Coalesce(             true,  [ Null,     Null,       Null,       Null      ]));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpress_AllNull_FlagsInBack()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce([ Null,     Null,       Null,       Null      ]                    ));
        NoNullRet(false, Coalesce([ Null,     Null,       Null,       Null      ], zeroMatters: false));
        NoNullRet(false, Coalesce([ Null,     Null,       Null,       Null      ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce([ Null,     Null,       Null,       Null      ], zeroMatters       ));
        NoNullRet(false, Coalesce([ Null,     Null,       Null,       Null      ], zeroMatters: true ));
        NoNullRet(false, Coalesce([ Null,     Null,       Null,       Null      ],              true ));
    }

    // TODO: Extension params is only hit with arity 5 (for flag free variants).

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams()
    {
        // ZeroMatters No
        NoNullRet(true,  Null    .Coalesce(                    NullyFalse, NullyFalse, NullyTrue ));
        NoNullRet(true,  Null    .Coalesce(zeroMatters: false, NullyFalse, NullyFalse, NullyTrue ));
        NoNullRet(true,  Null    .Coalesce(             false, NullyFalse, NullyFalse, NullyTrue ));
        // ZeroMatters Yes
        NoNullRet(false, Null    .Coalesce(zeroMatters,        NullyFalse, NullyFalse, NullyTrue ));
        NoNullRet(false, Null    .Coalesce(zeroMatters: true,  NullyFalse, NullyFalse, NullyTrue ));
        NoNullRet(true,  Null    .Coalesce(             true,  NullyFalse, NullyFalse, NullyTrue )); // Not a flag
        // ZeroMatters No
        NoNullRet(true,  False   .Coalesce(                    NullyFalse, NullyTrue,  NullyTrue ));
        NoNullRet(true,  False   .Coalesce(zeroMatters: false, NullyFalse, NullyTrue,  NullyTrue ));
        NoNullRet(true,  False   .Coalesce(             false, NullyFalse, NullyTrue,  NullyTrue ));
        // ZeroMatters Yes
        NoNullRet(false, False   .Coalesce(zeroMatters,        NullyFalse, NullyTrue,  NullyTrue ));
        NoNullRet(false, False   .Coalesce(zeroMatters: true,  NullyFalse, NullyTrue,  NullyTrue ));
        NoNullRet(true,  False   .Coalesce(             true,  NullyFalse, NullyTrue,  NullyTrue )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpress()
    {
        // ZeroMatters No
        NoNullRet(true,  Null    .Coalesce( [ NullyFalse, NullyFalse, NullyTrue ]                    ));
        NoNullRet(true,  Null    .Coalesce( [ NullyFalse, NullyFalse, NullyTrue ], zeroMatters: false));
        NoNullRet(true,  Null    .Coalesce( [ NullyFalse, NullyFalse, NullyTrue ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Null    .Coalesce( [ NullyFalse, NullyFalse, NullyTrue ], zeroMatters       ));
        NoNullRet(false, Null    .Coalesce( [ NullyFalse, NullyFalse, NullyTrue ], zeroMatters: true ));
        NoNullRet(false, Null    .Coalesce( [ NullyFalse, NullyFalse, NullyTrue ],              true ));
        // ZeroMatters No
        NoNullRet(true,  False   .Coalesce( [ NullyFalse, NullyTrue,  NullyTrue ]                    ));
        NoNullRet(true,  False   .Coalesce( [ NullyFalse, NullyTrue,  NullyTrue ], zeroMatters: false));
        NoNullRet(true,  False   .Coalesce( [ NullyFalse, NullyTrue,  NullyTrue ],              false));
        // ZeroMatters Yes
        NoNullRet(false, False   .Coalesce( [ NullyFalse, NullyTrue,  NullyTrue ], zeroMatters       ));
        NoNullRet(false, False   .Coalesce( [ NullyFalse, NullyTrue,  NullyTrue ], zeroMatters: true ));
        NoNullRet(false, False   .Coalesce( [ NullyFalse, NullyTrue,  NullyTrue ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpress_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Null    .Coalesce( [ Null,       Null,       Null      ]                    ));
        NoNullRet(false, Null    .Coalesce( [ Null,       Null,       Null      ], zeroMatters: false));
        NoNullRet(false, Null    .Coalesce( [ Null,       Null,       Null      ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Null    .Coalesce( [ Null,       Null,       Null      ], zeroMatters       ));
        NoNullRet(false, Null    .Coalesce( [ Null,       Null,       Null      ], zeroMatters: true ));
        NoNullRet(false, Null    .Coalesce( [ Null,       Null,       Null      ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsOnCollection()
    {
        // ZeroMatters No
        NoNullRet(true,  new [] { Null,     NullyFalse, False, NullyTrue }.Coalesce(                  ));
        NoNullRet(true,  new [] { Null,     NullyFalse, False, NullyTrue }.Coalesce(zeroMatters: false));
        NoNullRet(true,  new [] { Null,     NullyFalse, False, NullyTrue }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(false, new [] { Null,     NullyFalse, False, NullyTrue }.Coalesce(zeroMatters       ));
        NoNullRet(false, new [] { Null,     NullyFalse, False, NullyTrue }.Coalesce(zeroMatters: true ));
        NoNullRet(false, new [] { Null,     NullyFalse, False, NullyTrue }.Coalesce(             true ));
    }
}