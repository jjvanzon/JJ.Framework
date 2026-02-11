namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Variadic_Bool_Tests : TestBase
{
    // Bools

    // TODO: Not enough nully/non-nully variants. Needed to confuse the flag and nullable vals exchanging.

    [TestMethod]
    public void Coalesce_Variadic_Bools()
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

    [TestMethod]
    public void Coalesce_Variadic_Bools_ZeroMatters()
    {
        // Static
        // Params
        NoNullRet(true,          Coalesce(                      NullBool, NullyFalse, False,      NullyTrue                              ));
        NoNullRet(true,          Coalesce(zeroMatters: false,   NullBool, NullyFalse, False,      NullyTrue                              ));
        NoNullRet(true,          Coalesce(             false,   NullBool, NullyFalse, False,      NullyTrue                              ));
        NoNullRet(false,         Coalesce(zeroMatters,          NullBool, NullyFalse, False,      NullyTrue                              ));
        NoNullRet(false,         Coalesce(zeroMatters: true,    NullBool, NullyFalse, False,      NullyTrue                              ));
        NoNullRet(false,         Coalesce(             true,    NullBool, NullyFalse, False,      NullyTrue                              )); // TODO: Should have failed
        // Collection                                                                                                  
        NoNullRet(true,          Coalesce(                    [ NullBool, NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(true,          Coalesce(zeroMatters: false, [ NullBool, NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(true,          Coalesce(             false, [ NullBool, NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(false,         Coalesce(zeroMatters,        [ NullBool, NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(false,         Coalesce(zeroMatters: true,  [ NullBool, NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(false,         Coalesce(             true,  [ NullBool, NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(true,          Coalesce(                    [ NullBool, NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(true,          Coalesce(                    [ NullBool, NullyFalse, NullyFalse, NullyTrue ],         zeroMatters: false));
        NoNullRet(true,          Coalesce(                    [ NullBool, NullyFalse, NullyFalse, NullyTrue ],                      false));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullyFalse, NullyFalse, NullyTrue ],         zeroMatters       ));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullyFalse, NullyFalse, NullyTrue ],         zeroMatters: true ));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullyFalse, NullyFalse, NullyTrue ],                      true ));
        // Hits Last Resort                                                                                            
        NoNullRet(false,         Coalesce(                    [ NullBool, NullBool,   NullBool,   NullBool  ]                            ));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullBool,   NullBool,   NullBool  ],         zeroMatters: false));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullBool,   NullBool,   NullBool  ],                      false));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullBool,   NullBool,   NullBool  ],         zeroMatters       ));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullBool,   NullBool,   NullBool  ],         zeroMatters: true ));
        NoNullRet(false,         Coalesce(                    [ NullBool, NullBool,   NullBool,   NullBool  ],                      true ));
        // Extension
        // Params
        NoNullRet(true,  NullBool.Coalesce(                               NullyFalse, NullyFalse, NullyTrue                              ));
        NoNullRet(true,  NullBool.Coalesce(zeroMatters: false,            NullyFalse, NullyFalse, NullyTrue                              ));
        NoNullRet(true,  NullBool.Coalesce(             false,            NullyFalse, NullyFalse, NullyTrue                              ));
        NoNullRet(false, NullBool.Coalesce(zeroMatters,                   NullyFalse, NullyFalse, NullyTrue                              ));
        NoNullRet(false, NullBool.Coalesce(zeroMatters: true,             NullyFalse, NullyFalse, NullyTrue                              ));
        NoNullRet(false, NullBool.Coalesce(             true,             NullyFalse, NullyFalse, NullyTrue                              ));
        NoNullRet(true,  False   .Coalesce(                               NullyFalse, NullyTrue,  NullyTrue                              ));
        NoNullRet(true,  False   .Coalesce(zeroMatters: false,            NullyFalse, NullyTrue,  NullyTrue                              ));
        NoNullRet(true,  False   .Coalesce(             false,            NullyFalse, NullyTrue,  NullyTrue                              ));
        NoNullRet(false, False   .Coalesce(zeroMatters,                   NullyFalse, NullyTrue,  NullyTrue                              ));
        NoNullRet(false, False   .Coalesce(zeroMatters: true,             NullyFalse, NullyTrue,  NullyTrue                              ));
        NoNullRet(false, False   .Coalesce(             true,             NullyFalse, NullyTrue,  NullyTrue                              ));
        // Collection                                                                           
        NoNullRet(true,  NullBool.Coalesce(                   [           NullyFalse, NullyFalse, NullyTrue ]                            ));
        NoNullRet(true,  NullBool.Coalesce(                   [           NullyFalse, NullyFalse, NullyTrue ],         zeroMatters: false));
        NoNullRet(true,  NullBool.Coalesce(                   [           NullyFalse, NullyFalse, NullyTrue ],                      false));
        NoNullRet(false, NullBool.Coalesce(                   [           NullyFalse, NullyFalse, NullyTrue ],         zeroMatters       ));
        NoNullRet(false, NullBool.Coalesce(                   [           NullyFalse, NullyFalse, NullyTrue ],         zeroMatters: true ));
        NoNullRet(false, NullBool.Coalesce(                   [           NullyFalse, NullyFalse, NullyTrue ],                      true ));
        NoNullRet(true,  False   .Coalesce(                   [           NullyFalse, NullyTrue,  NullyTrue ]                            ));
        NoNullRet(true,  False   .Coalesce(                   [           NullyFalse, NullyTrue,  NullyTrue ],         zeroMatters: false));
        NoNullRet(true,  False   .Coalesce(                   [           NullyFalse, NullyTrue,  NullyTrue ],                      false));
        NoNullRet(false, False   .Coalesce(                   [           NullyFalse, NullyTrue,  NullyTrue ],         zeroMatters       ));
        NoNullRet(false, False   .Coalesce(                   [           NullyFalse, NullyTrue,  NullyTrue ],         zeroMatters: true ));
        NoNullRet(false, False   .Coalesce(                   [           NullyFalse, NullyTrue,  NullyTrue ],                      true ));
        // Hits Last Resort                                                                                           
        NoNullRet(false, NullBool.Coalesce(                   [           NullBool,   NullBool,   NullBool  ]                            ));
        NoNullRet(false, NullBool.Coalesce(                   [           NullBool,   NullBool,   NullBool  ],         zeroMatters: false));
        NoNullRet(false, NullBool.Coalesce(                   [           NullBool,   NullBool,   NullBool  ],                      false));
        NoNullRet(false, NullBool.Coalesce(                   [           NullBool,   NullBool,   NullBool  ],         zeroMatters       ));
        NoNullRet(false, NullBool.Coalesce(                   [           NullBool,   NullBool,   NullBool  ],         zeroMatters: true ));
        NoNullRet(false, NullBool.Coalesce(                   [           NullBool,   NullBool,   NullBool  ],                      true ));
        // Extension on collection                                            
        NoNullRet(true,                                new [] { NullBool, NullyFalse, False,      NullyTrue }.Coalesce(                  ));
        NoNullRet(true,                                new [] { NullBool, NullyFalse, False,      NullyTrue }.Coalesce(zeroMatters: false));
        NoNullRet(true,                                new [] { NullBool, NullyFalse, False,      NullyTrue }.Coalesce(             false));
        NoNullRet(false,                               new [] { NullBool, NullyFalse, False,      NullyTrue }.Coalesce(zeroMatters       ));
        NoNullRet(false,                               new [] { NullBool, NullyFalse, False,      NullyTrue }.Coalesce(zeroMatters: true ));
        NoNullRet(false,                               new [] { NullBool, NullyFalse, False,      NullyTrue }.Coalesce(             true ));
    }
}