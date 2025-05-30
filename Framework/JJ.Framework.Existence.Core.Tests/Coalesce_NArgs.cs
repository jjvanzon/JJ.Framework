namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArgs
{
    static string?[]? StringNullArray = (string?[]?)null;

    [TestMethod]
    public void Coalesce_NArgs_Strings()
    {
        NoNullRet("Finally",          Coalesce(  ""  , " " , "\n     ", "Finally"  ));
        NoNullRet("Finally", " "     .Coalesce(  ""  , " " , "\n     ", "Finally"  ));
        NoNullRet("Finally",          Coalesce([ ""  , " " , "\n     ", "Finally" ]));
        NoNullRet("Finally", " "     .Coalesce([ ""  , " " , "\n     ", "Finally" ]));
        NoNullRet("Hi",               Coalesce(  "Hi", " " , "\n     ", "Finally"  ));
        NoNullRet("Hi",      " "     .Coalesce(  ""  , "Hi", "\n     ", "Finally"  ));
        NoNullRet("Hi",               Coalesce([ ""  , " " , "Hi"     , "Finally" ]));
        NoNullRet("Hi",      " "     .Coalesce([ ""  , " " , "\n     ", "Hi"      ]));
        NoNullRet(" ",       NullText.Coalesce(NullyEmpty, NullText, NullySpace    ));
        NoNullRet("",        NullText.Coalesce(NullyEmpty, NullText, NoNullEmpty   ));
        NoNullRet("Finally", new [] { ""  , " "  , "\n     ", "Finally" }.Coalesce());
        NoNullRet("Hi",      new [] { ""  , "Hi" , "\n     ", "Finally" }.Coalesce());
        NoNullRet("",        new [] { NullText,    NullText,   NullText }.Coalesce());
        NoNullRet("",        new string[0] .Coalesce());
        NoNullRet("",        Coalesce(StringNullArray));
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
        NoNullRet(0, NullICollection.Coalesce());
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