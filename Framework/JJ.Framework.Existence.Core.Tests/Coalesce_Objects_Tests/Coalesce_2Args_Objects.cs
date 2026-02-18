namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_Objects_Tests : TestBase
{
    private static readonly Dummy? NullyFilled = NullyFilledObj;

    [TestMethod]
    public void Coalesce_2Args_Objects()
    {
        NoNullRet(              Coalesce(NullObj,     NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullObj    ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullObj    ));
        NoNullRet(NoNullObj,    Coalesce(NullObj,     NoNullObj  ));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NoNullObj  ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NoNullObj  ));
        NoNullRet(NullyFilled!, Coalesce(NullObj,     NullyFilled));
        NoNullRet(NoNullObj,    Coalesce(NoNullObj,   NullyFilled));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullyFilled));
        NoNullRet(              NullObj    .Coalesce(NullObj     ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NullObj     ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullObj     ));
        NoNullRet(NoNullObj,    NullObj    .Coalesce(NoNullObj   ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NoNullObj   ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NoNullObj   ));
        NoNullRet(NullyFilled!, NullObj    .Coalesce(NullyFilled ));
        NoNullRet(NoNullObj,    NoNullObj  .Coalesce(NullyFilled ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullyFilled ));
    }

    // Objects to Text

    [TestMethod]
    public void Coalesce_2Args_ObjectToText()
    {
        NoNullRet(Text,     Coalesce(NullObj,    Text));
        NoNullRet(Text,     Coalesce(NullObj,    Text));
        NoNullRet("NoNull", Coalesce(NoNullObj,  Text));
        NoNullRet("Filled", Coalesce(NullyFilled,Text));
        NoNullRet(Text,     NullObj    .Coalesce(Text));
        NoNullRet("NoNull", NoNullObj  .Coalesce(Text));
        NoNullRet("Filled", NullyFilled.Coalesce(Text));
    }
}