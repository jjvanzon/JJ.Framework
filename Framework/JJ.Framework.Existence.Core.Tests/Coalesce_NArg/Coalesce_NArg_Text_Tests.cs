namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArg_Text_Tests : TestBase
{
    [TestMethod] 
    public void Coalesce_NArg_Text_StaticParams() 
    {
        NoNullRet("Finally",          Coalesce(  "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",               Coalesce(  "Hi", " ",  "\n     ", "Finally"  ));
    }
    
    [TestMethod] 
    public void Coalesce_NArg_Text_ExtensionParams() 
    {
        NoNullRet("Finally", " "     .Coalesce(  "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",      " "     .Coalesce(  "",   "Hi", "\n     ", "Finally"  ));
    }
    
    [TestMethod] 
    public void Coalesce_NArg_Text_ExtensionParams_Nully() 
    {
        NoNullRet(" ",       NullText.Coalesce(NullyEmpty, NullText, NullySpace    ));
        NoNullRet("",        NullText.Coalesce(NullyEmpty, NullText, Empty         ));
    }
    
    [TestMethod] 
    public void Coalesce_NArg_Text_StaticCollExpress() 
    {
        NoNullRet("Finally",          Coalesce([ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",               Coalesce([ "",   " ",  "Hi",      "Finally" ]));
    }
    
    [TestMethod] 
    public void Coalesce_NArg_Text_ExtensionsCollExpress() 
    {
        NoNullRet("Finally", " "     .Coalesce([ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",      " "     .Coalesce([ "",   " ",  "\n     ", "Hi"      ]));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsOnColl()
    {
        NoNullRet("Finally", new [] { "",   " ",   "\n     ", "Finally" }.Coalesce());
        NoNullRet("Hi",      new [] { "",   "Hi",  "\n     ", "Finally" }.Coalesce());
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsOnColl_Nulls()
    {
        NoNullRet("",        new [] { NullText,    NullText,   NullText }.Coalesce());
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsOnColl_EmptyColl()
    {
        NoNullRet("",        Array.Empty<string>() .Coalesce());
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsOnColl_NullColl()
    {
        NoNullRet("",        Coalesce(StringNullArray));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_StaticParams_SpaceMattersNoFlagsInFront()
    {
        NoNullRet("Finally",          Coalesce(spaceMatters: false,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",               Coalesce(spaceMatters: false,   "Hi", " ",  "\n     ", "Finally"  ));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsParams_SpaceMattersNoFlagsInFront()
    {
        NoNullRet("Finally", " "     .Coalesce(spaceMatters: false,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",      " "     .Coalesce(spaceMatters: false,   "",   "Hi", "\n     ", "Finally"  ));
        NoNullRet(" ",       NullText.Coalesce(spaceMatters: false, NullyEmpty,   NullText,  NullySpace ));
        NoNullRet("",        NullText.Coalesce(spaceMatters: false, NullyEmpty,   NullText,  Empty      ));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_StaticCollExpress_SpaceMattersNoFlagsInFront()
    {
        NoNullRet("Finally",          Coalesce(spaceMatters: false, [ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",               Coalesce(spaceMatters: false, [ "",   " ",  "Hi",      "Finally" ]));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsCollExpress_SpaceMattersNoFlagsInFront()
    {
        NoNullRet("Finally", " "     .Coalesce(spaceMatters: false, [ "",   " ",  "\n     ", "Finally" ]));
        NoNullRet("Hi",      " "     .Coalesce(spaceMatters: false, [ "",   " ",  "\n     ", "Hi"      ]));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_StaticCollExpress_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("Finally",          Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: false));
        NoNullRet("Hi",               Coalesce([ "",   " ",  "Hi",      "Finally" ],         spaceMatters: false));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsCollExpress_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("Finally", " "     .Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: false));
        NoNullRet("Hi",      " "     .Coalesce([ "",   " ",  "\n     ", "Hi"      ],         spaceMatters: false));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsOnColl_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("Finally",          new []   { "",   " ",   "\n     ", "Finally"}.Coalesce(spaceMatters: false));
        NoNullRet("Hi",               new []   { "",   "Hi",  "\n     ", "Finally"}.Coalesce(spaceMatters: false));
        NoNullRet("",                 new []   { NullText,    NullText,   NullText}.Coalesce(spaceMatters: false));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsNullColl_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("",                 new string[0].Coalesce(   spaceMatters: false));
    }
    
    [TestMethod]
    public void Coalesce_NArg_Text_StaticNullColl_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("",                 Coalesce(StringNullArray, spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_StaticParams_SpaceMattersYesFlagsInFront()
    {

        NoNullRet(" ",           Coalesce(spaceMatters,         "",   " ",  "\n     ", "Finally"  ));
        NoNullRet(" ",           Coalesce(spaceMatters: true,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",          Coalesce(spaceMatters,         "Hi", " ",  "\n     ", "Finally"  ));
        NoNullRet("Hi",          Coalesce(spaceMatters: true,   "Hi", " ",  "\n     ", "Finally"  ));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_StaticCollExpress_SpaceMattersYesFlagsInFront()
    {
        NoNullRet(" ",           Coalesce(spaceMatters,       [ "",   " ",  "Hi",      "Finally" ]));
        NoNullRet(" ",           Coalesce(spaceMatters: true, [ "",   " ",  "Hi",      "Finally" ]));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsParams_SpaceMattersYesFlagsInFront()
    {
        NoNullRet(" ",  ""      .Coalesce(spaceMatters,         "",   " ",  "\n     ", "Finally"  ));
        NoNullRet(" ",  ""      .Coalesce(spaceMatters: true,   "",   " ",  "\n     ", "Finally"  ));
        NoNullRet(" ",  " "     .Coalesce(spaceMatters,         "",   "Hi", "\n     ", "Finally"  ));
        NoNullRet(" ",  " "     .Coalesce(spaceMatters: true,   "",   "Hi", "\n     ", "Finally"  ));
        NoNullRet(" ",  NullText.Coalesce(spaceMatters,       NullyEmpty,   NullText,  NullySpace ));
        NoNullRet(" ",  NullText.Coalesce(spaceMatters: true, NullyEmpty,   NullText,  NullySpace ));
        NoNullRet("",   NullText.Coalesce(spaceMatters,       NullyEmpty,   NullText,  Empty      ));
        NoNullRet("",   NullText.Coalesce(spaceMatters: true, NullyEmpty,   NullText,  Empty      ));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsCollExpress_SpaceMattersYesFlagsInFront()
    {
        NoNullRet(" ",  " "     .Coalesce(spaceMatters,       [ "",   " ",  "\n     ", "Hi"      ]));
        NoNullRet(" ",  " "     .Coalesce(spaceMatters: true, [ "",   " ",  "\n     ", "Hi"      ]));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_StaticCollExpress_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(" ",       Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters      ));
        NoNullRet(" ",       Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: true));
        NoNullRet(" ",       Coalesce([ "",   " ",  "Hi",      "Finally" ],         spaceMatters      ));
        NoNullRet(" ",       Coalesce([ "",   " ",  "Hi",      "Finally" ],         spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsCollExpress_SpaceMattersYesFlagsInBack()
    {
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters      ));
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Finally" ],         spaceMatters: true));
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Hi"      ],         spaceMatters      ));
        NoNullRet("\t", "\t".Coalesce([ "",   " ",  "\n     ", "Hi"      ],         spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsOnColl_SpaceMattersYes()
    {
        NoNullRet(" ",       new []  { "",   " ",   "\n     ", "Finally" }.Coalesce(spaceMatters      ));
        NoNullRet(" ",       new []  { "",   " ",   "\n     ", "Finally" }.Coalesce(spaceMatters: true));
        NoNullRet("Hi",      new []  { "",   "Hi",  "\n     ", "Finally" }.Coalesce(spaceMatters      ));
        NoNullRet("Hi",      new []  { "",   "Hi",  "\n     ", "Finally" }.Coalesce(spaceMatters: true));
        NoNullRet("",        new []  { NullText,    NullText,  NullText  }.Coalesce(spaceMatters      ));
        NoNullRet("",        new []  { NullText,    NullText,  NullText  }.Coalesce(spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_ExtensionsOnNullColl_SpaceMattersYes()
    {
        NoNullRet("",        new string[0].Coalesce(   spaceMatters      ));
        NoNullRet("",        new string[0].Coalesce(   spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_NArg_Text_StaticNullColl_SpaceMattersYesFlagsInBack()
    {
        NoNullRet("",        Coalesce(StringNullArray, spaceMatters      ));
        NoNullRet("",        Coalesce(StringNullArray, spaceMatters: true));
    }
}