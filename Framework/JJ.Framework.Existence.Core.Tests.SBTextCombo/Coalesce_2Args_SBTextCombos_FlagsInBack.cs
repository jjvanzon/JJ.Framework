namespace JJ.Framework.Existence.Core.SBTextCombo.Tests;

[TestClass]
public class Coalesce_2Args_SBTextCombos_FlagsInBack : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersNoFlagsInBack()
    {
        NoNullRet(Text,       Coalesce(NullSB,       Text, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text, spaceMatters: false));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text, spaceMatters: false));
        NoNullRet(Text,       NullSB       .Coalesce(Text, spaceMatters: false));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text, spaceMatters: false));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text, spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(" ",      Coalesce(NullySpaceSB, NullyFilledText, spaceMatters      ));
        NoNullRet(" ",      Coalesce(NullySpaceSB, NullyFilledText, spaceMatters: true));
        NoNullRet("Filled", Coalesce(NullyEmptySB, NullyFilledText, spaceMatters      ));
        NoNullRet("Filled", Coalesce(NullyEmptySB, NullyFilledText, spaceMatters: true));
        NoNullRet(" ",      NullySpaceSB.Coalesce( NullyFilledText, spaceMatters      ));
        NoNullRet(" ",      NullySpaceSB.Coalesce( NullyFilledText, spaceMatters: true));
        NoNullRet("Filled", NullyEmptySB.Coalesce( NullyFilledText, spaceMatters      ));
        NoNullRet("Filled", NullyEmptySB.Coalesce( NullyFilledText, spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersNoFlagsInBack()
    {
        NoNullRet("FilledSB", Coalesce(NullText,        NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   Coalesce(NullyFilledText, NullyFilledSB, spaceMatters: false));
        NoNullRet("",         Coalesce(NullText,        NullSB,        spaceMatters: false));
        NoNullRet("FilledSB", NullText       .Coalesce( NullyFilledSB, spaceMatters: false));
        NoNullRet("Filled",   NullyFilledText.Coalesce( NullyFilledSB, spaceMatters: false));
        NoNullRet("",         NullText       .Coalesce( NullSB,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder_SpaceMattersYesFlagsInBack()
    {
        NoNullRet(Space,      Coalesce(NullySpace, NullyFilledSB, spaceMatters      ));
        NoNullRet(Space,      Coalesce(NullySpace, NullyFilledSB, spaceMatters: true));
        NoNullRet("FilledSB", Coalesce(NullyEmpty, NullyFilledSB, spaceMatters      ));
        NoNullRet("FilledSB", Coalesce(NullyEmpty, NullyFilledSB, spaceMatters: true));
        NoNullRet(Space,      NullySpace.Coalesce( NullyFilledSB, spaceMatters      ));
        NoNullRet(Space,      NullySpace.Coalesce( NullyFilledSB, spaceMatters: true));
        NoNullRet("FilledSB", NullyEmpty.Coalesce( NullyFilledSB, spaceMatters      ));
        NoNullRet("FilledSB", NullyEmpty.Coalesce( NullyFilledSB, spaceMatters: true));
    }
}