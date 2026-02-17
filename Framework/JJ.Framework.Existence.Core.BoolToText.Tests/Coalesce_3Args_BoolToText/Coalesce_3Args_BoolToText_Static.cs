namespace JJ.Framework.Existence.Core.BoolToText.Tests;

[TestClass]
public class Coalesce_3Args_BoolToText_Static : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_BoolToText_Static_Batch1()
    {
        NoNullRet("",      Coalesce(NullBool,   NullBool,   NullText       ));
        NoNullRet("",      Coalesce(NullBool,   NullBool,   Empty          ));
        NoNullRet(" ",     Coalesce(NullBool,   NullBool,   Space          ));
        NoNullRet(Text,    Coalesce(NullBool,   NullBool,   Text           ));
        NoNullRet("",      Coalesce(NullBool,   NullBool,   NullyEmpty     ));
        NoNullRet(" ",     Coalesce(NullBool,   NullBool,   NullySpace     ));
        NoNullRet(Text,    Coalesce(NullBool,   NullBool,   NullyFilledText));
        NoNullRet("",      Coalesce(NullBool,   NullyFalse, NullText       ));
        NoNullRet("",      Coalesce(NullBool,   NullyFalse, Empty          ));
        NoNullRet(" ",     Coalesce(NullBool,   NullyFalse, Space          ));
        NoNullRet(Text,    Coalesce(NullBool,   NullyFalse, Text           ));
        NoNullRet("",      Coalesce(NullBool,   NullyFalse, NullyEmpty     ));
        NoNullRet(" ",     Coalesce(NullBool,   NullyFalse, NullySpace     ));
        NoNullRet(Text,    Coalesce(NullBool,   NullyFalse, NullyFilledText));
        NoNullRet("True",  Coalesce(NullBool,   NullyTrue,  NullText       ));
        NoNullRet("True",  Coalesce(NullBool,   NullyTrue,  Empty          ));
        NoNullRet("True",  Coalesce(NullBool,   NullyTrue,  Space          ));
        NoNullRet("True",  Coalesce(NullBool,   NullyTrue,  Text           ));
        NoNullRet("True",  Coalesce(NullBool,   NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullBool,   NullyTrue,  NullySpace     ));
        NoNullRet("True",  Coalesce(NullBool,   NullyTrue,  NullyFilledText));
        NoNullRet("",      Coalesce(NullBool,   false,      NullText       ));
        NoNullRet("",      Coalesce(NullBool,   false,      Empty          ));
        NoNullRet(" ",     Coalesce(NullBool,   false,      Space          ));
        NoNullRet(Text,    Coalesce(NullBool,   false,      Text           ));
        NoNullRet("",      Coalesce(NullBool,   false,      NullyEmpty     ));
        NoNullRet(" ",     Coalesce(NullBool,   false,      NullySpace     ));
        NoNullRet(Text,    Coalesce(NullBool,   false,      NullyFilledText));
        NoNullRet("True",  Coalesce(NullBool,   true,       NullText       ));
        NoNullRet("True",  Coalesce(NullBool,   true,       Empty          ));
        NoNullRet("True",  Coalesce(NullBool,   true,       Space          ));
        NoNullRet("True",  Coalesce(NullBool,   true,       Text           ));
        NoNullRet("True",  Coalesce(NullBool,   true,       NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullBool,   true,       NullySpace     ));
        NoNullRet("True",  Coalesce(NullBool,   true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Static_Batch2()
    {
        NoNullRet("",      Coalesce(NullyFalse, NullBool,   NullText       ));
        NoNullRet("",      Coalesce(NullyFalse, NullBool,   Empty          ));
        NoNullRet(" ",     Coalesce(NullyFalse, NullBool,   Space          ));
        NoNullRet(Text,    Coalesce(NullyFalse, NullBool,   Text           ));
        NoNullRet("",      Coalesce(NullyFalse, NullBool,   NullyEmpty     ));
        NoNullRet(" ",     Coalesce(NullyFalse, NullBool,   NullySpace     ));
        NoNullRet(Text,    Coalesce(NullyFalse, NullBool,   NullyFilledText));
        NoNullRet("",      Coalesce(NullyFalse, NullyFalse, NullText       ));
        NoNullRet("",      Coalesce(NullyFalse, NullyFalse, Empty          ));
        NoNullRet(" ",     Coalesce(NullyFalse, NullyFalse, Space          ));
        NoNullRet(Text,    Coalesce(NullyFalse, NullyFalse, Text           ));
        NoNullRet("",      Coalesce(NullyFalse, NullyFalse, NullyEmpty     ));
        NoNullRet(" ",     Coalesce(NullyFalse, NullyFalse, NullySpace     ));
        NoNullRet(Text,    Coalesce(NullyFalse, NullyFalse, NullyFilledText));
        NoNullRet("True",  Coalesce(NullyFalse, NullyTrue,  NullText       ));
        NoNullRet("True",  Coalesce(NullyFalse, NullyTrue,  Empty          ));
        NoNullRet("True",  Coalesce(NullyFalse, NullyTrue,  Space          ));
        NoNullRet("True",  Coalesce(NullyFalse, NullyTrue,  Text           ));
        NoNullRet("True",  Coalesce(NullyFalse, NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullyFalse, NullyTrue,  NullySpace     ));
        NoNullRet("True",  Coalesce(NullyFalse, NullyTrue,  NullyFilledText));
        NoNullRet("",      Coalesce(NullyFalse, false,      NullText       ));
        NoNullRet("",      Coalesce(NullyFalse, false,      Empty          ));
        NoNullRet(" ",     Coalesce(NullyFalse, false,      Space          ));
        NoNullRet(Text,    Coalesce(NullyFalse, false,      Text           ));
        NoNullRet("",      Coalesce(NullyFalse, false,      NullyEmpty     ));
        NoNullRet(" ",     Coalesce(NullyFalse, false,      NullySpace     ));
        NoNullRet(Text,    Coalesce(NullyFalse, false,      NullyFilledText));
        NoNullRet("True",  Coalesce(NullyFalse, true,       NullText       ));
        NoNullRet("True",  Coalesce(NullyFalse, true,       Empty          ));
        NoNullRet("True",  Coalesce(NullyFalse, true,       Space          ));
        NoNullRet("True",  Coalesce(NullyFalse, true,       Text           ));
        NoNullRet("True",  Coalesce(NullyFalse, true,       NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullyFalse, true,       NullySpace     ));
        NoNullRet("True",  Coalesce(NullyFalse, true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Static_Batch3()
    {
        NoNullRet("True",  Coalesce(NullyTrue,  NullBool,   NullText       ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullBool,   Empty          ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullBool,   Space          ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullBool,   Text           ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullBool,   NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullBool,   NullySpace     ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullBool,   NullyFilledText));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyFalse, NullText       ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyFalse, Empty          ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyFalse, Space          ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyFalse, Text           ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyFalse, NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyFalse, NullySpace     ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyFalse, NullyFilledText));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyTrue,  NullText       ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyTrue,  Empty          ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyTrue,  Space          ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyTrue,  Text           ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyTrue,  NullySpace     ));
        NoNullRet("True",  Coalesce(NullyTrue,  NullyTrue,  NullyFilledText));
        NoNullRet("True",  Coalesce(NullyTrue,  false,      NullText       ));
        NoNullRet("True",  Coalesce(NullyTrue,  false,      Empty          ));
        NoNullRet("True",  Coalesce(NullyTrue,  false,      Space          ));
        NoNullRet("True",  Coalesce(NullyTrue,  false,      Text           ));
        NoNullRet("True",  Coalesce(NullyTrue,  false,      NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullyTrue,  false,      NullySpace     ));
        NoNullRet("True",  Coalesce(NullyTrue,  false,      NullyFilledText));
        NoNullRet("True",  Coalesce(NullyTrue,  true,       NullText       ));
        NoNullRet("True",  Coalesce(NullyTrue,  true,       Empty          ));
        NoNullRet("True",  Coalesce(NullyTrue,  true,       Space          ));
        NoNullRet("True",  Coalesce(NullyTrue,  true,       Text           ));
        NoNullRet("True",  Coalesce(NullyTrue,  true,       NullyEmpty     ));
        NoNullRet("True",  Coalesce(NullyTrue,  true,       NullySpace     ));
        NoNullRet("True",  Coalesce(NullyTrue,  true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Static_Batch4()
    {
        NoNullRet("",      Coalesce(false,       NullBool,   NullText       ));
        NoNullRet("",      Coalesce(false,       NullBool,   Empty          ));
        NoNullRet(" ",     Coalesce(false,       NullBool,   Space          ));
        NoNullRet(Text,    Coalesce(false,       NullBool,   Text           ));
        NoNullRet("",      Coalesce(false,       NullBool,   NullyEmpty     ));
        NoNullRet(" ",     Coalesce(false,       NullBool,   NullySpace     ));
        NoNullRet(Text,    Coalesce(false,       NullBool,   NullyFilledText));
        NoNullRet("",      Coalesce(false,       NullyFalse, NullText       ));
        NoNullRet("",      Coalesce(false,       NullyFalse, Empty          ));
        NoNullRet(" ",     Coalesce(false,       NullyFalse, Space          ));
        NoNullRet(Text,    Coalesce(false,       NullyFalse, Text           ));
        NoNullRet("",      Coalesce(false,       NullyFalse, NullyEmpty     ));
        NoNullRet(" ",     Coalesce(false,       NullyFalse, NullySpace     ));
        NoNullRet(Text,    Coalesce(false,       NullyFalse, NullyFilledText));
        NoNullRet("True",  Coalesce(false,       NullyTrue,  NullText       ));
        NoNullRet("True",  Coalesce(false,       NullyTrue,  Empty          ));
        NoNullRet("True",  Coalesce(false,       NullyTrue,  Space          ));
        NoNullRet("True",  Coalesce(false,       NullyTrue,  Text           ));
        NoNullRet("True",  Coalesce(false,       NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  Coalesce(false,       NullyTrue,  NullySpace     ));
        NoNullRet("True",  Coalesce(false,       NullyTrue,  NullyFilledText));
        NoNullRet("",      Coalesce(false,       false,      NullText       ));
        NoNullRet("",      Coalesce(false,       false,      Empty          ));
        NoNullRet(" ",     Coalesce(false,       false,      Space          ));
        NoNullRet(Text,    Coalesce(false,       false,      Text           ));
        NoNullRet("",      Coalesce(false,       false,      NullyEmpty     ));
        NoNullRet(" ",     Coalesce(false,       false,      NullySpace     ));
        NoNullRet(Text,    Coalesce(false,       false,      NullyFilledText));
        NoNullRet("True",  Coalesce(false,       true,       NullText       ));
        NoNullRet("True",  Coalesce(false,       true,       Empty          ));
        NoNullRet("True",  Coalesce(false,       true,       Space          ));
        NoNullRet("True",  Coalesce(false,       true,       Text           ));
        NoNullRet("True",  Coalesce(false,       true,       NullyEmpty     ));
        NoNullRet("True",  Coalesce(false,       true,       NullySpace     ));
        NoNullRet("True",  Coalesce(false,       true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Static_Batch5()
    {
        NoNullRet("True",  Coalesce(true,       NullBool,   NullText       ));
        NoNullRet("True",  Coalesce(true,       NullBool,   Empty          ));
        NoNullRet("True",  Coalesce(true,       NullBool,   Space          ));
        NoNullRet("True",  Coalesce(true,       NullBool,   Text           ));
        NoNullRet("True",  Coalesce(true,       NullBool,   NullyEmpty     ));
        NoNullRet("True",  Coalesce(true,       NullBool,   NullySpace     ));
        NoNullRet("True",  Coalesce(true,       NullBool,   NullyFilledText));
        NoNullRet("True",  Coalesce(true,       NullyFalse, NullText       ));
        NoNullRet("True",  Coalesce(true,       NullyFalse, Empty          ));
        NoNullRet("True",  Coalesce(true,       NullyFalse, Space          ));
        NoNullRet("True",  Coalesce(true,       NullyFalse, Text           ));
        NoNullRet("True",  Coalesce(true,       NullyFalse, NullyEmpty     ));
        NoNullRet("True",  Coalesce(true,       NullyFalse, NullySpace     ));
        NoNullRet("True",  Coalesce(true,       NullyFalse, NullyFilledText));
        NoNullRet("True",  Coalesce(true,       NullyTrue,  NullText       ));
        NoNullRet("True",  Coalesce(true,       NullyTrue,  Empty          ));
        NoNullRet("True",  Coalesce(true,       NullyTrue,  Space          ));
        NoNullRet("True",  Coalesce(true,       NullyTrue,  Text           ));
        NoNullRet("True",  Coalesce(true,       NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  Coalesce(true,       NullyTrue,  NullySpace     ));
        NoNullRet("True",  Coalesce(true,       NullyTrue,  NullyFilledText));
        NoNullRet("True",  Coalesce(true,       false,      Empty          ));
        NoNullRet("True",  Coalesce(true,       false,      Space          ));
        NoNullRet("True",  Coalesce(true,       false,      Text           ));
        NoNullRet("True",  Coalesce(true,       false,      NullyEmpty     ));
        NoNullRet("True",  Coalesce(true,       false,      NullySpace     ));
        NoNullRet("True",  Coalesce(true,       false,      NullyFilledText));
        NoNullRet("True",  Coalesce(true,       true,       NullText       ));
        NoNullRet("True",  Coalesce(true,       true,       Empty          ));
        NoNullRet("True",  Coalesce(true,       true,       Space          ));
        NoNullRet("True",  Coalesce(true,       true,       Text           ));
        NoNullRet("True",  Coalesce(true,       true,       NullyEmpty     ));
        NoNullRet("True",  Coalesce(true,       true,       NullySpace     ));
        NoNullRet("True",  Coalesce(true,       true,       NullyFilledText));
    }
}