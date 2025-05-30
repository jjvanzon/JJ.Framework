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
// - [ ] .. Coalesce arity 3 - Thing to String
// - [ ] Coalesce arity N
// - [ ] Enum
// - [ ] Enum?
// - [ ] double
// - [ ] bool

[TestClass]
public class CoalesceTests_Arity3_ValuesToString
{
    static int? NullNum = null;
    static int? Nully0  = 0;
    static int? Nully1  = 1;
    
    static string  EmptyText      = ""  ;
    static string  Space          = " " ;
    static string  Text           = "Hi";
    static string? NullyEmptyText = ""  ;

    // TODO: False positives occur when using a number instead of a string for the 1st argument of NoNullRet.

    // Variance:
    // 0, 1, Nully0, Nully1, NullNum
    // NullText, EmptyText, Space, Text, NullyEmptyText, NullySpace, NullyWithText 

    [TestMethod]
    public void Coalesce_Arity3_ValsToString_Static()
    {
        // Example
        NoNullRet("1",  Coalesce(1,       NullNum, NullText      ));
        NoNullRet(Text, Coalesce(0,       NullNum, Text          ));
        
        NoNullRet("",   Coalesce(NullNum, NullNum, NullText      ));
        NoNullRet("",   Coalesce(NullNum, NullNum, EmptyText     ));
        NoNullRet(" ",  Coalesce(NullNum, NullNum, Space         ));
        NoNullRet(Text, Coalesce(NullNum, NullNum, Text          ));
        NoNullRet("",   Coalesce(NullNum, NullNum, NullyEmptyText));
        NoNullRet(" ",  Coalesce(NullNum, NullNum, NullySpace    ));
        NoNullRet(Text, Coalesce(NullNum, NullNum, NullyWithText ));
        NoNullRet("",   Coalesce(NullNum,  Nully0, NullText      ));
        NoNullRet("",   Coalesce(NullNum,  Nully0, EmptyText     ));
        NoNullRet(" ",  Coalesce(NullNum,  Nully0, Space         ));
        NoNullRet(Text, Coalesce(NullNum,  Nully0, Text          ));
        NoNullRet("",   Coalesce(NullNum,  Nully0, NullyEmptyText));
        NoNullRet(" ",  Coalesce(NullNum,  Nully0, NullySpace    ));
        NoNullRet(Text, Coalesce(NullNum,  Nully0, NullyWithText ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullText      ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, EmptyText     ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, Space         ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, Text          ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullyEmptyText));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullySpace    ));
        NoNullRet("1",  Coalesce(NullNum,  Nully1, NullyWithText ));
        NoNullRet("",   Coalesce(NullNum,       0, NullText      ));
        NoNullRet("",   Coalesce(NullNum,       0, EmptyText     ));
        NoNullRet(" ",  Coalesce(NullNum,       0, Space         ));
        NoNullRet(Text, Coalesce(NullNum,       0, Text          ));
        NoNullRet("",   Coalesce(NullNum,       0, NullyEmptyText));
        NoNullRet(" ",  Coalesce(NullNum,       0, NullySpace    ));
        NoNullRet(Text, Coalesce(NullNum,       0, NullyWithText ));
        NoNullRet("1",  Coalesce(NullNum,       1, NullText      ));
        NoNullRet("1",  Coalesce(NullNum,       1, EmptyText     ));
        NoNullRet("1",  Coalesce(NullNum,       1, Space         ));
        NoNullRet("1",  Coalesce(NullNum,       1, Text          ));
        NoNullRet("1",  Coalesce(NullNum,       1, NullyEmptyText));
        NoNullRet("1",  Coalesce(NullNum,       1, NullySpace    ));
        NoNullRet("1",  Coalesce(NullNum,       1, NullyWithText ));
        
        NoNullRet("",   Coalesce(Nully0,  NullNum, NullText      ));
        NoNullRet("",   Coalesce(Nully0,  NullNum, EmptyText     ));
        NoNullRet(" ",  Coalesce(Nully0,  NullNum, Space         ));
        NoNullRet(Text, Coalesce(Nully0,  NullNum, Text          ));
        NoNullRet("",   Coalesce(Nully0,  NullNum, NullyEmptyText));
        NoNullRet(" ",  Coalesce(Nully0,  NullNum, NullySpace    ));
        NoNullRet(Text, Coalesce(Nully0,  NullNum, NullyWithText ));
        NoNullRet("",   Coalesce(Nully0,   Nully0, NullText      ));
        NoNullRet("",   Coalesce(Nully0,   Nully0, EmptyText     ));
        NoNullRet(" ",  Coalesce(Nully0,   Nully0, Space         ));
        NoNullRet(Text, Coalesce(Nully0,   Nully0, Text          ));
        NoNullRet("",   Coalesce(Nully0,   Nully0, NullyEmptyText));
        NoNullRet(" ",  Coalesce(Nully0,   Nully0, NullySpace    ));
        NoNullRet(Text, Coalesce(Nully0,   Nully0, NullyWithText ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullText      ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, EmptyText     ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, Space         ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, Text          ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullyEmptyText));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullySpace    ));
        NoNullRet("1",  Coalesce(Nully0,   Nully1, NullyWithText ));
        NoNullRet("",   Coalesce(Nully0,        0, NullText      ));
        NoNullRet("",   Coalesce(Nully0,        0, EmptyText     ));
        NoNullRet(" ",  Coalesce(Nully0,        0, Space         ));
        NoNullRet(Text, Coalesce(Nully0,        0, Text          ));
        NoNullRet("",   Coalesce(Nully0,        0, NullyEmptyText));
        NoNullRet(" ",  Coalesce(Nully0,        0, NullySpace    ));
        NoNullRet(Text, Coalesce(Nully0,        0, NullyWithText ));
        NoNullRet("1",  Coalesce(Nully0,        1, NullText      ));
        NoNullRet("1",  Coalesce(Nully0,        1, EmptyText     ));
        NoNullRet("1",  Coalesce(Nully0,        1, Space         ));
        NoNullRet("1",  Coalesce(Nully0,        1, Text          ));
        NoNullRet("1",  Coalesce(Nully0,        1, NullyEmptyText));
        NoNullRet("1",  Coalesce(Nully0,        1, NullySpace    ));
        NoNullRet("1",  Coalesce(Nully0,        1, NullyWithText ));
        
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullText      ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, EmptyText     ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, Space         ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, Text          ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullyEmptyText));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullySpace    ));
        NoNullRet("1",  Coalesce(Nully1,  NullNum, NullyWithText ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullText      ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, EmptyText     ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, Space         ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, Text          ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullyEmptyText));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullySpace    ));
        NoNullRet("1",  Coalesce(Nully1,   Nully0, NullyWithText ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullText      ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, EmptyText     ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, Space         ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, Text          ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullyEmptyText));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullySpace    ));
        NoNullRet("1",  Coalesce(Nully1,   Nully1, NullyWithText ));
        NoNullRet("1",  Coalesce(Nully1,        0, NullText      ));
        NoNullRet("1",  Coalesce(Nully1,        0, EmptyText     ));
        NoNullRet("1",  Coalesce(Nully1,        0, Space         ));
        NoNullRet("1",  Coalesce(Nully1,        0, Text          ));
        NoNullRet("1",  Coalesce(Nully1,        0, NullyEmptyText));
        NoNullRet("1",  Coalesce(Nully1,        0, NullySpace    ));
        NoNullRet("1",  Coalesce(Nully1,        0, NullyWithText ));
        NoNullRet("1",  Coalesce(Nully1,        1, NullText      ));
        NoNullRet("1",  Coalesce(Nully1,        1, EmptyText     ));
        NoNullRet("1",  Coalesce(Nully1,        1, Space         ));
        NoNullRet("1",  Coalesce(Nully1,        1, Text          ));
        NoNullRet("1",  Coalesce(Nully1,        1, NullyEmptyText));
        NoNullRet("1",  Coalesce(Nully1,        1, NullySpace    ));
        NoNullRet("1",  Coalesce(Nully1,        1, NullyWithText ));
        
        NoNullRet("",   Coalesce(0,       NullNum, NullText      ));
        NoNullRet("",   Coalesce(0,       NullNum, EmptyText     ));
        NoNullRet(" ",  Coalesce(0,       NullNum, Space         ));
        NoNullRet(Text, Coalesce(0,       NullNum, Text          ));
        NoNullRet("",   Coalesce(0,       NullNum, NullyEmptyText));
        NoNullRet(" ",  Coalesce(0,       NullNum, NullySpace    ));
        NoNullRet(Text, Coalesce(0,       NullNum, NullyWithText ));
        NoNullRet("",   Coalesce(0,        Nully0, NullText      ));
        NoNullRet("",   Coalesce(0,        Nully0, EmptyText     ));
        NoNullRet(" ",  Coalesce(0,        Nully0, Space         ));
        NoNullRet(Text, Coalesce(0,        Nully0, Text          ));
        NoNullRet("",   Coalesce(0,        Nully0, NullyEmptyText));
        NoNullRet(" ",  Coalesce(0,        Nully0, NullySpace    ));
        NoNullRet(Text, Coalesce(0,        Nully0, NullyWithText ));
        NoNullRet("1",  Coalesce(0,        Nully1, NullText      ));
        NoNullRet("1",  Coalesce(0,        Nully1, EmptyText     ));
        NoNullRet("1",  Coalesce(0,        Nully1, Space         ));
        NoNullRet("1",  Coalesce(0,        Nully1, Text          ));
        NoNullRet("1",  Coalesce(0,        Nully1, NullyEmptyText));
        NoNullRet("1",  Coalesce(0,        Nully1, NullySpace    ));
        NoNullRet("1",  Coalesce(0,        Nully1, NullyWithText ));
        NoNullRet("",   Coalesce(0,             0, NullText      ));
        NoNullRet("",   Coalesce(0,             0, EmptyText     ));
        NoNullRet(" ",  Coalesce(0,             0, Space         ));
        NoNullRet(Text, Coalesce(0,             0, Text          ));
        NoNullRet("",   Coalesce(0,             0, NullyEmptyText));
        NoNullRet(" ",  Coalesce(0,             0, NullySpace    ));
        NoNullRet(Text, Coalesce(0,             0, NullyWithText ));
        NoNullRet("1",  Coalesce(0,             1, NullText      ));
        NoNullRet("1",  Coalesce(0,             1, EmptyText     ));
        NoNullRet("1",  Coalesce(0,             1, Space         ));
        NoNullRet("1",  Coalesce(0,             1, Text          ));
        NoNullRet("1",  Coalesce(0,             1, NullyEmptyText));
        NoNullRet("1",  Coalesce(0,             1, NullySpace    ));
        NoNullRet("1",  Coalesce(0,             1, NullyWithText ));
        
        NoNullRet("1",  Coalesce(1,       NullNum, NullText      ));
        NoNullRet("1",  Coalesce(1,       NullNum, EmptyText     ));
        NoNullRet("1",  Coalesce(1,       NullNum, Space         ));
        NoNullRet("1",  Coalesce(1,       NullNum, Text          ));
        NoNullRet("1",  Coalesce(1,       NullNum, NullyEmptyText));
        NoNullRet("1",  Coalesce(1,       NullNum, NullySpace    ));
        NoNullRet("1",  Coalesce(1,       NullNum, NullyWithText ));
        NoNullRet("1",  Coalesce(1,        Nully0, NullText      ));
        NoNullRet("1",  Coalesce(1,        Nully0, EmptyText     ));
        NoNullRet("1",  Coalesce(1,        Nully0, Space         ));
        NoNullRet("1",  Coalesce(1,        Nully0, Text          ));
        NoNullRet("1",  Coalesce(1,        Nully0, NullyEmptyText));
        NoNullRet("1",  Coalesce(1,        Nully0, NullySpace    ));
        NoNullRet("1",  Coalesce(1,        Nully0, NullyWithText ));
        NoNullRet("1",  Coalesce(1,        Nully1, NullText      ));
        NoNullRet("1",  Coalesce(1,        Nully1, EmptyText     ));
        NoNullRet("1",  Coalesce(1,        Nully1, Space         ));
        NoNullRet("1",  Coalesce(1,        Nully1, Text          ));
        NoNullRet("1",  Coalesce(1,        Nully1, NullyEmptyText));
        NoNullRet("1",  Coalesce(1,        Nully1, NullySpace    ));
        NoNullRet("1",  Coalesce(1,        Nully1, NullyWithText ));
        NoNullRet("1",  Coalesce(1,             0, EmptyText     ));
        NoNullRet("1",  Coalesce(1,             0, Space         ));
        NoNullRet("1",  Coalesce(1,             0, Text          ));
        NoNullRet("1",  Coalesce(1,             0, NullyEmptyText));
        NoNullRet("1",  Coalesce(1,             0, NullySpace    ));
        NoNullRet("1",  Coalesce(1,             0, NullyWithText ));
        NoNullRet("1",  Coalesce(1,             1, NullText      ));
        NoNullRet("1",  Coalesce(1,             1, EmptyText     ));
        NoNullRet("1",  Coalesce(1,             1, Space         ));
        NoNullRet("1",  Coalesce(1,             1, Text          ));
        NoNullRet("1",  Coalesce(1,             1, NullyEmptyText));
        NoNullRet("1",  Coalesce(1,             1, NullySpace    ));
        NoNullRet("1",  Coalesce(1,             1, NullyWithText ));

    }


    [TestMethod]
    public void Coalesce_Arity3_ValsToString_Extensions()
    {
        // Example
        NoNullRet("1", Nully1.Coalesce(NullNum, NullText));
        NoNullRet(Text, 0.Coalesce(NullNum, Text));
        
        NoNullRet("",   NullNum.Coalesce(NullNum, NullText      ));
        NoNullRet("",   NullNum.Coalesce(NullNum, EmptyText     ));
        NoNullRet(" ",  NullNum.Coalesce(NullNum, Space         ));
        NoNullRet(Text, NullNum.Coalesce(NullNum, Text          ));
        NoNullRet("",   NullNum.Coalesce(NullNum, NullyEmptyText));
        NoNullRet(" ",  NullNum.Coalesce(NullNum, NullySpace    ));
        NoNullRet(Text, NullNum.Coalesce(NullNum, NullyWithText ));
        NoNullRet("",   NullNum.Coalesce( Nully0, NullText      ));
        NoNullRet("",   NullNum.Coalesce( Nully0, EmptyText     ));
        NoNullRet(" ",  NullNum.Coalesce( Nully0, Space         ));
        NoNullRet(Text, NullNum.Coalesce( Nully0, Text          ));
        NoNullRet("",   NullNum.Coalesce( Nully0, NullyEmptyText));
        NoNullRet(" ",  NullNum.Coalesce( Nully0, NullySpace    ));
        NoNullRet(Text, NullNum.Coalesce( Nully0, NullyWithText ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullText      ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, EmptyText     ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, Space         ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, Text          ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullyEmptyText));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullySpace    ));
        NoNullRet("1",  NullNum.Coalesce( Nully1, NullyWithText ));
        NoNullRet("",   NullNum.Coalesce(      0, NullText      ));
        NoNullRet("",   NullNum.Coalesce(      0, EmptyText     ));
        NoNullRet(" ",  NullNum.Coalesce(      0, Space         ));
        NoNullRet(Text, NullNum.Coalesce(      0, Text          ));
        NoNullRet("",   NullNum.Coalesce(      0, NullyEmptyText));
        NoNullRet(" ",  NullNum.Coalesce(      0, NullySpace    ));
        NoNullRet(Text, NullNum.Coalesce(      0, NullyWithText ));
        NoNullRet("1",  NullNum.Coalesce(      1, NullText      ));
        NoNullRet("1",  NullNum.Coalesce(      1, EmptyText     ));
        NoNullRet("1",  NullNum.Coalesce(      1, Space         ));
        NoNullRet("1",  NullNum.Coalesce(      1, Text          ));
        NoNullRet("1",  NullNum.Coalesce(      1, NullyEmptyText));
        NoNullRet("1",  NullNum.Coalesce(      1, NullySpace    ));
        NoNullRet("1",  NullNum.Coalesce(      1, NullyWithText ));
        
        NoNullRet("",    Nully0.Coalesce(NullNum, NullText      ));
        NoNullRet("",    Nully0.Coalesce(NullNum, EmptyText     ));
        NoNullRet(" ",   Nully0.Coalesce(NullNum, Space         ));
        NoNullRet(Text,  Nully0.Coalesce(NullNum, Text          ));
        NoNullRet("",    Nully0.Coalesce(NullNum, NullyEmptyText));
        NoNullRet(" ",   Nully0.Coalesce(NullNum, NullySpace    ));
        NoNullRet(Text,  Nully0.Coalesce(NullNum, NullyWithText ));
        NoNullRet("",    Nully0.Coalesce( Nully0, NullText      ));
        NoNullRet("",    Nully0.Coalesce( Nully0, EmptyText     ));
        NoNullRet(" ",   Nully0.Coalesce( Nully0, Space         ));
        NoNullRet(Text,  Nully0.Coalesce( Nully0, Text          ));
        NoNullRet("",    Nully0.Coalesce( Nully0, NullyEmptyText));
        NoNullRet(" ",   Nully0.Coalesce( Nully0, NullySpace    ));
        NoNullRet(Text,  Nully0.Coalesce( Nully0, NullyWithText ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullText      ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, EmptyText     ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, Space         ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, Text          ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullyEmptyText));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullySpace    ));
        NoNullRet("1",   Nully0.Coalesce( Nully1, NullyWithText ));
        NoNullRet("",    Nully0.Coalesce(      0, NullText      ));
        NoNullRet("",    Nully0.Coalesce(      0, EmptyText     ));
        NoNullRet(" ",   Nully0.Coalesce(      0, Space         ));
        NoNullRet(Text,  Nully0.Coalesce(      0, Text          ));
        NoNullRet("",    Nully0.Coalesce(      0, NullyEmptyText));
        NoNullRet(" ",   Nully0.Coalesce(      0, NullySpace    ));
        NoNullRet(Text,  Nully0.Coalesce(      0, NullyWithText ));
        NoNullRet("1",   Nully0.Coalesce(      1, NullText      ));
        NoNullRet("1",   Nully0.Coalesce(      1, EmptyText     ));
        NoNullRet("1",   Nully0.Coalesce(      1, Space         ));
        NoNullRet("1",   Nully0.Coalesce(      1, Text          ));
        NoNullRet("1",   Nully0.Coalesce(      1, NullyEmptyText));
        NoNullRet("1",   Nully0.Coalesce(      1, NullySpace    ));
        NoNullRet("1",   Nully0.Coalesce(      1, NullyWithText ));
        
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullText      ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, EmptyText     ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, Space         ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, Text          ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullyEmptyText));
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullySpace    ));
        NoNullRet("1",   Nully1.Coalesce(NullNum, NullyWithText ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullText      ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, EmptyText     ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, Space         ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, Text          ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullyEmptyText));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullySpace    ));
        NoNullRet("1",   Nully1.Coalesce( Nully0, NullyWithText ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullText      ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, EmptyText     ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, Space         ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, Text          ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullyEmptyText));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullySpace    ));
        NoNullRet("1",   Nully1.Coalesce( Nully1, NullyWithText ));
        NoNullRet("1",   Nully1.Coalesce(      0, NullText      ));
        NoNullRet("1",   Nully1.Coalesce(      0, EmptyText     ));
        NoNullRet("1",   Nully1.Coalesce(      0, Space         ));
        NoNullRet("1",   Nully1.Coalesce(      0, Text          ));
        NoNullRet("1",   Nully1.Coalesce(      0, NullyEmptyText));
        NoNullRet("1",   Nully1.Coalesce(      0, NullySpace    ));
        NoNullRet("1",   Nully1.Coalesce(      0, NullyWithText ));
        NoNullRet("1",   Nully1.Coalesce(      1, NullText      ));
        NoNullRet("1",   Nully1.Coalesce(      1, EmptyText     ));
        NoNullRet("1",   Nully1.Coalesce(      1, Space         ));
        NoNullRet("1",   Nully1.Coalesce(      1, Text          ));
        NoNullRet("1",   Nully1.Coalesce(      1, NullyEmptyText));
        NoNullRet("1",   Nully1.Coalesce(      1, NullySpace    ));
        NoNullRet("1",   Nully1.Coalesce(      1, NullyWithText ));
        
        NoNullRet("",         0.Coalesce(NullNum, NullText      ));
        NoNullRet("",         0.Coalesce(NullNum, EmptyText     ));
        NoNullRet(" ",        0.Coalesce(NullNum, Space         ));
        NoNullRet(Text,       0.Coalesce(NullNum, Text          ));
        NoNullRet("",         0.Coalesce(NullNum, NullyEmptyText));
        NoNullRet(" ",        0.Coalesce(NullNum, NullySpace    ));
        NoNullRet(Text,       0.Coalesce(NullNum, NullyWithText ));
        NoNullRet("",         0.Coalesce( Nully0, NullText      ));
        NoNullRet("",         0.Coalesce( Nully0, EmptyText     ));
        NoNullRet(" ",        0.Coalesce( Nully0, Space         ));
        NoNullRet(Text,       0.Coalesce( Nully0, Text          ));
        NoNullRet("",         0.Coalesce( Nully0, NullyEmptyText));
        NoNullRet(" ",        0.Coalesce( Nully0, NullySpace    ));
        NoNullRet(Text,       0.Coalesce( Nully0, NullyWithText ));
        NoNullRet("1",        0.Coalesce( Nully1, NullText      ));
        NoNullRet("1",        0.Coalesce( Nully1, EmptyText     ));
        NoNullRet("1",        0.Coalesce( Nully1, Space         ));
        NoNullRet("1",        0.Coalesce( Nully1, Text          ));
        NoNullRet("1",        0.Coalesce( Nully1, NullyEmptyText));
        NoNullRet("1",        0.Coalesce( Nully1, NullySpace    ));
        NoNullRet("1",        0.Coalesce( Nully1, NullyWithText ));
        NoNullRet("",         0.Coalesce(      0, NullText      ));
        NoNullRet("",         0.Coalesce(      0, EmptyText     ));
        NoNullRet(" ",        0.Coalesce(      0, Space         ));
        NoNullRet(Text,       0.Coalesce(      0, Text          ));
        NoNullRet("",         0.Coalesce(      0, NullyEmptyText));
        NoNullRet(" ",        0.Coalesce(      0, NullySpace    ));
        NoNullRet(Text,       0.Coalesce(      0, NullyWithText ));
        NoNullRet("1",        0.Coalesce(      1, NullText      ));
        NoNullRet("1",        0.Coalesce(      1, EmptyText     ));
        NoNullRet("1",        0.Coalesce(      1, Space         ));
        NoNullRet("1",        0.Coalesce(      1, Text          ));
        NoNullRet("1",        0.Coalesce(      1, NullyEmptyText));
        NoNullRet("1",        0.Coalesce(      1, NullySpace    ));
        NoNullRet("1",        0.Coalesce(      1, NullyWithText ));
        
        NoNullRet("1",        1.Coalesce(NullNum, NullText      ));
        NoNullRet("1",        1.Coalesce(NullNum, EmptyText     ));
        NoNullRet("1",        1.Coalesce(NullNum, Space         ));
        NoNullRet("1",        1.Coalesce(NullNum, Text          ));
        NoNullRet("1",        1.Coalesce(NullNum, NullyEmptyText));
        NoNullRet("1",        1.Coalesce(NullNum, NullySpace    ));
        NoNullRet("1",        1.Coalesce(NullNum, NullyWithText ));
        NoNullRet("1",        1.Coalesce( Nully0, NullText      ));
        NoNullRet("1",        1.Coalesce( Nully0, EmptyText     ));
        NoNullRet("1",        1.Coalesce( Nully0, Space         ));
        NoNullRet("1",        1.Coalesce( Nully0, Text          ));
        NoNullRet("1",        1.Coalesce( Nully0, NullyEmptyText));
        NoNullRet("1",        1.Coalesce( Nully0, NullySpace    ));
        NoNullRet("1",        1.Coalesce( Nully0, NullyWithText ));
        NoNullRet("1",        1.Coalesce( Nully1, NullText      ));
        NoNullRet("1",        1.Coalesce( Nully1, EmptyText     ));
        NoNullRet("1",        1.Coalesce( Nully1, Space         ));
        NoNullRet("1",        1.Coalesce( Nully1, Text          ));
        NoNullRet("1",        1.Coalesce( Nully1, NullyEmptyText));
        NoNullRet("1",        1.Coalesce( Nully1, NullySpace    ));
        NoNullRet("1",        1.Coalesce( Nully1, NullyWithText ));
        NoNullRet("1",        1.Coalesce(      0, EmptyText     ));
        NoNullRet("1",        1.Coalesce(      0, Space         ));
        NoNullRet("1",        1.Coalesce(      0, Text          ));
        NoNullRet("1",        1.Coalesce(      0, NullyEmptyText));
        NoNullRet("1",        1.Coalesce(      0, NullySpace    ));
        NoNullRet("1",        1.Coalesce(      0, NullyWithText ));
        NoNullRet("1",        1.Coalesce(      1, NullText      ));
        NoNullRet("1",        1.Coalesce(      1, EmptyText     ));
        NoNullRet("1",        1.Coalesce(      1, Space         ));
        NoNullRet("1",        1.Coalesce(      1, Text          ));
        NoNullRet("1",        1.Coalesce(      1, NullyEmptyText));
        NoNullRet("1",        1.Coalesce(      1, NullySpace    ));
        NoNullRet("1",        1.Coalesce(      1, NullyWithText ));
    }
}