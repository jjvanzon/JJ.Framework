namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Variadic_Tests : TestBase
{
    const string?[]? StringNullArray = null;

    // StringBuilder

    [TestMethod]
    public void Coalesce_StringBuilders_StaticVariadic()
    {
        // Static Variadic
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
    public void Coalesce_StringBuilders_StaticCollExpress()
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
    public void Coalesce_StringBuilders_ExtensionsVariadic()
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
    public void Coalesce_StringBuilders_ExtensionsCollExpress()
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
    public void Coalesce_StringBuilders_StaticCollExpressFlagsInBack()
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
    public void Coalesce_StringBuilders_ExtensionOnCollectionFlagsInBack()
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
    public void Coalesce_StringBuilders_ExtensionCollExpressFlagsInBack()
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
    public void Coalesce_StringBuilders_Variadic_ReturnsNew()
    {
        // Returns new()
        NoNullRet(Coalesce(                     NullyEmptySB, NullyNewSB,   NewSB,        NullSB));
        NoNullRet(Coalesce(                     NewSB,        NullyEmptySB, NullyNewSB,   NullSB));
        NoNullRet(Coalesce(spaceMatters: false, NullyEmptySB, NullyNewSB,   NewSB,        NullSB));
        NoNullRet(Coalesce(spaceMatters: false, NewSB,        NullyEmptySB, NullyNewSB,   NullSB));
        NoNullRet(Coalesce(spaceMatters,        NullyNewSB,   NewSB,        NullyEmptySB, NullSB));
        NoNullRet(Coalesce(spaceMatters,        NullyEmptySB, NullyNewSB,   NewSB,        NullSB));
        NoNullRet(Coalesce(spaceMatters: true,  NewSB,        NullyEmptySB, NullyNewSB,   NullSB));
        NoNullRet(Coalesce(spaceMatters: true,  NullyNewSB,   NewSB,        NullyEmptySB, NullSB));
    }

    // Text
    
    [TestMethod] public void Coalesce_Text_StaticVariadic1              () => NoNullRet("Finally",          Coalesce(  "",   " ",  "\n     ", "Finally"  ));
    [TestMethod] public void Coalesce_Text_StaticVariadic2              () => NoNullRet("Hi",               Coalesce(  "Hi", " ",  "\n     ", "Finally"  ));
    [TestMethod] public void Coalesce_Text_ExtensionVariadic1           () => NoNullRet("Finally", " "     .Coalesce(  "",   " ",  "\n     ", "Finally"  ));
    [TestMethod] public void Coalesce_Text_ExtensionVariadic2           () => NoNullRet("Hi",      " "     .Coalesce(  "",   "Hi", "\n     ", "Finally"  ));
    [TestMethod] public void Coalesce_Text_ExtensionVariadicNully1      () => NoNullRet(" ",       NullText.Coalesce(NullyEmpty, NullText, NullySpace    ));
    [TestMethod] public void Coalesce_Text_ExtensionVariadicNully2      () => NoNullRet("",        NullText.Coalesce(NullyEmpty, NullText, Empty         ));
    
    [TestMethod] public void Coalesce_Text_StaticCollExpress1           () => NoNullRet("Finally",          Coalesce([ "",   " ",  "\n     ", "Finally" ]));
    [TestMethod] public void Coalesce_Text_StaticCollExpress2           () => NoNullRet("Hi",               Coalesce([ "",   " ",  "Hi",      "Finally" ]));
    [TestMethod] public void Coalesce_Text_ExtensionCollExpress1        () => NoNullRet("Finally", " "     .Coalesce([ "",   " ",  "\n     ", "Finally" ]));
    [TestMethod] public void Coalesce_Text_ExtensionCollExpress2        () => NoNullRet("Hi",      " "     .Coalesce([ "",   " ",  "\n     ", "Hi"      ]));

    [TestMethod] public void Coalesce_Text_ExtensionOnColl1             () => NoNullRet("Finally", new [] { "",   " ",   "\n     ", "Finally" }.Coalesce());
    [TestMethod] public void Coalesce_Text_ExtensionOnColl2             () => NoNullRet("Hi",      new [] { "",   "Hi",  "\n     ", "Finally" }.Coalesce());
    [TestMethod] public void Coalesce_Text_ExtensionOnColl_LastResortNew() => NoNullRet("",        new [] { NullText,    NullText,   NullText }.Coalesce());
    [TestMethod] public void Coalesce_Text_ExtensionOnColl_EmptyColl    () => NoNullRet("",        new string[0] .Coalesce());
    [TestMethod] public void Coalesce_Text_ExtensionOnColl_NullColl     () => NoNullRet("",        Coalesce(StringNullArray));
    
    [TestMethod]
    public void Coalesce_Variadic_Text_SpaceMatters_False()
    {
        NoNullRet("Finally",          Coalesce(spaceMatters: false,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Finally", " "     .Coalesce(spaceMatters: false,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Finally",          Coalesce(spaceMatters: false, [ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Finally", " "     .Coalesce(spaceMatters: false, [ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",               Coalesce(spaceMatters: false,   "Hi", " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",      " "     .Coalesce(spaceMatters: false,   "",   "Hi", "\n     ", "Finally"  ));
        NoNullRet("Hi",               Coalesce(spaceMatters: false, [ "",   " ",  "Hi",      "Finally" ]));
        NoNullRet("Hi",      " "     .Coalesce(spaceMatters: false, [ "",   " ",  "\n     ", "Hi"      ]));
        NoNullRet(" ",       NullText.Coalesce(spaceMatters: false, NullyEmpty,   NullText,  NullySpace ));
        NoNullRet("",        NullText.Coalesce(spaceMatters: false, NullyEmpty,   NullText,  Empty      ));
        NoNullRet("Finally",          Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: false));
        NoNullRet("Finally", " "     .Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: false));
        NoNullRet("Hi",               Coalesce([ "",   " ",  "Hi",      "Finally" ],         spaceMatters: false));
        NoNullRet("Hi",      " "     .Coalesce([ "",   " ",  "\n     ", "Hi"      ],         spaceMatters: false));
        NoNullRet("Finally",          new []   { "",   " ",   "\n     ", "Finally"}.Coalesce(spaceMatters: false));
        NoNullRet("Hi",               new []   { "",   "Hi",  "\n     ", "Finally"}.Coalesce(spaceMatters: false));
        NoNullRet("",                 new []   { NullText,    NullText,   NullText}.Coalesce(spaceMatters: false));
        NoNullRet("",                 new string[0].Coalesce(   spaceMatters: false));
        NoNullRet("",                 Coalesce(StringNullArray, spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_Variadic_Text_SpaceMatters_True()
    {
        NoNullRet(" ",           Coalesce(spaceMatters,         "",   " ",  "\n     ", "Finally"  ));
        NoNullRet(" ",           Coalesce(spaceMatters: true,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet(" ",  ""      .Coalesce(spaceMatters,         "",   " ",  "\n     ", "Finally"  ));
        NoNullRet(" ",  ""      .Coalesce(spaceMatters: true,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",          Coalesce(spaceMatters,         "Hi", " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",          Coalesce(spaceMatters: true,   "Hi", " ",  "\n     ", "Finally"  ));
        NoNullRet(" ",  " "     .Coalesce(spaceMatters,         "",   "Hi", "\n     ", "Finally"  ));
        NoNullRet(" ",  " "     .Coalesce(spaceMatters: true,   "",   "Hi", "\n     ", "Finally"  ));
        NoNullRet(" ",           Coalesce(spaceMatters,       [ "",   " ",  "Hi",      "Finally" ]));
        NoNullRet(" ",           Coalesce(spaceMatters: true, [ "",   " ",  "Hi",      "Finally" ]));
        NoNullRet(" ",  " "     .Coalesce(spaceMatters,       [ "",   " ",  "\n     ", "Hi"      ]));
        NoNullRet(" ",  " "     .Coalesce(spaceMatters: true, [ "",   " ",  "\n     ", "Hi"      ]));
        NoNullRet(" ",  NullText.Coalesce(spaceMatters,       NullyEmpty,   NullText,  NullySpace ));
        NoNullRet(" ",  NullText.Coalesce(spaceMatters: true, NullyEmpty,   NullText,  NullySpace ));
        NoNullRet("",   NullText.Coalesce(spaceMatters,       NullyEmpty,   NullText,  Empty      ));
        NoNullRet("",   NullText.Coalesce(spaceMatters: true, NullyEmpty,   NullText,  Empty      ));
        NoNullRet(" ",       Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters      ));
        NoNullRet(" ",       Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: true));
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters      ));
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: true));
        NoNullRet(" ",       Coalesce([ "",   " ",  "Hi",      "Finally" ],         spaceMatters      ));
        NoNullRet(" ",       Coalesce([ "",   " ",  "Hi",      "Finally" ],         spaceMatters: true));
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Hi"      ],         spaceMatters      ));
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Hi"      ],         spaceMatters: true));
        NoNullRet(" ",       new []  { "",   " ",   "\n     ", "Finally" }.Coalesce(spaceMatters      ));
        NoNullRet(" ",       new []  { "",   " ",   "\n     ", "Finally" }.Coalesce(spaceMatters: true));
        NoNullRet("Hi",      new []  { "",   "Hi",  "\n     ", "Finally" }.Coalesce(spaceMatters      ));
        NoNullRet("Hi",      new []  { "",   "Hi",  "\n     ", "Finally" }.Coalesce(spaceMatters: true));
        NoNullRet("",        new []  { NullText,    NullText,  NullText  }.Coalesce(spaceMatters      ));
        NoNullRet("",        new []  { NullText,    NullText,  NullText  }.Coalesce(spaceMatters: true));
        NoNullRet("",        new string[0].Coalesce(   spaceMatters      ));
        NoNullRet("",        new string[0].Coalesce(   spaceMatters: true));
        NoNullRet("",        Coalesce(StringNullArray, spaceMatters      ));
        NoNullRet("",        Coalesce(StringNullArray, spaceMatters: true));
    }

    // TODO: Bools




















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
 
    // Objects

    [TestMethod]
    public void Coalesce_Variadic_Objects()
    {
        // Static params
        NoNullRet(NoNullObj,      Coalesce(NullObj, NoNullObj, NullyFilledObj));
        NoNullRet(NullyFilledObj, Coalesce(NullObj, NullyFilledObj, NoNullObj));
        // Static collection
        NoNullRet(NoNullObj,      Coalesce([NullObj, NoNullObj, NullyFilledObj]));
        // Extension on collection
        NoNullRet(NullyFilledObj, new[] { NullObj, NullyFilledObj, NoNullObj }.Coalesce());
        // Extension first + params
        NoNullRet(NullyFilledObj, NullyFilledObj.Coalesce(NullObj, NullObj, NullObj));
        // Extension first + coll
        NoNullRet(NullyFilledObj, NullyFilledObj.Coalesce(new[] { NullObj, NullObj, NullObj }));
    }
}