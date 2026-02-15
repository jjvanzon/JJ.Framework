// ReSharper disable ConvertToConstant.Local
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArg_Values_Tests : TestBase
{
    private readonly int? Null = null;
    private readonly int Default = 0; // Can't be constant. Constant 0 clashes with enums.

    // Static

    // Static Params

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticParams_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                      NoNull0,    NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     Coalesce(zeroMatters: false,   NoNull1,    NoNull0,    NoNull1,    NoNull0      ));
        NoNullRet(1,     Coalesce(             false,   NoNull0,    NoNull0,    NoNull0,    NoNull1      ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,          NoNull0,    NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     Coalesce(zeroMatters: true,    NoNull1,    NoNull0,    NoNull1,    NoNull0      )); // Starts with 1
        NoNullRet(0,     Coalesce(             true,    NoNull0,    NoNull0,    NoNull0,    NoNull1      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticParams_AllNull()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                      Null,       Null,       Null,       Null         ));
        NoNullRet(0,     Coalesce(zeroMatters: false,   Null,       Null,       Null,       Null         ));
        NoNullRet(0,     Coalesce(             false,   Null,       Null,       Null,       Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,          Null,       Null,       Null,       Null         ));
        NoNullRet(0,     Coalesce(zeroMatters: true,    Null,       Null,       Null,       Null         ));
        NoNullRet(0,     Coalesce(             true,    Null,       Null,       Null,       Null         ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticParams_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                      Nully0,     NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     Coalesce(zeroMatters: false,   Nully1,     NoNull0,    NoNull1,    NoNull0      ));
        NoNullRet(1,     Coalesce(             false,   Nully0,     NoNull0,    NoNull0,    NoNull1      ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,          Nully0,     NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     Coalesce(zeroMatters: true,    Nully1,     NoNull0,    NoNull1,    NoNull0      )); // Starts with 1
        NoNullRet(0,     Coalesce(             true,    Nully0,     NoNull0,    NoNull0,    NoNull1      ));
    }

    // Checker pattern of nulls and falses, going by permutations of nullable/non-nullable, 

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticParams_NullAnd0()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                      Null,       Nully0,     Null,       Nully0       ));
        NoNullRet(0,     Coalesce(zeroMatters: false,   Nully0,     Null,       Nully0,     Default      ));
        NoNullRet(0,     Coalesce(             false,   Null,       Nully0,     Default,    Nully0       ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,          Nully0,     Null,       NoNull0,    Default      ));
        NoNullRet(0,     Coalesce(zeroMatters: true,    Null,       NoNull0,    Null,       Nully0       ));
        NoNullRet(0,     Coalesce(             true,    Nully0,     Null,       NoNull0,    Default      ));
    }

    // Now checker-pattern true and null, continuing to follow permutations of nullable/non-nullable.

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticParams_NullAnd1()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce(                      Nully1,     Default,    Nully1,     Null         ));
        NoNullRet(1,     Coalesce(zeroMatters: false,   Null,       NoNull1,    Null,       NoNull1      ));
        NoNullRet(1,     Coalesce(             false,   Nully1,     Default,    NoNull1,    Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(1,     Coalesce(zeroMatters,          Null,       NoNull1,    Default,    NoNull1      ));
        NoNullRet(1,     Coalesce(zeroMatters: true,    NoNull1,    Null,       Nully1,     Null         ));
        NoNullRet(0,     Coalesce(             true,    Default,    Nully1,     Null,       NoNull1      ));
    }

    // Checker-pattern true and false now, continued permutations of nullable/non-nullable

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticParams_1And0()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce(                      NoNull1,    Nully0,     NoNull1,    Nully0       ));
        NoNullRet(1,     Coalesce(zeroMatters: false,   NoNull0,    Nully1,     NoNull0,    NoNull1      ));
        NoNullRet(1,     Coalesce(             false,   NoNull1,    NoNull0,    Nully1,     Nully0       ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,          NoNull0,    NoNull1,    Nully0,     NoNull1      ));
        NoNullRet(1,     Coalesce(zeroMatters: true,    NoNull1,    NoNull0,    NoNull1,    Nully0       )); // Starts with 1
        NoNullRet(0,     Coalesce(             true,    NoNull0,    NoNull1,    NoNull0,    NoNull1      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticParams_Sparse1()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce(                      Null,       NoNull0,    NoNull0,    Nully1       ));
        NoNullRet(1,     Coalesce(zeroMatters: false,   Null,       NoNull0,    NoNull1,    Nully0       ));
        NoNullRet(1,     Coalesce(             false,   Null,       NoNull1,    NoNull0,    Null         ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,          Null,       Nully0,     NoNull0,    Nully1       ));
        NoNullRet(0,     Coalesce(zeroMatters: true,    Null,       Nully0,     NoNull1,    Nully0       ));
        NoNullRet(1,     Coalesce(             true,    Null,       Nully1,     NoNull0,    Null         ));
    }

    // Static Coll Express / Flags in Front

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInFront_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                    [ NoNull0,    NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     Coalesce(zeroMatters: false, [ NoNull1,    NoNull0,    NoNull1,    NoNull0    ] ));
        NoNullRet(1,     Coalesce(             false, [ NoNull0,    NoNull0,    NoNull0,    NoNull1    ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,        [ NoNull0,    NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     Coalesce(zeroMatters: true,  [ NoNull1,    NoNull0,    NoNull1,    NoNull0    ] )); // Starts with 1
        NoNullRet(0,     Coalesce(             true,  [ NoNull0,    NoNull0,    NoNull0,    NoNull1    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInFront_AllNull()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                    [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(0,     Coalesce(zeroMatters: false, [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(0,     Coalesce(             false, [ Null,       Null,       Null,       Null       ] ));
        // ZeroMatters Yes
        NoNullRet(0,     Coalesce(zeroMatters,        [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(0,     Coalesce(zeroMatters: true,  [ Null,       Null,       Null,       Null       ] ));
        NoNullRet(0,     Coalesce(             true,  [ Null,       Null,       Null,       Null       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInFront_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                    [ Nully0,     NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     Coalesce(zeroMatters: false, [ Nully1,     NoNull0,    NoNull1,    NoNull0    ] ));
        NoNullRet(1,     Coalesce(             false, [ Nully0,     NoNull0,    NoNull0,    NoNull1    ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce(zeroMatters,        [ Nully0,     NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     Coalesce(zeroMatters: true,  [ Nully1,     NoNull0,    NoNull1,    NoNull0    ] )); // Starts with 1
        NoNullRet(0,     Coalesce(             true,  [ Nully0,     NoNull0,    NoNull0,    NoNull1    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInFront_NullAnd0()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce(                    [ Null,       Nully0,     Null,       Nully0     ] ));
        NoNullRet(0,     Coalesce(zeroMatters: false, [ Nully0,     Null,       Nully0,     Default    ] ));
        NoNullRet(0,     Coalesce(             false, [ Null,       Nully0,     Default,    Nully0     ] ));
        // ZeroMatters Yes
        NoNullRet(0,     Coalesce(zeroMatters,        [ Nully0,     Null,       NoNull0,    Default    ] ));
        NoNullRet(0,     Coalesce(zeroMatters: true,  [ Null,       NoNull0,    Null,       Nully0     ] ));
        NoNullRet(0,     Coalesce(             true,  [ Nully0,     Null,       NoNull0,    Default    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInFront_NullAnd1()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce(                    [ Nully1,     Default,    Nully1,     Null       ] ));
        NoNullRet(1,     Coalesce(zeroMatters: false, [ Null,       NoNull1,    Null,       NoNull1    ] ));
        NoNullRet(1,     Coalesce(             false, [ Nully1,     Default,    NoNull1,    Null       ] ));
        // ZeroMatters Yes
        NoNullRet(1,     Coalesce(zeroMatters,        [ Null,       NoNull1,    Default,    NoNull1    ] ));
        NoNullRet(1,     Coalesce(zeroMatters: true,  [ NoNull1,    Null,       Nully1,     Null       ] ));
        NoNullRet(0,     Coalesce(             true,  [ Default,    Nully1,     Null,       NoNull1    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInFront_1And0()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce(                    [ NoNull1,    Nully0,     NoNull1,    Nully0     ] ));
        NoNullRet(1,     Coalesce(zeroMatters: false, [ NoNull0,    Nully1,     NoNull0,    NoNull1    ] ));
        NoNullRet(1,     Coalesce(             false, [ NoNull1,    NoNull0,    Nully1,     Nully0     ] ));
        // ZeroMatters Yes
        NoNullRet(0,     Coalesce(zeroMatters,        [ NoNull0,    NoNull1,    Nully0,     NoNull1    ] ));
        NoNullRet(1,     Coalesce(zeroMatters: true,  [ NoNull1,    NoNull0,    NoNull1,    Nully0     ] )); // Starts with 1
        NoNullRet(0,     Coalesce(             true,  [ NoNull0,    NoNull1,    NoNull0,    NoNull1    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInFront_Sparse1()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce(                    [ Null,       NoNull0,    NoNull0,    Nully1     ] ));
        NoNullRet(1,     Coalesce(zeroMatters: false, [ Null,       NoNull0,    NoNull1,    Nully0     ] ));
        NoNullRet(1,     Coalesce(             false, [ Null,       NoNull1,    NoNull0,    Null       ] ));
        // ZeroMatters Yes
        NoNullRet(0,     Coalesce(zeroMatters,        [ Null,       Nully0,     NoNull0,    Nully1     ] ));
        NoNullRet(0,     Coalesce(zeroMatters: true,  [ Null,       Nully0,     NoNull1,    Nully0     ] ));
        NoNullRet(1,     Coalesce(             true,  [ Null,       Nully1,     NoNull0,    Null       ] )); // 1st non-null is 1
    }

    // Static Coll Express / Flags in Back

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInBack_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce( [ NoNull0,    NoNull0,    NoNull0,    NoNull0    ]                    ));
        NoNullRet(1,     Coalesce( [ NoNull1,    NoNull0,    NoNull1,    NoNull0    ], zeroMatters: false));
        NoNullRet(1,     Coalesce( [ NoNull0,    NoNull0,    NoNull0,    NoNull1    ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce( [ NoNull0,    NoNull0,    NoNull0,    NoNull0    ], zeroMatters       ));
        NoNullRet(1,     Coalesce( [ NoNull1,    NoNull0,    NoNull1,    NoNull0    ], zeroMatters: true )); // Starts with 1
        NoNullRet(0,     Coalesce( [ NoNull0,    NoNull0,    NoNull0,    NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInBack_AllNull()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce( [ Null,       Null,       Null,       Null       ]                    ));
        NoNullRet(0,     Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters: false));
        NoNullRet(0,     Coalesce( [ Null,       Null,       Null,       Null       ],              false));
        // ZeroMatters Yes                                                            
        NoNullRet(0,     Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters       ));
        NoNullRet(0,     Coalesce( [ Null,       Null,       Null,       Null       ], zeroMatters: true ));
        NoNullRet(0,     Coalesce( [ Null,       Null,       Null,       Null       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInBack_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce( [ Nully0,     NoNull0,    NoNull0,    NoNull0    ]                    ));
        NoNullRet(1,     Coalesce( [ Nully1,     NoNull0,    NoNull1,    NoNull0    ], zeroMatters: false));
        NoNullRet(1,     Coalesce( [ Nully0,     NoNull0,    NoNull0,    NoNull1    ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Coalesce( [ Nully0,     NoNull0,    NoNull0,    NoNull0    ], zeroMatters       ));
        NoNullRet(1,     Coalesce( [ Nully1,     NoNull0,    NoNull1,    NoNull0    ], zeroMatters: true )); // Starts with 1
        NoNullRet(0,     Coalesce( [ Nully0,     NoNull0,    NoNull0,    NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInBack_NullAnd0()
    {
        // ZeroMatters No
        NoNullRet(0,     Coalesce( [ Null,       Nully0,     Null,       Nully0     ]                    ));
        NoNullRet(0,     Coalesce( [ Nully0,     Null,       Nully0,     Default    ], zeroMatters: false));
        NoNullRet(0,     Coalesce( [ Null,       Nully0,     Default,    Nully0     ],              false));
        // ZeroMatters Yes
        NoNullRet(0,     Coalesce( [ Nully0,     Null,       NoNull0,    Default    ], zeroMatters       ));
        NoNullRet(0,     Coalesce( [ Null,       NoNull0,    Null,       Nully0     ], zeroMatters: true ));
        NoNullRet(0,     Coalesce( [ Nully0,     Null,       NoNull0,    Default    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInBack_NullAnd1()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce( [ Nully1,     Default,    Nully1,     Null       ]                    ));
        NoNullRet(1,     Coalesce( [ Null,       NoNull1,    Null,       NoNull1    ], zeroMatters: false));
        NoNullRet(1,     Coalesce( [ Nully1,     Default,    NoNull1,    Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(1,     Coalesce( [ Null,       NoNull1,    Default,    NoNull1    ], zeroMatters       ));
        NoNullRet(1,     Coalesce( [ NoNull1,    Null,       Nully1,     Null       ], zeroMatters: true ));
        NoNullRet(0,     Coalesce( [ Default,    Nully1,     Null,       NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInBack_1And0()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce( [ NoNull1,    Nully0,     NoNull1,    Nully0     ]                    ));
        NoNullRet(1,     Coalesce( [ NoNull0,    Nully1,     NoNull0,    NoNull1    ], zeroMatters: false));
        NoNullRet(1,     Coalesce( [ NoNull1,    NoNull0,    Nully1,     Nully0     ],              false));
        // ZeroMatters Yes
        NoNullRet(0,     Coalesce( [ NoNull0,    NoNull1,    Nully0,     NoNull1    ], zeroMatters       ));
        NoNullRet(1,     Coalesce( [ NoNull1,    NoNull0,    NoNull1,    Nully0     ], zeroMatters: true )); // Starts with 1
        NoNullRet(0,     Coalesce( [ NoNull0,    NoNull1,    NoNull0,    NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_StaticCollExpressFlagsInBack_Sparse1()
    {
        // ZeroMatters No
        NoNullRet(1,     Coalesce( [ Null,       NoNull0,    NoNull0,    Nully1     ]                    ));
        NoNullRet(1,     Coalesce( [ Null,       NoNull0,    NoNull1,    Nully0     ], zeroMatters: false));
        NoNullRet(1,     Coalesce( [ Null,       NoNull1,    NoNull0,    Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(0,     Coalesce( [ Null,       Nully0,     NoNull0,    Nully1     ], zeroMatters       ));
        NoNullRet(0,     Coalesce( [ Null,       Nully0,     NoNull1,    Nully0     ], zeroMatters: true ));
        NoNullRet(1,     Coalesce( [ Null,       Nully1,     NoNull0,    Null       ],              true )); // 1st non-null is 1
    }

    // Extensions

    // Extensions Params

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsParams_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(0,     NoNull0   .Coalesce(                      NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     NoNull1   .Coalesce(zeroMatters: false,   NoNull0,    NoNull1,    NoNull0      ));
        NoNullRet(1,     NoNull0   .Coalesce(             false,   NoNull0,    NoNull0,    NoNull1      ));
        // ZeroMatters Ye.s                                                                 
        NoNullRet(0,     NoNull0   .Coalesce(zeroMatters,          NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     NoNull1   .Coalesce(zeroMatters: true,    NoNull0,    NoNull1,    NoNull0      )); // Starts with 1
        NoNullRet(0,     NoNull0   .Coalesce(             true,    NoNull0,    NoNull0,    NoNull1      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsParams_AllNull()
    {
        // ZeroMatters No
        NoNullRet(0,     Null      .Coalesce(                      Null,       Null,       Null         ));
        NoNullRet(0,     Null      .Coalesce(zeroMatters: false,   Null,       Null,       Null         ));
        NoNullRet(0,     Null      .Coalesce(             false,   Null,       Null,       Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(0,     Null      .Coalesce(zeroMatters,          Null,       Null,       Null         ));
        NoNullRet(0,     Null      .Coalesce(zeroMatters: true,    Null,       Null,       Null         ));
        NoNullRet(0,     Null      .Coalesce(             true,    Null,       Null,       Null         ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsParams_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(0,     Nully0.    Coalesce(                      NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     Nully1    .Coalesce(zeroMatters: false,   NoNull0,    NoNull1,    NoNull0      ));
        NoNullRet(1,     Nully0.    Coalesce(             false,   NoNull0,    NoNull0,    NoNull1      ));
        // ZeroMatters Yes                                                                 
        NoNullRet(0,     Nully0.    Coalesce(zeroMatters,          NoNull0,    NoNull0,    NoNull0      ));
        NoNullRet(1,     Nully1    .Coalesce(zeroMatters: true,    NoNull0,    NoNull1,    NoNull0      )); // Starts with 1
        NoNullRet(0,     Nully0.    Coalesce(             true,    NoNull0,    NoNull0,    NoNull1      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsParams_NullAnd0()
    {
        // ZeroMatters No
        NoNullRet(0,     Null      .Coalesce(                       Nully0,     Null,       Nully0       ));
        NoNullRet(0,     Nully0.    Coalesce(zeroMatters: false,    Null,       Nully0,     Default      ));
        NoNullRet(0,     Null      .Coalesce(             false,    Nully0,     Default,    Nully0       ));
        // ZeroMatters Yes                                                                    
        NoNullRet(0,     Nully0.    Coalesce(zeroMatters,           Null,       NoNull0,    Default      ));
        NoNullRet(0,     Null      .Coalesce(zeroMatters: true,     NoNull0,    Null,       Nully0       ));
        NoNullRet(0,     Nully0.    Coalesce(             true,     Null,       NoNull0,    Default      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsParams_NullAnd1()
    {
        // ZeroMatters No
        NoNullRet(1,     Nully1    .Coalesce(                      Default,    Nully1,     Null         ));
        NoNullRet(1,     Null      .Coalesce(zeroMatters: false,   NoNull1,    Null,       NoNull1      ));
        NoNullRet(1,     Nully1    .Coalesce(             false,   Default,    NoNull1,    Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(1,     Null      .Coalesce(zeroMatters,          NoNull1,    Default,    NoNull1      ));
        NoNullRet(1,     NoNull1   .Coalesce(zeroMatters: true,    Null,       Nully1,     Null         ));
        NoNullRet(0,     Default   .Coalesce(             true,    Nully1,     Null,       NoNull1      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsParams_1And0()
    {
        // ZeroMatters No
        NoNullRet(1,     NoNull1   .Coalesce(                      Nully0,     NoNull1,    Nully0       ));
        NoNullRet(1,     NoNull0   .Coalesce(zeroMatters: false,   Nully1,     NoNull0,    NoNull1      ));
        NoNullRet(1,     NoNull1   .Coalesce(             false,   NoNull0,    Nully1,     Nully0       ));
        // ZeroMatters Yes                                                                   
        NoNullRet(0,     NoNull0   .Coalesce(zeroMatters,          NoNull1,    Nully0,     NoNull1      ));
        NoNullRet(1,     NoNull1   .Coalesce(zeroMatters: true,    NoNull0,    NoNull1,    Nully0       )); // Starts with 1
        NoNullRet(0,     NoNull0   .Coalesce(             true,    NoNull1,    NoNull0,    NoNull1      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsParams_Sparse1()
    {
        // ZeroMatters No
        NoNullRet(1,     Null      .Coalesce(                      NoNull0,    NoNull0,    Nully1       ));
        NoNullRet(1,     Null      .Coalesce(zeroMatters: false,   NoNull0,    NoNull1,    Nully0       ));
        NoNullRet(1,     Null      .Coalesce(             false,   NoNull1,    NoNull0,    Null         ));
        // ZeroMatters Yes                                                                   
        NoNullRet(0,     Null      .Coalesce(zeroMatters,          Nully0,     NoNull0,    Nully1       ));
        NoNullRet(0,     Null      .Coalesce(zeroMatters: true,    Nully0,     NoNull1,    Nully0       ));
        NoNullRet(1,     Null      .Coalesce(             true,    Nully1,     NoNull0,    Null         )); // Starts with 1
    }

    // Extensions Coll Express / Flags in Front

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInFront_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(0,     NoNull0   .Coalesce(                    [ NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     NoNull1   .Coalesce(zeroMatters: false, [ NoNull0,    NoNull1,    NoNull0    ] ));
        NoNullRet(1,     NoNull0   .Coalesce(             false, [ NoNull0,    NoNull0,    NoNull1    ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     NoNull0   .Coalesce(zeroMatters,        [ NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     NoNull1   .Coalesce(zeroMatters: true,  [ NoNull0,    NoNull1,    NoNull0    ] )); // Starts with 1
        NoNullRet(0,     NoNull0   .Coalesce(             true,  [ NoNull0,    NoNull0,    NoNull1    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInFront_AllNull()
    {
        // ZeroMatters No
        NoNullRet(0,     Null      .Coalesce(                    [ Null,       Null,       Null       ] ));
        NoNullRet(0,     Null      .Coalesce(zeroMatters: false, [ Null,       Null,       Null       ] ));
        NoNullRet(0,     Null      .Coalesce(             false, [ Null,       Null,       Null       ] ));
        // ZeroMatters Yes         
        NoNullRet(0,     Null      .Coalesce(zeroMatters,        [ Null,       Null,       Null       ] ));
        NoNullRet(0,     Null      .Coalesce(zeroMatters: true,  [ Null,       Null,       Null       ] ));
        NoNullRet(0,     Null      .Coalesce(             true,  [ Null,       Null,       Null       ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInFront_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(0,     Nully0.    Coalesce(                    [ NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     Nully1    .Coalesce(zeroMatters: false, [ NoNull0,    NoNull1,    NoNull0    ] ));
        NoNullRet(1,     Nully0.    Coalesce(             false, [ NoNull0,    NoNull0,    NoNull1    ] ));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Nully0.    Coalesce(zeroMatters,        [ NoNull0,    NoNull0,    NoNull0    ] ));
        NoNullRet(1,     Nully1    .Coalesce(zeroMatters: true,  [ NoNull0,    NoNull1,    NoNull0    ] )); // Starts with 1
        NoNullRet(0,     Nully0.    Coalesce(             true,  [ NoNull0,    NoNull0,    NoNull1    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInFront_NullAnd0()
    {
        // ZeroMatters No
        NoNullRet(0,     Null      .Coalesce(                    [ Nully0,     Null,       Nully0     ] ));
        NoNullRet(0,     Nully0.    Coalesce(zeroMatters: false, [ Null,       Nully0,     Default    ] ));
        NoNullRet(0,     Null      .Coalesce(             false, [ Nully0,     Default,    Nully0     ] ));
        // ZeroMatters Yes
        NoNullRet(0,     Nully0.    Coalesce(zeroMatters,        [ Null,       NoNull0,    Default    ] ));
        NoNullRet(0,     Null      .Coalesce(zeroMatters: true,  [ NoNull0,    Null,       Nully0     ] ));
        NoNullRet(0,     Nully0.    Coalesce(             true,  [ Null,       NoNull0,    Default    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInFront_NullAnd1()
    {
        // ZeroMatters No
        NoNullRet(1,     Nully1     .Coalesce(                    [ Default,    Nully1,     Null       ] ));
        NoNullRet(1,     Null       .Coalesce(zeroMatters: false, [ NoNull1,    Null,       NoNull1    ] ));
        NoNullRet(1,     Nully1     .Coalesce(             false, [ Default,    NoNull1,    Null       ] ));
        // ZeroMatters Yes          
        NoNullRet(1,     Null       .Coalesce(zeroMatters,        [ NoNull1,    Default,    NoNull1    ] ));
        NoNullRet(1,     NoNull1    .Coalesce(zeroMatters: true,  [ Null,       Nully1,     Null       ] ));
        NoNullRet(0,     Default    .Coalesce(             true,  [ Nully1,     Null,       NoNull1    ] ));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInFront_1And0()
    {
        // ZeroMatters No
        NoNullRet(1,     NoNull1    .Coalesce(                    [ Nully0,     NoNull1,    Nully0     ] ));
        NoNullRet(1,     NoNull0    .Coalesce(zeroMatters: false, [ Nully1,     NoNull0,    NoNull1    ] ));
        NoNullRet(1,     NoNull1    .Coalesce(             false, [ NoNull0,    Nully1,     Nully0     ] ));
        // ZeroMatters Yes         
        NoNullRet(0,     NoNull0    .Coalesce(zeroMatters,        [ NoNull1,    Nully0,     NoNull1    ] ));
        NoNullRet(1,     NoNull1    .Coalesce(zeroMatters: true,  [ NoNull0,    NoNull1,    Nully0     ] )); // Starts with 1
        NoNullRet(0,     NoNull0    .Coalesce(             true,  [ NoNull1,    NoNull0,    NoNull1    ] ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInFront_Sparse1()
    {
        // ZeroMatters No
        NoNullRet(1,     Null       .Coalesce(                    [ NoNull0,    NoNull0,    Nully1     ] ));
        NoNullRet(1,     Null       .Coalesce(zeroMatters: false, [ NoNull0,    NoNull1,    Nully0     ] ));
        NoNullRet(1,     Null       .Coalesce(             false, [ NoNull1,    NoNull0,    Null       ] ));
        // ZeroMatters Yes          
        NoNullRet(0,     Null       .Coalesce(zeroMatters,        [ Nully0,     NoNull0,    Nully1     ] ));
        NoNullRet(0,     Null       .Coalesce(zeroMatters: true,  [ Nully0,     NoNull1,    Nully0     ] ));
        NoNullRet(1,     Null       .Coalesce(             true,  [ Nully1,     NoNull0,    Null       ] )); // 1st non-null is 1
    }

    // Extensions Coll Express / Flags in Back

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInBack_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(0,     NoNull0   .Coalesce( [ NoNull0,    NoNull0,    NoNull0    ]                    ));
        NoNullRet(1,     NoNull1   .Coalesce( [ NoNull0,    NoNull1,    NoNull0    ], zeroMatters: false));
        NoNullRet(1,     NoNull0   .Coalesce( [ NoNull0,    NoNull0,    NoNull1    ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     NoNull0   .Coalesce( [ NoNull0,    NoNull0,    NoNull0    ], zeroMatters       ));
        NoNullRet(1,     NoNull1   .Coalesce( [ NoNull0,    NoNull1,    NoNull0    ], zeroMatters: true )); // Starts with 1
        NoNullRet(0,     NoNull0   .Coalesce( [ NoNull0,    NoNull0,    NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInBack_AllNull()
    {
        // ZeroMatters No
        NoNullRet(0,     Null      .Coalesce( [ Null,       Null,       Null       ]                    ));
        NoNullRet(0,     Null      .Coalesce( [ Null,       Null,       Null       ], zeroMatters: false));
        NoNullRet(0,     Null      .Coalesce( [ Null,       Null,       Null       ],              false));
        // ZeroMatters Yes                                                             
        NoNullRet(0,     Null      .Coalesce( [ Null,       Null,       Null       ], zeroMatters       ));
        NoNullRet(0,     Null      .Coalesce( [ Null,       Null,       Null       ], zeroMatters: true ));
        NoNullRet(0,     Null      .Coalesce( [ Null,       Null,       Null       ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInBack_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(0,     Nully0.    Coalesce( [ NoNull0,    NoNull0,    NoNull0    ]                    ));
        NoNullRet(1,     Nully1    .Coalesce( [ NoNull0,    NoNull1,    NoNull0    ], zeroMatters: false));
        NoNullRet(1,     Nully0.    Coalesce( [ NoNull0,    NoNull0,    NoNull1    ],              false));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,     Nully0.    Coalesce( [ NoNull0,    NoNull0,    NoNull0    ], zeroMatters       ));
        NoNullRet(1,     Nully1    .Coalesce( [ NoNull0,    NoNull1,    NoNull0    ], zeroMatters: true )); // Starts with 1
        NoNullRet(0,     Nully0.    Coalesce( [ NoNull0,    NoNull0,    NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInBack_NullAnd0()
    {
        // ZeroMatters No
        NoNullRet(0,     Null      .Coalesce( [ Nully0,     Null,       Nully0     ]                    ));
        NoNullRet(0,     Nully0.    Coalesce( [ Null,       Nully0,     Default    ], zeroMatters: false));
        NoNullRet(0,     Null      .Coalesce( [ Nully0,     Default,    Nully0     ],              false));
        // ZeroMatters Yes
        NoNullRet(0,     Nully0.    Coalesce( [ Null,       NoNull0,    Default    ], zeroMatters       ));
        NoNullRet(0,     Null      .Coalesce( [ NoNull0,    Null,       Nully0     ], zeroMatters: true ));
        NoNullRet(0,     Nully0.    Coalesce( [ Null,       NoNull0,    Default    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInBack_NullAnd1()
    {
        // ZeroMatters No
        NoNullRet(1,     Nully1    .Coalesce( [ Default,    Nully1,     Null       ]                    ));
        NoNullRet(1,     Null      .Coalesce( [ NoNull1,    Null,       NoNull1    ], zeroMatters: false));
        NoNullRet(1,     Nully1    .Coalesce( [ Default,    NoNull1,    Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(1,     Null      .Coalesce( [ NoNull1,    Default,    NoNull1    ], zeroMatters       ));
        NoNullRet(1,     NoNull1   .Coalesce( [ Null,       Nully1,     Null       ], zeroMatters: true ));
        NoNullRet(0,     Default   .Coalesce( [ Nully1,     Null,       NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInBack_1And0()
    {
        // ZeroMatters No
        NoNullRet(1,     NoNull1   .Coalesce( [ Nully0,     NoNull1,    Nully0     ]                    ));
        NoNullRet(1,     NoNull0   .Coalesce( [ Nully1,     NoNull0,    NoNull1    ], zeroMatters: false));
        NoNullRet(1,     NoNull1   .Coalesce( [ NoNull0,    Nully1,     Nully0     ],              false));
        // ZeroMatters Yes         
        NoNullRet(0,     NoNull0   .Coalesce( [ NoNull1,    Nully0,     NoNull1    ], zeroMatters       ));
        NoNullRet(1,     NoNull1   .Coalesce( [ NoNull0,    NoNull1,    Nully0     ], zeroMatters: true )); // Starts with 1
        NoNullRet(0,     NoNull0   .Coalesce( [ NoNull1,    NoNull0,    NoNull1    ],              true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionsCollExpressFlagsInBack_Sparse1()
    {
        // ZeroMatters No
        NoNullRet(1,     Null      .Coalesce( [ NoNull0,    NoNull0,    Nully1     ]                    ));
        NoNullRet(1,     Null      .Coalesce( [ NoNull0,    NoNull1,    Nully0     ], zeroMatters: false));
        NoNullRet(1,     Null      .Coalesce( [ NoNull1,    NoNull0,    Null       ],              false));
        // ZeroMatters Yes
        NoNullRet(0,     Null      .Coalesce( [ Nully0,     NoNull0,    Nully1     ], zeroMatters       ));
        NoNullRet(0,     Null      .Coalesce( [ Nully0,     NoNull1,    Nully0     ], zeroMatters: true ));
        NoNullRet(1,     Null      .Coalesce( [ Nully1,     NoNull0,    Null       ],              true )); // 1st non-null is 1
    }

    // Extensions on Collections

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionOnCollection_NoNulls()
    {
        // ZeroMatters No
        NoNullRet(0,      new [] { NoNull0,    NoNull0,    NoNull0,    NoNull0    }.Coalesce(                  ));
        NoNullRet(1,      new [] { NoNull1,    NoNull0,    NoNull1,    NoNull0    }.Coalesce(zeroMatters: false));
        NoNullRet(1,      new [] { NoNull0,    NoNull0,    NoNull0,    NoNull1    }.Coalesce(             false));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,      new [] { NoNull0,    NoNull0,    NoNull0,    NoNull0    }.Coalesce(zeroMatters       ));
        NoNullRet(1,      new [] { NoNull1,    NoNull0,    NoNull1,    NoNull0    }.Coalesce(zeroMatters: true )); // Starts with 1
        NoNullRet(0,      new [] { NoNull0,    NoNull0,    NoNull0,    NoNull1    }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionOnCollection_AllNull()
    {
        // ZeroMatters No
        NoNullRet(0,     new [] { Null,       Null,       Null,       Null       }.Coalesce(                  ));
        NoNullRet(0,     new [] { Null,       Null,       Null,       Null       }.Coalesce(zeroMatters: false));
        NoNullRet(0,     new [] { Null,       Null,       Null,       Null       }.Coalesce(             false));
        // ZeroMatters Yes                                                            
        NoNullRet(0,     new [] { Null,       Null,       Null,       Null       }.Coalesce(zeroMatters       ));
        NoNullRet(0,     new [] { Null,       Null,       Null,       Null       }.Coalesce(zeroMatters: true ));
        NoNullRet(0,     new [] { Null,       Null,       Null,       Null       }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionOnCollection_NullyFirst()
    {
        // ZeroMatters No
        NoNullRet(0,      new [] { Nully0,     NoNull0,    NoNull0,    NoNull0    }.Coalesce(                  ));
        NoNullRet(1,      new [] { Nully1,     NoNull0,    NoNull1,    NoNull0    }.Coalesce(zeroMatters: false));
        NoNullRet(1,      new [] { Nully0,     NoNull0,    NoNull0,    NoNull1    }.Coalesce(             false));
        // ZeroMatters Yes                                                                               
        NoNullRet(0,      new [] { Nully0,     NoNull0,    NoNull0,    NoNull0    }.Coalesce(zeroMatters       ));
        NoNullRet(1,      new [] { Nully1,     NoNull0,    NoNull1,    NoNull0    }.Coalesce(zeroMatters: true )); // Starts with 1
        NoNullRet(0,      new [] { Nully0,     NoNull0,    NoNull0,    NoNull1    }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionOnCollection_NullAnd1()
    {
        // ZeroMatters No
        NoNullRet(1,     new [] { Nully1,     Default,    Nully1,     Null       }.Coalesce(                  ));
        NoNullRet(1,     new [] { Null,       NoNull1,    Null,       NoNull1    }.Coalesce(zeroMatters: false));
        NoNullRet(1,     new [] { Nully1,     Default,    NoNull1,    Null       }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(1,     new [] { Null,       NoNull1,    Default,    NoNull1    }.Coalesce(zeroMatters       ));
        NoNullRet(1,     new [] { NoNull1,    Null,       Nully1,     Null       }.Coalesce(zeroMatters: true ));
        NoNullRet(0,     new [] { Default,    Nully1,     Null,       NoNull1    }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionOnCollection_1And0()
    {
        // ZeroMatters No
        NoNullRet(1,     new [] { NoNull1,    Nully0,     NoNull1,    Nully0     }.Coalesce(                  ));
        NoNullRet(1,     new [] { NoNull0,    Nully1,     NoNull0,    NoNull1    }.Coalesce(zeroMatters: false));
        NoNullRet(1,     new [] { NoNull1,    NoNull0,    Nully1,     Nully0     }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(0,     new [] { NoNull0,    NoNull1,    Nully0,     NoNull1    }.Coalesce(zeroMatters       ));
        NoNullRet(1,     new [] { NoNull1,    NoNull0,    NoNull1,    Nully0     }.Coalesce(zeroMatters: true )); // Starts with 1
        NoNullRet(0,     new [] { NoNull0,    NoNull1,    NoNull0,    NoNull1    }.Coalesce(             true ));
    }

    [TestMethod]
    public void Coalesce_NArg_Vals_ExtensionOnCollection_Sparse1()
    {
        // ZeroMatters No
        NoNullRet(1,     new [] { Null,       NoNull0,    NoNull0,    Nully1     }.Coalesce(                  ));
        NoNullRet(1,     new [] { Null,       NoNull0,    NoNull1,    Nully0     }.Coalesce(zeroMatters: false));
        NoNullRet(1,     new [] { Null,       NoNull1,    NoNull0,    Null       }.Coalesce(             false));
        // ZeroMatters Yes
        NoNullRet(0,     new [] { Null,       Nully0,     NoNull0,    Nully1     }.Coalesce(zeroMatters       ));
        NoNullRet(0,     new [] { Null,       Nully0,     NoNull1,    Nully0     }.Coalesce(zeroMatters: true ));
        NoNullRet(1,     new [] { Null,       Nully1,     NoNull0,    Null       }.Coalesce(             true )); // 1st non-null is 1
    }

    // Null Collections

    [TestMethod]
    public void Coalesce_NArg_Vals_NullCollections()
    {
        ICollection<int>? nullColl = null;
        // Static Flags in Front
        NoNullRet(NoNull0,        Coalesce(                    nullColl));
        NoNullRet(NoNull0,        Coalesce(zeroMatters: false, nullColl));
        NoNullRet(NoNull0,        Coalesce(             false, nullColl));
        NoNullRet(NoNull0,        Coalesce(zeroMatters,        nullColl));
        NoNullRet(NoNull0,        Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(NoNull0,        Coalesce(             true,  nullColl));
        // Static Flags in Back
        NoNullRet(NoNull0,        Coalesce(nullColl                    ));
        NoNullRet(NoNull0,        Coalesce(nullColl, zeroMatters: false));
        NoNullRet(NoNull0,        Coalesce(nullColl,              false));
        NoNullRet(NoNull0,        Coalesce(nullColl, zeroMatters       ));
        NoNullRet(NoNull0,        Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(NoNull0,        Coalesce(nullColl,              true ));
        // Extension Flags in Front
        NoNullRet(0,     Null    .Coalesce(                    nullColl));
        NoNullRet(0,     Null    .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(0,     Null    .Coalesce(             false, nullColl));
        NoNullRet(0,     Null    .Coalesce(zeroMatters,        nullColl));
        NoNullRet(0,     Null    .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(0,     Null    .Coalesce(             true,  nullColl));
        NoNullRet(0,     NoNull0 .Coalesce(                    nullColl));
        NoNullRet(0,     NoNull0 .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(0,     NoNull0 .Coalesce(             false, nullColl));
        NoNullRet(0,     NoNull0 .Coalesce(zeroMatters,        nullColl));
        NoNullRet(0,     NoNull0 .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(0,     NoNull0 .Coalesce(             true,  nullColl));
        NoNullRet(0,     Nully0  .Coalesce(                    nullColl));
        NoNullRet(0,     Nully0  .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(0,     Nully0  .Coalesce(             false, nullColl));
        NoNullRet(0,     Nully0  .Coalesce(zeroMatters,        nullColl));
        NoNullRet(0,     Nully0  .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(0,     Nully0  .Coalesce(             true,  nullColl));
        NoNullRet(1,     NoNull1 .Coalesce(                    nullColl));
        NoNullRet(1,     NoNull1 .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(1,     NoNull1 .Coalesce(             false, nullColl));
        NoNullRet(1,     NoNull1 .Coalesce(zeroMatters,        nullColl));
        NoNullRet(1,     NoNull1 .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(1,     NoNull1 .Coalesce(             true,  nullColl));
        NoNullRet(1,     Nully1  .Coalesce(                    nullColl));
        NoNullRet(1,     Nully1  .Coalesce(zeroMatters: false, nullColl));
        NoNullRet(1,     Nully1  .Coalesce(             false, nullColl));
        NoNullRet(1,     Nully1  .Coalesce(zeroMatters,        nullColl));
        NoNullRet(1,     Nully1  .Coalesce(zeroMatters: true,  nullColl));
        NoNullRet(1,     Nully1  .Coalesce(             true,  nullColl));
        // Extension Flags in Back
        NoNullRet(0,     Null    .Coalesce(nullColl                    ));
        NoNullRet(0,     Null    .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(0,     Null    .Coalesce(nullColl,              false));
        NoNullRet(0,     Null    .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(0,     Null    .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(0,     Null    .Coalesce(nullColl,              true ));
        NoNullRet(0,     NoNull0 .Coalesce(nullColl                    ));
        NoNullRet(0,     NoNull0 .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(0,     NoNull0 .Coalesce(nullColl,              false));
        NoNullRet(0,     NoNull0 .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(0,     NoNull0 .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(0,     NoNull0 .Coalesce(nullColl,              true ));
        NoNullRet(0,     Nully0  .Coalesce(nullColl                    ));
        NoNullRet(0,     Nully0  .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(0,     Nully0  .Coalesce(nullColl,              false));
        NoNullRet(0,     Nully0  .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(0,     Nully0  .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(0,     Nully0  .Coalesce(nullColl,              true ));
        NoNullRet(1,     NoNull1 .Coalesce(nullColl                    ));
        NoNullRet(1,     NoNull1 .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(1,     NoNull1 .Coalesce(nullColl,              false));
        NoNullRet(1,     NoNull1 .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(1,     NoNull1 .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(1,     NoNull1 .Coalesce(nullColl,              true ));
        NoNullRet(1,     Nully1  .Coalesce(nullColl                    ));
        NoNullRet(1,     Nully1  .Coalesce(nullColl, zeroMatters: false));
        NoNullRet(1,     Nully1  .Coalesce(nullColl,              false));
        NoNullRet(1,     Nully1  .Coalesce(nullColl, zeroMatters       ));
        NoNullRet(1,     Nully1  .Coalesce(nullColl, zeroMatters: true ));
        NoNullRet(1,     Nully1  .Coalesce(nullColl,              true ));
        // Extensions on Collection
        NoNullRet(0,     nullColl.Coalesce(                            ));
        NoNullRet(0,     nullColl.Coalesce(          zeroMatters: false));
        NoNullRet(0,     nullColl.Coalesce(                       false));
        NoNullRet(0,     nullColl.Coalesce(          zeroMatters       ));
    }
}