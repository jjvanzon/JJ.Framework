namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArg_Bool_Tests : TestBase
{
    private readonly bool? Null = null;
    private const bool Default = default;

    // Static

    // Static Params

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      False,      False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   True,       False,      True,       False        ));
        NoNullRet(true,  Coalesce(             false,   False,      False,      False,      True         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          False,      False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       False,      True,       False        )); // Starts with true
        NoNullRet(true,  Coalesce(             true,    False,      False,      False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      Null,       Null,       Null,       Null         ));
        NoNullRet(false, Coalesce(zeroMatters: false,   Null,       Null,       Null,       Null         ));
        NoNullRet(false, Coalesce(             false,   Null,       Null,       Null,       Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          Null,       Null,       Null,       Null         ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       Null,       Null,       Null         ));
        NoNullRet(true,  Coalesce(             true,    Null,       Null,       Null,       Null         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      NullyFalse, False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   NullyTrue,  False,      True,       False        ));
        NoNullRet(true,  Coalesce(             false,   NullyFalse, False,      False,      True         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          NullyFalse, False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    NullyTrue,  False,      True,       False        )); // Starts with true
        NoNullRet(true,  Coalesce(             true,    NullyFalse, False,      False,      True         )); // Not a flag
    }

    // Checker pattern of nulls and falses, going by permutations of nullable/non-nullable, 

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      Null,       NullyFalse, Null,       NullyFalse   ));
        NoNullRet(false, Coalesce(zeroMatters: false,   NullyFalse, Null,       NullyFalse, Default      ));
        NoNullRet(false, Coalesce(             false,   Null,       NullyFalse, Default,    NullyFalse   ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          NullyFalse, Null,       False,      Default      ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       False,      Null,       NullyFalse   ));
        NoNullRet(true,  Coalesce(             true,    NullyFalse, Null,       False,      Default      )); // Not a flag
    }

    // Now checker-pattern true and null, continuing to follow permutations of nullable/non-nullable.

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      NullyTrue,  Default,    NullyTrue,  Null         ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   Null,       True,       Null,       True         ));
        NoNullRet(true,  Coalesce(             false,   NullyTrue,  Default,    True,       Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(true,  Coalesce(zeroMatters,          Null,       True,       Default,    True         ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       Null,       NullyTrue,  Null         ));
        NoNullRet(true,  Coalesce(             true,    Default,    NullyTrue,  Null,       True         )); // Not a flag
    }

    // Checker-pattern true and false now, continued permutations of nullable/non-nullable

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      True,       NullyFalse, True,       NullyFalse   ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   False,      NullyTrue,  False,      True         ));
        NoNullRet(true,  Coalesce(             false,   True,       False,      NullyTrue,  NullyFalse   ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          False,      True,       NullyFalse, True         ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       False,      True,       NullyFalse   )); // Starts with true
        NoNullRet(true,  Coalesce(             true,    False,      True,       False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      Null,       False,      False,      NullyTrue    ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   Null,       False,      True,       NullyFalse   ));
        NoNullRet(true,  Coalesce(             false,   Null,       True,       False,      Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          Null,       NullyFalse, False,      NullyTrue    ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       NullyFalse, True,       NullyFalse   ));
        NoNullRet(true,  Coalesce(             true,    Null,       NullyTrue,  False,      Null         )); // Not a flag
    }

    // Static Coll Express / Flags in Front

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ False,      False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ True,       False,      True,       False      ] ));
        NoNullRet(true,  Coalesce(             false, [ False,      False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,        [ False,      False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ True,       False,      True,       False      ] )); // Starts with true
        NoNullRet(false, Coalesce(             true,  [ False,      False,      False,      True       ] ));
    }

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
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ NullyFalse, False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ NullyTrue,  False,      True,       False      ] ));
        NoNullRet(true,  Coalesce(             false, [ NullyFalse, False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,        [ NullyFalse, False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ NullyTrue,  False,      True,       False      ] )); // Starts with true
        NoNullRet(false, Coalesce(             true,  [ NullyFalse, False,      False,      True       ] ));
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

    // Static Coll Express / Flags in Back

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ False,      False,      False,      False      ]                    ));
        NoNullRet(true,  Coalesce( [ True,       False,      True,       False      ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ False,      False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce( [ False,      False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ True,       False,      True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, Coalesce( [ False,      False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null       ]                    ));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters: false));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null       ],              false));
        // ZeroMatters Yes                                                            
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters       ));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters: true ));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ NullyFalse, False,      False,      False      ]                    ));
        NoNullRet(true,  Coalesce( [ NullyTrue,  False,      True,       False      ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ NullyFalse, False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce( [ NullyFalse, False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ NullyTrue,  False,      True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, Coalesce( [ NullyFalse, False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, Null,       NullyFalse ]                    ));
        NoNullRet(false, Coalesce( [ NullyFalse, Null,       NullyFalse, Default    ], zeroMatters: false));
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, Default,    NullyFalse ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce( [ NullyFalse, Null,       False,      Default    ], zeroMatters       ));
        NoNullRet(false, Coalesce( [ Null,       False,      Null,       NullyFalse ], zeroMatters: true ));
        NoNullRet(false, Coalesce( [ NullyFalse, Null,       False,      Default    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce( [ NullyTrue,  Default,    NullyTrue,  Null       ]                    ));
        NoNullRet(true,  Coalesce( [ Null,       True,       Null,       True       ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ NullyTrue,  Default,    True,       Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(true,  Coalesce( [ Null,       True,       Default,    True       ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ True,       Null,       NullyTrue,  Null       ], zeroMatters: true ));
        NoNullRet(false, Coalesce( [ Default,    NullyTrue,  Null,       True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce( [ True,       NullyFalse, True,       NullyFalse ]                    ));
        NoNullRet(true,  Coalesce( [ False,      NullyTrue,  False,      True       ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ True,       False,      NullyTrue,  NullyFalse ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce( [ False,      True,       NullyFalse, True       ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ True,       False,      True,       NullyFalse ], zeroMatters: true )); // Starts with true
        NoNullRet(false, Coalesce( [ False,      True,       False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce( [ Null,       False,      False,      NullyTrue  ]                    ));
        NoNullRet(true,  Coalesce( [ Null,       False,      True,       NullyFalse ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ Null,       True,       False,      Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, False,      NullyTrue  ], zeroMatters       ));
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, True,       NullyFalse ], zeroMatters: true ));
        NoNullRet(true,  Coalesce( [ Null,       NullyTrue,  False,      Null       ],              true )); // Starts with true
    }

    // Extensions

    // Extensions Params

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, False     .Coalesce(                      False,      False,      False        ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false,   False,      True,       False        ));
        NoNullRet(true,  False     .Coalesce(             false,   False,      False,      True         ));
        // ZeroMatters Ye.s                                                                 
        NoNullRet(false, False     .Coalesce(zeroMatters,          False,      False,      False        ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,    False,      True,       False        )); // Starts with true
        NoNullRet(true,  False     .Coalesce(             true,    False,      False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                      Null,       Null,       Null         ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: false,   Null,       Null,       Null         ));
        NoNullRet(false, Null      .Coalesce(             false,   Null,       Null,       Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(false, Null      .Coalesce(zeroMatters,          Null,       Null,       Null         ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,    Null,       Null,       Null         ));
        NoNullRet(true,  Null      .Coalesce(             true,    Null,       Null,       Null         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, NullyFalse.Coalesce(                      False,      False,      False        ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false,   False,      True,       False        ));
        NoNullRet(true,  NullyFalse.Coalesce(             false,   False,      False,      True         ));
        // ZeroMatters Ye.s                                                                 
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,          False,      False,      False        ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,    False,      True,       False        )); // Starts with true
        NoNullRet(true,  NullyFalse.Coalesce(             true,    False,      False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                       NullyFalse, Null,       NullyFalse   ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false,    Null,       NullyFalse, Default      ));
        NoNullRet(false, Null      .Coalesce(             false,    NullyFalse, Default,    NullyFalse   ));
        // ZeroMatters Yes                                                                    
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,           Null,       False,      Default      ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,     False,      Null,       NullyFalse   ));
        NoNullRet(true,  NullyFalse.Coalesce(             true,     Null,       False,      Default      )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  NullyTrue .Coalesce(                      Default,    NullyTrue,  Null         ));
        NoNullRet(true,  Null      .Coalesce(zeroMatters: false,   True,       Null,       True         ));
        NoNullRet(true,  NullyTrue .Coalesce(             false,   Default,    True,       Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(true,  Null      .Coalesce(zeroMatters,          True,       Default,    True         ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,    Null,       NullyTrue,  Null         ));
        NoNullRet(true,  Default   .Coalesce(             true,    NullyTrue,  Null,       True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  True      .Coalesce(                      NullyFalse, True,       NullyFalse   ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false,   NullyTrue,  False,      True         ));
        NoNullRet(true,  True      .Coalesce(             false,   False,      NullyTrue,  NullyFalse   ));
        // ZeroMatters Yes                                                                   
        NoNullRet(false, False     .Coalesce(zeroMatters,          True,       NullyFalse, True         ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,    False,      True,       NullyFalse   )); // Starts with true
        NoNullRet(true,  False     .Coalesce(             true,    True,       False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Null      .Coalesce(                      False,      False,      NullyTrue    ));
        NoNullRet(true,  Null      .Coalesce(zeroMatters: false,   False,      True,       NullyFalse   ));
        NoNullRet(true,  Null      .Coalesce(             false,   True,       False,      Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(false, Null      .Coalesce(zeroMatters,          NullyFalse, False,      NullyTrue    ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,    NullyFalse, True,       NullyFalse   ));
        NoNullRet(true,  Null      .Coalesce(             true,    NullyTrue,  False,      Null         )); // Not a flag
    }

    // Extensions Coll Express / Flags in Front

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, False     .Coalesce(                    [ False,      False,      False      ] ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, [ False,      True,       False      ] ));
        NoNullRet(true,  False     .Coalesce(             false, [ False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, False     .Coalesce(zeroMatters,        [ False,      False,      False      ] ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  [ False,      True,       False      ] )); // Starts with true
        NoNullRet(false, False     .Coalesce(             true,  [ False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                    [ Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: false, [ Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(             false, [ Null,       Null,       Null       ] ));
        // ZeroMatters Yes         
        NoNullRet(false, Null      .Coalesce(zeroMatters,        [ Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,  [ Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(             true,  [ Null,       Null,       Null       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, NullyFalse.Coalesce(                    [ False,      False,      False      ] ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, [ False,      True,       False      ] ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, [ False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        [ False,      False,      False      ] ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  [ False,      True,       False      ] )); // Starts with true
        NoNullRet(false, NullyFalse.Coalesce(             true,  [ False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                    [ NullyFalse, Null,       NullyFalse ] ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, [ Null,       NullyFalse, Default    ] ));
        NoNullRet(false, Null      .Coalesce(             false, [ NullyFalse, Default,    NullyFalse ] ));
        // ZeroMatters Yes
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        [ Null,       False,      Default    ] ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,  [ False,      Null,       NullyFalse ] ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  [ Null,       False,      Default    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  NullyTrue  .Coalesce(                    [ Default,    NullyTrue,  Null       ] ));
        NoNullRet(true,  Null       .Coalesce(zeroMatters: false, [ True,       Null,       True       ] ));
        NoNullRet(true,  NullyTrue  .Coalesce(             false, [ Default,    True,       Null       ] ));
        // ZeroMatters Yes          
        NoNullRet(true,  Null       .Coalesce(zeroMatters,        [ True,       Default,    True       ] ));
        NoNullRet(true,  True       .Coalesce(zeroMatters: true,  [ Null,       NullyTrue,  Null       ] ));
        NoNullRet(false, Default    .Coalesce(             true,  [ NullyTrue,  Null,       True       ] ));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  True       .Coalesce(                    [ NullyFalse, True,       NullyFalse ] ));
        NoNullRet(true,  False      .Coalesce(zeroMatters: false, [ NullyTrue,  False,      True       ] ));
        NoNullRet(true,  True       .Coalesce(             false, [ False,      NullyTrue,  NullyFalse ] ));
        // ZeroMatters Yes         
        NoNullRet(false, False      .Coalesce(zeroMatters,        [ True,       NullyFalse, True       ] ));
        NoNullRet(true,  True       .Coalesce(zeroMatters: true,  [ False,      True,       NullyFalse ] )); // Starts with true
        NoNullRet(false, False      .Coalesce(             true,  [ True,       False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Null       .Coalesce(                    [ False,      False,      NullyTrue  ] ));
        NoNullRet(true,  Null       .Coalesce(zeroMatters: false, [ False,      True,       NullyFalse ] ));
        NoNullRet(true,  Null       .Coalesce(             false, [ True,       False,      Null       ] ));
        // ZeroMatters Yes          
        NoNullRet(false, Null       .Coalesce(zeroMatters,        [ NullyFalse, False,      NullyTrue  ] ));
        NoNullRet(false, Null       .Coalesce(zeroMatters: true,  [ NullyFalse, True,       NullyFalse ] ));
        NoNullRet(true,  Null       .Coalesce(             true,  [ NullyTrue,  False,      Null       ] )); // Starts with true
    }

    // Extensions Coll Express / Flags in Back

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, False     .Coalesce( [ False,      False,      False      ]                    ));
        NoNullRet(true,  True      .Coalesce( [ False,      True,       False      ], zeroMatters: false));
        NoNullRet(true,  False     .Coalesce( [ False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, False     .Coalesce( [ False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  True      .Coalesce( [ False,      True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, False     .Coalesce( [ False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null       ]                    ));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null       ], zeroMatters: false));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null       ],              false));
        // ZeroMatters Yes                                                             
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null       ], zeroMatters       ));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null       ], zeroMatters: true ));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, NullyFalse.Coalesce( [ False,      False,      False      ]                    ));
        NoNullRet(true,  NullyTrue .Coalesce( [ False,      True,       False      ], zeroMatters: false));
        NoNullRet(true,  NullyFalse.Coalesce( [ False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, NullyFalse.Coalesce( [ False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce( [ False,      True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, NullyFalse.Coalesce( [ False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, Null,       NullyFalse ]                    ));
        NoNullRet(false, NullyFalse.Coalesce( [ Null,       NullyFalse, Default    ], zeroMatters: false));
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, Default,    NullyFalse ],              false));
        // ZeroMatters Yes
        NoNullRet(false, NullyFalse.Coalesce( [ Null,       False,      Default    ], zeroMatters       ));
        NoNullRet(false, Null      .Coalesce( [ False,      Null,       NullyFalse ], zeroMatters: true ));
        NoNullRet(false, NullyFalse.Coalesce( [ Null,       False,      Default    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  NullyTrue .Coalesce( [ Default,    NullyTrue,  Null       ]                    ));
        NoNullRet(true,  Null      .Coalesce( [ True,       Null,       True       ], zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce( [ Default,    True,       Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(true,  Null      .Coalesce( [ True,       Default,    True       ], zeroMatters       ));
        NoNullRet(true,  True      .Coalesce( [ Null,       NullyTrue,  Null       ], zeroMatters: true ));
        NoNullRet(false, Default   .Coalesce( [ NullyTrue,  Null,       True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  True      .Coalesce( [ NullyFalse, True,       NullyFalse ]                    ));
        NoNullRet(true,  False     .Coalesce( [ NullyTrue,  False,      True       ], zeroMatters: false));
        NoNullRet(true,  True      .Coalesce( [ False,      NullyTrue,  NullyFalse ],              false));
        // ZeroMatters Yes         
        NoNullRet(false, False     .Coalesce( [ True,       NullyFalse, True       ], zeroMatters       ));
        NoNullRet(true,  True      .Coalesce( [ False,      True,       NullyFalse ], zeroMatters: true )); // Starts with true
        NoNullRet(false, False     .Coalesce( [ True,       False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Null      .Coalesce( [ False,      False,      NullyTrue  ]                    ));
        NoNullRet(true,  Null      .Coalesce( [ False,      True,       NullyFalse ], zeroMatters: false));
        NoNullRet(true,  Null      .Coalesce( [ True,       False,      Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, False,      NullyTrue  ], zeroMatters       ));
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, True,       NullyFalse ], zeroMatters: true ));
        NoNullRet(true,  Null      .Coalesce( [ NullyTrue,  False,      Null       ],              true )); // Starts with true
    }

    // Extensions on Collections

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false,  new [] { False,      False,      False,      False      }.Coalesce(                  ));
        NoNullRet(true,   new [] { True,       False,      True,       False      }.Coalesce(zeroMatters: false));
        NoNullRet(true,   new [] { False,      False,      False,      True       }.Coalesce(             false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false,  new [] { False,      False,      False,      False      }.Coalesce(zeroMatters       ));
        NoNullRet(true,   new [] { True,       False,      True,       False      }.Coalesce(zeroMatters: true )); // Starts with true
        NoNullRet(false,  new [] { False,      False,      False,      True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, new [] { Null,       Null,       Null,       Null       }.Coalesce(                  ));
        NoNullRet(false, new [] { Null,       Null,       Null,       Null       }.Coalesce(zeroMatters: false));
        NoNullRet(false, new [] { Null,       Null,       Null,       Null       }.Coalesce(             false));
        // ZeroMatters Yes                                                            
        NoNullRet(false, new [] { Null,       Null,       Null,       Null       }.Coalesce(zeroMatters       ));
        NoNullRet(false, new [] { Null,       Null,       Null,       Null       }.Coalesce(zeroMatters: true ));
        NoNullRet(false, new [] { Null,       Null,       Null,       Null       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false,  new [] { NullyFalse, False,      False,      False      }.Coalesce(                  ));
        NoNullRet(true,   new [] { NullyTrue,  False,      True,       False      }.Coalesce(zeroMatters: false));
        NoNullRet(true,   new [] { NullyFalse, False,      False,      True       }.Coalesce(             false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false,  new [] { NullyFalse, False,      False,      False      }.Coalesce(zeroMatters       ));
        NoNullRet(true,   new [] { NullyTrue,  False,      True,       False      }.Coalesce(zeroMatters: true )); // Starts with true
        NoNullRet(false,  new [] { NullyFalse, False,      False,      True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  new [] { NullyTrue,  Default,    NullyTrue,  Null       }.Coalesce(                  ));
        NoNullRet(true,  new [] { Null,       True,       Null,       True       }.Coalesce(zeroMatters: false));
        NoNullRet(true,  new [] { NullyTrue,  Default,    True,       Null       }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(true,  new [] { Null,       True,       Default,    True       }.Coalesce(zeroMatters       ));
        NoNullRet(true,  new [] { True,       Null,       NullyTrue,  Null       }.Coalesce(zeroMatters: true ));
        NoNullRet(false, new [] { Default,    NullyTrue,  Null,       True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  new [] { True,       NullyFalse, True,       NullyFalse }.Coalesce(                  ));
        NoNullRet(true,  new [] { False,      NullyTrue,  False,      True       }.Coalesce(zeroMatters: false));
        NoNullRet(true,  new [] { True,       False,      NullyTrue,  NullyFalse }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(false, new [] { False,      True,       NullyFalse, True       }.Coalesce(zeroMatters       ));
        NoNullRet(true,  new [] { True,       False,      True,       NullyFalse }.Coalesce(zeroMatters: true )); // Starts with true
        NoNullRet(false, new [] { False,      True,       False,      True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  new [] { Null,       False,      False,      NullyTrue  }.Coalesce(                  ));
        NoNullRet(true,  new [] { Null,       False,      True,       NullyFalse }.Coalesce(zeroMatters: false));
        NoNullRet(true,  new [] { Null,       True,       False,      Null       }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(false, new [] { Null,       NullyFalse, False,      NullyTrue  }.Coalesce(zeroMatters       ));
        NoNullRet(false, new [] { Null,       NullyFalse, True,       NullyFalse }.Coalesce(zeroMatters: true ));
        NoNullRet(true,  new [] { Null,       NullyTrue,  False,      Null       }.Coalesce(             true )); // Starts with true
    }

    // Null Collections

    [TestMethod]
    public void Coalesce_NArg_Bool_NullCollections()
    {
        ICollection<bool>? nullColl = null;
        // Static Flags in Front
        NoNullRet(false,          Coalesce(                    nullColl));
        NoNullRet(false,          Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false,          Coalesce(             false, nullColl));
        NoNullRet(false,          Coalesce(zeroMatters,        nullColl));
        NoNullRet(false,          Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false,          Coalesce(             true,  nullColl));
        // Static Flags in Back
        NoNullRet(false,          Coalesce(nullColl                    ));
        NoNullRet(false,          Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false,          Coalesce(nullColl,              false));
        NoNullRet(false,          Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false,          Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false,          Coalesce(nullColl,              true ));
        // Extension Flags in Front
        // TODO: Add first=true cases.
        NoNullRet(false, Null    .Coalesce(                    nullColl));
        NoNullRet(false, Null    .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, Null    .Coalesce(             false, nullColl));
        NoNullRet(false, Null    .Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, Null    .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, Null    .Coalesce(             true,  nullColl));
        NoNullRet(false, False   .Coalesce(                    nullColl));
        NoNullRet(false, False   .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, False   .Coalesce(             false, nullColl));
        NoNullRet(false, False   .Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, False   .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, False   .Coalesce(             true,  nullColl));
        // Extension Flags in Back
        // TODO: Add first=true cases.
        NoNullRet(false, Null    .Coalesce(nullColl                    ));
        NoNullRet(false, Null    .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, Null    .Coalesce(nullColl,              false));
        NoNullRet(false, Null    .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, Null    .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, Null    .Coalesce(nullColl,              true ));
        NoNullRet(false, False   .Coalesce(nullColl                    ));
        NoNullRet(false, False   .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, False   .Coalesce(nullColl,              false));
        NoNullRet(false, False   .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, False   .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, False   .Coalesce(nullColl,              true ));
        // Extensions on Collection
        NoNullRet(false, nullColl.Coalesce(                            ));
        NoNullRet(false, nullColl.Coalesce(          zeroMatters: false));
        NoNullRet(false, nullColl.Coalesce(                       false));
        NoNullRet(false, nullColl.Coalesce(          zeroMatters       ));
    }
}