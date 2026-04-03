namespace JJ.Framework.Existence.Core.BoolToText.Tests;

[TestClass]
public class Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInFront : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInFront_Batch1()
    {
             NoNullRet("",      NullBool  .Coalesce(                    NullyFalse, NullText       ));
             NoNullRet("",      NullBool  .Coalesce(zeroMatters: false, NullyFalse, NullText       ));
             NoNullRet("",      NullBool  .Coalesce(             false, NullyFalse, NullText       ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        NullyFalse, NullText       ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  NullyFalse, NullText       ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  NullyFalse, NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("",      NullBool  .Coalesce(                    NullyFalse, Empty          ));
             NoNullRet("",      NullBool  .Coalesce(zeroMatters: false, NullyFalse, Empty          ));
             NoNullRet("",      NullBool  .Coalesce(             false, NullyFalse, Empty          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        NullyFalse, Empty          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  NullyFalse, Empty          ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  NullyFalse, Empty          )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     NullBool  .Coalesce(                    NullyFalse, Space          ));
             NoNullRet(" ",     NullBool  .Coalesce(zeroMatters: false, NullyFalse, Space          ));
             NoNullRet(" ",     NullBool  .Coalesce(             false, NullyFalse, Space          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        NullyFalse, Space          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  NullyFalse, Space          ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  NullyFalse, Space          )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    NullBool  .Coalesce(                    NullyFalse, Text           ));
             NoNullRet(Text,    NullBool  .Coalesce(zeroMatters: false, NullyFalse, Text           ));
             NoNullRet(Text,    NullBool  .Coalesce(             false, NullyFalse, Text           ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        NullyFalse, Text           ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  NullyFalse, Text           ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  NullyFalse, Text           )), "Actual <True>"); // Not a flag
             NoNullRet("",      NullBool  .Coalesce(                    NullyFalse, NullyEmpty     ));
             NoNullRet("",      NullBool  .Coalesce(zeroMatters: false, NullyFalse, NullyEmpty     ));
             NoNullRet("",      NullBool  .Coalesce(             false, NullyFalse, NullyEmpty     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        NullyFalse, NullyEmpty     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  NullyFalse, NullyEmpty     ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  NullyFalse, NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     NullBool  .Coalesce(                    NullyFalse, NullySpace     ));
             NoNullRet(" ",     NullBool  .Coalesce(zeroMatters: false, NullyFalse, NullySpace     ));
             NoNullRet(" ",     NullBool  .Coalesce(             false, NullyFalse, NullySpace     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        NullyFalse, NullySpace     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  NullyFalse, NullySpace     ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  NullyFalse, NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    NullBool  .Coalesce(                    NullyFalse, NullyFilledText));
             NoNullRet(Text,    NullBool  .Coalesce(zeroMatters: false, NullyFalse, NullyFilledText));
             NoNullRet(Text,    NullBool  .Coalesce(             false, NullyFalse, NullyFilledText));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        NullyFalse, NullyFilledText));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  NullyFalse, NullyFilledText));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  NullyFalse, NullyFilledText)), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullBool  .Coalesce(                    NullyTrue,  NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(             false, NullyTrue,  NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        NullyTrue,  NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  NullyTrue,  NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(                    NullyTrue,  Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(             false, NullyTrue,  Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        NullyTrue,  Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  NullyTrue,  Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(                    NullyTrue,  Space          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  Space          ));
             NoNullRet("True",  NullBool  .Coalesce(             false, NullyTrue,  Space          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        NullyTrue,  Space          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  Space          ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  NullyTrue,  Space          ));
             NoNullRet("True",  NullBool  .Coalesce(                    NullyTrue,  Text           ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  Text           ));
             NoNullRet("True",  NullBool  .Coalesce(             false, NullyTrue,  Text           ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        NullyTrue,  Text           ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  Text           ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  NullyTrue,  Text           ));
             NoNullRet("True",  NullBool  .Coalesce(                    NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(             false, NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(                    NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(             false, NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(                    NullyTrue,  NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(             false, NullyTrue,  NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        NullyTrue,  NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(             true,  NullyTrue,  NullyFilledText));
             NoNullRet("",      NullBool  .Coalesce(                    false,      NullText       ));
             NoNullRet("",      NullBool  .Coalesce(zeroMatters: false, false,      NullText       ));
             NoNullRet("",      NullBool  .Coalesce(             false, false,      NullText       ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        false,      NullText       ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  false,      NullText       ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  false,      NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("",      NullBool  .Coalesce(                    false,      Empty          ));
             NoNullRet("",      NullBool  .Coalesce(zeroMatters: false, false,      Empty          ));
             NoNullRet("",      NullBool  .Coalesce(             false, false,      Empty          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        false,      Empty          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  false,      Empty          ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  false,      Empty          )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     NullBool  .Coalesce(                    false,      Space          ));
             NoNullRet(" ",     NullBool  .Coalesce(zeroMatters: false, false,      Space          ));
             NoNullRet(" ",     NullBool  .Coalesce(             false, false,      Space          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        false,      Space          ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  false,      Space          ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  false,      Space          )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    NullBool  .Coalesce(                    false,      Text           ));
             NoNullRet(Text,    NullBool  .Coalesce(zeroMatters: false, false,      Text           ));
             NoNullRet(Text,    NullBool  .Coalesce(             false, false,      Text           ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        false,      Text           ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  false,      Text           ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  false,      Text           )), "Actual <True>"); // Not a flag
             NoNullRet("",      NullBool  .Coalesce(                    false,      NullyEmpty     ));
             NoNullRet("",      NullBool  .Coalesce(zeroMatters: false, false,      NullyEmpty     ));
             NoNullRet("",      NullBool  .Coalesce(             false, false,      NullyEmpty     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        false,      NullyEmpty     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  false,      NullyEmpty     ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  false,      NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     NullBool  .Coalesce(                    false,      NullySpace     ));
             NoNullRet(" ",     NullBool  .Coalesce(zeroMatters: false, false,      NullySpace     ));
             NoNullRet(" ",     NullBool  .Coalesce(             false, false,      NullySpace     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        false,      NullySpace     ));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  false,      NullySpace     ));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  false,      NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    NullBool  .Coalesce(                    false,      NullyFilledText));
             NoNullRet(Text,    NullBool  .Coalesce(zeroMatters: false, false,      NullyFilledText));
             NoNullRet(Text,    NullBool  .Coalesce(             false, false,      NullyFilledText));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters,        false,      NullyFilledText));
             NoNullRet("False", NullBool  .Coalesce(zeroMatters: true,  false,      NullyFilledText));
Throws(() => NoNullRet("False", NullBool  .Coalesce(             true,  false,      NullyFilledText)), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullBool  .Coalesce(                    true,       NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, true,       NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(             false, true,       NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        true,       NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  true,       NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  true,       NullText       ));
             NoNullRet("True",  NullBool  .Coalesce(                    true,       Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, true,       Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(             false, true,       Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        true,       Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  true,       Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  true,       Empty          ));
             NoNullRet("True",  NullBool  .Coalesce(                    true,       Space          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, true,       Space          ));
             NoNullRet("True",  NullBool  .Coalesce(             false, true,       Space          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        true,       Space          ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  true,       Space          ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  true,       Space          ));
             NoNullRet("True",  NullBool  .Coalesce(                    true,       Text           ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, true,       Text           ));
             NoNullRet("True",  NullBool  .Coalesce(             false, true,       Text           ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        true,       Text           ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  true,       Text           ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  true,       Text           ));
             NoNullRet("True",  NullBool  .Coalesce(                    true,       NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, true,       NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(             false, true,       NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        true,       NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  true,       NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  true,       NullyEmpty     ));
             NoNullRet("True",  NullBool  .Coalesce(                    true,       NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, true,       NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(             false, true,       NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        true,       NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  true,       NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(             true,  true,       NullySpace     ));
             NoNullRet("True",  NullBool  .Coalesce(                    true,       NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: false, true,       NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(             false, true,       NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters,        true,       NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(zeroMatters: true,  true,       NullyFilledText));
             NoNullRet("True",  NullBool  .Coalesce(             true,  true,       NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInFront_Batch2()
    {
             NoNullRet("",      NullyFalse.Coalesce(                    NullBool,   NullText       ));
             NoNullRet("",      NullyFalse.Coalesce(zeroMatters: false, NullBool,   NullText       ));
             NoNullRet("",      NullyFalse.Coalesce(             false, NullBool,   NullText       ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullBool,   NullText       ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullBool,   NullText       ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullBool,   NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("",      NullyFalse.Coalesce(                    NullBool,   Empty          ));
             NoNullRet("",      NullyFalse.Coalesce(zeroMatters: false, NullBool,   Empty          ));
             NoNullRet("",      NullyFalse.Coalesce(             false, NullBool,   Empty          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullBool,   Empty          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullBool,   Empty          ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullBool,   Empty          )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     NullyFalse.Coalesce(                    NullBool,   Space          ));
             NoNullRet(" ",     NullyFalse.Coalesce(zeroMatters: false, NullBool,   Space          ));
             NoNullRet(" ",     NullyFalse.Coalesce(             false, NullBool,   Space          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullBool,   Space          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullBool,   Space          ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullBool,   Space          )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    NullyFalse.Coalesce(                    NullBool,   Text           ));
             NoNullRet(Text,    NullyFalse.Coalesce(zeroMatters: false, NullBool,   Text           ));
             NoNullRet(Text,    NullyFalse.Coalesce(             false, NullBool,   Text           ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullBool,   Text           ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullBool,   Text           ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullBool,   Text           )), "Actual <True>"); // Not a flag
             NoNullRet("",      NullyFalse.Coalesce(                    NullBool,   NullyEmpty     ));
             NoNullRet("",      NullyFalse.Coalesce(zeroMatters: false, NullBool,   NullyEmpty     ));
             NoNullRet("",      NullyFalse.Coalesce(             false, NullBool,   NullyEmpty     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullBool,   NullyEmpty     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullBool,   NullyEmpty     ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullBool,   NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     NullyFalse.Coalesce(                    NullBool,   NullySpace     ));
             NoNullRet(" ",     NullyFalse.Coalesce(zeroMatters: false, NullBool,   NullySpace     ));
             NoNullRet(" ",     NullyFalse.Coalesce(             false, NullBool,   NullySpace     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullBool,   NullySpace     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullBool,   NullySpace     ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullBool,   NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    NullyFalse.Coalesce(                    NullBool,   NullyFilledText));
             NoNullRet(Text,    NullyFalse.Coalesce(zeroMatters: false, NullBool,   NullyFilledText));
             NoNullRet(Text,    NullyFalse.Coalesce(             false, NullBool,   NullyFilledText));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullBool,   NullyFilledText));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullBool,   NullyFilledText));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullBool,   NullyFilledText)), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    NullyTrue,  NullText       ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  NullText       ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, NullyTrue,  NullText       ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullyTrue,  NullText       ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  NullText       ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullyTrue,  NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    NullyTrue,  Empty          ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  Empty          ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, NullyTrue,  Empty          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullyTrue,  Empty          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  Empty          ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullyTrue,  Empty          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    NullyTrue,  Space          ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  Space          ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, NullyTrue,  Space          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullyTrue,  Space          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  Space          ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullyTrue,  Space          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    NullyTrue,  Text           ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  Text           ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, NullyTrue,  Text           ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullyTrue,  Text           ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  Text           ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullyTrue,  Text           )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, NullyTrue,  NullyEmpty     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullyTrue,  NullyEmpty     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  NullyEmpty     ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullyTrue,  NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  NullySpace     ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, NullyTrue,  NullySpace     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullyTrue,  NullySpace     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  NullySpace     ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullyTrue,  NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    NullyTrue,  NullyFilledText));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  NullyFilledText));
             NoNullRet("True",  NullyFalse.Coalesce(             false, NullyTrue,  NullyFilledText));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        NullyTrue,  NullyFilledText));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  NullyFilledText));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  NullyTrue,  NullyFilledText)), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    true,       NullText       ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, true,       NullText       ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, true,       NullText       ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        true,       NullText       ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  true,       NullText       ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  true,       NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    true,       Empty          ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, true,       Empty          ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, true,       Empty          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        true,       Empty          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  true,       Empty          ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  true,       Empty          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    true,       Space          ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, true,       Space          ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, true,       Space          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        true,       Space          ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  true,       Space          ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  true,       Space          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    true,       Text           ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, true,       Text           ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, true,       Text           ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        true,       Text           ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  true,       Text           ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  true,       Text           )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    true,       NullyEmpty     ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, true,       NullyEmpty     ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, true,       NullyEmpty     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        true,       NullyEmpty     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  true,       NullyEmpty     ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  true,       NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    true,       NullySpace     ));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, true,       NullySpace     ));
             NoNullRet("True",  NullyFalse.Coalesce(             false, true,       NullySpace     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        true,       NullySpace     ));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  true,       NullySpace     ));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  true,       NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  NullyFalse.Coalesce(                    true,       NullyFilledText));
             NoNullRet("True",  NullyFalse.Coalesce(zeroMatters: false, true,       NullyFilledText));
             NoNullRet("True",  NullyFalse.Coalesce(             false, true,       NullyFilledText));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters,        true,       NullyFilledText));
             NoNullRet("False", NullyFalse.Coalesce(zeroMatters: true,  true,       NullyFilledText));
