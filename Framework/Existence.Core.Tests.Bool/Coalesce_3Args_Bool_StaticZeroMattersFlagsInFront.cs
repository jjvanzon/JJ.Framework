namespace JJ.Framework.Existence.Core.Bool.Tests;

[TestClass]
public class Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch1()
    {
             NoNullRet(false, Coalesce(                    NullBool,   NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: false, NullBool,   NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(             false, NullBool,   NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   NullyFalse, NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   NullyFalse, NullBool  )), "Actual <True>"); // Not a flag

             NoNullRet(true,  Coalesce(                    NullBool,   NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullBool,   NullyFalse, NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   NullyFalse, NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   NullyFalse, NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   NullyFalse, NullyTrue )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, Coalesce(                    NullBool,   NullyFalse, False     ));
             NoNullRet(false, Coalesce(zeroMatters: false, NullBool,   NullyFalse, False     ));
             NoNullRet(false, Coalesce(             false, NullBool,   NullyFalse, False     ));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   NullyFalse, False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   NullyFalse, False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   NullyFalse, False     )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullBool,   NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   NullyFalse, True      ));
             NoNullRet(true,  Coalesce(             false, NullBool,   NullyFalse, True      ));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   NullyFalse, True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   NullyFalse, True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   NullyFalse, True      )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullBool,   NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(             false, NullBool,   NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(             true,  NullBool,   NullyTrue,  NullBool  ));
             
             NoNullRet(true,  Coalesce(                    NullBool,   NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(             false, NullBool,   NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(             true,  NullBool,   NullyTrue,  NullyFalse));
             
             NoNullRet(true,  Coalesce(                    NullBool,   NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(             false, NullBool,   NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(             true,  NullBool,   NullyTrue,  False     ));
             
             NoNullRet(true,  Coalesce(                    NullBool,   NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(             false, NullBool,   NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(             true,  NullBool,   NullyTrue,  True      ));
             
             NoNullRet(false, Coalesce(                    NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: false, NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(             false, NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   False,      NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   False,      NullyFalse)), "Actual <True>"); // Not a flag
             
             NoNullRet(false, Coalesce(                    NullBool,   False,      NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: false, NullBool,   False,      NullBool  ));
             NoNullRet(false, Coalesce(             false, NullBool,   False,      NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   False,      NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   False,      NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   False,      NullBool  )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, Coalesce(                    NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: false, NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(             false, NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   False,      NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   False,      NullyFalse)), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullBool,   False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   False,      NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullBool,   False,      NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   False,      NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   False,      NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   False,      NullyTrue )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullBool,   False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   False,      True      ));
             NoNullRet(true,  Coalesce(             false, NullBool,   False,      True      ));
             NoNullRet(false, Coalesce(zeroMatters,        NullBool,   False,      True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullBool,   False,      True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullBool,   False,      True      )), "Actual <True>"); // Not a flag
                     
             NoNullRet(true,  Coalesce(                    NullBool,   True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   True,       NullBool  ));
             NoNullRet(true,  Coalesce(             false, NullBool,   True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   True,       NullBool  ));
             NoNullRet(true,  Coalesce(             true,  NullBool,   True,       NullBool  ));     

             NoNullRet(true,  Coalesce(                    NullBool,   True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   True,       NullyFalse));
             NoNullRet(true,  Coalesce(             false, NullBool,   True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   True,       NullyFalse));
             NoNullRet(true,  Coalesce(             true,  NullBool,   True,       NullyFalse));     

             NoNullRet(true,  Coalesce(                    NullBool,   True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   True,       NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullBool,   True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   True,       NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  NullBool,   True,       NullyTrue ));
             
             NoNullRet(true,  Coalesce(                    NullBool,   True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullBool,   True,       False     ));
             NoNullRet(true,  Coalesce(             false, NullBool,   True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullBool,   True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullBool,   True,       False     ));
             NoNullRet(true,  Coalesce(             true,  NullBool,   True,       False     ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch2()
    {
             NoNullRet(false, Coalesce(                    NullyFalse, NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: false, NullyFalse, NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(             false, NullyFalse, NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullBool,   NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullBool,   NullyFalse)), "Actual <True>"); // Not a flag
     
             NoNullRet(true,  Coalesce(                    NullyFalse, NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, NullBool,   NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullBool,   NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullBool,   NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullBool,   NullyTrue )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, Coalesce(                    NullyFalse, NullBool,   False     ));
             NoNullRet(false, Coalesce(zeroMatters: false, NullyFalse, NullBool,   False     ));
             NoNullRet(false, Coalesce(             false, NullyFalse, NullBool,   False     ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullBool,   False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullBool,   False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullBool,   False     )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, NullBool,   True      ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, NullBool,   True      ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullBool,   True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullBool,   True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullBool,   True      )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, NullyTrue,  NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullyTrue,  NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullyTrue,  NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullyTrue,  NullBool  )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(             false, NullyFalse, NullyTrue,  NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullyTrue,  NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullyTrue,  NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullyTrue,  NullyFalse)), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, NullyTrue,  False     ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullyTrue,  False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullyTrue,  False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullyTrue,  False     )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, NullyTrue,  True      ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, NullyTrue,  True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, NullyTrue,  True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, NullyTrue,  True      )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, Coalesce(                    NullyFalse, False,      NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: false, NullyFalse, False,      NullBool  ));
             NoNullRet(false, Coalesce(             false, NullyFalse, False,      NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, False,      NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, False,      NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, False,      NullBool  )), "Actual <True>"); // Not a flag
                     
             NoNullRet(false, Coalesce(                    NullyFalse, False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: false, NullyFalse, False,      NullyFalse));
             NoNullRet(false, Coalesce(             false, NullyFalse, False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, False,      NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, False,      NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, False,      NullyFalse)), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, False,      NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, False,      NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, False,      NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, False,      NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, False,      NullyTrue )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, False,      True      ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, False,      True      ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, False,      True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, False,      True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, False,      True      )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, True,       NullBool  ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, True,       NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, True,       NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, True,       NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, True,       NullBool  )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, True,       NullyFalse));
             NoNullRet(true,  Coalesce(             false, NullyFalse, True,       NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, True,       NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, True,       NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, True,       NullyFalse)), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, True,       NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, True,       NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, True,       NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, True,       NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, True,       NullyTrue )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    NullyFalse, True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyFalse, True,       False     ));
             NoNullRet(true,  Coalesce(             false, NullyFalse, True,       False     ));
             NoNullRet(false, Coalesce(zeroMatters,        NullyFalse, True,       False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  NullyFalse, True,       False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  NullyFalse, True,       False     )), "Actual <True>"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch3()
    {
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullBool,   NullyFalse));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullBool,   NullyTrue ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullBool,   False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullBool,   False     ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullBool,   False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullBool,   False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullBool,   False     ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullBool,   False     ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullBool,   True      ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullBool,   True      ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullBool,   True      ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullyFalse, NullBool  ));
                     
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullyFalse, NullyTrue ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullyFalse, False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullyFalse, False     ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullyFalse, False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullyFalse, False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse, False     ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullyFalse, False     ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  NullyFalse, True      ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse, True      ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  NullyFalse, True      ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  False,      NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  False,      NullBool  ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  False,      NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  False,      NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  False,      NullBool  ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  False,      NullBool  ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  False,      NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  False,      NullyFalse));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  False,      NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  False,      NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  False,      NullyFalse));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  False,      NullyFalse));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  False,      NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  False,      NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  False,      NullyTrue ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  False,      True      ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  False,      True      ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  False,      True      ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  True,       NullBool  ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  True,       NullBool  ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  True,       NullBool  ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  True,       NullyFalse));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  True,       NullyFalse));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  True,       NullyFalse));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  True,       NullyTrue ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  True,       NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  True,       NullyTrue ));
             
             NoNullRet(true,  Coalesce(                    NullyTrue,  True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, NullyTrue,  True,       False     ));
             NoNullRet(true,  Coalesce(             false, NullyTrue,  True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        NullyTrue,  True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  NullyTrue,  True,       False     ));
             NoNullRet(true,  Coalesce(             true,  NullyTrue,  True,       False     ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch4()
    {
             NoNullRet(false, Coalesce(                    False,      NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: false, False,      NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(             false, False,      NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullBool,   NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullBool,   NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullBool,   NullyFalse)), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(             false, False,      NullBool,   NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullBool,   NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullBool,   NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullBool,   NullyTrue )), "Actual <True>"); // Not a flag
                     
             NoNullRet(false, Coalesce(                    False,      NullBool,   False     ));
             NoNullRet(false, Coalesce(zeroMatters: false, False,      NullBool,   False     ));
             NoNullRet(false, Coalesce(             false, False,      NullBool,   False     ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullBool,   False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullBool,   False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullBool,   False     )), "Actual <True>"); // Not a flag
     
             NoNullRet(true,  Coalesce(                    False,      NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullBool,   True      ));
             NoNullRet(true,  Coalesce(             false, False,      NullBool,   True      ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullBool,   True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullBool,   True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullBool,   True      )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, Coalesce(                    False,      NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: false, False,      NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(             false, False,      NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyFalse, NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyFalse, NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyFalse, NullBool  )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(             false, False,      NullyFalse, NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyFalse, NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyFalse, NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyFalse, NullyTrue )), "Actual <True>"); // Not a flag
                     
             NoNullRet(false, Coalesce(                    False,      NullyFalse, False     ));
             NoNullRet(false, Coalesce(zeroMatters: false, False,      NullyFalse, False     ));
             NoNullRet(false, Coalesce(             false, False,      NullyFalse, False     ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyFalse, False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyFalse, False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyFalse, False     )), "Actual <True>"); // Not a flag
     
             NoNullRet(true,  Coalesce(                    False,      NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullyFalse, True      ));
             NoNullRet(true,  Coalesce(             false, False,      NullyFalse, True      ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyFalse, True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyFalse, True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyFalse, True      )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(             false, False,      NullyTrue,  NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyTrue,  NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyTrue,  NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyTrue,  NullBool  )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(             false, False,      NullyTrue,  NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyTrue,  NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyTrue,  NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyTrue,  NullyFalse)), "Actual <True>"); // Not a flag
                     
             NoNullRet(true,  Coalesce(                    False,      NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(             false, False,      NullyTrue,  False     ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyTrue,  False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyTrue,  False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyTrue,  False     )), "Actual <True>"); // Not a flag
     
             NoNullRet(true,  Coalesce(                    False,      NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(             false, False,      NullyTrue,  True      ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      NullyTrue,  True      ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      NullyTrue,  True      ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      NullyTrue,  True      )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      True,       NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      True,       NullBool  ));
             NoNullRet(true,  Coalesce(             false, False,      True,       NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      True,       NullBool  ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      True,       NullBool  ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      True,       NullBool  )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      True,       NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      True,       NullyFalse));
             NoNullRet(true,  Coalesce(             false, False,      True,       NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters,        False,      True,       NullyFalse));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      True,       NullyFalse));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      True,       NullyFalse)), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      True,       NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      True,       NullyTrue ));
             NoNullRet(true,  Coalesce(             false, False,      True,       NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      True,       NullyTrue ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      True,       NullyTrue ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      True,       NullyTrue )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  Coalesce(                    False,      True,       False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, False,      True,       False     ));
             NoNullRet(true,  Coalesce(             false, False,      True,       False     ));
             NoNullRet(false, Coalesce(zeroMatters,        False,      True,       False     ));
             NoNullRet(false, Coalesce(zeroMatters: true,  False,      True,       False     ));
