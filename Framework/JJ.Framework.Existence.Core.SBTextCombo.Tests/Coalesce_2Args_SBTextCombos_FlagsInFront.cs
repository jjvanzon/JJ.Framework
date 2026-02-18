namespace JJ.Framework.Existence.Core.SBTextCombo.Tests;

[TestClass]
public class Coalesce_2Args_SBTextCombos_FlagsInFront : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersNoFlagsInBack()
    {
        NoNullRet(Text,       Coalesce(spaceMatters: false, NullSB,        Text));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, FilledSB,      Text));
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullyFilledSB, Text));
        NoNullRet(Text,       NullSB       .Coalesce(spaceMatters: false,  Text));
        NoNullRet("FilledSB", FilledSB     .Coalesce(spaceMatters: false,  Text));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(spaceMatters: false,  Text));
    }

    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(" ",      Coalesce(spaceMatters,       NullySpaceSB, NullyFilledText));
        NoNullRet(" ",      Coalesce(spaceMatters: true, NullySpaceSB, NullyFilledText));
        NoNullRet("Filled", Coalesce(spaceMatters,       NullyEmptySB, NullyFilledText));
        NoNullRet("Filled", Coalesce(spaceMatters: true, NullyEmptySB, NullyFilledText));
        NoNullRet(" ",      NullySpaceSB.Coalesce(spaceMatters,        NullyFilledText));
        NoNullRet(" ",      NullySpaceSB.Coalesce(spaceMatters: true,  NullyFilledText));
        NoNullRet("Filled", NullyEmptySB.Coalesce(spaceMatters,        NullyFilledText));
        NoNullRet("Filled", NullyEmptySB.Coalesce(spaceMatters: true,  NullyFilledText));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("FilledSB", Coalesce(spaceMatters: false, NullText,        NullyFilledSB ));
        NoNullRet("Filled",   Coalesce(spaceMatters: false, NullyFilledText, NullyFilledSB ));
        NoNullRet("",         Coalesce(spaceMatters: false, NullText,        NullSB        ));
        NoNullRet("FilledSB", NullText       .Coalesce(spaceMatters: false,  NullyFilledSB ));
        NoNullRet("Filled",   NullyFilledText.Coalesce(spaceMatters: false,  NullyFilledSB ));
        NoNullRet("",         NullText       .Coalesce(spaceMatters: false,  NullSB        ));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(Space,      Coalesce(spaceMatters,       NullySpace, NullyFilledSB));
        NoNullRet(Space,      Coalesce(spaceMatters: true, NullySpace, NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters,       NullyEmpty, NullyFilledSB));
        NoNullRet("FilledSB", Coalesce(spaceMatters: true, NullyEmpty, NullyFilledSB));
        NoNullRet(Space,      NullySpace.Coalesce(spaceMatters,        NullyFilledSB));
        NoNullRet(Space,      NullySpace.Coalesce(spaceMatters: true,  NullyFilledSB));
        NoNullRet("FilledSB", NullyEmpty.Coalesce(spaceMatters,        NullyFilledSB));
        NoNullRet("FilledSB", NullyEmpty.Coalesce(spaceMatters: true,  NullyFilledSB));
    }
}