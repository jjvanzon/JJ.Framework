namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Variadic_Values_Tests : TestBase
{
    // Values

    [TestMethod]
    public void Coalesce_Variadic_Values()
    {
        // Static params
        NoNullRet(1,         Coalesce(  NullNum, Nully0, NoNull0, Nully1 ));
        // Static collection
        NoNullRet(1,         Coalesce([ NullNum, Nully0, Nully0, Nully1 ]));
        // Extension params
        NoNullRet(0, NullNum.Coalesce(  NullNum, NullNum, NullNum        ));
        // Extension on collection
        NoNullRet(1,          new [] {  NullNum, Nully0, NoNull0, Nully1 }.Coalesce());
    }

    [TestMethod]
    public void Coalesce_Variadic_Values_ZeroMatters()
    {
        // Static
        // Params
        NoNullRet(1,         Coalesce(                      NullNum, Nully0,  NoNull0, Nully1                       ));
        NoNullRet(1,         Coalesce(zeroMatters: false,   NullNum, Nully0,  NoNull0, Nully1                       ));
        NoNullRet(1,         Coalesce(             false,   NullNum, Nully0,  NoNull0, Nully1                       ));
        NoNullRet(0,         Coalesce(zeroMatters,          NullNum, Nully0,  NoNull0, Nully1                       ));
        NoNullRet(0,         Coalesce(zeroMatters: true,    NullNum, Nully0,  NoNull0, Nully1                       ));
        NoNullRet(0,         Coalesce(             true,    NullNum, Nully0,  NoNull0, Nully1                       ));
        // Collection                                                                          
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0,  Nully0,  Nully1  ]                    ));
        NoNullRet(1,         Coalesce(zeroMatters: false, [ NullNum, Nully0,  Nully0,  Nully1  ]                    ));
        NoNullRet(1,         Coalesce(             false, [ NullNum, Nully0,  Nully0,  Nully1  ]                    ));
        NoNullRet(0,         Coalesce(zeroMatters,        [ NullNum, Nully0,  Nully0,  Nully1  ]                    ));
        NoNullRet(0,         Coalesce(zeroMatters: true,  [ NullNum, Nully0,  Nully0,  Nully1  ]                    ));
        NoNullRet(0,         Coalesce(             true,  [ NullNum, Nully0,  Nully0,  Nully1  ]                    ));
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0,  Nully0,  Nully1  ]                    ));
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0,  Nully0,  Nully1  ], zeroMatters: false));
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0,  Nully0,  Nully1  ],              false));
        NoNullRet(0,         Coalesce(                    [ NullNum, Nully0,  Nully0,  Nully1  ], zeroMatters       ));
        NoNullRet(0,         Coalesce(                    [ NullNum, Nully0,  Nully0,  Nully1  ], zeroMatters: true ));
        NoNullRet(0,         Coalesce(                    [ NullNum, Nully0,  Nully0,  Nully1  ],              true ));
        // Hits Last Resort
        NoNullRet(0,         Coalesce(                    [ NullNum, NullNum, NullNum, NullNum ]                    ));
        NoNullRet(0,         Coalesce(                    [ NullNum, NullNum, NullNum, NullNum ], zeroMatters: false));
        NoNullRet(0,         Coalesce(                    [ NullNum, NullNum, NullNum, NullNum ],              false));
        NoNullRet(0,         Coalesce(                    [ NullNum, NullNum, NullNum, NullNum ], zeroMatters       ));
        NoNullRet(0,         Coalesce(                    [ NullNum, NullNum, NullNum, NullNum ], zeroMatters: true ));
        NoNullRet(0,         Coalesce(                    [ NullNum, NullNum, NullNum, NullNum ],              true ));
        // Extension
        // Params
        NoNullRet(1, NullNum.Coalesce(                               Nully0,  Nully0,  Nully1                       ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false,            Nully0,  Nully0,  Nully1                       ));
        NoNullRet(1, NullNum.Coalesce(             false,            Nully0,  Nully0,  Nully1                       ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters,                   Nully0,  Nully0,  Nully1                       ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true,             Nully0,  Nully0,  Nully1                       ));
        NoNullRet(0, NullNum.Coalesce(             true,             Nully0,  Nully0,  Nully1                       ));
        NoNullRet(1, NoNull0.Coalesce(                               Nully0,  Nully1,  Nully2                       ));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false,            Nully0,  Nully1,  Nully2                       ));
        NoNullRet(1, NoNull0.Coalesce(             false,            Nully0,  Nully1,  Nully2                       ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters,                   Nully0,  Nully1,  Nully2                       ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true,             Nully0,  Nully1,  Nully2                       ));
        NoNullRet(0, NoNull0.Coalesce(             true,             Nully0,  Nully1,  Nully2                       ));
        // Collection                                                                            
        NoNullRet(1, NullNum.Coalesce(                    [          Nully0,  Nully0,  Nully1 ]                     ));
        NoNullRet(1, NullNum.Coalesce(                    [          Nully0,  Nully0,  Nully1 ],  zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(                    [          Nully0,  Nully0,  Nully1 ],               false));
        NoNullRet(0, NullNum.Coalesce(                    [          Nully0,  Nully0,  Nully1 ],  zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(                    [          Nully0,  Nully0,  Nully1 ],  zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(                    [          Nully0,  Nully0,  Nully1 ],               true ));
        NoNullRet(1, NoNull0.Coalesce(                    [          Nully0,  Nully1,  Nully2 ]                     ));
        NoNullRet(1, NoNull0.Coalesce(                    [          Nully0,  Nully1,  Nully2 ],  zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(                    [          Nully0,  Nully1,  Nully2 ],               false));
        NoNullRet(0, NoNull0.Coalesce(                    [          Nully0,  Nully1,  Nully2 ],  zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(                    [          Nully0,  Nully1,  Nully2 ],  zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(                    [          Nully0,  Nully1,  Nully2 ],               true ));
        // Hits Last Resort
        NoNullRet(0, NullNum.Coalesce(                    [          NullNum, NullNum, NullNum]                     ));
        NoNullRet(0, NullNum.Coalesce(                    [          NullNum, NullNum, NullNum],  zeroMatters: false));
        NoNullRet(0, NullNum.Coalesce(                    [          NullNum, NullNum, NullNum],               false));
        NoNullRet(0, NullNum.Coalesce(                    [          NullNum, NullNum, NullNum],  zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(                    [          NullNum, NullNum, NullNum],  zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(                    [          NullNum, NullNum, NullNum],               true ));
        // Extension on collection                                            
        NoNullRet(1,                               new [] { NullNum, Nully0,  NoNull0, Nully1 }.Coalesce(                  ));
        NoNullRet(1,                               new [] { NullNum, Nully0,  NoNull0, Nully1 }.Coalesce(zeroMatters: false));
        NoNullRet(1,                               new [] { NullNum, Nully0,  NoNull0, Nully1 }.Coalesce(             false));
        NoNullRet(0,                               new [] { NullNum, Nully0,  NoNull0, Nully1 }.Coalesce(zeroMatters       ));
        NoNullRet(0,                               new [] { NullNum, Nully0,  NoNull0, Nully1 }.Coalesce(zeroMatters: true ));
        NoNullRet(0,                               new [] { NullNum, Nully0,  NoNull0, Nully1 }.Coalesce(             true ));
    }
}