namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Objects
{
    private static readonly StringBuilder? Null        = Mocks.NullObj;
    private static readonly StringBuilder  NoNull      = Mocks.NoNullObj;
    private static readonly StringBuilder? NullyFilled = Mocks.NullyFilled;

    [TestMethod]
    public void Coalesce_3Args_Objects_Static()
    {
        NoNullRet(             Coalesce(Null,        Null,        Null       ));
        NoNullRet(NoNull,      Coalesce(Null,        Null,        NoNull     ));
        NoNullRet(NullyFilled, Coalesce(Null,        Null,        NullyFilled));
        NoNullRet(NoNull,      Coalesce(Null,        NoNull,      Null       ));
        NoNullRet(NoNull,      Coalesce(Null,        NoNull,      NoNull     ));
        NoNullRet(NoNull,      Coalesce(Null,        NoNull,      NullyFilled));
        NoNullRet(NullyFilled, Coalesce(Null,        NullyFilled, Null       ));
        NoNullRet(NullyFilled, Coalesce(Null,        NullyFilled, NoNull     ));
        NoNullRet(NullyFilled, Coalesce(Null,        NullyFilled, NullyFilled));
        NoNullRet(NoNull,      Coalesce(NoNull,      Null,        Null       ));
        NoNullRet(NoNull,      Coalesce(NoNull,      Null,        NoNull     ));
        NoNullRet(NoNull,      Coalesce(NoNull,      Null,        NullyFilled));
        NoNullRet(NoNull,      Coalesce(NoNull,      NoNull,      Null       ));
        NoNullRet(NoNull,      Coalesce(NoNull,      NoNull,      NoNull     ));
        NoNullRet(NoNull,      Coalesce(NoNull,      NoNull,      NullyFilled));
        NoNullRet(NoNull,      Coalesce(NoNull,      NullyFilled, Null       ));
        NoNullRet(NoNull,      Coalesce(NoNull,      NullyFilled, NoNull     ));
        NoNullRet(NoNull,      Coalesce(NoNull,      NullyFilled, NullyFilled));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, Null,        Null       ));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, Null,        NoNull     ));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, Null,        NullyFilled));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, NoNull,      Null       ));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, NoNull,      NoNull     ));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, NoNull,      NullyFilled));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, NullyFilled, Null       ));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, NullyFilled, NoNull     ));
        NoNullRet(NullyFilled, Coalesce(NullyFilled, NullyFilled, NullyFilled));
    }

    [TestMethod]
    public void Coalesce_3Args_Objects_Extensions()
    {
        NoNullRet(             Null        .Coalesce(Null,        Null       ));
        NoNullRet(NoNull,      Null        .Coalesce(Null,        NoNull     ));
        NoNullRet(NullyFilled, Null        .Coalesce(Null,        NullyFilled));
        NoNullRet(NoNull,      Null        .Coalesce(NoNull,      Null       ));
        NoNullRet(NoNull,      Null        .Coalesce(NoNull,      NoNull     ));
        NoNullRet(NoNull,      Null        .Coalesce(NoNull,      NullyFilled));
        NoNullRet(NullyFilled, Null        .Coalesce(NullyFilled, Null       ));
        NoNullRet(NullyFilled, Null        .Coalesce(NullyFilled, NoNull     ));
        NoNullRet(NullyFilled, Null        .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(NoNull,      NoNull      .Coalesce(Null,        Null       ));
        NoNullRet(NoNull,      NoNull      .Coalesce(Null,        NoNull     ));
        NoNullRet(NoNull,      NoNull      .Coalesce(Null,        NullyFilled));
        NoNullRet(NoNull,      NoNull      .Coalesce(NoNull,      Null       ));
        NoNullRet(NoNull,      NoNull      .Coalesce(NoNull,      NoNull     ));
        NoNullRet(NoNull,      NoNull      .Coalesce(NoNull,      NullyFilled));
        NoNullRet(NoNull,      NoNull      .Coalesce(NullyFilled, Null       ));
        NoNullRet(NoNull,      NoNull      .Coalesce(NullyFilled, NoNull     ));
        NoNullRet(NoNull,      NoNull      .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(Null,        Null       ));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(Null,        NoNull     ));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(Null,        NullyFilled));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(NoNull,      Null       ));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(NoNull,      NoNull     ));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(NoNull,      NullyFilled));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(NullyFilled, Null       ));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(NullyFilled, NoNull     ));
        NoNullRet(NullyFilled, NullyFilled .Coalesce(NullyFilled, NullyFilled));
    }
}
