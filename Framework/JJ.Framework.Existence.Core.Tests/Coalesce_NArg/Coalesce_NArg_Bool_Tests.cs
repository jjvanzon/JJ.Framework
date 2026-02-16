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
        NoNullRet(false, Coalesce(                      False,      False,      False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   True,       False,      True,       True,       True         ));
        NoNullRet(true,  Coalesce(             false,   False,      False,      False,      False,      True         ));
        // ZeroMatters Yes                                                                                        
        NoNullRet(false, Coalesce(zeroMatters,          False,      False,      False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       False,      True,       True,       True         )); // Starts with true
        NoNullRet(true,  Coalesce(             true,    False,      False,      False,      False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      Null,       Null,       Null,       Null,       Null         ));
        NoNullRet(false, Coalesce(zeroMatters: false,   Null,       Null,       Null,       Null,       Null         ));
        NoNullRet(false, Coalesce(             false,   Null,       Null,       Null,       Null,       Null         ));
        // ZeroMatters Yes                                                                                        
        NoNullRet(false, Coalesce(zeroMatters,          Null,       Null,       Null,       Null,       Null         ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       Null,       Null,       Null,       Null         ));
        NoNullRet(true,  Coalesce(             true,    Null,       Null,       Null,       Null,       Null         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      NullyFalse, False,      False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   NullyTrue,  False,      True,       True,       True         ));
        NoNullRet(true,  Coalesce(             false,   NullyFalse, False,      False,      False,      True         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          NullyFalse, False,      False,      False,      False        ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    NullyTrue,  False,      True,       True,       True         )); // Starts with true
        NoNullRet(true,  Coalesce(             true,    NullyFalse, False,      False,      False,      True         )); // Not a flag
    }

    // Checker pattern of null/default and falses, going by permutations of nullable/non-nullable combinations.

    // NOTE: In order to go from arity 4 to arity 5, the 2nd last parameters were just copied.

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                      Null,       NullyFalse, Null,       Null,       NullyFalse   )); // nully-nully-nully-nully (permutations)
        NoNullRet(false, Coalesce(zeroMatters: false,   NullyFalse, Null,       NullyFalse, NullyFalse, Default      )); // nully-nully-nully-NONUL
        NoNullRet(false, Coalesce(             false,   Null,       NullyFalse, Default,    Default,    NullyFalse   )); // nully-nully-NONUL-nully
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          NullyFalse, Null,       False,      False,      Default      )); // nully-nully-NONUL-NONUL
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       False,      Null,       Null,       NullyFalse   )); // nully-NONUL-nully-nully (etc.)
        NoNullRet(true,  Coalesce(             true,    NullyFalse, Null,       False,      False,      Default      )); // Not a flag
    }

    // Now checker-pattern true and null, continuing to follow permutations of nullable/non-nullable.

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      NullyTrue,  Default,    NullyTrue,  NullyTrue,  Null         ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   Null,       True,       Null,       Null,       True         ));
        NoNullRet(true,  Coalesce(             false,   NullyTrue,  Default,    True,       True,       Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(true,  Coalesce(zeroMatters,          Null,       True,       Default,    Default,    True         ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       Null,       NullyTrue,  NullyTrue,  Null         ));
        NoNullRet(true,  Coalesce(             true,    Default,    NullyTrue,  Null,       Null,       True         )); // Not a flag
    }

    // Checker-pattern true and false now, continued permutations of nullable/non-nullable

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      True,       NullyFalse, True,       True,       NullyFalse   ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   False,      NullyTrue,  False,      False,      True         ));
        NoNullRet(true,  Coalesce(             false,   True,       False,      NullyTrue,  NullyTrue,  NullyFalse   ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          False,      True,       NullyFalse, NullyFalse, True         ));
        NoNullRet(true,  Coalesce(zeroMatters: true,    True,       False,      True,       True,       NullyFalse   )); // Starts with true
        NoNullRet(true,  Coalesce(             true,    False,      True,       False,      False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticParams_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                      Null,       False,      False,      False,      NullyTrue    ));
        NoNullRet(true,  Coalesce(zeroMatters: false,   Null,       False,      True,       True,       NullyFalse   ));
        NoNullRet(true,  Coalesce(             false,   Null,       True,       False,      False,      Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,          Null,       NullyFalse, False,      False,      NullyTrue    ));
        NoNullRet(false, Coalesce(zeroMatters: true,    Null,       NullyFalse, True,       True,       NullyFalse   ));
        NoNullRet(true,  Coalesce(             true,    Null,       NullyTrue,  False,      False,      Null         )); // Not a flag
    }

    // Static Coll Express / Flags in Front

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ False,      False,      False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ True,       False,      True,       True,       False      ] ));
        NoNullRet(true,  Coalesce(             false, [ False,      False,      False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,        [ False,      False,      False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ True,       False,      True,       True,       False      ] )); // Starts with true
        NoNullRet(false, Coalesce(             true,  [ False,      False,      False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ Null,       Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(zeroMatters: false, [ Null,       Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(             false, [ Null,       Null,       Null,       Null,       Null       ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ Null,       Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,       Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Coalesce(             true,  [ Null,       Null,       Null,       Null,       Null       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ NullyFalse, False,      False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ NullyTrue,  False,      True,       True,       False      ] ));
        NoNullRet(true,  Coalesce(             false, [ NullyFalse, False,      False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce(zeroMatters,        [ NullyFalse, False,      False,      False,      False      ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ NullyTrue,  False,      True,       True,       False      ] )); // Starts with true
        NoNullRet(false, Coalesce(             true,  [ NullyFalse, False,      False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce(                    [ Null,       NullyFalse, Null,       Null,       NullyFalse ] ));
        NoNullRet(false, Coalesce(zeroMatters: false, [ NullyFalse, Null,       NullyFalse, NullyFalse, Default    ] ));
        NoNullRet(false, Coalesce(             false, [ Null,       NullyFalse, Default,    Default,    NullyFalse ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ NullyFalse, Null,       False,      False,      Default    ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,       False,      Null,       Null,       NullyFalse ] ));
        NoNullRet(false, Coalesce(             true,  [ NullyFalse, Null,       False,      False,      Default    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ NullyTrue,  Default,    NullyTrue,  NullyTrue,  Null       ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ Null,       True,       Null,       Null,       True       ] ));
        NoNullRet(true,  Coalesce(             false, [ NullyTrue,  Default,    True,       True,       Null       ] ));
        // ZeroMatters Yes
        NoNullRet(true,  Coalesce(zeroMatters,        [ Null,       True,       Default,    Default,    True       ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ True,       Null,       NullyTrue,  NullyTrue,  Null       ] ));
        NoNullRet(false, Coalesce(             true,  [ Default,    NullyTrue,  Null,       Null,       True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ True,       NullyFalse, True,       True,       NullyFalse ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ False,      NullyTrue,  False,      False,      True       ] ));
        NoNullRet(true,  Coalesce(             false, [ True,       False,      NullyTrue,  NullyTrue,  NullyFalse ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ False,      True,       NullyFalse, NullyFalse, True       ] ));
        NoNullRet(true,  Coalesce(zeroMatters: true,  [ True,       False,      True,       True,       NullyFalse ] )); // Starts with true
        NoNullRet(false, Coalesce(             true,  [ False,      True,       False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ Null,       False,      False,      False,      NullyTrue  ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ Null,       False,      True,       True,       NullyFalse ] ));
        NoNullRet(true,  Coalesce(             false, [ Null,       True,       False,      False,      Null       ] ));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce(zeroMatters,        [ Null,       NullyFalse, False,      False,      NullyTrue  ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,       NullyFalse, True,       True,       NullyFalse ] ));
        NoNullRet(true,  Coalesce(             true,  [ Null,       NullyTrue,  False,      False,      Null       ] )); // Starts with true
    }

    // Static Coll Express / Flags in Back

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ False,      False,      False,      False,      False      ]                    ));
        NoNullRet(true,  Coalesce( [ True,       False,      True,       True,       False      ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ False,      False,      False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce( [ False,      False,      False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ True,       False,      True,       True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, Coalesce( [ False,      False,      False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null,       Null       ]                    ));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null,       Null       ], zeroMatters: false));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null,       Null       ],              false));
        // ZeroMatters Yes                                                            
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null,       Null       ], zeroMatters       ));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null,       Null       ], zeroMatters: true ));
        NoNullRet(false, Coalesce( [ Null,       Null,       Null,       Null,       Null       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ NullyFalse, False,      False,      False,      False      ]                    ));
        NoNullRet(true,  Coalesce( [ NullyTrue,  False,      True,       True,       False      ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ NullyFalse, False,      False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, Coalesce( [ NullyFalse, False,      False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ NullyTrue,  False,      True,       True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, Coalesce( [ NullyFalse, False,      False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, Null,       Null,       NullyFalse ]                    ));
        NoNullRet(false, Coalesce( [ NullyFalse, Null,       NullyFalse, NullyFalse, Default    ], zeroMatters: false));
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, Default,    Default,    NullyFalse ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce( [ NullyFalse, Null,       False,      False,      Default    ], zeroMatters       ));
        NoNullRet(false, Coalesce( [ Null,       False,      Null,       Null,       NullyFalse ], zeroMatters: true ));
        NoNullRet(false, Coalesce( [ NullyFalse, Null,       False,      False,      Default    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce( [ NullyTrue,  Default,    NullyTrue,  NullyTrue,  Null       ]                    ));
        NoNullRet(true,  Coalesce( [ Null,       True,       Null,       Null,       True       ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ NullyTrue,  Default,    True,       True,       Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(true,  Coalesce( [ Null,       True,       Default,    Default,    True       ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ True,       Null,       NullyTrue,  NullyTrue,  Null       ], zeroMatters: true ));
        NoNullRet(false, Coalesce( [ Default,    NullyTrue,  Null,       Null,       True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce( [ True,       NullyFalse, True,       True,       NullyFalse ]                    ));
        NoNullRet(true,  Coalesce( [ False,      NullyTrue,  False,      False,      True       ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ True,       False,      NullyTrue,  NullyTrue,  NullyFalse ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce( [ False,      True,       NullyFalse, NullyFalse, True       ], zeroMatters       ));
        NoNullRet(true,  Coalesce( [ True,       False,      True,       True,       NullyFalse ], zeroMatters: true )); // Starts with true
        NoNullRet(false, Coalesce( [ False,      True,       False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce( [ Null,       False,      False,      False,      NullyTrue  ]                    ));
        NoNullRet(true,  Coalesce( [ Null,       False,      True,       True,       NullyFalse ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ Null,       True,       False,      False,      Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, False,      False,      NullyTrue  ], zeroMatters       ));
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, True,       True,       NullyFalse ], zeroMatters: true ));
        NoNullRet(true,  Coalesce( [ Null,       NullyTrue,  False,      False,      Null       ],              true )); // Starts with true
    }

    // Extensions

    // Extensions Params

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, False     .Coalesce(                      False,      False,      False,      False        ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false,   False,      True,       True,       False        ));
        NoNullRet(true,  False     .Coalesce(             false,   False,      False,      False,      True         ));
        // ZeroMatters Ye.s                                                                 
        NoNullRet(false, False     .Coalesce(zeroMatters,          False,      False,      False,      False        ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,    False,      True,       True,       False        )); // Starts with true
        NoNullRet(true,  False     .Coalesce(             true,    False,      False,      False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                      Null,       Null,       Null,       Null         ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: false,   Null,       Null,       Null,       Null         ));
        NoNullRet(false, Null      .Coalesce(             false,   Null,       Null,       Null,       Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(false, Null      .Coalesce(zeroMatters,          Null,       Null,       Null,       Null         ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,    Null,       Null,       Null,       Null         ));
        NoNullRet(true,  Null      .Coalesce(             true,    Null,       Null,       Null,       Null         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, NullyFalse.Coalesce(                      False,      False,      False,      False        ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false,   False,      True,       True,       False        ));
        NoNullRet(true,  NullyFalse.Coalesce(             false,   False,      False,      False,      True         ));
        // ZeroMatters Ye.s                                                                 
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,          False,      False,      False,      False        ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,    False,      True,       True,       False        )); // Starts with true
        NoNullRet(true,  NullyFalse.Coalesce(             true,    False,      False,      False,      True         )); // Not a flag
    }

    /*
    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NullyLast()
    {
        // ZeroMatters No
        NoNullRet(false, False     .Coalesce(                      False,      False,      False,      NullyFalse   ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false,   False,      True,       True,       NullyFalse   ));
        NoNullRet(true,  False     .Coalesce(             false,   False,      False,      False,      NullyTrue    ));
        // ZeroMatters Yes                                                                 
        NoNullRet(false, False     .Coalesce(zeroMatters,          False,      False,      False,      NullyFalse   ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,    False,      True,       True,       NullyFalse   ));
        NoNullRet(true,  False     .Coalesce(             true,    False,      False,      False,      NullyTrue    ));
    }
    */

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                       NullyFalse, Null,       Null,       NullyFalse   ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false,    Null,       NullyFalse, NullyFalse, Default      ));
        NoNullRet(false, Null      .Coalesce(             false,    NullyFalse, Default,    Default,    NullyFalse   ));
        // ZeroMatters Yes                                                                    
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,           Null,       False,      False,      Default      ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,     False,      Null,       Null,       NullyFalse   ));
        NoNullRet(true,  NullyFalse.Coalesce(             true,     Null,       False,      False,      Default      )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  NullyTrue .Coalesce(                      Default,    NullyTrue,  NullyTrue,  Null         ));
        NoNullRet(true,  Null      .Coalesce(zeroMatters: false,   True,       Null,       Null,       True         ));
        NoNullRet(true,  NullyTrue .Coalesce(             false,   Default,    True,       True,       Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(true,  Null      .Coalesce(zeroMatters,          True,       Default,    Default,    True         ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,    Null,       NullyTrue,  NullyTrue,  Null         ));
        NoNullRet(true,  Default   .Coalesce(             true,    NullyTrue,  Null,       Null,       True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  True      .Coalesce(                      NullyFalse, True,       True,       NullyFalse   ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false,   NullyTrue,  False,      False,      True         ));
        NoNullRet(true,  True      .Coalesce(             false,   False,      NullyTrue,  NullyTrue,  NullyFalse   ));
        // ZeroMatters Yes                                                                   
        NoNullRet(false, False     .Coalesce(zeroMatters,          True,       NullyFalse, NullyFalse, True         ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,    False,      True,       True,       NullyFalse   )); // Starts with true
        NoNullRet(true,  False     .Coalesce(             true,    True,       False,      False,      True         )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsParams_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Null      .Coalesce(                      False,      False,      False,      NullyTrue    ));
        NoNullRet(true,  Null      .Coalesce(zeroMatters: false,   False,      True,       True,       NullyFalse   ));
        NoNullRet(true,  Null      .Coalesce(             false,   True,       False,      False,      Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(false, Null      .Coalesce(zeroMatters,          NullyFalse, False,      False,      NullyTrue    ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,    NullyFalse, True,       True,       NullyFalse   ));
        NoNullRet(true,  Null      .Coalesce(             true,    NullyTrue,  False,      False,      Null         )); // Not a flag
    }

    // Extensions Coll Express / Flags in Front

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, False     .Coalesce(                    [ False,      False,      False,      False      ] ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, [ False,      True,       True,       False      ] ));
        NoNullRet(true,  False     .Coalesce(             false, [ False,      False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, False     .Coalesce(zeroMatters,        [ False,      False,      False,      False      ] ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  [ False,      True,       True,       False      ] )); // Starts with true
        NoNullRet(false, False     .Coalesce(             true,  [ False,      False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                    [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: false, [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(             false, [ Null,       Null,       Null,       Null       ] ));
        // ZeroMatters Yes         
        NoNullRet(false, Null      .Coalesce(zeroMatters,        [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,  [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(false, Null      .Coalesce(             true,  [ Null,       Null,       Null,       Null       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, NullyFalse.Coalesce(                    [ False,      False,      False,      False      ] ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, [ False,      True,       True,       False      ] ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, [ False,      False,      False,      True       ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        [ False,      False,      False,      False      ] ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  [ False,      True,       True,       False      ] )); // Starts with true
        NoNullRet(false, NullyFalse.Coalesce(             true,  [ False,      False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce(                    [ NullyFalse, Null,       Null,       NullyFalse ] ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, [ Null,       NullyFalse, NullyFalse, Default    ] ));
        NoNullRet(false, Null      .Coalesce(             false, [ NullyFalse, Default,    Default,    NullyFalse ] ));
        // ZeroMatters Yes
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        [ Null,       False,      False,      Default    ] ));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,  [ False,      Null,       Null,       NullyFalse ] ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  [ Null,       False,      False,      Default    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  NullyTrue  .Coalesce(                    [ Default,    NullyTrue,  NullyTrue,  Null       ] ));
        NoNullRet(true,  Null       .Coalesce(zeroMatters: false, [ True,       Null,       Null,       True       ] ));
        NoNullRet(true,  NullyTrue  .Coalesce(             false, [ Default,    True,       True,       Null       ] ));
        // ZeroMatters Yes          
        NoNullRet(true,  Null       .Coalesce(zeroMatters,        [ True,       Default,    Default,    True       ] ));
        NoNullRet(true,  True       .Coalesce(zeroMatters: true,  [ Null,       NullyTrue,  NullyTrue,  Null       ] ));
        NoNullRet(false, Default    .Coalesce(             true,  [ NullyTrue,  Null,       Null,       True       ] ));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  True       .Coalesce(                    [ NullyFalse, True,       True,       NullyFalse ] ));
        NoNullRet(true,  False      .Coalesce(zeroMatters: false, [ NullyTrue,  False,      False,      True       ] ));
        NoNullRet(true,  True       .Coalesce(             false, [ False,      NullyTrue,  NullyTrue,  NullyFalse ] ));
        // ZeroMatters Yes         
        NoNullRet(false, False      .Coalesce(zeroMatters,        [ True,       NullyFalse, NullyFalse, True       ] ));
        NoNullRet(true,  True       .Coalesce(zeroMatters: true,  [ False,      True,       True,       NullyFalse ] )); // Starts with true
        NoNullRet(false, False      .Coalesce(             true,  [ True,       False,      False,      True       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInFront_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Null       .Coalesce(                    [ False,      False,      False,      NullyTrue  ] ));
        NoNullRet(true,  Null       .Coalesce(zeroMatters: false, [ False,      True,       True,       NullyFalse ] ));
        NoNullRet(true,  Null       .Coalesce(             false, [ True,       False,      False,      Null       ] ));
        // ZeroMatters Yes          
        NoNullRet(false, Null       .Coalesce(zeroMatters,        [ NullyFalse, False,      False,      NullyTrue  ] ));
        NoNullRet(false, Null       .Coalesce(zeroMatters: true,  [ NullyFalse, True,       True,       NullyFalse ] ));
        NoNullRet(true,  Null       .Coalesce(             true,  [ NullyTrue,  False,      False,      Null       ] )); // Starts with true
    }

    // Extensions Coll Express / Flags in Back

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false, False     .Coalesce( [ False,      False,      False,      False      ]                    ));
        NoNullRet(true,  True      .Coalesce( [ False,      True,       True,       False      ], zeroMatters: false));
        NoNullRet(true,  False     .Coalesce( [ False,      False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, False     .Coalesce( [ False,      False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  True      .Coalesce( [ False,      True,       True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, False     .Coalesce( [ False,      False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null,       Null       ]                    ));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters: false));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null,       Null       ],              false));
        // ZeroMatters Yes                                                             
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters       ));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters: true ));
        NoNullRet(false, Null      .Coalesce( [ Null,       Null,       Null,       Null       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false, NullyFalse.Coalesce( [ False,      False,      False,      False      ]                    ));
        NoNullRet(true,  NullyTrue .Coalesce( [ False,      True,       True,       False      ], zeroMatters: false));
        NoNullRet(true,  NullyFalse.Coalesce( [ False,      False,      False,      True       ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false, NullyFalse.Coalesce( [ False,      False,      False,      False      ], zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce( [ False,      True,       True,       False      ], zeroMatters: true )); // Starts with true
        NoNullRet(false, NullyFalse.Coalesce( [ False,      False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NullAndFalse()
    {
        // ZeroMatters No
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, Null,       Null,       NullyFalse ]                    ));
        NoNullRet(false, NullyFalse.Coalesce( [ Null,       NullyFalse, NullyFalse, Default    ], zeroMatters: false));
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, Default,    Default,    NullyFalse ],              false));
        // ZeroMatters Yes
        NoNullRet(false, NullyFalse.Coalesce( [ Null,       False,      False,      Default    ], zeroMatters       ));
        NoNullRet(false, Null      .Coalesce( [ False,      Null,       Null,       NullyFalse ], zeroMatters: true ));
        NoNullRet(false, NullyFalse.Coalesce( [ Null,       False,      False,      Default    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  NullyTrue .Coalesce( [ Default,    NullyTrue,  NullyTrue,  Null       ]                    ));
        NoNullRet(true,  Null      .Coalesce( [ True,       Null,       Null,       True       ], zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce( [ Default,    True,       True,       Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(true,  Null      .Coalesce( [ True,       Default,    Default,    True       ], zeroMatters       ));
        NoNullRet(true,  True      .Coalesce( [ Null,       NullyTrue,  NullyTrue,  Null       ], zeroMatters: true ));
        NoNullRet(false, Default   .Coalesce( [ NullyTrue,  Null,       Null,       True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  True      .Coalesce( [ NullyFalse, True,       True,       NullyFalse ]                    ));
        NoNullRet(true,  False     .Coalesce( [ NullyTrue,  False,      False,      True       ], zeroMatters: false));
        NoNullRet(true,  True      .Coalesce( [ False,      NullyTrue,  NullyTrue,  NullyFalse ],              false));
        // ZeroMatters Yes         
        NoNullRet(false, False     .Coalesce( [ True,       NullyFalse, NullyFalse, True       ], zeroMatters       ));
        NoNullRet(true,  True      .Coalesce( [ False,      True,       True,       NullyFalse ], zeroMatters: true )); // Starts with true
        NoNullRet(false, False     .Coalesce( [ True,       False,      False,      True       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionsCollExpressFlagsInBack_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  Null      .Coalesce( [ False,      False,      False,      NullyTrue  ]                    ));
        NoNullRet(true,  Null      .Coalesce( [ False,      True,       True,       NullyFalse ], zeroMatters: false));
        NoNullRet(true,  Null      .Coalesce( [ True,       False,      False,      Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, False,      False,      NullyTrue  ], zeroMatters       ));
        NoNullRet(false, Null      .Coalesce( [ NullyFalse, True,       True,       NullyFalse ], zeroMatters: true ));
        NoNullRet(true,  Null      .Coalesce( [ NullyTrue,  False,      False,      Null       ],              true )); // Starts with true
    }

    // Extensions on Collections

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(false,  new [] { False,      False,      False,      False,      False      }.Coalesce(                  ));
        NoNullRet(true,   new [] { True,       False,      True,       True,       False      }.Coalesce(zeroMatters: false));
        NoNullRet(true,   new [] { False,      False,      False,      False,      True       }.Coalesce(             false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false,  new [] { False,      False,      False,      False,      False      }.Coalesce(zeroMatters       ));
        NoNullRet(true,   new [] { True,       False,      True,       True,       False      }.Coalesce(zeroMatters: true )); // Starts with true
        NoNullRet(false,  new [] { False,      False,      False,      False,      True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_AllNull()
    {
        // ZeroMatters No
        NoNullRet(false, new [] { Null,        Null,       Null,       Null,       Null       }.Coalesce(                  ));
        NoNullRet(false, new [] { Null,        Null,       Null,       Null,       Null       }.Coalesce(zeroMatters: false));
        NoNullRet(false, new [] { Null,        Null,       Null,       Null,       Null       }.Coalesce(             false));
        // ZeroMatters Yes                                                            
        NoNullRet(false, new [] { Null,        Null,       Null,       Null,       Null       }.Coalesce(zeroMatters       ));
        NoNullRet(false, new [] { Null,        Null,       Null,       Null,       Null       }.Coalesce(zeroMatters: true ));
        NoNullRet(false, new [] { Null,        Null,       Null,       Null,       Null       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(false,  new [] { NullyFalse, False,      False,      False,      False      }.Coalesce(                  ));
        NoNullRet(true,   new [] { NullyTrue,  False,      True,       True,       False      }.Coalesce(zeroMatters: false));
        NoNullRet(true,   new [] { NullyFalse, False,      False,      False,      True       }.Coalesce(             false));
        // ZeroMatters Yes                                                                               
        NoNullRet(false,  new [] { NullyFalse, False,      False,      False,      False      }.Coalesce(zeroMatters       ));
        NoNullRet(true,   new [] { NullyTrue,  False,      True,       True,       False      }.Coalesce(zeroMatters: true )); // Starts with true
        NoNullRet(false,  new [] { NullyFalse, False,      False,      False,      True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_NullAndTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  new [] { NullyTrue,  Default,    NullyTrue,  NullyTrue,  Null       }.Coalesce(                  ));
        NoNullRet(true,  new [] { Null,       True,       Null,       Null,       True       }.Coalesce(zeroMatters: false));
        NoNullRet(true,  new [] { NullyTrue,  Default,    True,       True,       Null       }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(true,  new [] { Null,       True,       Default,    Default,    True       }.Coalesce(zeroMatters       ));
        NoNullRet(true,  new [] { True,       Null,       NullyTrue,  NullyTrue,  Null       }.Coalesce(zeroMatters: true ));
        NoNullRet(false, new [] { Default,    NullyTrue,  Null,       Null,       True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_TrueAndFalse()
    {
        // ZeroMatters No
        NoNullRet(true,  new [] { True,       NullyFalse, True,       True,       NullyFalse }.Coalesce(                  ));
        NoNullRet(true,  new [] { False,      NullyTrue,  False,      False,      True       }.Coalesce(zeroMatters: false));
        NoNullRet(true,  new [] { True,       False,      NullyTrue,  NullyTrue,  NullyFalse }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(false, new [] { False,      True,       NullyFalse, NullyFalse, True       }.Coalesce(zeroMatters       ));
        NoNullRet(true,  new [] { True,       False,      True,       True,       NullyFalse }.Coalesce(zeroMatters: true )); // Starts with true
        NoNullRet(false, new [] { False,      True,       False,      False,      True       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_ExtensionOnCollection_SparseTrue()
    {
        // ZeroMatters No
        NoNullRet(true,  new [] { Null,       False,      False,      False,      NullyTrue  }.Coalesce(                  ));
        NoNullRet(true,  new [] { Null,       False,      True,       True,       NullyFalse }.Coalesce(zeroMatters: false));
        NoNullRet(true,  new [] { Null,       True,       False,      False,      Null       }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(false, new [] { Null,       NullyFalse, False,      False,      NullyTrue  }.Coalesce(zeroMatters       ));
        NoNullRet(false, new [] { Null,       NullyFalse, True,       True,       NullyFalse }.Coalesce(zeroMatters: true ));
        NoNullRet(true,  new [] { Null,       NullyTrue,  False,      False,      Null       }.Coalesce(             true )); // Starts with true
    }

    // Null Collections

    [TestMethod]
    public void Coalesce_NArg_Bool_NullCollNoNullItem()
    {
        ICollection<bool>? nullColl = null;
        // Static Flags in Front
        NoNullRet(false,            Coalesce(                    nullColl));
        NoNullRet(false,            Coalesce(                    nullColl));
        NoNullRet(false,            Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false,            Coalesce(             false, nullColl));
        NoNullRet(false,            Coalesce(zeroMatters,        nullColl));
        NoNullRet(false,            Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false,            Coalesce(             true,  nullColl));
        // Static Flags in Back
        NoNullRet(false,            Coalesce(nullColl                    ));
        NoNullRet(false,            Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false,            Coalesce(nullColl,              false));
        NoNullRet(false,            Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false,            Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false,            Coalesce(nullColl,              true ));
        // Extension Flags in Front
        NoNullRet(false, Null      .Coalesce(                    nullColl));
        NoNullRet(false, Null      .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, Null      .Coalesce(             false, nullColl));
        NoNullRet(false, Null      .Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, Null      .Coalesce(             true,  nullColl));
        NoNullRet(false, False     .Coalesce(                    nullColl));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, False     .Coalesce(             false, nullColl));
        NoNullRet(false, False     .Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, False     .Coalesce(             true,  nullColl));
        NoNullRet(false, NullyFalse.Coalesce(                    nullColl));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, NullyFalse.Coalesce(             false, nullColl));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, NullyFalse.Coalesce(             true,  nullColl));
        NoNullRet(true,  True      .Coalesce(                    nullColl));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(true,  True      .Coalesce(             false, nullColl));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        nullColl));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(true,  True      .Coalesce(             true,  nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(                    nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(             false, nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  nullColl));
        // Extension Flags in Back
        NoNullRet(false, Null      .Coalesce(nullColl                    ));
        NoNullRet(false, Null      .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, Null      .Coalesce(nullColl,              false));
        NoNullRet(false, Null      .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, Null      .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, Null      .Coalesce(nullColl,              true ));
        NoNullRet(false, False     .Coalesce(nullColl                    ));
        NoNullRet(false, False     .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, False     .Coalesce(nullColl,              false));
        NoNullRet(false, False     .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, False     .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, False     .Coalesce(nullColl,              true ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl                    ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, NullyFalse.Coalesce(nullColl,              false));
        NoNullRet(false, NullyFalse.Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl,              true ));
        NoNullRet(true,  True      .Coalesce(nullColl                    ));
        NoNullRet(true,  True      .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(true,  True      .Coalesce(nullColl,              false));
        NoNullRet(true,  True      .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(true,  True      .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(true,  True      .Coalesce(nullColl,              true ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl                    ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl,              false));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl,              true ));
        // Extensions on Collection
        NoNullRet(false, nullColl  .Coalesce(                            ));
        NoNullRet(false, nullColl  .Coalesce(          zeroMatters: false));
        NoNullRet(false, nullColl  .Coalesce(                       false));
        NoNullRet(false, nullColl  .Coalesce(          zeroMatters       ));
    }

    [TestMethod]
    public void Coalesce_NArg_Bool_NullCollNullItem()
    {
        ICollection<bool?>? nullColl = null;
        // Static Flags in Front
        NoNullRet(false,            Coalesce(                    nullColl));
        NoNullRet(false,            Coalesce(                    nullColl));
        NoNullRet(false,            Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false,            Coalesce(             false, nullColl));
        NoNullRet(false,            Coalesce(zeroMatters,        nullColl));
        NoNullRet(false,            Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false,            Coalesce(             true,  nullColl));
        // Static Flags in Back
        NoNullRet(false,            Coalesce(nullColl                    ));
        NoNullRet(false,            Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false,            Coalesce(nullColl,              false));
        NoNullRet(false,            Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false,            Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false,            Coalesce(nullColl,              true ));
        // Extension Flags in Front
        NoNullRet(false, Null      .Coalesce(                    nullColl));
        NoNullRet(false, Null      .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, Null      .Coalesce(             false, nullColl));
        NoNullRet(false, Null      .Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, Null      .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, Null      .Coalesce(             true,  nullColl));
        NoNullRet(false, False     .Coalesce(                    nullColl));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, False     .Coalesce(             false, nullColl));
        NoNullRet(false, False     .Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, False     .Coalesce(             true,  nullColl));
        NoNullRet(false, NullyFalse.Coalesce(                    nullColl));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, nullColl));
        NoNullRet(false, NullyFalse.Coalesce(             false, nullColl));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        nullColl));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(false, NullyFalse.Coalesce(             true,  nullColl));
        NoNullRet(true,  True      .Coalesce(                    nullColl));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(true,  True      .Coalesce(             false, nullColl));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        nullColl));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(true,  True      .Coalesce(             true,  nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(                    nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(             false, nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  nullColl));
        // Extension Flags in Back
        NoNullRet(false, Null      .Coalesce(nullColl                    ));
        NoNullRet(false, Null      .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, Null      .Coalesce(nullColl,              false));
        NoNullRet(false, Null      .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, Null      .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, Null      .Coalesce(nullColl,              true ));
        NoNullRet(false, False     .Coalesce(nullColl                    ));
        NoNullRet(false, False     .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, False     .Coalesce(nullColl,              false));
        NoNullRet(false, False     .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, False     .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, False     .Coalesce(nullColl,              true ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl                    ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl, zeroMatters: false));
        NoNullRet(false, NullyFalse.Coalesce(nullColl,              false));
        NoNullRet(false, NullyFalse.Coalesce(nullColl, zeroMatters       ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(false, NullyFalse.Coalesce(nullColl,              true ));
        NoNullRet(true,  True      .Coalesce(nullColl                    ));
        NoNullRet(true,  True      .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(true,  True      .Coalesce(nullColl,              false));
        NoNullRet(true,  True      .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(true,  True      .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(true,  True      .Coalesce(nullColl,              true ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl                    ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl,              false));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(true,  NullyTrue .Coalesce(nullColl,              true ));
        // Extensions on Collection
        NoNullRet(false, nullColl  .Coalesce(                            ));
        NoNullRet(false, nullColl  .Coalesce(          zeroMatters: false));
        NoNullRet(false, nullColl  .Coalesce(                       false));
        NoNullRet(false, nullColl  .Coalesce(          zeroMatters       ));
    }
}