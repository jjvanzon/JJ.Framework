namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront_Batch1()
    {
        NoNullRet(false, NullBool  .Coalesce(                    NullyFalse, NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: false, NullyFalse, NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(             false, NullyFalse, NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        NullyFalse, NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  NullyFalse, NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(             true,  NullyFalse, NullBool  ));

        NoNullRet(true,  NullBool  .Coalesce(                    NullyFalse, NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, NullyFalse, NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(             false, NullyFalse, NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        NullyFalse, NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  NullyFalse, NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(             true,  NullyFalse, NullyTrue ));
        
        NoNullRet(false, NullBool  .Coalesce(                    NullyFalse, False     ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: false, NullyFalse, False     ));
        NoNullRet(false, NullBool  .Coalesce(             false, NullyFalse, False     ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        NullyFalse, False     ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  NullyFalse, False     ));
        NoNullRet(false, NullBool  .Coalesce(             true,  NullyFalse, False     ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    NullyFalse, True      ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, NullyFalse, True      ));
        NoNullRet(true,  NullBool  .Coalesce(             false, NullyFalse, True      ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        NullyFalse, True      ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  NullyFalse, True      ));
        NoNullRet(false, NullBool  .Coalesce(             true,  NullyFalse, True      ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    NullyTrue,  NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(             false, NullyTrue,  NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        NullyTrue,  NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  NullyTrue,  NullBool  ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    NullyTrue,  NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(             false, NullyTrue,  NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        NullyTrue,  NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(             true,  NullyTrue,  NullyFalse));
        
        NoNullRet(true,  NullBool  .Coalesce(                    NullyTrue,  False     ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  False     ));
        NoNullRet(true,  NullBool  .Coalesce(             false, NullyTrue,  False     ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        NullyTrue,  False     ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  False     ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  NullyTrue,  False     ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    NullyTrue,  True      ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, NullyTrue,  True      ));
        NoNullRet(true,  NullBool  .Coalesce(             false, NullyTrue,  True      ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        NullyTrue,  True      ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  NullyTrue,  True      ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  NullyTrue,  True      ));
        
        NoNullRet(false, NullBool  .Coalesce(                    False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: false, False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(             false, False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(             true,  False,      NullyFalse));
        
        NoNullRet(false, NullBool  .Coalesce(                    False,      NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: false, False,      NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(             false, False,      NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        False,      NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  False,      NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(             true,  False,      NullBool  ));
        
        NoNullRet(false, NullBool  .Coalesce(                    False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: false, False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(             false, False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  False,      NullyFalse));
        NoNullRet(false, NullBool  .Coalesce(             true,  False,      NullyFalse));
        
        NoNullRet(true,  NullBool  .Coalesce(                    False,      NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, False,      NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(             false, False,      NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        False,      NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  False,      NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(             true,  False,      NullyTrue ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    False,      True      ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, False,      True      ));
        NoNullRet(true,  NullBool  .Coalesce(             false, False,      True      ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters,        False,      True      ));
        NoNullRet(false, NullBool  .Coalesce(zeroMatters: true,  False,      True      ));
        NoNullRet(false, NullBool  .Coalesce(             true,  False,      True      ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    True,       NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, True,       NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(             false, True,       NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        True,       NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  True,       NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  True,       NullBool  ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    True,       NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, True,       NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(             false, True,       NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        True,       NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  True,       NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(             true,  True,       NullyFalse));
        
        NoNullRet(true,  NullBool  .Coalesce(                    True,       NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, True,       NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(             false, True,       NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        True,       NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  True,       NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  True,       NullyTrue ));
        
        NoNullRet(true,  NullBool  .Coalesce(                    True,       False     ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: false, True,       False     ));
        NoNullRet(true,  NullBool  .Coalesce(             false, True,       False     ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters,        True,       False     ));
        NoNullRet(true,  NullBool  .Coalesce(zeroMatters: true,  True,       False     ));
        NoNullRet(true,  NullBool  .Coalesce(             true,  True,       False     ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront_Batch2()
    {
        NoNullRet(false, NullyFalse.Coalesce(                    NullBool,   NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, NullBool,   NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(             false, NullBool,   NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullBool,   NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullBool,   NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullBool,   NullyFalse));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    NullBool,   NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, NullBool,   NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, NullBool,   NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullBool,   NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullBool,   NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullBool,   NullyTrue ));
        
        NoNullRet(false, NullyFalse.Coalesce(                    NullBool,   False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, NullBool,   False     ));
        NoNullRet(false, NullyFalse.Coalesce(             false, NullBool,   False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullBool,   False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullBool,   False     ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullBool,   False     ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    NullBool,   True      ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, NullBool,   True      ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, NullBool,   True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullBool,   True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullBool,   True      ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullBool,   True      ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    NullyTrue,  NullBool  ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  NullBool  ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, NullyTrue,  NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullyTrue,  NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullyTrue,  NullBool  ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    NullyTrue,  NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(             false, NullyTrue,  NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullyTrue,  NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullyTrue,  NullyFalse));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    NullyTrue,  False     ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  False     ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, NullyTrue,  False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullyTrue,  False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  False     ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullyTrue,  False     ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    NullyTrue,  True      ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, NullyTrue,  True      ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, NullyTrue,  True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        NullyTrue,  True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  NullyTrue,  True      ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  NullyTrue,  True      ));
        
        NoNullRet(false, NullyFalse.Coalesce(                    False,      NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, False,      NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(             false, False,      NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        False,      NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  False,      NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  False,      NullBool  ));
        
        NoNullRet(false, NullyFalse.Coalesce(                    False,      NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: false, False,      NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(             false, False,      NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        False,      NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  False,      NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(             true,  False,      NullyFalse));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    False,      NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, False,      NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, False,      NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        False,      NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  False,      NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  False,      NullyTrue ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    False,      True      ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, False,      True      ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, False,      True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        False,      True      ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  False,      True      ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  False,      True      ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    True,       NullBool  ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, True,       NullBool  ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, True,       NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        True,       NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  True,       NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  True,       NullBool  ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    True,       NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, True,       NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(             false, True,       NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        True,       NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  True,       NullyFalse));
        NoNullRet(false, NullyFalse.Coalesce(             true,  True,       NullyFalse));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    True,       NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, True,       NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, True,       NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        True,       NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  True,       NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  True,       NullyTrue ));
        
        NoNullRet(true,  NullyFalse.Coalesce(                    True,       False     ));
        NoNullRet(true,  NullyFalse.Coalesce(zeroMatters: false, True,       False     ));
        NoNullRet(true,  NullyFalse.Coalesce(             false, True,       False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters,        True,       False     ));
        NoNullRet(false, NullyFalse.Coalesce(zeroMatters: true,  True,       False     ));
        NoNullRet(false, NullyFalse.Coalesce(             true,  True,       False     ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront_Batch3()
    {
        NoNullRet(true,  NullyTrue .Coalesce(                    NullBool,   NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullBool,   NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullBool,   NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullBool,   NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullBool,   NullyFalse));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    NullBool,   NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullBool,   NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullBool,   NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullBool,   NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullBool,   NullyTrue ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    NullBool,   False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullBool,   False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullBool,   False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullBool,   False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullBool,   False     ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    NullBool,   True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullBool,   True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullBool,   True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullBool,   True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullBool,   True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullBool,   True      ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    NullyFalse, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullyFalse, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullyFalse, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullyFalse, NullBool  ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    NullyFalse, NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullyFalse, NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullyFalse, NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullyFalse, NullyTrue ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    NullyFalse, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullyFalse, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullyFalse, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullyFalse, False     ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    NullyFalse, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, NullyFalse, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, NullyFalse, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        NullyFalse, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  NullyFalse, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  NullyFalse, True      ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    False,      NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, False,      NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, False,      NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        False,      NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  False,      NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  False,      NullBool  ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    False,      NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, False,      NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             false, False,      NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        False,      NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  False,      NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  False,      NullyFalse));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    False,      NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, False,      NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, False,      NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        False,      NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  False,      NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  False,      NullyTrue ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    False,      True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, False,      True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, False,      True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        False,      True      ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  False,      True      ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  False,      True      ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    True,       NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, True,       NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, True,       NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        True,       NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  True,       NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  True,       NullBool  ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    True,       NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, True,       NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             false, True,       NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        True,       NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  True,       NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  True,       NullyFalse));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    True,       NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, True,       NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, True,       NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        True,       NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  True,       NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  True,       NullyTrue ));
        
        NoNullRet(true,  NullyTrue .Coalesce(                    True,       False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: false, True,       False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             false, True,       False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters,        True,       False     ));
        NoNullRet(true,  NullyTrue .Coalesce(zeroMatters: true,  True,       False     ));
        NoNullRet(true,  NullyTrue .Coalesce(             true,  True,       False     ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront_Batch4()
    {
        NoNullRet(false, False     .Coalesce(                    NullBool,   NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, NullBool,   NullyFalse));
        NoNullRet(false, False     .Coalesce(             false, NullBool,   NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullBool,   NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullBool,   NullyFalse));
        NoNullRet(false, False     .Coalesce(             true,  NullBool,   NullyFalse));
        
        NoNullRet(true,  False     .Coalesce(                    NullBool,   NullyTrue ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullBool,   NullyTrue ));
        NoNullRet(true,  False     .Coalesce(             false, NullBool,   NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullBool,   NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullBool,   NullyTrue ));
        NoNullRet(false, False     .Coalesce(             true,  NullBool,   NullyTrue ));
        
        NoNullRet(false, False     .Coalesce(                    NullBool,   False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, NullBool,   False     ));
        NoNullRet(false, False     .Coalesce(             false, NullBool,   False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullBool,   False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullBool,   False     ));
        NoNullRet(false, False     .Coalesce(             true,  NullBool,   False     ));
        
        NoNullRet(true,  False     .Coalesce(                    NullBool,   True      ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullBool,   True      ));
        NoNullRet(true,  False     .Coalesce(             false, NullBool,   True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullBool,   True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullBool,   True      ));
        NoNullRet(false, False     .Coalesce(             true,  NullBool,   True      ));

        NoNullRet(false, False     .Coalesce(                    NullyFalse, NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, NullyFalse, NullBool  ));
        NoNullRet(false, False     .Coalesce(             false, NullyFalse, NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyFalse, NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyFalse, NullBool  ));
        NoNullRet(false, False     .Coalesce(             true,  NullyFalse, NullBool  ));
        
        NoNullRet(true,  False     .Coalesce(                    NullyFalse, NullyTrue ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullyFalse, NullyTrue ));
        NoNullRet(true,  False     .Coalesce(             false, NullyFalse, NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyFalse, NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyFalse, NullyTrue ));
        NoNullRet(false, False     .Coalesce(             true,  NullyFalse, NullyTrue ));
        
        NoNullRet(false, False     .Coalesce(                    NullyFalse, False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters: false, NullyFalse, False     ));
        NoNullRet(false, False     .Coalesce(             false, NullyFalse, False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyFalse, False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyFalse, False     ));
        NoNullRet(false, False     .Coalesce(             true,  NullyFalse, False     ));
        
        NoNullRet(true,  False     .Coalesce(                    NullyFalse, True      ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullyFalse, True      ));
        NoNullRet(true,  False     .Coalesce(             false, NullyFalse, True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyFalse, True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyFalse, True      ));
        NoNullRet(false, False     .Coalesce(             true,  NullyFalse, True      ));
        
        NoNullRet(true,  False     .Coalesce(                    NullyTrue,  NullBool  ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullyTrue,  NullBool  ));
        NoNullRet(true,  False     .Coalesce(             false, NullyTrue,  NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyTrue,  NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyTrue,  NullBool  ));
        NoNullRet(false, False     .Coalesce(             true,  NullyTrue,  NullBool  ));
        
        NoNullRet(true,  False     .Coalesce(                    NullyTrue,  NullyFalse));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullyTrue,  NullyFalse));
        NoNullRet(true,  False     .Coalesce(             false, NullyTrue,  NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyTrue,  NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse));
        NoNullRet(false, False     .Coalesce(             true,  NullyTrue,  NullyFalse));
        
        NoNullRet(true,  False     .Coalesce(                    NullyTrue,  False     ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullyTrue,  False     ));
        NoNullRet(true,  False     .Coalesce(             false, NullyTrue,  False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyTrue,  False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyTrue,  False     ));
        NoNullRet(false, False     .Coalesce(             true,  NullyTrue,  False     ));
        
        NoNullRet(true,  False     .Coalesce(                    NullyTrue,  True      ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, NullyTrue,  True      ));
        NoNullRet(true,  False     .Coalesce(             false, NullyTrue,  True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        NullyTrue,  True      ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  NullyTrue,  True      ));
        NoNullRet(false, False     .Coalesce(             true,  NullyTrue,  True      ));
        
        NoNullRet(true,  False     .Coalesce(                    True,       NullBool  ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, True,       NullBool  ));
        NoNullRet(true,  False     .Coalesce(             false, True,       NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        True,       NullBool  ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  True,       NullBool  ));
        NoNullRet(false, False     .Coalesce(             true,  True,       NullBool  ));
        
        NoNullRet(true,  False     .Coalesce(                    True,       NullyFalse));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, True,       NullyFalse));
        NoNullRet(true,  False     .Coalesce(             false, True,       NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters,        True,       NullyFalse));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  True,       NullyFalse));
        NoNullRet(false, False     .Coalesce(             true,  True,       NullyFalse));
        
        NoNullRet(true,  False     .Coalesce(                    True,       NullyTrue ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, True,       NullyTrue ));
        NoNullRet(true,  False     .Coalesce(             false, True,       NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        True,       NullyTrue ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  True,       NullyTrue ));
        NoNullRet(false, False     .Coalesce(             true,  True,       NullyTrue ));
        
        NoNullRet(true,  False     .Coalesce(                    True,       False     ));
        NoNullRet(true,  False     .Coalesce(zeroMatters: false, True,       False     ));
        NoNullRet(true,  False     .Coalesce(             false, True,       False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters,        True,       False     ));
        NoNullRet(false, False     .Coalesce(zeroMatters: true,  True,       False     ));
        NoNullRet(false, False     .Coalesce(             true,  True,       False     ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront_Batch5()
    {
        NoNullRet(true,  True      .Coalesce(                    NullBool,   NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullBool,   NullyFalse));
        NoNullRet(true,  True      .Coalesce(             false, NullBool,   NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullBool,   NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullBool,   NullyFalse));
        NoNullRet(true,  True      .Coalesce(             true,  NullBool,   NullyFalse));
        
        NoNullRet(true,  True      .Coalesce(                    NullBool,   NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullBool,   NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             false, NullBool,   NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullBool,   NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullBool,   NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             true,  NullBool,   NullyTrue ));
        
        NoNullRet(true,  True      .Coalesce(                    NullBool,   False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullBool,   False     ));
        NoNullRet(true,  True      .Coalesce(             false, NullBool,   False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullBool,   False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullBool,   False     ));
        NoNullRet(true,  True      .Coalesce(             true,  NullBool,   False     ));
        
        NoNullRet(true,  True      .Coalesce(                    NullBool,   True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullBool,   True      ));
        NoNullRet(true,  True      .Coalesce(             false, NullBool,   True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullBool,   True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullBool,   True      ));
        NoNullRet(true,  True      .Coalesce(             true,  NullBool,   True      ));
        
        NoNullRet(true,  True      .Coalesce(                    NullyFalse, NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyFalse, NullBool  ));
        NoNullRet(true,  True      .Coalesce(             false, NullyFalse, NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyFalse, NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyFalse, NullBool  ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyFalse, NullBool  ));
        
        NoNullRet(true,  True      .Coalesce(                    NullyFalse, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyFalse, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             false, NullyFalse, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyFalse, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyFalse, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyFalse, NullyTrue ));
        
        NoNullRet(true,  True      .Coalesce(                    NullyFalse, False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyFalse, False     ));
        NoNullRet(true,  True      .Coalesce(             false, NullyFalse, False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyFalse, False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyFalse, False     ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyFalse, False     ));
        
        NoNullRet(true,  True      .Coalesce(                    NullyFalse, True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyFalse, True      ));
        NoNullRet(true,  True      .Coalesce(             false, NullyFalse, True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyFalse, True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyFalse, True      ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyFalse, True      ));
        
        NoNullRet(true,  True      .Coalesce(                    NullyTrue,  NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyTrue,  NullBool  ));
        NoNullRet(true,  True      .Coalesce(             false, NullyTrue,  NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyTrue,  NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyTrue,  NullBool  ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyTrue,  NullBool  ));
        
        NoNullRet(true,  True      .Coalesce(                    NullyTrue,  NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyTrue,  NullyFalse));
        NoNullRet(true,  True      .Coalesce(             false, NullyTrue,  NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyTrue,  NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyTrue,  NullyFalse));
        NoNullRet(true,  True      .Coalesce(             true,  NullyTrue,  NullyFalse));
        
        NoNullRet(true,  True      .Coalesce(                    NullyTrue,  False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyTrue,  False     ));
        NoNullRet(true,  True      .Coalesce(             false, NullyTrue,  False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyTrue,  False     ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyTrue,  False     ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyTrue,  False     ));
        
        NoNullRet(true,  True      .Coalesce(                    NullyTrue,  True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, NullyTrue,  True      ));
        NoNullRet(true,  True      .Coalesce(             false, NullyTrue,  True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        NullyTrue,  True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  NullyTrue,  True      ));
        NoNullRet(true,  True      .Coalesce(             true,  NullyTrue,  True      ));
        
        NoNullRet(true,  True      .Coalesce(                    False,      NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, False,      NullBool  ));
        NoNullRet(true,  True      .Coalesce(             false, False,      NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        False,      NullBool  ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  False,      NullBool  ));
        NoNullRet(true,  True      .Coalesce(             true,  False,      NullBool  ));
        
        NoNullRet(true,  True      .Coalesce(                    False,      NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, False,      NullyFalse));
        NoNullRet(true,  True      .Coalesce(             false, False,      NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        False,      NullyFalse));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  False,      NullyFalse));
        NoNullRet(true,  True      .Coalesce(             true,  False,      NullyFalse));
        
        NoNullRet(true,  True      .Coalesce(                    False,      NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, False,      NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             false, False,      NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        False,      NullyTrue ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  False,      NullyTrue ));
        NoNullRet(true,  True      .Coalesce(             true,  False,      NullyTrue ));
        
        NoNullRet(true,  True      .Coalesce(                    False,      True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: false, False,      True      ));
        NoNullRet(true,  True      .Coalesce(             false, False,      True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters,        False,      True      ));
        NoNullRet(true,  True      .Coalesce(zeroMatters: true,  False,      True      ));
        NoNullRet(true,  True      .Coalesce(             true,  False,      True      ));
    }
}