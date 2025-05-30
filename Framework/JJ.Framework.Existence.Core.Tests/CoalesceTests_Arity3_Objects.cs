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
// - [ ] .. Coalesce arity 3 - Objects
// - [ ] Coalesce arity 3 - Values
// - [ ] Coalesce arity N
// - [ ] Enum
// - [ ] Enum?
// - [ ] double
// - [ ] bool

[TestClass]
public class CoalesceTests_Arity3_Objects
{
    // TODO: Move to its own file.
    public void Test_Coalesce_Arity3_Objects()
    {
        //NoNullRet(NullyFilled, Coalesce(NullyFilled, NullyFilled, NullyFilled));
    }
}
