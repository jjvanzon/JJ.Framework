namespace JJ.Framework.Existence.Core.Values.Tests;

[TestClass]
public class Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInBack : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInBack_Batch1()
    {
        NoNullRet(0, NullNum.Coalesce(Nully0,  NullNum                    ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NullNum, zeroMatters: false));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NullNum,              false));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NullNum, zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NullNum, zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NullNum,              true ));

        NoNullRet(1, NullNum.Coalesce(Nully0,  Nully1                     ));
        NoNullRet(1, NullNum.Coalesce(Nully0,  Nully1,  zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(Nully0,  Nully1,               false));
        NoNullRet(0, NullNum.Coalesce(Nully0,  Nully1,  zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  Nully1,  zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  Nully1,               true ));
        
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull0                    ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull0, zeroMatters: false));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull0,              false));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull0, zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull0, zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull0,              true ));
        
        NoNullRet(1, NullNum.Coalesce(Nully0,  NoNull1                    ));
        NoNullRet(1, NullNum.Coalesce(Nully0,  NoNull1, zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(Nully0,  NoNull1,              false));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull1, zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull1, zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull1,              true ));
        
        NoNullRet(1, NullNum.Coalesce(Nully1,  NullNum                    ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NullNum, zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NullNum,              false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NullNum, zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NullNum, zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NullNum,              true ));
        
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully0                     ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully0,  zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully0,               false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully0,  zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully0,  zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully0,               true ));
        
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull0                    ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull0, zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull0,              false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull0, zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull0, zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull0,              true ));
        
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull1                    ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull1, zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull1,              false));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull1, zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull1, zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull1,              true ));
        
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0                     ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,  zeroMatters: false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,               false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,  zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,  zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,               true ));
        
        NoNullRet(0, NullNum.Coalesce(NoNull0, NullNum                    ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NullNum, zeroMatters: false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NullNum,              false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NullNum, zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NullNum, zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NullNum,              true ));
        
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0                     ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,  zeroMatters: false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,               false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,  zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,  zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0,               true ));
        
        NoNullRet(1, NullNum.Coalesce(NoNull0, Nully1                     ));
        NoNullRet(1, NullNum.Coalesce(NoNull0, Nully1,  zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(NoNull0, Nully1,               false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully1,  zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully1,  zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully1,               true ));
        
        NoNullRet(1, NullNum.Coalesce(NoNull0, NoNull1                    ));
        NoNullRet(1, NullNum.Coalesce(NoNull0, NoNull1, zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(NoNull0, NoNull1,              false));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NoNull1, zeroMatters       ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NoNull1, zeroMatters: true ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NoNull1,              true ));
        
        NoNullRet(1, NullNum.Coalesce(NoNull1, NullNum                    ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NullNum, zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NullNum,              false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NullNum, zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NullNum, zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NullNum,              true ));
        
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully0                     ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully0,  zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully0,               false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully0,  zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully0,  zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully0,               true ));
        
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully1                     ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully1,  zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully1,               false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully1,  zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully1,  zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully1,               true ));
        
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull0                    ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull0, zeroMatters: false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull0,              false));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull0, zeroMatters       ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull0, zeroMatters: true ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull0,              true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInBack_Batch2()
    {
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0                     ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0,  zeroMatters: false));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0,               false));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0,  zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0,  zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0,               true ));
        
        NoNullRet(1, Nully0 .Coalesce(NullNum, Nully1                     ));
        NoNullRet(1, Nully0 .Coalesce(NullNum, Nully1,  zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NullNum, Nully1,               false));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully1,  zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully1,  zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully1,               true ));
        
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0                    ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0, zeroMatters: false));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0,              false));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0,              true ));
        
        NoNullRet(1, Nully0 .Coalesce(NullNum, NoNull1                    ));
        NoNullRet(1, Nully0 .Coalesce(NullNum, NoNull1, zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NullNum, NoNull1,              false));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull1, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull1, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull1,              true ));
        
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NullNum                    ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NullNum, zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NullNum,              false));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NullNum, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NullNum, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NullNum,              true ));
        
        NoNullRet(1, Nully0 .Coalesce(Nully1,  Nully0                     ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  Nully0,  zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  Nully0,               false));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  Nully0,  zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  Nully0,  zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  Nully0,               true ));
        
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull0                    ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull0, zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull0,              false));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NoNull0, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NoNull0, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NoNull0,              true ));
        
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull1                    ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull1, zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull1,              false));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NoNull1, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NoNull1, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(Nully1,  NoNull1,              true ));
        
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum                    ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum, zeroMatters: false));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum,              false));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum,              true ));
        
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0                     ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0,  zeroMatters: false));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0,               false));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0,  zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0,  zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0,               true ));
        
        NoNullRet(1, Nully0 .Coalesce(NoNull0, Nully1                     ));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, Nully1,  zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, Nully1,               false));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully1,  zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully1,  zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully1,               true ));
        
        NoNullRet(1, Nully0 .Coalesce(NoNull0, NoNull1                    ));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, NoNull1, zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, NoNull1,              false));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NoNull1, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NoNull1, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NoNull1,              true ));
        
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NullNum                    ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NullNum, zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NullNum,              false));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, NullNum, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, NullNum, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, NullNum,              true ));
        
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully0                     ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully0,  zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully0,               false));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, Nully0,  zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, Nully0,  zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, Nully0,               true ));
        
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully1                     ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully1,  zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully1,               false));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, Nully1,  zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, Nully1,  zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, Nully1,               true ));
        
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NoNull0                    ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NoNull0, zeroMatters: false));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NoNull0,              false));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, NoNull0, zeroMatters       ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, NoNull0, zeroMatters: true ));
        NoNullRet(0, Nully0 .Coalesce(NoNull1, NoNull0,              true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInBack_Batch3()
    {
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0                     ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0,  zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0,               false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0,  zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0,  zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0,               true ));
        
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1                     ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1,  zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1,               false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1,  zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1,  zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1,               true ));
        
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0                    ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0,              false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1                    ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1,              false));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum                    ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum,              false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1                     ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1,  zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1,               false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1,  zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1,  zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1,               true ));
        
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0                    ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0,              false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1                    ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1,              false));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum                    ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum,              false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0                     ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0,  zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0,               false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0,  zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0,  zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0,               true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1                     ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1,  zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1,               false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1,  zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1,  zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1,               true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1                    ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1,              false));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum                    ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum,              false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum,              true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0                     ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0,  zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0,               false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0,  zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0,  zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0,               true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1                     ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1,  zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1,               false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1,  zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1,  zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1,               true ));
        
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0                    ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0, zeroMatters: false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0,              false));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0, zeroMatters       ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0, zeroMatters: true ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0,              true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInBack_Batch4()
    {
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0                     ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0,  zeroMatters: false));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0,               false));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0,  zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0,  zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0,               true ));
        
        NoNullRet(1, NoNull0.Coalesce(NullNum, Nully1                     ));
        NoNullRet(1, NoNull0.Coalesce(NullNum, Nully1,  zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(NullNum, Nully1,               false));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully1,  zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully1,  zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully1,               true ));
        
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0                    ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0, zeroMatters: false));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0,              false));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(NullNum, NoNull1                    ));
        NoNullRet(1, NoNull0.Coalesce(NullNum, NoNull1, zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(NullNum, NoNull1,              false));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull1, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull1, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull1,              true ));

        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum                    ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum, zeroMatters: false));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum,              false));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(Nully0,  Nully1                     ));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  Nully1,  zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  Nully1,               false));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  Nully1,  zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  Nully1,  zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  Nully1,               true ));
        
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0                    ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0, zeroMatters: false));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0,              false));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(Nully0,  NoNull1                    ));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  NoNull1, zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  NoNull1,              false));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull1, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull1, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull1,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NullNum                    ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NullNum, zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NullNum,              false));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NullNum, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NullNum, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NullNum,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(Nully1,  Nully0                     ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  Nully0,  zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  Nully0,               false));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  Nully0,  zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  Nully0,  zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  Nully0,               true ));
        
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull0                    ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull0, zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull0,              false));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NoNull0, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NoNull0, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NoNull0,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull1                    ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull1, zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull1,              false));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NoNull1, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NoNull1, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(Nully1,  NoNull1,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NullNum                    ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NullNum, zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NullNum,              false));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, NullNum, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, NullNum, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, NullNum,              true ));
        
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully0                     ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully0,  zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully0,               false));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, Nully0,  zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, Nully0,  zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, Nully0,               true ));
        
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully1                     ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully1,  zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully1,               false));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, Nully1,  zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, Nully1,  zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, Nully1,               true ));
        
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NoNull0                    ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NoNull0, zeroMatters: false));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NoNull0,              false));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, NoNull0, zeroMatters       ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, NoNull0, zeroMatters: true ));
        NoNullRet(0, NoNull0.Coalesce(NoNull1, NoNull0,              true ));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInBack_Batch5()
    {
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0                     ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0,  zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0,               false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0,  zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0,  zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0,               true ));
        
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1                     ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1,  zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1,               false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1,  zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1,  zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1,               true ));
        
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0                    ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0,              false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1                    ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1,              false));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum                    ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum,              false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1                     ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1,  zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1,               false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1,  zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1,  zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1,               true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0                    ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0,              false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1                    ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1,              false));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum                    ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum,              false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0                     ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0,  zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0,               false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0,  zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0,  zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0,               true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0                    ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0,              false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1                    ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1,              false));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum                    ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum,              false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum,              true ));
        
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0                     ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0,  zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0,               false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0,  zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0,  zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0,               true ));
        
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1                     ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1,  zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1,               false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1,  zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1,  zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1,               true ));
        
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1                    ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1, zeroMatters: false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1,              false));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1, zeroMatters       ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1, zeroMatters: true ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1,              true ));
    }
}