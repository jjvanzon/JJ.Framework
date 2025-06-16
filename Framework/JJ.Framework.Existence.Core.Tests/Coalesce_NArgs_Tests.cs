namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArgs_Tests : TestBase
{
    static string?[]? StringNullArray = (string?[]?)null;

    [TestMethod]
    public void Coalesce_NArgs_Strings()
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
    public void Coalesce_NArgs_Strings_SpaceMatters_False()
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
    public void Coalesce_NArgs_Strings_SpaceMatters_True()
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
    public void Coalesce_NArgs_Values()
    {
        // Static params
        NoNullRet(1, Coalesce(  NullNum, Nully0, NoNull0, Nully1));
        // Static collection
        NoNullRet(1, Coalesce([ NullNum, Nully0, Nully0, Nully1 ]));
        // Extension params
        NoNullRet(0, NullNum.Coalesce(NullNum, NullNum, NullNum));
        // Extension on collection
        NoNullRet(1, new [] { NullNum, Nully0, NoNull0, Nully1 }.Coalesce());
        // Null collection
        NoNullRet(0, Coalesce(NullArray));
        NoNullRet(0, NullIColl.Coalesce());
    }

    [TestMethod]
    public void Coalesce_NArgs_Objects()
    {
        // Static params
        NoNullRet(NoNullObj,               Coalesce(         NullObj, NoNullObj,   NullyFilled  ));
        NoNullRet(NullyFilled,             Coalesce(         NullObj, NullyFilled, NoNullObj    ));
        // Static collection
        NoNullRet(NoNullObj,               Coalesce(       [ NullObj, NoNullObj,   NullyFilled ]));
        // Extension on collection
        NoNullRet(NullyFilled,                      new [] { NullObj, NullyFilled, NoNullObj    }.Coalesce());
        // Extension first + params
        NoNullRet(NullyFilled, NullyFilled.Coalesce(         NullObj, NullObj,     NullObj      ));
        // Extension first + coll
        NoNullRet(NullyFilled, NullyFilled.Coalesce(new [] { NullObj, NullObj,     NullObj }    ));
    }
}