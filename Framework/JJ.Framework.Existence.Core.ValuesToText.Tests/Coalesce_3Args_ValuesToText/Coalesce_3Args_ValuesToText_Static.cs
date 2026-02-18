namespace JJ.Framework.Existence.Core.ValuesToText.Tests;

[TestClass]
public class Coalesce_3Args_ValuesToText_Static : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_ValuesToText_Static_Batch1()
    {
        NoNullRet("",   Coalesce(NullNum, NullNum, NullText       ));
        NoNullRet("",   Coalesce(NullNum, NullNum, Empty          ));
        NoNullRet(" ",  Coalesce(NullNum, NullNum, Space          ));
        NoNullRet(Text, Coalesce(NullNum, NullNum, Text           ));
        NoNullRet("",   Coalesce(NullNum, NullNum, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(NullNum, NullNum, NullySpace     ));
        NoNullRet(Text, Coalesce(NullNum, NullNum, NullyFilledText));
        NoNullRet("",   Coalesce(NullNum,  Nully0, NullText       ));
        NoNullRet("",   Coalesce(NullNum,  Nully0, Empty          ));
        NoNullRet(" ",  Coalesce(NullNum,  Nully0, Space          ));
        NoNullRet(Text, Coalesce(NullNum,  Nully0, Text           ));
        NoNullRet("",   Coalesce(NullNum,  Nully0, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(NullNum,  Nully0, NullySpace     ));
        NoNullRet(Text, Coalesce(NullNum,  Nully0, NullyFilledText));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullText       ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, Empty          ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, Space          ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, Text           ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullySpace     ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullyFilledText));
        NoNullRet("",   Coalesce(NullNum,       0, NullText       ));
        NoNullRet("",   Coalesce(NullNum,       0, Empty          ));
        NoNullRet(" ",  Coalesce(NullNum,       0, Space          ));
        NoNullRet(Text, Coalesce(NullNum,       0, Text           ));
        NoNullRet("",   Coalesce(NullNum,       0, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(NullNum,       0, NullySpace     ));
        NoNullRet(Text, Coalesce(NullNum,       0, NullyFilledText));
        NoNullRet("1",  Coalesce(NullNum,       1, NullText       ));
        NoNullRet("1",  Coalesce(NullNum,       1, Empty          ));
        NoNullRet("1",  Coalesce(NullNum,       1, Space          ));
        NoNullRet("1",  Coalesce(NullNum,       1, Text           ));
        NoNullRet("1",  Coalesce(NullNum,       1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(NullNum,       1, NullySpace     ));
        NoNullRet("1",  Coalesce(NullNum,       1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_ValuesToText_Static_Batch2()
    {
        NoNullRet("",   Coalesce(Nully0,  NullNum, NullText       ));
        NoNullRet("",   Coalesce(Nully0,  NullNum, Empty          ));
        NoNullRet(" ",  Coalesce(Nully0,  NullNum, Space          ));
        NoNullRet(Text, Coalesce(Nully0,  NullNum, Text           ));
        NoNullRet("",   Coalesce(Nully0,  NullNum, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(Nully0,  NullNum, NullySpace     ));
        NoNullRet(Text, Coalesce(Nully0,  NullNum, NullyFilledText));
        NoNullRet("",   Coalesce(Nully0,   Nully0, NullText       ));
        NoNullRet("",   Coalesce(Nully0,   Nully0, Empty          ));
        NoNullRet(" ",  Coalesce(Nully0,   Nully0, Space          ));
        NoNullRet(Text, Coalesce(Nully0,   Nully0, Text           ));
        NoNullRet("",   Coalesce(Nully0,   Nully0, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(Nully0,   Nully0, NullySpace     ));
        NoNullRet(Text, Coalesce(Nully0,   Nully0, NullyFilledText));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullText       ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, Empty          ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, Space          ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, Text           ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullySpace     ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullyFilledText));
        NoNullRet("",   Coalesce(Nully0,        0, NullText       ));
        NoNullRet("",   Coalesce(Nully0,        0, Empty          ));
        NoNullRet(" ",  Coalesce(Nully0,        0, Space          ));
        NoNullRet(Text, Coalesce(Nully0,        0, Text           ));
        NoNullRet("",   Coalesce(Nully0,        0, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(Nully0,        0, NullySpace     ));
        NoNullRet(Text, Coalesce(Nully0,        0, NullyFilledText));
        NoNullRet("1",  Coalesce(Nully0,        1, NullText       ));
        NoNullRet("1",  Coalesce(Nully0,        1, Empty          ));
        NoNullRet("1",  Coalesce(Nully0,        1, Space          ));
        NoNullRet("1",  Coalesce(Nully0,        1, Text           ));
        NoNullRet("1",  Coalesce(Nully0,        1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(Nully0,        1, NullySpace     ));
        NoNullRet("1",  Coalesce(Nully0,        1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_ValuesToText_Static_Batch3()
    {
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullText       ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, Empty          ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, Space          ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, Text           ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullyEmpty     ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullySpace     ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullyFilledText));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullText       ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, Empty          ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, Space          ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, Text           ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullyEmpty     ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullySpace     ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullyFilledText));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullText       ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, Empty          ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, Space          ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, Text           ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullySpace     ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullyFilledText));
        NoNullRet("1",  Coalesce(Nully1,        0, NullText       ));
        NoNullRet("1",  Coalesce(Nully1,        0, Empty          ));
        NoNullRet("1",  Coalesce(Nully1,        0, Space          ));
        NoNullRet("1",  Coalesce(Nully1,        0, Text           ));
        NoNullRet("1",  Coalesce(Nully1,        0, NullyEmpty     ));
        NoNullRet("1",  Coalesce(Nully1,        0, NullySpace     ));
        NoNullRet("1",  Coalesce(Nully1,        0, NullyFilledText));
        NoNullRet("1",  Coalesce(Nully1,        1, NullText       ));
        NoNullRet("1",  Coalesce(Nully1,        1, Empty          ));
        NoNullRet("1",  Coalesce(Nully1,        1, Space          ));
        NoNullRet("1",  Coalesce(Nully1,        1, Text           ));
        NoNullRet("1",  Coalesce(Nully1,        1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(Nully1,        1, NullySpace     ));
        NoNullRet("1",  Coalesce(Nully1,        1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_ValuesToText_Static_Batch4()
    {
        NoNullRet("",   Coalesce(0,       NullNum, NullText       ));
        NoNullRet("",   Coalesce(0,       NullNum, Empty          ));
        NoNullRet(" ",  Coalesce(0,       NullNum, Space          ));
        NoNullRet(Text, Coalesce(0,       NullNum, Text           ));
        NoNullRet("",   Coalesce(0,       NullNum, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(0,       NullNum, NullySpace     ));
        NoNullRet(Text, Coalesce(0,       NullNum, NullyFilledText));
        NoNullRet("",   Coalesce(0,        Nully0, NullText       ));
        NoNullRet("",   Coalesce(0,        Nully0, Empty          ));
        NoNullRet(" ",  Coalesce(0,        Nully0, Space          ));
        NoNullRet(Text, Coalesce(0,        Nully0, Text           ));
        NoNullRet("",   Coalesce(0,        Nully0, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(0,        Nully0, NullySpace     ));
        NoNullRet(Text, Coalesce(0,        Nully0, NullyFilledText));
        NoNullRet("1",  Coalesce(0,        Nully1, NullText       ));
        NoNullRet("1",  Coalesce(0,        Nully1, Empty          ));
        NoNullRet("1",  Coalesce(0,        Nully1, Space          ));
        NoNullRet("1",  Coalesce(0,        Nully1, Text           ));
        NoNullRet("1",  Coalesce(0,        Nully1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(0,        Nully1, NullySpace     ));
        NoNullRet("1",  Coalesce(0,        Nully1, NullyFilledText));
        NoNullRet("",   Coalesce(0,             0, NullText       ));
        NoNullRet("",   Coalesce(0,             0, Empty          ));
        NoNullRet(" ",  Coalesce(0,             0, Space          ));
        NoNullRet(Text, Coalesce(0,             0, Text           ));
        NoNullRet("",   Coalesce(0,             0, NullyEmpty     ));
        NoNullRet(" ",  Coalesce(0,             0, NullySpace     ));
        NoNullRet(Text, Coalesce(0,             0, NullyFilledText));
        NoNullRet("1",  Coalesce(0,             1, NullText       ));
        NoNullRet("1",  Coalesce(0,             1, Empty          ));
        NoNullRet("1",  Coalesce(0,             1, Space          ));
        NoNullRet("1",  Coalesce(0,             1, Text           ));
        NoNullRet("1",  Coalesce(0,             1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(0,             1, NullySpace     ));
        NoNullRet("1",  Coalesce(0,             1, NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_ValuesToText_Static_Batch5()
    {
        NoNullRet("1",  Coalesce(1,       NullNum, NullText       ));
        NoNullRet("1",  Coalesce(1,       NullNum, Empty          ));
        NoNullRet("1",  Coalesce(1,       NullNum, Space          ));
        NoNullRet("1",  Coalesce(1,       NullNum, Text           ));
        NoNullRet("1",  Coalesce(1,       NullNum, NullyEmpty     ));
        NoNullRet("1",  Coalesce(1,       NullNum, NullySpace     ));
        NoNullRet("1",  Coalesce(1,       NullNum, NullyFilledText));
        NoNullRet("1",  Coalesce(1,        Nully0, NullText       ));
        NoNullRet("1",  Coalesce(1,        Nully0, Empty          ));
        NoNullRet("1",  Coalesce(1,        Nully0, Space          ));
        NoNullRet("1",  Coalesce(1,        Nully0, Text           ));
        NoNullRet("1",  Coalesce(1,        Nully0, NullyEmpty     ));
        NoNullRet("1",  Coalesce(1,        Nully0, NullySpace     ));
        NoNullRet("1",  Coalesce(1,        Nully0, NullyFilledText));
        NoNullRet("1",  Coalesce(1,        Nully1, NullText       ));
        NoNullRet("1",  Coalesce(1,        Nully1, Empty          ));
        NoNullRet("1",  Coalesce(1,        Nully1, Space          ));
        NoNullRet("1",  Coalesce(1,        Nully1, Text           ));
        NoNullRet("1",  Coalesce(1,        Nully1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(1,        Nully1, NullySpace     ));
        NoNullRet("1",  Coalesce(1,        Nully1, NullyFilledText));
        NoNullRet("1",  Coalesce(1,             0, Empty          ));
        NoNullRet("1",  Coalesce(1,             0, Space          ));
        NoNullRet("1",  Coalesce(1,             0, Text           ));
        NoNullRet("1",  Coalesce(1,             0, NullyEmpty     ));
        NoNullRet("1",  Coalesce(1,             0, NullySpace     ));
        NoNullRet("1",  Coalesce(1,             0, NullyFilledText));
        NoNullRet("1",  Coalesce(1,             1, NullText       ));
        NoNullRet("1",  Coalesce(1,             1, Empty          ));
        NoNullRet("1",  Coalesce(1,             1, Space          ));
        NoNullRet("1",  Coalesce(1,             1, Text           ));
        NoNullRet("1",  Coalesce(1,             1, NullyEmpty     ));
        NoNullRet("1",  Coalesce(1,             1, NullySpace     ));
        NoNullRet("1",  Coalesce(1,             1, NullyFilledText));
    }
}