Throws(() => NoNullRet(false, Coalesce(             true,  False,      True,       False     )), "Actual <True>"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch5()
    {
             NoNullRet(true,  Coalesce(                    True,       NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(             false, True,       NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullBool,   NullyFalse));
             NoNullRet(true,  Coalesce(             true,  True,       NullBool,   NullyFalse));

             NoNullRet(true,  Coalesce(                    True,       NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(             false, True,       NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullBool,   NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  True,       NullBool,   NullyTrue ));

             NoNullRet(true,  Coalesce(                    True,       NullBool,   False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullBool,   False     ));
             NoNullRet(true,  Coalesce(             false, True,       NullBool,   False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullBool,   False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullBool,   False     ));
             NoNullRet(true,  Coalesce(             true,  True,       NullBool,   False     ));
             
             NoNullRet(true,  Coalesce(                    True,       NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullBool,   True      ));
             NoNullRet(true,  Coalesce(             false, True,       NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullBool,   True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullBool,   True      ));
             NoNullRet(true,  Coalesce(             true,  True,       NullBool,   True      ));

             NoNullRet(true,  Coalesce(                    True,       NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(             false, True,       NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyFalse, NullBool  ));
             NoNullRet(true,  Coalesce(             true,  True,       NullyFalse, NullBool  ));

             NoNullRet(true,  Coalesce(                    True,       NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(             false, True,       NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyFalse, NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  True,       NullyFalse, NullyTrue ));

             NoNullRet(true,  Coalesce(                    True,       NullyFalse, False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyFalse, False     ));
             NoNullRet(true,  Coalesce(             false, True,       NullyFalse, False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyFalse, False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyFalse, False     ));
             NoNullRet(true,  Coalesce(             true,  True,       NullyFalse, False     ));
             
             NoNullRet(true,  Coalesce(                    True,       NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyFalse, True      ));
             NoNullRet(true,  Coalesce(             false, True,       NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyFalse, True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyFalse, True      ));
             NoNullRet(true,  Coalesce(             true,  True,       NullyFalse, True      ));

             NoNullRet(true,  Coalesce(                    True,       NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(             false, True,       NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyTrue,  NullBool  ));
             NoNullRet(true,  Coalesce(             true,  True,       NullyTrue,  NullBool  ));

             NoNullRet(true,  Coalesce(                    True,       NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(             false, True,       NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyTrue,  NullyFalse));
             NoNullRet(true,  Coalesce(             true,  True,       NullyTrue,  NullyFalse));

             NoNullRet(true,  Coalesce(                    True,       NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(             false, True,       NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyTrue,  False     ));
             NoNullRet(true,  Coalesce(             true,  True,       NullyTrue,  False     ));
             
             NoNullRet(true,  Coalesce(                    True,       NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(             false, True,       NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       NullyTrue,  True      ));
             NoNullRet(true,  Coalesce(             true,  True,       NullyTrue,  True      ));

             NoNullRet(true,  Coalesce(                    True,       False,      NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       False,      NullBool  ));
             NoNullRet(true,  Coalesce(             false, True,       False,      NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       False,      NullBool  ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       False,      NullBool  ));
             NoNullRet(true,  Coalesce(             true,  True,       False,      NullBool  ));

             NoNullRet(true,  Coalesce(                    True,       False,      NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       False,      NullyFalse));
             NoNullRet(true,  Coalesce(             false, True,       False,      NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       False,      NullyFalse));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       False,      NullyFalse));
             NoNullRet(true,  Coalesce(             true,  True,       False,      NullyFalse));

             NoNullRet(true,  Coalesce(                    True,       False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       False,      NullyTrue ));
             NoNullRet(true,  Coalesce(             false, True,       False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       False,      NullyTrue ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       False,      NullyTrue ));
             NoNullRet(true,  Coalesce(             true,  True,       False,      NullyTrue ));
              
             NoNullRet(true,  Coalesce(                    True,       False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters: false, True,       False,      True      ));
             NoNullRet(true,  Coalesce(             false, True,       False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters,        True,       False,      True      ));
             NoNullRet(true,  Coalesce(zeroMatters: true,  True,       False,      True      ));
             NoNullRet(true,  Coalesce(             true,  True,       False,      True      ));
   }
}