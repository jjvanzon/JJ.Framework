namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_BoolToText_Extensions : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch1()
    {
        NoNullRet("",   NullNum.Coalesce(NullNum, NullText       ));
        NoNullRet("",   NullNum.Coalesce(NullNum, Empty          ));
        NoNullRet(" ",  NullNum.Coalesce(NullNum, Space          ));
        NoNullRet(Text, NullNum.Coalesce(NullNum, Text           ));
        NoNullRet("",   NullNum.Coalesce(NullNum, NullyEmpty     ));
        NoNullRet(" ",  NullNum.Coalesce(NullNum, NullySpace     ));
        NoNullRet(Text, NullNum.Coalesce(NullNum, NullyFilledText));
        NoNullRet("",   NullNum.Coalesce( Nully0, NullText       ));
        NoNullRet("",   NullNum.Coalesce( Nully0, Empty          ));
        NoNullRet(" ",  NullNum.Coalesce( Nully0, Space          ));
        NoNullRet(Text, NullNum.Coalesce( Nully0, Text           ));
        NoNullRet("",   NullNum.Coalesce( Nully0, NullyEmpty     ));
        NoNullRet(" ",  NullNum.Coalesce( Nully0, NullySpace     ));
        NoNullRet(Text, NullNum.Coalesce( Nully0, NullyFilledText));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullText       ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, Empty          ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, Space          ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, Text           ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullyEmpty     ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullySpace     ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullyFilledText));
        NoNullRet("",   NullNum.Coalesce(      0, NullText       ));
        NoNullRet("",   NullNum.Coalesce(      0, Empty          ));
        NoNullRet(" ",  NullNum.Coalesce(      0, Space          ));
        NoNullRet(Text, NullNum.Coalesce(      0, Text           ));
        NoNullRet("",   NullNum.Coalesce(      0, NullyEmpty     ));
        NoNullRet(" ",  NullNum.Coalesce(      0, NullySpace     ));
        NoNullRet(Text, NullNum.Coalesce(      0, NullyFilledText));
        NoNullRet("1",  NullNum.Coalesce(      1, NullText       ));
        NoNullRet("1",  NullNum.Coalesce(      1, Empty          ));
        NoNullRet("1",  NullNum.Coalesce(      1, Space          ));
        NoNullRet("1",  NullNum.Coalesce(      1, Text           ));
        NoNullRet("1",  NullNum.Coalesce(      1, NullyEmpty     ));
        NoNullRet("1",  NullNum.Coalesce(      1, NullySpace     ));
        NoNullRet("1",  NullNum.Coalesce(      1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch2()
    {
        NoNullRet("",    Nully0.Coalesce(NullNum, NullText       ));
        NoNullRet("",    Nully0.Coalesce(NullNum, Empty          ));
        NoNullRet(" ",   Nully0.Coalesce(NullNum, Space          ));
        NoNullRet(Text,  Nully0.Coalesce(NullNum, Text           ));
        NoNullRet("",    Nully0.Coalesce(NullNum, NullyEmpty     ));
        NoNullRet(" ",   Nully0.Coalesce(NullNum, NullySpace     ));
        NoNullRet(Text,  Nully0.Coalesce(NullNum, NullyFilledText));
        NoNullRet("",    Nully0.Coalesce( Nully0, NullText       ));
        NoNullRet("",    Nully0.Coalesce( Nully0, Empty          ));
        NoNullRet(" ",   Nully0.Coalesce( Nully0, Space          ));
        NoNullRet(Text,  Nully0.Coalesce( Nully0, Text           ));
        NoNullRet("",    Nully0.Coalesce( Nully0, NullyEmpty     ));
        NoNullRet(" ",   Nully0.Coalesce( Nully0, NullySpace     ));
        NoNullRet(Text,  Nully0.Coalesce( Nully0, NullyFilledText));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullText       ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, Empty          ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, Space          ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, Text           ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullyEmpty     ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullySpace     ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullyFilledText));
        NoNullRet("",    Nully0.Coalesce(      0, NullText       ));
        NoNullRet("",    Nully0.Coalesce(      0, Empty          ));
        NoNullRet(" ",   Nully0.Coalesce(      0, Space          ));
        NoNullRet(Text,  Nully0.Coalesce(      0, Text           ));
        NoNullRet("",    Nully0.Coalesce(      0, NullyEmpty     ));
        NoNullRet(" ",   Nully0.Coalesce(      0, NullySpace     ));
        NoNullRet(Text,  Nully0.Coalesce(      0, NullyFilledText));
        NoNullRet("1",   Nully0.Coalesce(      1, NullText       ));
        NoNullRet("1",   Nully0.Coalesce(      1, Empty          ));
        NoNullRet("1",   Nully0.Coalesce(      1, Space          ));
        NoNullRet("1",   Nully0.Coalesce(      1, Text           ));
        NoNullRet("1",   Nully0.Coalesce(      1, NullyEmpty     ));
        NoNullRet("1",   Nully0.Coalesce(      1, NullySpace     ));
        NoNullRet("1",   Nully0.Coalesce(      1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch3()
    {
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullText       ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, Empty          ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, Space          ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, Text           ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullyEmpty     ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullySpace     ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullyFilledText));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullText       ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, Empty          ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, Space          ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, Text           ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullyEmpty     ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullySpace     ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullyFilledText));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullText       ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, Empty          ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, Space          ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, Text           ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullyEmpty     ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullySpace     ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullyFilledText));
        NoNullRet("1",   Nully1.Coalesce(      0, NullText       ));
        NoNullRet("1",   Nully1.Coalesce(      0, Empty          ));
        NoNullRet("1",   Nully1.Coalesce(      0, Space          ));
        NoNullRet("1",   Nully1.Coalesce(      0, Text           ));
        NoNullRet("1",   Nully1.Coalesce(      0, NullyEmpty     ));
        NoNullRet("1",   Nully1.Coalesce(      0, NullySpace     ));
        NoNullRet("1",   Nully1.Coalesce(      0, NullyFilledText));
        NoNullRet("1",   Nully1.Coalesce(      1, NullText       ));
        NoNullRet("1",   Nully1.Coalesce(      1, Empty          ));
        NoNullRet("1",   Nully1.Coalesce(      1, Space          ));
        NoNullRet("1",   Nully1.Coalesce(      1, Text           ));
        NoNullRet("1",   Nully1.Coalesce(      1, NullyEmpty     ));
        NoNullRet("1",   Nully1.Coalesce(      1, NullySpace     ));
        NoNullRet("1",   Nully1.Coalesce(      1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch4()
    {
        NoNullRet("",         0.Coalesce(NullNum, NullText       ));
        NoNullRet("",         0.Coalesce(NullNum, Empty          ));
        NoNullRet(" ",        0.Coalesce(NullNum, Space          ));
        NoNullRet(Text,       0.Coalesce(NullNum, Text           ));
        NoNullRet("",         0.Coalesce(NullNum, NullyEmpty     ));
        NoNullRet(" ",        0.Coalesce(NullNum, NullySpace     ));
        NoNullRet(Text,       0.Coalesce(NullNum, NullyFilledText));
        NoNullRet("",         0.Coalesce( Nully0, NullText       ));
        NoNullRet("",         0.Coalesce( Nully0, Empty          ));
        NoNullRet(" ",        0.Coalesce( Nully0, Space          ));
        NoNullRet(Text,       0.Coalesce( Nully0, Text           ));
        NoNullRet("",         0.Coalesce( Nully0, NullyEmpty     ));
        NoNullRet(" ",        0.Coalesce( Nully0, NullySpace     ));
        NoNullRet(Text,       0.Coalesce( Nully0, NullyFilledText));
        NoNullRet("1",        0.Coalesce( Nully1, NullText       ));
        NoNullRet("1",        0.Coalesce( Nully1, Empty          ));
        NoNullRet("1",        0.Coalesce( Nully1, Space          ));
        NoNullRet("1",        0.Coalesce( Nully1, Text           ));
        NoNullRet("1",        0.Coalesce( Nully1, NullyEmpty     ));
        NoNullRet("1",        0.Coalesce( Nully1, NullySpace     ));
        NoNullRet("1",        0.Coalesce( Nully1, NullyFilledText));
        NoNullRet("",         0.Coalesce(      0, NullText       ));
        NoNullRet("",         0.Coalesce(      0, Empty          ));
        NoNullRet(" ",        0.Coalesce(      0, Space          ));
        NoNullRet(Text,       0.Coalesce(      0, Text           ));
        NoNullRet("",         0.Coalesce(      0, NullyEmpty     ));
        NoNullRet(" ",        0.Coalesce(      0, NullySpace     ));
        NoNullRet(Text,       0.Coalesce(      0, NullyFilledText));
        NoNullRet("1",        0.Coalesce(      1, NullText       ));
        NoNullRet("1",        0.Coalesce(      1, Empty          ));
        NoNullRet("1",        0.Coalesce(      1, Space          ));
        NoNullRet("1",        0.Coalesce(      1, Text           ));
        NoNullRet("1",        0.Coalesce(      1, NullyEmpty     ));
        NoNullRet("1",        0.Coalesce(      1, NullySpace     ));
        NoNullRet("1",        0.Coalesce(      1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch5()
    {
        NoNullRet("1",        1.Coalesce(NullNum, NullText       ));
        NoNullRet("1",        1.Coalesce(NullNum, Empty          ));
        NoNullRet("1",        1.Coalesce(NullNum, Space          ));
        NoNullRet("1",        1.Coalesce(NullNum, Text           ));
        NoNullRet("1",        1.Coalesce(NullNum, NullyEmpty     ));
        NoNullRet("1",        1.Coalesce(NullNum, NullySpace     ));
        NoNullRet("1",        1.Coalesce(NullNum, NullyFilledText));
        NoNullRet("1",        1.Coalesce( Nully0, NullText       ));
        NoNullRet("1",        1.Coalesce( Nully0, Empty          ));
        NoNullRet("1",        1.Coalesce( Nully0, Space          ));
        NoNullRet("1",        1.Coalesce( Nully0, Text           ));
        NoNullRet("1",        1.Coalesce( Nully0, NullyEmpty     ));
        NoNullRet("1",        1.Coalesce( Nully0, NullySpace     ));
        NoNullRet("1",        1.Coalesce( Nully0, NullyFilledText));
        NoNullRet("1",        1.Coalesce( Nully1, NullText       ));
        NoNullRet("1",        1.Coalesce( Nully1, Empty          ));
        NoNullRet("1",        1.Coalesce( Nully1, Space          ));
        NoNullRet("1",        1.Coalesce( Nully1, Text           ));
        NoNullRet("1",        1.Coalesce( Nully1, NullyEmpty     ));
        NoNullRet("1",        1.Coalesce( Nully1, NullySpace     ));
        NoNullRet("1",        1.Coalesce( Nully1, NullyFilledText));
        NoNullRet("1",        1.Coalesce(      0, Empty          ));
        NoNullRet("1",        1.Coalesce(      0, Space          ));
        NoNullRet("1",        1.Coalesce(      0, Text           ));
        NoNullRet("1",        1.Coalesce(      0, NullyEmpty     ));
        NoNullRet("1",        1.Coalesce(      0, NullySpace     ));
        NoNullRet("1",        1.Coalesce(      0, NullyFilledText));
        NoNullRet("1",        1.Coalesce(      1, NullText       ));
        NoNullRet("1",        1.Coalesce(      1, Empty          ));
        NoNullRet("1",        1.Coalesce(      1, Space          ));
        NoNullRet("1",        1.Coalesce(      1, Text           ));
        NoNullRet("1",        1.Coalesce(      1, NullyEmpty     ));
        NoNullRet("1",        1.Coalesce(      1, NullySpace     ));
        NoNullRet("1",        1.Coalesce(      1, NullyFilledText));
    }
}