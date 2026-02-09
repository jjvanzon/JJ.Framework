namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack_Batch1()
    {
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullBool                      ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullBool,   zeroMatters: false));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullBool,                false));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullBool,   zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullBool,                true ));

        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, NullyTrue,               false));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullyTrue,  zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullyTrue,               true ));
        
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, False                         ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, False,      zeroMatters: false));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, False,                   false));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, False,      zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, False,      zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, False,                   true ));
        
        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, True                          ));
        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, True,                    false));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, True,       zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, True,       zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, True,                    true ));
        
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullBool                      ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullBool,                false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullBool,                true ));
        
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyFalse                    ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyFalse,              false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  False                         ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  False,      zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  False,                   false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  False,      zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  False,                   true ));
        
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  True                          ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  True,                    false));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  True,       zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  True,                    true ));
        
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse                    ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse, zeroMatters: false));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse,              false));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse, zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse,              true ));
        
        NoNullRet(false, Coalesce(NullBool,   False,      NullBool                      ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullBool,   zeroMatters: false));
        NoNullRet(false, Coalesce(NullBool,   False,      NullBool,                false));
        NoNullRet(false, Coalesce(NullBool,   False,      NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullBool,   zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullBool,                true ));
        
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse                    ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse, zeroMatters: false));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse,              false));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse, zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullBool,   False,      NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullBool,   False,      NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   False,      NullyTrue,               false));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyTrue,  zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullBool,   False,      True                          ));
        NoNullRet(true,  Coalesce(NullBool,   False,      True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   False,      True,                    false));
        NoNullRet(false, Coalesce(NullBool,   False,      True,       zeroMatters       ));
        NoNullRet(false, Coalesce(NullBool,   False,      True,       zeroMatters: true ));
        NoNullRet(false, Coalesce(NullBool,   False,      True,                    true ));
                
        NoNullRet(true,  Coalesce(NullBool,   True,       NullBool                      ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullBool,                false));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullBool,                true ));

        NoNullRet(true,  Coalesce(NullBool,   True,       NullyFalse                    ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyFalse,              false));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyFalse,              true ));

        NoNullRet(true,  Coalesce(NullBool,   True,       NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyTrue,               false));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullBool,   True,       False                         ));
        NoNullRet(true,  Coalesce(NullBool,   True,       False,      zeroMatters: false));
        NoNullRet(true,  Coalesce(NullBool,   True,       False,                   false));
        NoNullRet(true,  Coalesce(NullBool,   True,       False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(NullBool,   True,       False,      zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullBool,   True,       False,                   true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack_Batch2()
    {
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyFalse                    ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyFalse, zeroMatters: false));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyFalse,              false));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyFalse, zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyFalse,              true ));

        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   NullyTrue,               false));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyTrue,  zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyTrue,               true ));
        
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   False                         ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   False,      zeroMatters: false));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   False,                   false));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   False,      zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   False,      zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   False,                   true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   True                          ));
        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   True,                    false));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   True,       zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   True,       zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   True,                    true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullBool                      ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullBool,                false));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  NullBool,   zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  NullBool,                true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullyFalse                    ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullyFalse,              false));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  NullyFalse, zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  False                         ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  False,      zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  False,                   false));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  False,      zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  False,      zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  False,                   true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  True                          ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  True,                    false));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  True,       zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  True,       zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, NullyTrue,  True,                    true ));
        
        NoNullRet(false, Coalesce(NullyFalse, False,      NullBool                      ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullBool,   zeroMatters: false));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullBool,                false));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullBool,   zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullBool,                true ));
                
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyFalse                    ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyFalse, zeroMatters: false));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyFalse,              false));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyFalse, zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, False,      NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullyFalse, False,      NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, False,      NullyTrue,               false));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyTrue,  zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, False,      True                          ));
        NoNullRet(true,  Coalesce(NullyFalse, False,      True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, False,      True,                    false));
        NoNullRet(false, Coalesce(NullyFalse, False,      True,       zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, False,      True,       zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, False,      True,                    true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullBool                      ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullBool,                false));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullBool,   zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullBool,                true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyFalse                    ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyFalse,              false));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullyFalse, zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyTrue,               false));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullyTrue,  zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, True,       NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullyFalse, True,       False                         ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       False,      zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyFalse, True,       False,                   false));
        NoNullRet(false, Coalesce(NullyFalse, True,       False,      zeroMatters       ));
        NoNullRet(false, Coalesce(NullyFalse, True,       False,      zeroMatters: true ));
        NoNullRet(false, Coalesce(NullyFalse, True,       False,                   true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack_Batch3()
    {
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyFalse                    ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyFalse,              false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyTrue,               false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   False                         ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   False,      zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   False,                   false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   False,      zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   False,                   true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   True                          ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   True,                    false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   True,       zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   True,                    true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullBool                      ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullBool,                false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullBool,                true ));
                
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyTrue,               false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, False                         ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, False,      zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, False,                   false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, False,      zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, False,                   true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, True                          ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, True,                    false));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, True,       zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, True,                    true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullBool                      ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullBool,                false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullBool,                true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyFalse                    ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyFalse,              false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyTrue,               false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  False,      True                          ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      True,       zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      True,                    false));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      True,       zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      True,                    true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullBool                      ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullBool,   zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullBool,                false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullBool,   zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullBool,                true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyFalse                    ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyFalse, zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyFalse,              false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyFalse, zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyFalse,              true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyTrue                     ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyTrue,  zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyTrue,               false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyTrue,  zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyTrue,               true ));
        
        NoNullRet(true,  Coalesce(NullyTrue,  True,       False                         ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       False,      zeroMatters: false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       False,                   false));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       False,      zeroMatters: true ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       False,                   true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack_Batch4()
    {
        NoNullRet(false, Coalesce(False,      NullBool,   NullyFalse                    ));
        NoNullRet(false, Coalesce(False,      NullBool,   NullyFalse, zeroMatters: false));
      //NoNullRet(false, Coalesce(False,      NullBool,   NullyFalse,              false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullBool,   NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullBool,   NullyFalse, zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullBool,   NullyFalse,              true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      NullBool,   NullyTrue                     ));
        NoNullRet(true,  Coalesce(False,      NullBool,   NullyTrue,  zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullBool,   NullyTrue,               false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullBool,   NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullBool,   NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullBool,   NullyTrue,               true )); // TODO: Does not work
                
        NoNullRet(false, Coalesce(False,      NullBool,   False                         ));
        NoNullRet(false, Coalesce(False,      NullBool,   False,      zeroMatters: false));
      //NoNullRet(false, Coalesce(False,      NullBool,   False,                   false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullBool,   False,      zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullBool,   False,      zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullBool,   False,                   true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(False,      NullBool,   True                          ));
        NoNullRet(true,  Coalesce(False,      NullBool,   True,       zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullBool,   True,                    false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullBool,   True,       zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullBool,   True,       zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullBool,   True,                    true )); // TODO: Does not work
        
        NoNullRet(false, Coalesce(False,      NullyFalse, NullBool                      ));
        NoNullRet(false, Coalesce(False,      NullyFalse, NullBool,   zeroMatters: false));
      //NoNullRet(false, Coalesce(False,      NullyFalse, NullBool,                false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyFalse, NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyFalse, NullBool,   zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyFalse, NullBool,                true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      NullyFalse, NullyTrue                     ));
        NoNullRet(true,  Coalesce(False,      NullyFalse, NullyTrue,  zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullyFalse, NullyTrue,               false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyFalse, NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyFalse, NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyFalse, NullyTrue,               true )); // TODO: Does not work
                
        NoNullRet(false, Coalesce(False,      NullyFalse, False                         ));
        NoNullRet(false, Coalesce(False,      NullyFalse, False,      zeroMatters: false));
      //NoNullRet(false, Coalesce(False,      NullyFalse, False,                   false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyFalse, False,      zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyFalse, False,      zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyFalse, False,                   true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(False,      NullyFalse, True                          ));
        NoNullRet(true,  Coalesce(False,      NullyFalse, True,       zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullyFalse, True,                    false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyFalse, True,       zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyFalse, True,       zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyFalse, True,                    true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      NullyTrue,  NullBool                      ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  NullBool,   zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullyTrue,  NullBool,                false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyTrue,  NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyTrue,  NullBool,   zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyTrue,  NullBool,                true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      NullyTrue,  NullyFalse                    ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  NullyFalse, zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullyTrue,  NullyFalse,              false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyTrue,  NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyTrue,  NullyFalse, zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyTrue,  NullyFalse,              true )); // TODO: Does not work
                
        NoNullRet(true,  Coalesce(False,      NullyTrue,  False                         ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  False,      zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullyTrue,  False,                   false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyTrue,  False,      zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyTrue,  False,      zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyTrue,  False,                   true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(False,      NullyTrue,  True                          ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  True,       zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      NullyTrue,  True,                    false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      NullyTrue,  True,       zeroMatters       ));
        NoNullRet(false, Coalesce(False,      NullyTrue,  True,       zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      NullyTrue,  True,                    true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      True,       NullBool                      ));
        NoNullRet(true,  Coalesce(False,      True,       NullBool,   zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      True,       NullBool,                false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      True,       NullBool,   zeroMatters       ));
        NoNullRet(false, Coalesce(False,      True,       NullBool,   zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      True,       NullBool,                true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      True,       NullyFalse                    ));
        NoNullRet(true,  Coalesce(False,      True,       NullyFalse, zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      True,       NullyFalse,              false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      True,       NullyFalse, zeroMatters       ));
        NoNullRet(false, Coalesce(False,      True,       NullyFalse, zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      True,       NullyFalse,              true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      True,       NullyTrue                     ));
        NoNullRet(true,  Coalesce(False,      True,       NullyTrue,  zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      True,       NullyTrue,               false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      True,       NullyTrue,  zeroMatters       ));
        NoNullRet(false, Coalesce(False,      True,       NullyTrue,  zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      True,       NullyTrue,               true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(False,      True,       False                         ));
        NoNullRet(true,  Coalesce(False,      True,       False,      zeroMatters: false));
      //NoNullRet(true,  Coalesce(False,      True,       False,                   false)); // TODO: Does not work
        NoNullRet(false, Coalesce(False,      True,       False,      zeroMatters       ));
        NoNullRet(false, Coalesce(False,      True,       False,      zeroMatters: true ));
      //NoNullRet(false, Coalesce(False,      True,       False,                   true )); // TODO: Does not work
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack_Batch5()
    {
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyFalse                    ));
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyFalse, zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullBool,   NullyFalse,              false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyFalse, zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullBool,   NullyFalse,              true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullBool,   NullyTrue                     ));
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyTrue,  zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullBool,   NullyTrue,               false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyTrue,  zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullBool,   NullyTrue,               true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullBool,   False                         ));
        NoNullRet(true,  Coalesce(True,       NullBool,   False,      zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullBool,   False,                   false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullBool,   False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullBool,   False,      zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullBool,   False,                   true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(True,       NullBool,   True                          ));
        NoNullRet(true,  Coalesce(True,       NullBool,   True,       zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullBool,   True,                    false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullBool,   True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullBool,   True,       zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullBool,   True,                    true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullyFalse, NullBool                      ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullBool,   zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, NullBool,                false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullBool,   zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, NullBool,                true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullyFalse, NullyTrue                     ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullyTrue,  zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, NullyTrue,               false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullyTrue,  zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, NullyTrue,               true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullyFalse, False                         ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, False,      zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, False,                   false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyFalse, False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, False,      zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, False,                   true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(True,       NullyFalse, True                          ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, True,       zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, True,                    false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyFalse, True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, True,       zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyFalse, True,                    true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullBool                      ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullBool,   zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  NullBool,                false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullBool,   zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  NullBool,                true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyFalse                    ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyFalse, zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyFalse,              false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyFalse, zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyFalse,              true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       NullyTrue,  False                         ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  False,      zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  False,                   false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyTrue,  False,      zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  False,      zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  False,                   true )); // TODO: Does not work
        
        NoNullRet(true,  Coalesce(True,       NullyTrue,  True                          ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  True,       zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  True,                    false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       NullyTrue,  True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  True,       zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       NullyTrue,  True,                    true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       False,      NullBool                      ));
        NoNullRet(true,  Coalesce(True,       False,      NullBool,   zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       False,      NullBool,                false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       False,      NullBool,   zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       False,      NullBool,   zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       False,      NullBool,                true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       False,      NullyFalse                    ));
        NoNullRet(true,  Coalesce(True,       False,      NullyFalse, zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       False,      NullyFalse,              false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       False,      NullyFalse, zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       False,      NullyFalse, zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       False,      NullyFalse,              true )); // TODO: Does not work

        NoNullRet(true,  Coalesce(True,       False,      NullyTrue                     ));
        NoNullRet(true,  Coalesce(True,       False,      NullyTrue,  zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       False,      NullyTrue,               false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       False,      NullyTrue,  zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       False,      NullyTrue,  zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       False,      NullyTrue,               true )); // TODO: Does not work
         
        NoNullRet(true,  Coalesce(True,       False,      True                          ));
        NoNullRet(true,  Coalesce(True,       False,      True,       zeroMatters: false));
      //NoNullRet(true,  Coalesce(True,       False,      True,                    false)); // TODO: Does not work
        NoNullRet(true,  Coalesce(True,       False,      True,       zeroMatters       ));
        NoNullRet(true,  Coalesce(True,       False,      True,       zeroMatters: true ));
      //NoNullRet(true,  Coalesce(True,       False,      True,                    true )); // TODO: Does not work
   }
}