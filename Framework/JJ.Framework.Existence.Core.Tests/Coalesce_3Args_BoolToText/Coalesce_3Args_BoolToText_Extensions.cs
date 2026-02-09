namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_BoolToText_Extensions : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch1()
    {
        NoNullRet("",      NullBool  .Coalesce(NullBool,   NullText       ));
        NoNullRet("",      NullBool  .Coalesce(NullBool,   Empty          ));
        NoNullRet(" ",     NullBool  .Coalesce(NullBool,   Space          ));
        NoNullRet(Text,    NullBool  .Coalesce(NullBool,   Text           ));
        NoNullRet("",      NullBool  .Coalesce(NullBool,   NullyEmpty     ));
        NoNullRet(" ",     NullBool  .Coalesce(NullBool,   NullySpace     ));
        NoNullRet(Text,    NullBool  .Coalesce(NullBool,   NullyFilledText));
        NoNullRet("",      NullBool  .Coalesce(NullyFalse, NullText       ));
        NoNullRet("",      NullBool  .Coalesce(NullyFalse, Empty          ));
        NoNullRet(" ",     NullBool  .Coalesce(NullyFalse, Space          ));
        NoNullRet(Text,    NullBool  .Coalesce(NullyFalse, Text           ));
        NoNullRet("",      NullBool  .Coalesce(NullyFalse, NullyEmpty     ));
        NoNullRet(" ",     NullBool  .Coalesce(NullyFalse, NullySpace     ));
        NoNullRet(Text,    NullBool  .Coalesce(NullyFalse, NullyFilledText));
        NoNullRet("True",  NullBool  .Coalesce(NullyTrue,  NullText       ));
        NoNullRet("True",  NullBool  .Coalesce(NullyTrue,  Empty          ));
        NoNullRet("True",  NullBool  .Coalesce(NullyTrue,  Space          ));
        NoNullRet("True",  NullBool  .Coalesce(NullyTrue,  Text           ));
        NoNullRet("True",  NullBool  .Coalesce(NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  NullBool  .Coalesce(NullyTrue,  NullySpace     ));
        NoNullRet("True",  NullBool  .Coalesce(NullyTrue,  NullyFilledText));
        NoNullRet("",      NullBool  .Coalesce(false,      NullText       ));
        NoNullRet("",      NullBool  .Coalesce(false,      Empty          ));
        NoNullRet(" ",     NullBool  .Coalesce(false,      Space          ));
        NoNullRet(Text,    NullBool  .Coalesce(false,      Text           ));
        NoNullRet("",      NullBool  .Coalesce(false,      NullyEmpty     ));
        NoNullRet(" ",     NullBool  .Coalesce(false,      NullySpace     ));
        NoNullRet(Text,    NullBool  .Coalesce(false,      NullyFilledText));
        NoNullRet("True",  NullBool  .Coalesce(true,       NullText       ));
        NoNullRet("True",  NullBool  .Coalesce(true,       Empty          ));
        NoNullRet("True",  NullBool  .Coalesce(true,       Space          ));
        NoNullRet("True",  NullBool  .Coalesce(true,       Text           ));
        NoNullRet("True",  NullBool  .Coalesce(true,       NullyEmpty     ));
        NoNullRet("True",  NullBool  .Coalesce(true,       NullySpace     ));
        NoNullRet("True",  NullBool  .Coalesce(true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch2()
    {
        NoNullRet("",      NullyFalse.Coalesce(NullBool,   NullText       ));
        NoNullRet("",      NullyFalse.Coalesce(NullBool,   Empty          ));
        NoNullRet(" ",     NullyFalse.Coalesce(NullBool,   Space          ));
        NoNullRet(Text,    NullyFalse.Coalesce(NullBool,   Text           ));
        NoNullRet("",      NullyFalse.Coalesce(NullBool,   NullyEmpty     ));
        NoNullRet(" ",     NullyFalse.Coalesce(NullBool,   NullySpace     ));
        NoNullRet(Text,    NullyFalse.Coalesce(NullBool,   NullyFilledText));
        NoNullRet("",      NullyFalse.Coalesce(NullyFalse, NullText       ));
        NoNullRet("",      NullyFalse.Coalesce(NullyFalse, Empty          ));
        NoNullRet(" ",     NullyFalse.Coalesce(NullyFalse, Space          ));
        NoNullRet(Text,    NullyFalse.Coalesce(NullyFalse, Text           ));
        NoNullRet("",      NullyFalse.Coalesce(NullyFalse, NullyEmpty     ));
        NoNullRet(" ",     NullyFalse.Coalesce(NullyFalse, NullySpace     ));
        NoNullRet(Text,    NullyFalse.Coalesce(NullyFalse, NullyFilledText));
        NoNullRet("True",  NullyFalse.Coalesce(NullyTrue,  NullText       ));
        NoNullRet("True",  NullyFalse.Coalesce(NullyTrue,  Empty          ));
        NoNullRet("True",  NullyFalse.Coalesce(NullyTrue,  Space          ));
        NoNullRet("True",  NullyFalse.Coalesce(NullyTrue,  Text           ));
        NoNullRet("True",  NullyFalse.Coalesce(NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  NullyFalse.Coalesce(NullyTrue,  NullySpace     ));
        NoNullRet("True",  NullyFalse.Coalesce(NullyTrue,  NullyFilledText));
        NoNullRet("",      NullyFalse.Coalesce(false,      NullText       ));
        NoNullRet("",      NullyFalse.Coalesce(false,      Empty          ));
        NoNullRet(" ",     NullyFalse.Coalesce(false,      Space          ));
        NoNullRet(Text,    NullyFalse.Coalesce(false,      Text           ));
        NoNullRet("",      NullyFalse.Coalesce(false,      NullyEmpty     ));
        NoNullRet(" ",     NullyFalse.Coalesce(false,      NullySpace     ));
        NoNullRet(Text,    NullyFalse.Coalesce(false,      NullyFilledText));
        NoNullRet("True",  NullyFalse.Coalesce(true,       NullText       ));
        NoNullRet("True",  NullyFalse.Coalesce(true,       Empty          ));
        NoNullRet("True",  NullyFalse.Coalesce(true,       Space          ));
        NoNullRet("True",  NullyFalse.Coalesce(true,       Text           ));
        NoNullRet("True",  NullyFalse.Coalesce(true,       NullyEmpty     ));
        NoNullRet("True",  NullyFalse.Coalesce(true,       NullySpace     ));
        NoNullRet("True",  NullyFalse.Coalesce(true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch3()
    {
        NoNullRet("True",  NullyTrue .Coalesce(NullBool,   NullText       ));
        NoNullRet("True",  NullyTrue .Coalesce(NullBool,   Empty          ));
        NoNullRet("True",  NullyTrue .Coalesce(NullBool,   Space          ));
        NoNullRet("True",  NullyTrue .Coalesce(NullBool,   Text           ));
        NoNullRet("True",  NullyTrue .Coalesce(NullBool,   NullyEmpty     ));
        NoNullRet("True",  NullyTrue .Coalesce(NullBool,   NullySpace     ));
        NoNullRet("True",  NullyTrue .Coalesce(NullBool,   NullyFilledText));
        NoNullRet("True",  NullyTrue .Coalesce(NullyFalse, NullText       ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyFalse, Empty          ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyFalse, Space          ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyFalse, Text           ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyFalse, NullyEmpty     ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyFalse, NullySpace     ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyFalse, NullyFilledText));
        NoNullRet("True",  NullyTrue .Coalesce(NullyTrue,  NullText       ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyTrue,  Empty          ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyTrue,  Space          ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyTrue,  Text           ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyTrue,  NullySpace     ));
        NoNullRet("True",  NullyTrue .Coalesce(NullyTrue,  NullyFilledText));
        NoNullRet("True",  NullyTrue .Coalesce(false,      NullText       ));
        NoNullRet("True",  NullyTrue .Coalesce(false,      Empty          ));
        NoNullRet("True",  NullyTrue .Coalesce(false,      Space          ));
        NoNullRet("True",  NullyTrue .Coalesce(false,      Text           ));
        NoNullRet("True",  NullyTrue .Coalesce(false,      NullyEmpty     ));
        NoNullRet("True",  NullyTrue .Coalesce(false,      NullySpace     ));
        NoNullRet("True",  NullyTrue .Coalesce(false,      NullyFilledText));
        NoNullRet("True",  NullyTrue .Coalesce(true,       NullText       ));
        NoNullRet("True",  NullyTrue .Coalesce(true,       Empty          ));
        NoNullRet("True",  NullyTrue .Coalesce(true,       Space          ));
        NoNullRet("True",  NullyTrue .Coalesce(true,       Text           ));
        NoNullRet("True",  NullyTrue .Coalesce(true,       NullyEmpty     ));
        NoNullRet("True",  NullyTrue .Coalesce(true,       NullySpace     ));
        NoNullRet("True",  NullyTrue .Coalesce(true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch4()
    {
        NoNullRet("",      false     .Coalesce(NullBool,   NullText       ));
        NoNullRet("",      false     .Coalesce(NullBool,   Empty          ));
        NoNullRet(" ",     false     .Coalesce(NullBool,   Space          ));
        NoNullRet(Text,    false     .Coalesce(NullBool,   Text           ));
        NoNullRet("",      false     .Coalesce(NullBool,   NullyEmpty     ));
        NoNullRet(" ",     false     .Coalesce(NullBool,   NullySpace     ));
        NoNullRet(Text,    false     .Coalesce(NullBool,   NullyFilledText));
        NoNullRet("",      false     .Coalesce(NullyFalse, NullText       ));
        NoNullRet("",      false     .Coalesce(NullyFalse, Empty          ));
        NoNullRet(" ",     false     .Coalesce(NullyFalse, Space          ));
        NoNullRet(Text,    false     .Coalesce(NullyFalse, Text           ));
        NoNullRet("",      false     .Coalesce(NullyFalse, NullyEmpty     ));
        NoNullRet(" ",     false     .Coalesce(NullyFalse, NullySpace     ));
        NoNullRet(Text,    false     .Coalesce(NullyFalse, NullyFilledText));
        NoNullRet("True",  false     .Coalesce(NullyTrue,  NullText       ));
        NoNullRet("True",  false     .Coalesce(NullyTrue,  Empty          ));
        NoNullRet("True",  false     .Coalesce(NullyTrue,  Space          ));
        NoNullRet("True",  false     .Coalesce(NullyTrue,  Text           ));
        NoNullRet("True",  false     .Coalesce(NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  false     .Coalesce(NullyTrue,  NullySpace     ));
        NoNullRet("True",  false     .Coalesce(NullyTrue,  NullyFilledText));
        NoNullRet("",      false     .Coalesce(false,      NullText       ));
        NoNullRet("",      false     .Coalesce(false,      Empty          ));
        NoNullRet(" ",     false     .Coalesce(false,      Space          ));
        NoNullRet(Text,    false     .Coalesce(false,      Text           ));
        NoNullRet("",      false     .Coalesce(false,      NullyEmpty     ));
        NoNullRet(" ",     false     .Coalesce(false,      NullySpace     ));
        NoNullRet(Text,    false     .Coalesce(false,      NullyFilledText));
        NoNullRet("True",  false     .Coalesce(true,       NullText       ));
        NoNullRet("True",  false     .Coalesce(true,       Empty          ));
        NoNullRet("True",  false     .Coalesce(true,       Space          ));
        NoNullRet("True",  false     .Coalesce(true,       Text           ));
        NoNullRet("True",  false     .Coalesce(true,       NullyEmpty     ));
        NoNullRet("True",  false     .Coalesce(true,       NullySpace     ));
        NoNullRet("True",  false     .Coalesce(true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_Extensions_Batch5()
    {
        NoNullRet("True",  true      .Coalesce(NullBool,   NullText       ));
        NoNullRet("True",  true      .Coalesce(NullBool,   Empty          ));
        NoNullRet("True",  true      .Coalesce(NullBool,   Space          ));
        NoNullRet("True",  true      .Coalesce(NullBool,   Text           ));
        NoNullRet("True",  true      .Coalesce(NullBool,   NullyEmpty     ));
        NoNullRet("True",  true      .Coalesce(NullBool,   NullySpace     ));
        NoNullRet("True",  true      .Coalesce(NullBool,   NullyFilledText));
        NoNullRet("True",  true      .Coalesce(NullyFalse, NullText       ));
        NoNullRet("True",  true      .Coalesce(NullyFalse, Empty          ));
        NoNullRet("True",  true      .Coalesce(NullyFalse, Space          ));
        NoNullRet("True",  true      .Coalesce(NullyFalse, Text           ));
        NoNullRet("True",  true      .Coalesce(NullyFalse, NullyEmpty     ));
        NoNullRet("True",  true      .Coalesce(NullyFalse, NullySpace     ));
        NoNullRet("True",  true      .Coalesce(NullyFalse, NullyFilledText));
        NoNullRet("True",  true      .Coalesce(NullyTrue,  NullText       ));
        NoNullRet("True",  true      .Coalesce(NullyTrue,  Empty          ));
        NoNullRet("True",  true      .Coalesce(NullyTrue,  Space          ));
        NoNullRet("True",  true      .Coalesce(NullyTrue,  Text           ));
        NoNullRet("True",  true      .Coalesce(NullyTrue,  NullyEmpty     ));
        NoNullRet("True",  true      .Coalesce(NullyTrue,  NullySpace     ));
        NoNullRet("True",  true      .Coalesce(NullyTrue,  NullyFilledText));
        NoNullRet("True",  true      .Coalesce(false,      Empty          ));
        NoNullRet("True",  true      .Coalesce(false,      Space          ));
        NoNullRet("True",  true      .Coalesce(false,      Text           ));
        NoNullRet("True",  true      .Coalesce(false,      NullyEmpty     ));
        NoNullRet("True",  true      .Coalesce(false,      NullySpace     ));
        NoNullRet("True",  true      .Coalesce(false,      NullyFilledText));
        NoNullRet("True",  true      .Coalesce(true,       NullText       ));
        NoNullRet("True",  true      .Coalesce(true,       Empty          ));
        NoNullRet("True",  true      .Coalesce(true,       Space          ));
        NoNullRet("True",  true      .Coalesce(true,       Text           ));
        NoNullRet("True",  true      .Coalesce(true,       NullyEmpty     ));
        NoNullRet("True",  true      .Coalesce(true,       NullySpace     ));
        NoNullRet("True",  true      .Coalesce(true,       NullyFilledText));
    }
}