Throws(() => NoNullRet("False", NullyFalse.Coalesce(             true,  true,       NullyFilledText)), "Actual <True>"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInFront_Batch3()
    {
             NoNullRet("True",  NullyTrue .Coalesce(                    NullBool,   NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullBool,   NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullBool,   NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullBool,   NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullBool,   NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullBool,   Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullBool,   Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullBool,   Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullBool,   Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullBool,   Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullBool,   Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullBool,   Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullBool,   Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullBool,   Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullBool,   Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullBool,   Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullBool,   Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullBool,   Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullBool,   Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullBool,   Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullBool,   NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullBool,   NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullBool,   NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullBool,   NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullBool,   NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullBool,   NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullBool,   NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullBool,   NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullBool,   NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullBool,   NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullBool,   NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullBool,   NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullBool,   NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullBool,   NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullBool,   NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullyFalse, NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullyFalse, NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullyFalse, NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullyFalse, NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullyFalse, Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullyFalse, Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullyFalse, Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullyFalse, Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullyFalse, Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullyFalse, Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullyFalse, Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullyFalse, Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullyFalse, Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullyFalse, Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullyFalse, Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullyFalse, Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullyFalse, NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullyFalse, NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullyFalse, NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullyFalse, NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullyFalse, NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullyFalse, NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullyFalse, NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullyFalse, NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(                    NullyFalse, NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(             false, NullyFalse, NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        NullyFalse, NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  NullyFalse, NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(                    false,      NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, false,      NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, false,      NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        false,      NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  false,      NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  false,      NullText       ));
             NoNullRet("True",  NullyTrue .Coalesce(                    false,      Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, false,      Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, false,      Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        false,      Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  false,      Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  false,      Empty          ));
             NoNullRet("True",  NullyTrue .Coalesce(                    false,      Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, false,      Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, false,      Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        false,      Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  false,      Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  false,      Space          ));
             NoNullRet("True",  NullyTrue .Coalesce(                    false,      Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, false,      Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, false,      Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        false,      Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  false,      Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  false,      Text           ));
             NoNullRet("True",  NullyTrue .Coalesce(                    false,      NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, false,      NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, false,      NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        false,      NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  false,      NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  false,      NullyEmpty     ));
             NoNullRet("True",  NullyTrue .Coalesce(                    false,      NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, false,      NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(             false, false,      NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        false,      NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  false,      NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  false,      NullySpace     ));
             NoNullRet("True",  NullyTrue .Coalesce(                    false,      NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: false, false,      NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(             false, false,      NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters,        false,      NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(zeroMatters: true,  false,      NullyFilledText));
             NoNullRet("True",  NullyTrue .Coalesce(             true,  false,      NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInFront_Batch4()
    {
             NoNullRet("",      false     .Coalesce(                    NullBool,   NullText       ));
             NoNullRet("",      false     .Coalesce(zeroMatters: false, NullBool,   NullText       ));
             NoNullRet("",      false     .Coalesce(             false, NullBool,   NullText       ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullBool,   NullText       ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullBool,   NullText       ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullBool,   NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("",      false     .Coalesce(                    NullBool,   Empty          ));
             NoNullRet("",      false     .Coalesce(zeroMatters: false, NullBool,   Empty          ));
             NoNullRet("",      false     .Coalesce(             false, NullBool,   Empty          ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullBool,   Empty          ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullBool,   Empty          ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullBool,   Empty          )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     false     .Coalesce(                    NullBool,   Space          ));
             NoNullRet(" ",     false     .Coalesce(zeroMatters: false, NullBool,   Space          ));
             NoNullRet(" ",     false     .Coalesce(             false, NullBool,   Space          ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullBool,   Space          ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullBool,   Space          ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullBool,   Space          )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    false     .Coalesce(                    NullBool,   Text           ));
             NoNullRet(Text,    false     .Coalesce(zeroMatters: false, NullBool,   Text           ));
             NoNullRet(Text,    false     .Coalesce(             false, NullBool,   Text           ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullBool,   Text           ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullBool,   Text           ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullBool,   Text           )), "Actual <True>"); // Not a flag
             NoNullRet("",      false     .Coalesce(                    NullBool,   NullyEmpty     ));
             NoNullRet("",      false     .Coalesce(zeroMatters: false, NullBool,   NullyEmpty     ));
             NoNullRet("",      false     .Coalesce(             false, NullBool,   NullyEmpty     ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullBool,   NullyEmpty     ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullBool,   NullyEmpty     ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullBool,   NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet(" ",     false     .Coalesce(                    NullBool,   NullySpace     ));
             NoNullRet(" ",     false     .Coalesce(zeroMatters: false, NullBool,   NullySpace     ));
             NoNullRet(" ",     false     .Coalesce(             false, NullBool,   NullySpace     ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullBool,   NullySpace     ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullBool,   NullySpace     ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullBool,   NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet(Text,    false     .Coalesce(                    NullBool,   NullyFilledText));
             NoNullRet(Text,    false     .Coalesce(zeroMatters: false, NullBool,   NullyFilledText));
             NoNullRet(Text,    false     .Coalesce(             false, NullBool,   NullyFilledText));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullBool,   NullyFilledText));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullBool,   NullyFilledText));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullBool,   NullyFilledText)), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    NullyTrue,  NullText       ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, NullyTrue,  NullText       ));
             NoNullRet("True",  false     .Coalesce(             false, NullyTrue,  NullText       ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullyTrue,  NullText       ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullyTrue,  NullText       ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullyTrue,  NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    NullyTrue,  Empty          ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, NullyTrue,  Empty          ));
             NoNullRet("True",  false     .Coalesce(             false, NullyTrue,  Empty          ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullyTrue,  Empty          ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullyTrue,  Empty          ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullyTrue,  Empty          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    NullyTrue,  Space          ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, NullyTrue,  Space          ));
             NoNullRet("True",  false     .Coalesce(             false, NullyTrue,  Space          ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullyTrue,  Space          ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullyTrue,  Space          ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullyTrue,  Space          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    NullyTrue,  Text           ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, NullyTrue,  Text           ));
             NoNullRet("True",  false     .Coalesce(             false, NullyTrue,  Text           ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullyTrue,  Text           ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullyTrue,  Text           ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullyTrue,  Text           )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, NullyTrue,  NullyEmpty     ));
             NoNullRet("True",  false     .Coalesce(             false, NullyTrue,  NullyEmpty     ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullyTrue,  NullyEmpty     ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullyTrue,  NullyEmpty     ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullyTrue,  NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    NullyTrue,  NullySpace     ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, NullyTrue,  NullySpace     ));
             NoNullRet("True",  false     .Coalesce(             false, NullyTrue,  NullySpace     ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullyTrue,  NullySpace     ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullyTrue,  NullySpace     ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullyTrue,  NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    NullyTrue,  NullyFilledText));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, NullyTrue,  NullyFilledText));
             NoNullRet("True",  false     .Coalesce(             false, NullyTrue,  NullyFilledText));
             NoNullRet("False", false     .Coalesce(zeroMatters,        NullyTrue,  NullyFilledText));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  NullyTrue,  NullyFilledText));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  NullyTrue,  NullyFilledText)), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    true,       NullText       ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, true,       NullText       ));
             NoNullRet("True",  false     .Coalesce(             false, true,       NullText       ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        true,       NullText       ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  true,       NullText       ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  true,       NullText       )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    true,       Empty          ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, true,       Empty          ));
             NoNullRet("True",  false     .Coalesce(             false, true,       Empty          ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        true,       Empty          ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  true,       Empty          ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  true,       Empty          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    true,       Space          ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, true,       Space          ));
             NoNullRet("True",  false     .Coalesce(             false, true,       Space          ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        true,       Space          ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  true,       Space          ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  true,       Space          )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    true,       Text           ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, true,       Text           ));
             NoNullRet("True",  false     .Coalesce(             false, true,       Text           ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        true,       Text           ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  true,       Text           ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  true,       Text           )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    true,       NullyEmpty     ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, true,       NullyEmpty     ));
             NoNullRet("True",  false     .Coalesce(             false, true,       NullyEmpty     ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        true,       NullyEmpty     ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  true,       NullyEmpty     ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  true,       NullyEmpty     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    true,       NullySpace     ));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, true,       NullySpace     ));
             NoNullRet("True",  false     .Coalesce(             false, true,       NullySpace     ));
             NoNullRet("False", false     .Coalesce(zeroMatters,        true,       NullySpace     ));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  true,       NullySpace     ));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  true,       NullySpace     )), "Actual <True>"); // Not a flag
             NoNullRet("True",  false     .Coalesce(                    true,       NullyFilledText));
             NoNullRet("True",  false     .Coalesce(zeroMatters: false, true,       NullyFilledText));
             NoNullRet("True",  false     .Coalesce(             false, true,       NullyFilledText));
             NoNullRet("False", false     .Coalesce(zeroMatters,        true,       NullyFilledText));
             NoNullRet("False", false     .Coalesce(zeroMatters: true,  true,       NullyFilledText));
