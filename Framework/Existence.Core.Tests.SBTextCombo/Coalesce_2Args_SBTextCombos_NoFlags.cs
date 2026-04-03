namespace JJ.Framework.Existence.Core.SBTextCombo.Tests;

[TestClass]
public class Coalesce_2Args_SBTextCombos_NoFlags : TestBase
{
    [TestMethod]
    public void Coalesce_2Args_StringBuilderAndText()
    {
        NoNullRet(Text,       Coalesce(NullSB,       Text));
        NoNullRet("FilledSB", Coalesce(FilledSB,     Text));
        NoNullRet("FilledSB", Coalesce(NullyFilledSB,Text));
        NoNullRet(Text,       NullSB       .Coalesce(Text));
        NoNullRet("FilledSB", FilledSB     .Coalesce(Text));
        NoNullRet("FilledSB", NullyFilledSB.Coalesce(Text));
    }

    [TestMethod]
    public void Coalesce_2Args_TextAndStringBuilder()
    {
        NoNullRet("FilledSB", Coalesce(NullText,        NullyFilledSB));
        NoNullRet("Filled",   Coalesce(NullyFilledText, NullyFilledSB));
        NoNullRet("",         Coalesce(NullText,        NullSB       ));
        NoNullRet("FilledSB", NullText       .Coalesce( NullyFilledSB));
        NoNullRet("Filled",   NullyFilledText.Coalesce( NullyFilledSB));
        NoNullRet("",         NullText       .Coalesce( NullSB       ));
    }
}