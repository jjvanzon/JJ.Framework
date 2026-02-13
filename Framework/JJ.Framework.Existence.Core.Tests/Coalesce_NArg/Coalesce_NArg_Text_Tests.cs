namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArg_Text_Tests : TestBase
{
    // Text
    
    [TestMethod] 
    public void Coalesce_Text_Variadic() 
    {
        // Static
        NoNullRet("Finally",          Coalesce(  "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",               Coalesce(  "Hi", " ",  "\n     ", "Finally"  ));
        // Extensions
        NoNullRet("Finally", " "     .Coalesce(  "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",      " "     .Coalesce(  "",   "Hi", "\n     ", "Finally"  ));
        // Extensions Nully
        NoNullRet(" ",       NullText.Coalesce(NullyEmpty, NullText, NullySpace    ));
        NoNullRet("",        NullText.Coalesce(NullyEmpty, NullText, Empty         ));
    }
    
    [TestMethod] 
    public void Coalesce_Text_CollExpress() 
    {
        // Static
        NoNullRet("Finally",          Coalesce([ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",               Coalesce([ "",   " ",  "Hi",      "Finally" ]));
        // Extension
        NoNullRet("Finally", " "     .Coalesce([ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",      " "     .Coalesce([ "",   " ",  "\n     ", "Hi"      ]));
    }

    [TestMethod]
    public void Coalesce_Text_ExtensionsOnColl()
    {
        // Main Case
        NoNullRet("Finally", new [] { "",   " ",   "\n     ", "Finally" }.Coalesce());
        NoNullRet("Hi",      new [] { "",   "Hi",  "\n     ", "Finally" }.Coalesce());
        // Last Resort New
        NoNullRet("",        new [] { NullText,    NullText,   NullText }.Coalesce());
        // Empty Coll
        NoNullRet("",        new string[0] .Coalesce());
        // Null Coll
        NoNullRet("",        Coalesce(StringNullArray));
    }
    
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
}