Throws(() => NoNullRet("False", false     .Coalesce(             true,  true,       NullyFilledText)), "Actual <True>"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInFront_Batch5()
    {
             NoNullRet("True",  true      .Coalesce(                     NullBool,   NullText        ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullBool,   NullText        ));
             NoNullRet("True",  true      .Coalesce(             false,  NullBool,   NullText        ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullBool,   NullText        ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullBool,   NullText        ));
             NoNullRet("True",  true      .Coalesce(             true,   NullBool,   NullText        ));
             NoNullRet("True",  true      .Coalesce(                     NullBool,   Empty           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullBool,   Empty           ));
             NoNullRet("True",  true      .Coalesce(             false,  NullBool,   Empty           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullBool,   Empty           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullBool,   Empty           ));
             NoNullRet("True",  true      .Coalesce(             true,   NullBool,   Empty           ));
             NoNullRet("True",  true      .Coalesce(                     NullBool,   Space           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullBool,   Space           ));
             NoNullRet("True",  true      .Coalesce(             false,  NullBool,   Space           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullBool,   Space           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullBool,   Space           ));
             NoNullRet("True",  true      .Coalesce(             true,   NullBool,   Space           ));
             NoNullRet("True",  true      .Coalesce(                     NullBool,   Text            ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullBool,   Text            ));
             NoNullRet("True",  true      .Coalesce(             false,  NullBool,   Text            ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullBool,   Text            ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullBool,   Text            ));
             NoNullRet("True",  true      .Coalesce(             true,   NullBool,   Text            ));
             NoNullRet("True",  true      .Coalesce(                     NullBool,   NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullBool,   NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(             false,  NullBool,   NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullBool,   NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullBool,   NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(             true,   NullBool,   NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(                     NullBool,   NullySpace      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullBool,   NullySpace      ));
             NoNullRet("True",  true      .Coalesce(             false,  NullBool,   NullySpace      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullBool,   NullySpace      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullBool,   NullySpace      ));
             NoNullRet("True",  true      .Coalesce(             true,   NullBool,   NullySpace      ));
             NoNullRet("True",  true      .Coalesce(                     NullBool,   NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullBool,   NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(             false,  NullBool,   NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullBool,   NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullBool,   NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(             true,   NullBool,   NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(                     NullyFalse, NullText        ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullyFalse, NullText        ));
             NoNullRet("True",  true      .Coalesce(             false,  NullyFalse, NullText        ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullyFalse, NullText        ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullyFalse, NullText        ));
             NoNullRet("True",  true      .Coalesce(             true,   NullyFalse, NullText        ));
             NoNullRet("True",  true      .Coalesce(                     NullyFalse, Empty           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullyFalse, Empty           ));
             NoNullRet("True",  true      .Coalesce(             false,  NullyFalse, Empty           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullyFalse, Empty           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullyFalse, Empty           ));
             NoNullRet("True",  true      .Coalesce(             true,   NullyFalse, Empty           ));
             NoNullRet("True",  true      .Coalesce(                     NullyFalse, Space           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullyFalse, Space           ));
             NoNullRet("True",  true      .Coalesce(             false,  NullyFalse, Space           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullyFalse, Space           ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullyFalse, Space           ));
             NoNullRet("True",  true      .Coalesce(             true,   NullyFalse, Space           ));
             NoNullRet("True",  true      .Coalesce(                     NullyFalse, Text            ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullyFalse, Text            ));
             NoNullRet("True",  true      .Coalesce(             false,  NullyFalse, Text            ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullyFalse, Text            ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullyFalse, Text            ));
             NoNullRet("True",  true      .Coalesce(             true,   NullyFalse, Text            ));
             NoNullRet("True",  true      .Coalesce(                     NullyFalse, NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullyFalse, NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(             false,  NullyFalse, NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullyFalse, NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullyFalse, NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(             true,   NullyFalse, NullyEmpty      ));
             NoNullRet("True",  true      .Coalesce(                     NullyFalse, NullySpace      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullyFalse, NullySpace      ));
             NoNullRet("True",  true      .Coalesce(             false,  NullyFalse, NullySpace      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullyFalse, NullySpace      ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullyFalse, NullySpace      ));
             NoNullRet("True",  true      .Coalesce(             true,   NullyFalse, NullySpace      ));
             NoNullRet("True",  true      .Coalesce(                     NullyFalse, NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: false,  NullyFalse, NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(             false,  NullyFalse, NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(zeroMatters,         NullyFalse, NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(zeroMatters: true,   NullyFalse, NullyFilledText ));
             NoNullRet("True",  true      .Coalesce(             true,   NullyFalse, NullyFilledText ));
    }
}