namespace JJ.Framework.Existence.Core.Tests;

// Should check:
// - [x] int
// - [x] int?
// - [x] string
// - [x] string?
// - [x] Reference Types (StringBuilder)
// - [x] Nullable reference types (StringBuilder?)
// - [x] ~ Coalescing from collection to collection
// - [x] Collection types
// - [x] Trim tolerance
// - [x] Static variant
// - [x] Extension variant
// - [x] Coalesce arity 1
// - [x] Coalesce arity 2
// - [x] Coalesce arity 3 - Text
// - [x] Coalesce arity 3 - Objects
// - [ ] .. Coalesce arity 3 - Thing to String
// - [ ] Coalesce arity 3 - Values
// - [ ] Coalesce arity N
// - [ ] Enum
// - [ ] Enum?
// - [ ] double
// - [ ] bool

[TestClass]
public class CoalesceTests_Arity3_Objects
{
    private static readonly StringBuilder? Null        = TestHelper.NullObj;
    private static readonly StringBuilder  NoNull      = TestHelper.NoNullObj;
    private static readonly StringBuilder? NullyFilled = TestHelper.NullyFilled;

    [TestMethod]
    public void Test_Coalesce_Arity3_Objects()
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
