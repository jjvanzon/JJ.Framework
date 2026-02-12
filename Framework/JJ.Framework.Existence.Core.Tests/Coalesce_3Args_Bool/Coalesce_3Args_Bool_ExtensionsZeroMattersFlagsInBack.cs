namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack_Batch1()
    {
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullBool                      ));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullBool,   zeroMatters: false));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullBool,                false));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullBool,   zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullBool,                true )), "Actual <True>"); // Not a flag

             NoNullRet(true,  NullBool  .Coalesce(NullyFalse, NullyTrue                     ));
             NoNullRet(true,  NullBool  .Coalesce(NullyFalse, NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(NullyFalse, NullyTrue,               false));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullyTrue,  zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, False                         ));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, False,      zeroMatters: false));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, False,                   false));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, False,      zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, False,      zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(NullyFalse, False,                   true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullBool  .Coalesce(NullyFalse, True                          ));
             NoNullRet(true,  NullBool  .Coalesce(NullyFalse, True,       zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(NullyFalse, True,                    false));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, True,       zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(NullyFalse, True,       zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(NullyFalse, True,                    true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullBool                      ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullBool,   zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullBool,                false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullBool,   zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullBool,   zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullBool,                true ));
             
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyFalse                    ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyFalse, zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyFalse,              false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyFalse, zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyFalse, zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyFalse,              true ));
             
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  False                         ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  False,      zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  False,                   false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  False,      zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  False,      zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  False,                   true ));
             
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  True                          ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  True,       zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  True,                    false));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  True,       zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  True,       zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  True,                    true ));
             
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse                    ));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse, zeroMatters: false));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse,              false));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse, zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse,              true )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, NullBool  .Coalesce(False,      NullBool                      ));
             NoNullRet(false, NullBool  .Coalesce(False,      NullBool,   zeroMatters: false));
             NoNullRet(false, NullBool  .Coalesce(False,      NullBool,                false));
             NoNullRet(false, NullBool  .Coalesce(False,      NullBool,   zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(False,      NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(False,      NullBool,                true )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse                    ));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse, zeroMatters: false));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse,              false));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse, zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse,              true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullBool  .Coalesce(False,      NullyTrue                     ));
             NoNullRet(true,  NullBool  .Coalesce(False,      NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(False,      NullyTrue,               false));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyTrue,  zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(False,      NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(False,      NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullBool  .Coalesce(False,      True                          ));
             NoNullRet(true,  NullBool  .Coalesce(False,      True,       zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(False,      True,                    false));
             NoNullRet(false, NullBool  .Coalesce(False,      True,       zeroMatters       ));
             NoNullRet(false, NullBool  .Coalesce(False,      True,       zeroMatters: true ));
Throws(() => NoNullRet(false, NullBool  .Coalesce(False,      True,                    true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullBool  .Coalesce(True,       NullBool                      ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullBool,   zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullBool,                false));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullBool,   zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullBool,   zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullBool,                true ));
             
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyFalse                    ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyFalse, zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyFalse,              false));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyFalse, zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyFalse, zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyFalse,              true ));
             
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyTrue                     ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyTrue,               false));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyTrue,  zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(True,       NullyTrue,               true ));
             
             NoNullRet(true,  NullBool  .Coalesce(True,       False                         ));
             NoNullRet(true,  NullBool  .Coalesce(True,       False,      zeroMatters: false));
             NoNullRet(true,  NullBool  .Coalesce(True,       False,                   false));
             NoNullRet(true,  NullBool  .Coalesce(True,       False,      zeroMatters       ));
             NoNullRet(true,  NullBool  .Coalesce(True,       False,      zeroMatters: true ));
             NoNullRet(true,  NullBool  .Coalesce(True,       False,                   true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack_Batch2()
    {
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyFalse                    ));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyFalse, zeroMatters: false));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyFalse,              false));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyFalse, zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyFalse,              true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(NullBool,   NullyTrue                     ));
             NoNullRet(true,  NullyFalse.Coalesce(NullBool,   NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(NullBool,   NullyTrue,               false));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyTrue,  zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   False                         ));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   False,      zeroMatters: false));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   False,                   false));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   False,      zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   False,      zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullBool,   False,                   true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(NullBool,   True                          ));
             NoNullRet(true,  NullyFalse.Coalesce(NullBool,   True,       zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(NullBool,   True,                    false));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   True,       zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullBool,   True,       zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullBool,   True,                    true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullBool                      ));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullBool,   zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullBool,                false));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  NullBool,   zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  NullBool,                true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullyFalse                    ));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullyFalse, zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullyFalse,              false));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  NullyFalse, zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  NullyFalse,              true )), "Actual <True>"); // Not a flag
        
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  False                         ));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  False,      zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  False,                   false));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  False,      zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  False,      zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  False,                   true )), "Actual <True>"); // Not a flag
        
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  True                          ));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  True,       zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  True,                    false));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  True,       zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  True,       zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(NullyTrue,  True,                    true )), "Actual <True>"); // Not a flag
        
             NoNullRet(false, NullyFalse.Coalesce(False,      NullBool                      ));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullBool,   zeroMatters: false));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullBool,                false));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullBool,   zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(False,      NullBool,                true )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, NullyFalse.Coalesce(False,      NullyFalse                    ));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullyFalse, zeroMatters: false));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullyFalse,              false));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullyFalse, zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(False,      NullyFalse,              true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(False,      NullyTrue                     ));
             NoNullRet(true,  NullyFalse.Coalesce(False,      NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(False,      NullyTrue,               false));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullyTrue,  zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(False,      NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(False,      NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(False,      True                          ));
             NoNullRet(true,  NullyFalse.Coalesce(False,      True,       zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(False,      True,                    false));
             NoNullRet(false, NullyFalse.Coalesce(False,      True,       zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(False,      True,       zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(False,      True,                    true )), "Actual <True>"); // Not a flag
        
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullBool                      ));
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullBool,   zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullBool,                false));
             NoNullRet(false, NullyFalse.Coalesce(True,       NullBool,   zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(True,       NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(True,       NullBool,                true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullyFalse                    ));
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullyFalse, zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullyFalse,              false));
             NoNullRet(false, NullyFalse.Coalesce(True,       NullyFalse, zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(True,       NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(True,       NullyFalse,              true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullyTrue                     ));
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(True,       NullyTrue,               false));
             NoNullRet(false, NullyFalse.Coalesce(True,       NullyTrue,  zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(True,       NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(True,       NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  NullyFalse.Coalesce(True,       False                         ));
             NoNullRet(true,  NullyFalse.Coalesce(True,       False,      zeroMatters: false));
             NoNullRet(true,  NullyFalse.Coalesce(True,       False,                   false));
             NoNullRet(false, NullyFalse.Coalesce(True,       False,      zeroMatters       ));
             NoNullRet(false, NullyFalse.Coalesce(True,       False,      zeroMatters: true ));
Throws(() => NoNullRet(false, NullyFalse.Coalesce(True,       False,                   true )), "Actual <True>"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack_Batch3()
    {
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyFalse                    ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyFalse, zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyFalse,              false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyFalse, zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyFalse, zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyFalse,              true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyTrue                     ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyTrue,               false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyTrue,  zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyTrue,               true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   False                         ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   False,      zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   False,                   false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   False,      zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   False,      zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   False,                   true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   True                          ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   True,       zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   True,                    false));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   True,       zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   True,       zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullBool,   True,                    true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullBool                      ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullBool,   zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullBool,                false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullBool,   zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullBool,   zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullBool,                true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyTrue                     ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyTrue,               false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyTrue,  zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyTrue,               true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, False                         ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, False,      zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, False,                   false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, False,      zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, False,      zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, False,                   true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, True                          ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, True,       zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, True,                    false));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, True,       zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, True,       zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, True,                    true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullBool                      ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullBool,   zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullBool,                false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullBool,   zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullBool,   zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullBool,                true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyFalse                    ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyFalse, zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyFalse,              false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyFalse, zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyFalse, zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyFalse,              true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyTrue                     ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyTrue,               false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyTrue,  zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      NullyTrue,               true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(False,      True                          ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      True,       zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      True,                    false));
             NoNullRet(true,  NullyTrue .Coalesce(False,      True,       zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      True,       zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(False,      True,                    true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullBool                      ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullBool,   zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullBool,                false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullBool,   zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullBool,   zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullBool,                true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyFalse                    ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyFalse, zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyFalse,              false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyFalse, zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyFalse, zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyFalse,              true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyTrue                     ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyTrue,  zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyTrue,               false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyTrue,  zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       NullyTrue,               true ));
             
             NoNullRet(true,  NullyTrue .Coalesce(True,       False                         ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       False,      zeroMatters: false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       False,                   false));
             NoNullRet(true,  NullyTrue .Coalesce(True,       False,      zeroMatters       ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       False,      zeroMatters: true ));
             NoNullRet(true,  NullyTrue .Coalesce(True,       False,                   true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack_Batch4()
    {
             NoNullRet(false, False     .Coalesce(NullBool,   NullyFalse                    ));
             NoNullRet(false, False     .Coalesce(NullBool,   NullyFalse, zeroMatters: false));
             NoNullRet(false, False     .Coalesce(NullBool,   NullyFalse,              false));
             NoNullRet(false, False     .Coalesce(NullBool,   NullyFalse, zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullBool,   NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullBool,   NullyFalse,              true )), "Actual <True>"); // Not a flag
        
             NoNullRet(true,  False     .Coalesce(NullBool,   NullyTrue                     ));
             NoNullRet(true,  False     .Coalesce(NullBool,   NullyTrue,  zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullBool,   NullyTrue,               false));
             NoNullRet(false, False     .Coalesce(NullBool,   NullyTrue,  zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullBool,   NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullBool,   NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, False     .Coalesce(NullBool,   False                         ));
             NoNullRet(false, False     .Coalesce(NullBool,   False,      zeroMatters: false));
             NoNullRet(false, False     .Coalesce(NullBool,   False,                   false));
             NoNullRet(false, False     .Coalesce(NullBool,   False,      zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullBool,   False,      zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullBool,   False,                   true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(NullBool,   True                          ));
             NoNullRet(true,  False     .Coalesce(NullBool,   True,       zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullBool,   True,                    false));
             NoNullRet(false, False     .Coalesce(NullBool,   True,       zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullBool,   True,       zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullBool,   True,                    true )), "Actual <True>"); // Not a flag
          
             NoNullRet(false, False     .Coalesce(NullyFalse, NullBool                      ));
             NoNullRet(false, False     .Coalesce(NullyFalse, NullBool,   zeroMatters: false));
             NoNullRet(false, False     .Coalesce(NullyFalse, NullBool,                false));
             NoNullRet(false, False     .Coalesce(NullyFalse, NullBool,   zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyFalse, NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyFalse, NullBool,                true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(NullyFalse, NullyTrue                     ));
             NoNullRet(true,  False     .Coalesce(NullyFalse, NullyTrue,  zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullyFalse, NullyTrue,               false));
             NoNullRet(false, False     .Coalesce(NullyFalse, NullyTrue,  zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyFalse, NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyFalse, NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(false, False     .Coalesce(NullyFalse, False                         ));
             NoNullRet(false, False     .Coalesce(NullyFalse, False,      zeroMatters: false));
             NoNullRet(false, False     .Coalesce(NullyFalse, False,                   false));
             NoNullRet(false, False     .Coalesce(NullyFalse, False,      zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyFalse, False,      zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyFalse, False,                   true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(NullyFalse, True                          ));
             NoNullRet(true,  False     .Coalesce(NullyFalse, True,       zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullyFalse, True,                    false));
             NoNullRet(false, False     .Coalesce(NullyFalse, True,       zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyFalse, True,       zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyFalse, True,                    true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(NullyTrue,  NullBool                      ));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  NullBool,   zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  NullBool,                false));
             NoNullRet(false, False     .Coalesce(NullyTrue,  NullBool,   zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyTrue,  NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyTrue,  NullBool,                true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(NullyTrue,  NullyFalse                    ));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  NullyFalse, zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  NullyFalse,              false));
             NoNullRet(false, False     .Coalesce(NullyTrue,  NullyFalse, zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyTrue,  NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyTrue,  NullyFalse,              true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(NullyTrue,  False                         ));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  False,      zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  False,                   false));
             NoNullRet(false, False     .Coalesce(NullyTrue,  False,      zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyTrue,  False,      zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyTrue,  False,                   true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(NullyTrue,  True                          ));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  True,       zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(NullyTrue,  True,                    false));
             NoNullRet(false, False     .Coalesce(NullyTrue,  True,       zeroMatters       ));
             NoNullRet(false, False     .Coalesce(NullyTrue,  True,       zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(NullyTrue,  True,                    true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(True,       NullBool                      ));
             NoNullRet(true,  False     .Coalesce(True,       NullBool,   zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(True,       NullBool,                false));
             NoNullRet(false, False     .Coalesce(True,       NullBool,   zeroMatters       ));
             NoNullRet(false, False     .Coalesce(True,       NullBool,   zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(True,       NullBool,                true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(True,       NullyFalse                    ));
             NoNullRet(true,  False     .Coalesce(True,       NullyFalse, zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(True,       NullyFalse,              false));
             NoNullRet(false, False     .Coalesce(True,       NullyFalse, zeroMatters       ));
             NoNullRet(false, False     .Coalesce(True,       NullyFalse, zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(True,       NullyFalse,              true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(True,       NullyTrue                     ));
             NoNullRet(true,  False     .Coalesce(True,       NullyTrue,  zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(True,       NullyTrue,               false));
             NoNullRet(false, False     .Coalesce(True,       NullyTrue,  zeroMatters       ));
             NoNullRet(false, False     .Coalesce(True,       NullyTrue,  zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(True,       NullyTrue,               true )), "Actual <True>"); // Not a flag
             
             NoNullRet(true,  False     .Coalesce(True,       False                         ));
             NoNullRet(true,  False     .Coalesce(True,       False,      zeroMatters: false));
             NoNullRet(true,  False     .Coalesce(True,       False,                   false));
             NoNullRet(false, False     .Coalesce(True,       False,      zeroMatters       ));
             NoNullRet(false, False     .Coalesce(True,       False,      zeroMatters: true ));
Throws(() => NoNullRet(false, False     .Coalesce(True,       False,                   true )), "Actual <True>"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack_Batch5()
    {
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyFalse                    ));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyFalse, zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyFalse,              false));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyFalse, zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyFalse, zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyFalse,              true ));
             
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyTrue                     ));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyTrue,  zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyTrue,               false));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyTrue,  zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullBool,   NullyTrue,               true ));
             
             NoNullRet(true,  True      .Coalesce(NullBool,   False                         ));
             NoNullRet(true,  True      .Coalesce(NullBool,   False,      zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullBool,   False,                   false));
             NoNullRet(true,  True      .Coalesce(NullBool,   False,      zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullBool,   False,      zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullBool,   False,                   true ));
             
             NoNullRet(true,  True      .Coalesce(NullBool,   True                          ));
             NoNullRet(true,  True      .Coalesce(NullBool,   True,       zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullBool,   True,                    false));
             NoNullRet(true,  True      .Coalesce(NullBool,   True,       zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullBool,   True,       zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullBool,   True,                    true ));
             
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullBool                      ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullBool,   zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullBool,                false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullBool,   zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullBool,   zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullBool,                true ));
             
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullyTrue                     ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullyTrue,  zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullyTrue,               false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullyTrue,  zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, NullyTrue,               true ));
             
             NoNullRet(true,  True      .Coalesce(NullyFalse, False                         ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, False,      zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, False,                   false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, False,      zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, False,      zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, False,                   true ));
             
             NoNullRet(true,  True      .Coalesce(NullyFalse, True                          ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, True,       zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, True,                    false));
             NoNullRet(true,  True      .Coalesce(NullyFalse, True,       zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, True,       zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyFalse, True,                    true ));
             
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullBool                      ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullBool,   zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullBool,                false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullBool,   zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullBool,   zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullBool,                true ));
             
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyFalse                    ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyFalse, zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyFalse,              false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyFalse, zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyFalse, zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyFalse,              true ));
             
             NoNullRet(true,  True      .Coalesce(NullyTrue,  False                         ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  False,      zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  False,                   false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  False,      zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  False,      zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  False,                   true ));
             
             NoNullRet(true,  True      .Coalesce(NullyTrue,  True                          ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  True,       zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  True,                    false));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  True,       zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  True,       zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(NullyTrue,  True,                    true ));
             
             NoNullRet(true,  True      .Coalesce(False,      NullBool                      ));
             NoNullRet(true,  True      .Coalesce(False,      NullBool,   zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(False,      NullBool,                false));
             NoNullRet(true,  True      .Coalesce(False,      NullBool,   zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(False,      NullBool,   zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(False,      NullBool,                true ));
             
             NoNullRet(true,  True      .Coalesce(False,      NullyFalse                    ));
             NoNullRet(true,  True      .Coalesce(False,      NullyFalse, zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(False,      NullyFalse,              false));
             NoNullRet(true,  True      .Coalesce(False,      NullyFalse, zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(False,      NullyFalse, zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(False,      NullyFalse,              true ));
             
             NoNullRet(true,  True      .Coalesce(False,      NullyTrue                     ));
             NoNullRet(true,  True      .Coalesce(False,      NullyTrue,  zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(False,      NullyTrue,               false));
             NoNullRet(true,  True      .Coalesce(False,      NullyTrue,  zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(False,      NullyTrue,  zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(False,      NullyTrue,               true ));
             
             NoNullRet(true,  True      .Coalesce(False,      True                          ));
             NoNullRet(true,  True      .Coalesce(False,      True,       zeroMatters: false));
             NoNullRet(true,  True      .Coalesce(False,      True,                    false));
             NoNullRet(true,  True      .Coalesce(False,      True,       zeroMatters       ));
             NoNullRet(true,  True      .Coalesce(False,      True,       zeroMatters: true ));
             NoNullRet(true,  True      .Coalesce(False,      True,                    true ));
    }
}