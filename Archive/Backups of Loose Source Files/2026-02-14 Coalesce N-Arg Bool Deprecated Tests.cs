
    /*
    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInFront_Old()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce(                    [ Null,       NullyFalse, NullyFalse, NullyTrue  ] ));
        NoNullRet(true,  Coalesce(zeroMatters: false, [ Null,       NullyFalse, NullyFalse, NullyTrue  ] ));
        NoNullRet(true,  Coalesce(             false, [ Null,       NullyFalse, NullyFalse, NullyTrue  ] ));
        // ZeroMatters Yes                                                                             
        NoNullRet(false, Coalesce(zeroMatters,        [ Null,       NullyFalse, NullyFalse, NullyTrue  ] ));
        NoNullRet(false, Coalesce(zeroMatters: true,  [ Null,       NullyFalse, NullyFalse, NullyTrue  ] ));
        NoNullRet(false, Coalesce(             true,  [ Null,       NullyFalse, NullyFalse, NullyTrue  ] ));
    }
    */

    /*
    [TestMethod]
    public void Coalesce_NArg_Bool_StaticCollExpressFlagsInBack_Old()
    {
        // ZeroMatters No
        NoNullRet(true,  Coalesce( [ Null,       NullyFalse, NullyFalse, NullyTrue  ]                    ));
        NoNullRet(true,  Coalesce( [ Null,       NullyFalse, NullyFalse, NullyTrue  ], zeroMatters: false));
        NoNullRet(true,  Coalesce( [ Null,       NullyFalse, NullyFalse, NullyTrue  ],              false));
        // ZeroMatters Yes                                                          
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, NullyFalse, NullyTrue  ], zeroMatters       ));
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, NullyFalse, NullyTrue  ], zeroMatters: true ));
        NoNullRet(false, Coalesce( [ Null,       NullyFalse, NullyFalse, NullyTrue  ],              true ));
    }
    */
    // Deprecated:

    /*
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
    */
