
    [TestMethod]
    public void Coalesce_Variadic_Bools_NoFlags()
    {
        // Static params
        NoNullRet(true,           Coalesce(  NullBool, NullyFalse, False,      NullyTrue            ));
        // Static collection                                                                        
        NoNullRet(true,           Coalesce([ NullBool, NullyFalse, NullyFalse, NullyTrue ]          ));
        // Extension params                                                                         
        NoNullRet(false, NullBool.Coalesce(  NullBool, NullBool,   NullBool                         ));
        // Extension on collection
        NoNullRet(true,            new [] {  NullBool, NullyFalse, False,      NullyTrue }.Coalesce());
    }
