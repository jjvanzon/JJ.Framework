namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Variadic_Tests : TestBase
{
    static string?[]? StringNullArray = (string?[]?)null;

    [TestMethod]
    public void Coalesce_Variadic_StringBuilders()
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

        // Static
        NoNullRet(NullyFilledSB, Coalesce(                     [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullyFilledSB, Coalesce(                     [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]));
        NoNullRet(NullyFilledSB, Coalesce(spaceMatters: false, [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullyFilledSB, Coalesce(spaceMatters: false, [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters,        [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters,        [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters: true,  [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullySpaceSB,  Coalesce(spaceMatters: true,  [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));

        // Extension Variadic
        NoNullRet(NullyFilledSB, NullSB       .Coalesce(                        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB  ));
        NoNullRet(NullyFilledSB, NullyFilledSB.Coalesce(                        NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB   ));
        NoNullRet(NullyFilledSB, NullySpaceSB .Coalesce(spaceMatters: false,    NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB   ));
        NoNullRet(NullyFilledSB, NullyEmptySB .Coalesce(spaceMatters: false,    NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB     ));
        NoNullRet(NullySpaceSB,  NullyNewSB   .Coalesce(spaceMatters,           NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB         ));
        NoNullRet(NullySpaceSB,  NullSB       .Coalesce(spaceMatters,           NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB  ));
        NoNullRet(NullySpaceSB,  NullySpaceSB .Coalesce(spaceMatters: true,     NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB   ));
        NoNullRet(NullySpaceSB,  NullyEmptySB .Coalesce(spaceMatters: true,     NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB     ));
                                                                 
        // Extensions
        NoNullRet(NullyFilledSB, NullSB       .Coalesce(                      [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullyFilledSB, NullyFilledSB.Coalesce(                      [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]));
        NoNullRet(NullyFilledSB, NullySpaceSB .Coalesce(spaceMatters: false,  [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullyFilledSB, NullyEmptySB .Coalesce(spaceMatters: false,  [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));
        NoNullRet(NullySpaceSB,  NullyNewSB   .Coalesce(spaceMatters,         [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ]));
        NoNullRet(NullySpaceSB,  NullSB       .Coalesce(spaceMatters,         [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]));
        NoNullRet(NullySpaceSB,  NullySpaceSB .Coalesce(spaceMatters: true,   [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ]));
        NoNullRet(NullySpaceSB,  NullyEmptySB .Coalesce(spaceMatters: true,   [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ]));
       
        // Flag in the Back
        NoNullRet(NullyFilledSB, Coalesce([ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]                     ));
        NoNullRet(NullyFilledSB, Coalesce([ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]                     ));
        NoNullRet(NullyFilledSB, Coalesce([ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: false));
        NoNullRet(NullyFilledSB, Coalesce([ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: false));
        NoNullRet(NullySpaceSB,  Coalesce([ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  Coalesce([ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  Coalesce([ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: true ));
        NoNullRet(NullySpaceSB,  Coalesce([ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: true ));

        NoNullRet(NullyFilledSB, new []   { NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB }.Coalesce(                   ));
        NoNullRet(NullyFilledSB, new []   { NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  }.Coalesce(                   ));
        NoNullRet(NullyFilledSB, new []   { NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  }.Coalesce(spaceMatters: false));
        NoNullRet(NullyFilledSB, new []   { NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    }.Coalesce(spaceMatters: false));
        NoNullRet(NullySpaceSB,  new []   { NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        }.Coalesce(spaceMatters       ));
        NoNullRet(NullySpaceSB,  new []   { NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB }.Coalesce(spaceMatters       ));
        NoNullRet(NullySpaceSB,  new []   { NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  }.Coalesce(spaceMatters: true ));
        NoNullRet(NullySpaceSB,  new []   { NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    }.Coalesce(spaceMatters: true ));
                                                                       
        NoNullRet(NullyFilledSB, NullSB       .Coalesce( [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ]                     ));
        NoNullRet(NullyFilledSB, NullyFilledSB.Coalesce( [ NullSB,        NullyNewSB,    NullyEmptySB,  NullySpaceSB  ]                     ));
        NoNullRet(NullyFilledSB, NullySpaceSB .Coalesce( [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: false));
        NoNullRet(NullyFilledSB, NullyEmptySB .Coalesce( [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: false));
        NoNullRet(NullySpaceSB,  NullyNewSB   .Coalesce( [ NullyEmptySB,  NullySpaceSB,  NullyFilledSB, NullSB        ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  NullSB       .Coalesce( [ NullyNewSB,    NullyEmptySB,  NullySpaceSB,  NullyFilledSB ], spaceMatters       ));
        NoNullRet(NullySpaceSB,  NullySpaceSB .Coalesce( [ NullyFilledSB, NullSB,        NullyNewSB,    NullyEmptySB  ], spaceMatters: true ));
        NoNullRet(NullySpaceSB,  NullyEmptySB .Coalesce( [ NullySpaceSB,  NullyFilledSB, NullSB,        NullyNewSB    ], spaceMatters: true ));

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

    [TestMethod]
    public void Coalesce_Variadic_Strings()
    {
        NoNullRet("Finally",          Coalesce(  "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Finally", " "     .Coalesce(  "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Finally",          Coalesce([ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Finally", " "     .Coalesce([ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",               Coalesce(  "Hi", " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",      " "     .Coalesce(  "",   "Hi", "\n     ", "Finally"  ));
        NoNullRet("Hi",               Coalesce([ "",   " ",  "Hi",      "Finally" ]));
        NoNullRet("Hi",      " "     .Coalesce([ "",   " ",  "\n     ", "Hi"      ]));
        NoNullRet(" ",       NullText.Coalesce(NullyEmpty, NullText, NullySpace    ));
        NoNullRet("",        NullText.Coalesce(NullyEmpty, NullText, Empty         ));
        NoNullRet("Finally", new [] { "",   " ",   "\n     ", "Finally" }.Coalesce());
        NoNullRet("Hi",      new [] { "",   "Hi",  "\n     ", "Finally" }.Coalesce());
        NoNullRet("",        new [] { NullText,    NullText,   NullText }.Coalesce());
        NoNullRet("",        new string[0] .Coalesce());
        NoNullRet("",        Coalesce(StringNullArray));
    }

    [TestMethod]
    public void Coalesce_Variadic_Strings_SpaceMatters_False()
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
    public void Coalesce_Variadic_Strings_SpaceMatters_True()
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
        NoNullRet(1,         Coalesce(                      NullNum, Nully0, NoNull0, Nully1                      ));
        NoNullRet(1,         Coalesce(zeroMatters: false,   NullNum, Nully0, NoNull0, Nully1                      ));
        NoNullRet(1,         Coalesce(             false,   NullNum, Nully0, NoNull0, Nully1                      ));
        NoNullRet(0,         Coalesce(zeroMatters,          NullNum, Nully0, NoNull0, Nully1                      ));
        NoNullRet(0,         Coalesce(zeroMatters: true,    NullNum, Nully0, NoNull0, Nully1                      ));
        NoNullRet(0,         Coalesce(             true,    NullNum, Nully0, NoNull0, Nully1                      ));
        // Collection
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(1,         Coalesce(zeroMatters: false, [ NullNum, Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(1,         Coalesce(             false, [ NullNum, Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(0,         Coalesce(zeroMatters,        [ NullNum, Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(0,         Coalesce(zeroMatters: true,  [ NullNum, Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(0,         Coalesce(             true,  [ NullNum, Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0, Nully0,  Nully1 ], zeroMatters: false));
        NoNullRet(1,         Coalesce(                    [ NullNum, Nully0, Nully0,  Nully1 ],              false));
        NoNullRet(0,         Coalesce(                    [ NullNum, Nully0, Nully0,  Nully1 ], zeroMatters       ));
        NoNullRet(0,         Coalesce(                    [ NullNum, Nully0, Nully0,  Nully1 ], zeroMatters: true ));
        NoNullRet(0,         Coalesce(                    [ NullNum, Nully0, Nully0,  Nully1 ],              true ));
        // Extension
        // Params
        NoNullRet(1, NullNum.Coalesce(                               Nully0, Nully0,  Nully1                      ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false,            Nully0, Nully0,  Nully1                      ));
        NoNullRet(1, NullNum.Coalesce(             false,            Nully0, Nully0,  Nully1                      ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters,                   Nully0, Nully0,  Nully1                      ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true,             Nully0, Nully0,  Nully1                      ));
        NoNullRet(0, NullNum.Coalesce(             true,             Nully0, Nully0,  Nully1                      ));
        NoNullRet(1, NoNull0.Coalesce(                               Nully0, Nully1,  Nully2                      ));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false,            Nully0, Nully1,  Nully2                      ));
        NoNullRet(1, NoNull0.Coalesce(             false,            Nully0, Nully1,  Nully2                      ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters,                   Nully0, Nully1,  Nully2                      ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true,             Nully0, Nully1,  Nully2                      ));
        NoNullRet(0, NoNull0.Coalesce(             true,             Nully0, Nully1,  Nully2                      ));
        // Collection
        NoNullRet(1, NullNum.Coalesce(                    [          Nully0, Nully0,  Nully1 ]                    ));
        NoNullRet(1, NullNum.Coalesce(                    [          Nully0, Nully0,  Nully1 ], zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(                    [          Nully0, Nully0,  Nully1 ],              false));
        NoNullRet(0, NullNum.Coalesce(                    [          Nully0, Nully0,  Nully1 ], zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(                    [          Nully0, Nully0,  Nully1 ], zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(                    [          Nully0, Nully0,  Nully1 ],              true ));
        NoNullRet(1, NoNull0.Coalesce(                    [          Nully0, Nully1,  Nully2 ]                    ));
        NoNullRet(1, NoNull0.Coalesce(                    [          Nully0, Nully1,  Nully2 ], zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(                    [          Nully0, Nully1,  Nully2 ],              false));
        NoNullRet(0, NoNull0.Coalesce(                    [          Nully0, Nully1,  Nully2 ], zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(                    [          Nully0, Nully1,  Nully2 ], zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(                    [          Nully0, Nully1,  Nully2 ],              true ));
        // Extension on collection
        NoNullRet(1,                               new [] { NullNum, Nully0, NoNull0, Nully1 }.Coalesce(                  ));
        NoNullRet(1,                               new [] { NullNum, Nully0, NoNull0, Nully1 }.Coalesce(zeroMatters: false));
        NoNullRet(1,                               new [] { NullNum, Nully0, NoNull0, Nully1 }.Coalesce(             false));
        NoNullRet(0,                               new [] { NullNum, Nully0, NoNull0, Nully1 }.Coalesce(zeroMatters       ));
        NoNullRet(0,                               new [] { NullNum, Nully0, NoNull0, Nully1 }.Coalesce(zeroMatters: true ));
        NoNullRet(0,                               new [] { NullNum, Nully0, NoNull0, Nully1 }.Coalesce(             true ));
    }
        
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