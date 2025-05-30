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
// - [x] Coalesce arity 3 - Values
// - [ ] Coalesce arity 3 - Thing to String
// - [ ] Coalesce arity N
// - [ ] Enum
// - [ ] Enum?
// - [ ] double
// - [ ] bool

[TestClass]
public class CoalesceTests_Arity3_Values
{
    [TestMethod]
    public void Coalesce_Arity3_Values_Static()
    {
        NoNullRet(0, Coalesce(NullNum, NullNum, NullNum));
        NoNullRet(0, Coalesce(NullNum, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(NullNum, NullNum, Nully1 ));
        NoNullRet(0, Coalesce(NullNum, NullNum, NoNull0));
        NoNullRet(1, Coalesce(NullNum, NullNum, NoNull1));
        NoNullRet(0, Coalesce(NullNum, Nully0,  NullNum));
        NoNullRet(0, Coalesce(NullNum, Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(NullNum, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(NullNum, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(NullNum, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(NullNum, Nully1,  NullNum));
        NoNullRet(1, Coalesce(NullNum, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(NullNum, Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(NullNum, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(NullNum, Nully1,  NoNull1));
        NoNullRet(0, Coalesce(NullNum, NoNull0, NullNum));
        NoNullRet(0, Coalesce(NullNum, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(NullNum, NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(NullNum, NoNull0, NoNull0));
        NoNullRet(1, Coalesce(NullNum, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(NullNum, NoNull1, NullNum));
        NoNullRet(1, Coalesce(NullNum, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(NullNum, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(NullNum, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(NullNum, NoNull1, NoNull1));
                     
        NoNullRet(0, Coalesce(Nully0,  NullNum, NullNum));
        NoNullRet(0, Coalesce(Nully0,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  NullNum, Nully1 ));
        NoNullRet(0, Coalesce(Nully0,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(Nully0,  NullNum, NoNull1));
        NoNullRet(0, Coalesce(Nully0,  Nully0,  NullNum));
        NoNullRet(0, Coalesce(Nully0,  Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(Nully0,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(Nully0,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  NullNum));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  NoNull0));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  NoNull1));
        NoNullRet(0, Coalesce(Nully0,  NoNull0, NullNum));
        NoNullRet(0, Coalesce(Nully0,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(Nully0,  NoNull0, NoNull0));
        NoNullRet(1, Coalesce(Nully0,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, NoNull1));
                     
        NoNullRet(1, Coalesce(Nully1,  NullNum, NullNum));
        NoNullRet(1, Coalesce(Nully1,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(Nully1,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  NullNum));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  NullNum));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  NoNull0));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  NoNull1));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, NullNum));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, NoNull0));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, NoNull1));
                     
        NoNullRet(0, Coalesce(NoNull0, NullNum, NullNum));
        NoNullRet(0, Coalesce(NoNull0, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, NullNum, Nully1 ));
        NoNullRet(0, Coalesce(NoNull0, NullNum, NoNull0));
        NoNullRet(1, Coalesce(NoNull0, NullNum, NoNull1));
        NoNullRet(0, Coalesce(NoNull0, Nully0,  NullNum));
        NoNullRet(0, Coalesce(NoNull0, Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(NoNull0, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(NoNull0, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  NullNum));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  NoNull1));
        NoNullRet(0, Coalesce(NoNull0, NoNull0, NullNum));
        NoNullRet(0, Coalesce(NoNull0, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(NoNull0, NoNull0, NoNull0));
        NoNullRet(1, Coalesce(NoNull0, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, NullNum));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, NoNull1));
        NoNullRet(1, Coalesce(NoNull1, NullNum, NullNum));
        NoNullRet(1, Coalesce(NoNull1, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, NullNum, NoNull0));
        NoNullRet(1, Coalesce(NoNull1, NullNum, NoNull1));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  NullNum));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  NullNum));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, NullNum));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, NoNull0));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, NullNum));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_Arity3_Values_Extensions()
    {
        NoNullRet(0, NullNum .Coalesce(NullNum, NullNum));
        NoNullRet(0, NullNum .Coalesce(NullNum, Nully0 ));
        NoNullRet(1, NullNum .Coalesce(NullNum, Nully1 ));
        NoNullRet(0, NullNum .Coalesce(NullNum, NoNull0));
        NoNullRet(1, NullNum .Coalesce(NullNum, NoNull1));
        NoNullRet(0, NullNum .Coalesce(Nully0,  NullNum));
        NoNullRet(0, NullNum .Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, NullNum .Coalesce(Nully0,  Nully1 ));
        NoNullRet(0, NullNum .Coalesce(Nully0,  NoNull0));
        NoNullRet(1, NullNum .Coalesce(Nully0,  NoNull1));
        NoNullRet(1, NullNum .Coalesce(Nully1,  NullNum));
        NoNullRet(1, NullNum .Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, NullNum .Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, NullNum .Coalesce(Nully1,  NoNull0));
        NoNullRet(1, NullNum .Coalesce(Nully1,  NoNull1));
        NoNullRet(0, NullNum .Coalesce(NoNull0, NullNum));
        NoNullRet(0, NullNum .Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, NullNum .Coalesce(NoNull0, Nully1 ));
        NoNullRet(0, NullNum .Coalesce(NoNull0, NoNull0));
        NoNullRet(1, NullNum .Coalesce(NoNull0, NoNull1));
        NoNullRet(1, NullNum .Coalesce(NoNull1, NullNum));
        NoNullRet(1, NullNum .Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, NullNum .Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, NullNum .Coalesce(NoNull1, NoNull0));
        NoNullRet(1, NullNum .Coalesce(NoNull1, NoNull1));

        NoNullRet(0, Nully0 .Coalesce(NullNum, NullNum));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(NullNum, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(NullNum, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(Nully0,  NullNum));
        NoNullRet(0, Nully0 .Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(Nully0,  Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(Nully0,  NoNull0));
        NoNullRet(1, Nully0 .Coalesce(Nully0,  NoNull1));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NullNum));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull0));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull1));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, NoNull1));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NullNum));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NoNull1));

        NoNullRet(1, Nully1 .Coalesce(NullNum, NullNum));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull1));

        NoNullRet(0, NoNull0.Coalesce(NullNum, NullNum));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(NullNum, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(NullNum, NoNull1));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  NoNull1));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NullNum));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull0));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(NoNull0, NullNum));
        NoNullRet(0, NoNull0.Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(NoNull0, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(NoNull0, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(NoNull0, NoNull1));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NullNum));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NoNull1));

        NoNullRet(1, NoNull1.Coalesce(NullNum, NullNum));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, NullNum));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, NoNull1));
    }
}