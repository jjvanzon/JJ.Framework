namespace JJ.Framework.Existence.Core.Values.Tests;

[TestClass]
public class Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInFront : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInFront_Batch1()
    {
        NoNullRet(0, NullNum.Coalesce(                    Nully0,  NullNum));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: false, Nully0,  NullNum));
        NoNullRet(0, NullNum.Coalesce(             false, Nully0,  NullNum));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , Nully0,  NullNum));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , Nully0,  NullNum));
        NoNullRet(0, NullNum.Coalesce(             true , Nully0,  NullNum));

        NoNullRet(1, NullNum.Coalesce(                    Nully0,  Nully1 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, Nully0,  Nully1 ));
        NoNullRet(1, NullNum.Coalesce(             false, Nully0,  Nully1 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , Nully0,  Nully1 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , Nully0,  Nully1 ));
        NoNullRet(0, NullNum.Coalesce(             true , Nully0,  Nully1 ));
        
        NoNullRet(0, NullNum.Coalesce(                    Nully0,  NoNull0));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: false, Nully0,  NoNull0));
        NoNullRet(0, NullNum.Coalesce(             false, Nully0,  NoNull0));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , Nully0,  NoNull0));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , Nully0,  NoNull0));
        NoNullRet(0, NullNum.Coalesce(             true , Nully0,  NoNull0));
        
        NoNullRet(1, NullNum.Coalesce(                    Nully0,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, Nully0,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(             false, Nully0,  NoNull1));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , Nully0,  NoNull1));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , Nully0,  NoNull1));
        NoNullRet(0, NullNum.Coalesce(             true , Nully0,  NoNull1));
        
        NoNullRet(1, NullNum.Coalesce(                    Nully1,  NullNum));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, Nully1,  NullNum));
        NoNullRet(1, NullNum.Coalesce(             false, Nully1,  NullNum));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , Nully1,  NullNum));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , Nully1,  NullNum));
        NoNullRet(1, NullNum.Coalesce(             true , Nully1,  NullNum));
        
        NoNullRet(1, NullNum.Coalesce(                    Nully1,  Nully0 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, Nully1,  Nully0 ));
        NoNullRet(1, NullNum.Coalesce(             false, Nully1,  Nully0 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , Nully1,  Nully0 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , Nully1,  Nully0 ));
        NoNullRet(1, NullNum.Coalesce(             true , Nully1,  Nully0 ));
        
        NoNullRet(1, NullNum.Coalesce(                    Nully1,  NoNull0));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, Nully1,  NoNull0));
        NoNullRet(1, NullNum.Coalesce(             false, Nully1,  NoNull0));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , Nully1,  NoNull0));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , Nully1,  NoNull0));
        NoNullRet(1, NullNum.Coalesce(             true , Nully1,  NoNull0));
        
        NoNullRet(1, NullNum.Coalesce(                    Nully1,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, Nully1,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(             false, Nully1,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , Nully1,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , Nully1,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(             true , Nully1,  NoNull1));
        
        NoNullRet(0, NullNum.Coalesce(                    NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: false, NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(             false, NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(             true , NoNull0, Nully0 ));
        
        NoNullRet(0, NullNum.Coalesce(                    NoNull0, NullNum));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: false, NoNull0, NullNum));
        NoNullRet(0, NullNum.Coalesce(             false, NoNull0, NullNum));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , NoNull0, NullNum));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , NoNull0, NullNum));
        NoNullRet(0, NullNum.Coalesce(             true , NoNull0, NullNum));
        
        NoNullRet(0, NullNum.Coalesce(                    NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: false, NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(             false, NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , NoNull0, Nully0 ));
        NoNullRet(0, NullNum.Coalesce(             true , NoNull0, Nully0 ));
        
        NoNullRet(1, NullNum.Coalesce(                    NoNull0, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, NoNull0, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(             false, NoNull0, Nully1 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , NoNull0, Nully1 ));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , NoNull0, Nully1 ));
        NoNullRet(0, NullNum.Coalesce(             true , NoNull0, Nully1 ));
        
        NoNullRet(1, NullNum.Coalesce(                    NoNull0, NoNull1));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, NoNull0, NoNull1));
        NoNullRet(1, NullNum.Coalesce(             false, NoNull0, NoNull1));
        NoNullRet(0, NullNum.Coalesce(zeroMatters       , NoNull0, NoNull1));
        NoNullRet(0, NullNum.Coalesce(zeroMatters: true , NoNull0, NoNull1));
        NoNullRet(0, NullNum.Coalesce(             true , NoNull0, NoNull1));
        
        NoNullRet(1, NullNum.Coalesce(                    NoNull1, NullNum));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, NoNull1, NullNum));
        NoNullRet(1, NullNum.Coalesce(             false, NoNull1, NullNum));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , NoNull1, NullNum));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , NoNull1, NullNum));
        NoNullRet(1, NullNum.Coalesce(             true , NoNull1, NullNum));
        
        NoNullRet(1, NullNum.Coalesce(                    NoNull1, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, NoNull1, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(             false, NoNull1, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , NoNull1, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , NoNull1, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(             true , NoNull1, Nully0 ));
        
        NoNullRet(1, NullNum.Coalesce(                    NoNull1, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, NoNull1, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(             false, NoNull1, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , NoNull1, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , NoNull1, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(             true , NoNull1, Nully1 ));
        
        NoNullRet(1, NullNum.Coalesce(                    NoNull1, NoNull0));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: false, NoNull1, NoNull0));
        NoNullRet(1, NullNum.Coalesce(             false, NoNull1, NoNull0));
        NoNullRet(1, NullNum.Coalesce(zeroMatters       , NoNull1, NoNull0));
        NoNullRet(1, NullNum.Coalesce(zeroMatters: true , NoNull1, NoNull0));
        NoNullRet(1, NullNum.Coalesce(             true , NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInFront_Batch2()
    {
        NoNullRet(0, Nully0 .Coalesce(                    NullNum, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: false, NullNum, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(             false, NullNum, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NullNum, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NullNum, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(             true , NullNum, Nully0 ));
        
        NoNullRet(1, Nully0 .Coalesce(                    NullNum, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NullNum, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(             false, NullNum, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NullNum, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NullNum, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(             true , NullNum, Nully1 ));
        
        NoNullRet(0, Nully0 .Coalesce(                    NullNum, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: false, NullNum, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(             false, NullNum, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NullNum, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NullNum, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(             true , NullNum, NoNull0));
        
        NoNullRet(1, Nully0 .Coalesce(                    NullNum, NoNull1));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NullNum, NoNull1));
        NoNullRet(1, Nully0 .Coalesce(             false, NullNum, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NullNum, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NullNum, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(             true , NullNum, NoNull1));
        
        NoNullRet(1, Nully0 .Coalesce(                    Nully1,  NullNum));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, Nully1,  NullNum));
        NoNullRet(1, Nully0 .Coalesce(             false, Nully1,  NullNum));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , Nully1,  NullNum));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , Nully1,  NullNum));
        NoNullRet(0, Nully0 .Coalesce(             true , Nully1,  NullNum));
        
        NoNullRet(1, Nully0 .Coalesce(                    Nully1,  Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, Nully1,  Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(             false, Nully1,  Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , Nully1,  Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , Nully1,  Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(             true , Nully1,  Nully0 ));
        
        NoNullRet(1, Nully0 .Coalesce(                    Nully1,  NoNull0));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, Nully1,  NoNull0));
        NoNullRet(1, Nully0 .Coalesce(             false, Nully1,  NoNull0));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , Nully1,  NoNull0));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , Nully1,  NoNull0));
        NoNullRet(0, Nully0 .Coalesce(             true , Nully1,  NoNull0));
        
        NoNullRet(1, Nully0 .Coalesce(                    Nully1,  NoNull1));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, Nully1,  NoNull1));
        NoNullRet(1, Nully0 .Coalesce(             false, Nully1,  NoNull1));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , Nully1,  NoNull1));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , Nully1,  NoNull1));
        NoNullRet(0, Nully0 .Coalesce(             true , Nully1,  NoNull1));
        
        NoNullRet(0, Nully0 .Coalesce(                    NoNull0, NullNum));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: false, NoNull0, NullNum));
        NoNullRet(0, Nully0 .Coalesce(             false, NoNull0, NullNum));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull0, NullNum));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull0, NullNum));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull0, NullNum));
        
        NoNullRet(0, Nully0 .Coalesce(                    NoNull0, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: false, NoNull0, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(             false, NoNull0, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull0, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull0, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull0, Nully0 ));
        
        NoNullRet(1, Nully0 .Coalesce(                    NoNull0, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NoNull0, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(             false, NoNull0, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull0, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull0, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull0, Nully1 ));
        
        NoNullRet(1, Nully0 .Coalesce(                    NoNull0, NoNull1));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NoNull0, NoNull1));
        NoNullRet(1, Nully0 .Coalesce(             false, NoNull0, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull0, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull0, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull0, NoNull1));
        
        NoNullRet(1, Nully0 .Coalesce(                    NoNull1, NullNum));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NoNull1, NullNum));
        NoNullRet(1, Nully0 .Coalesce(             false, NoNull1, NullNum));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull1, NullNum));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull1, NullNum));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull1, NullNum));
        
        NoNullRet(1, Nully0 .Coalesce(                    NoNull1, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NoNull1, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(             false, NoNull1, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull1, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull1, Nully0 ));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull1, Nully0 ));
        
        NoNullRet(1, Nully0 .Coalesce(                    NoNull1, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NoNull1, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(             false, NoNull1, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull1, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull1, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull1, Nully1 ));
        
        NoNullRet(1, Nully0 .Coalesce(                    NoNull1, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(zeroMatters: false, NoNull1, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(             false, NoNull1, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters       , NoNull1, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(zeroMatters: true , NoNull1, NoNull0));
        NoNullRet(0, Nully0 .Coalesce(             true , NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInFront_Batch3()
    {
        NoNullRet(1, Nully1 .Coalesce(                    NullNum, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NullNum, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(             false, NullNum, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NullNum, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NullNum, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(             true , NullNum, Nully0 ));
        
        NoNullRet(1, Nully1 .Coalesce(                    NullNum, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NullNum, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             false, NullNum, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NullNum, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NullNum, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             true , NullNum, Nully1 ));
        
        NoNullRet(1, Nully1 .Coalesce(                    NullNum, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NullNum, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(             false, NullNum, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NullNum, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NullNum, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(             true , NullNum, NoNull0));
        
        NoNullRet(1, Nully1 .Coalesce(                    NullNum, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NullNum, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(             false, NullNum, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NullNum, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NullNum, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(             true , NullNum, NoNull1));
        
        NoNullRet(1, Nully1 .Coalesce(                    Nully0,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, Nully0,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(             false, Nully0,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , Nully0,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , Nully0,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(             true , Nully0,  NullNum));
        
        NoNullRet(1, Nully1 .Coalesce(                    Nully0,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, Nully0,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             false, Nully0,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , Nully0,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , Nully0,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             true , Nully0,  Nully1 ));
        
        NoNullRet(1, Nully1 .Coalesce(                    Nully0,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, Nully0,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(             false, Nully0,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , Nully0,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , Nully0,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(             true , Nully0,  NoNull0));
        
        NoNullRet(1, Nully1 .Coalesce(                    Nully0,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, Nully0,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(             false, Nully0,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , Nully0,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , Nully0,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(             true , Nully0,  NoNull1));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull0, NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull0, NullNum));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull0, NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull0, NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull0, NullNum));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull0, NullNum));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull0, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull0, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull0, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull0, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull0, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull0, Nully0 ));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull0, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull0, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull0, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull0, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull0, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull0, Nully1 ));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull0, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull0, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull0, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull0, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull0, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull0, NoNull1));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull1, NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull1, NullNum));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull1, NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull1, NullNum));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull1, NullNum));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull1, NullNum));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull1, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull1, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull1, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull1, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull1, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull1, Nully0 ));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull1, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull1, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull1, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull1, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull1, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull1, Nully1 ));
        
        NoNullRet(1, Nully1 .Coalesce(                    NoNull1, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: false, NoNull1, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(             false, NoNull1, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters       , NoNull1, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(zeroMatters: true , NoNull1, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(             true , NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInFront_Batch4()
    {
        NoNullRet(0, NoNull0.Coalesce(                    NullNum, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: false, NullNum, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(             false, NullNum, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NullNum, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NullNum, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(             true , NullNum, Nully0 ));
        
        NoNullRet(1, NoNull0.Coalesce(                    NullNum, Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, NullNum, Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(             false, NullNum, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NullNum, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NullNum, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(             true , NullNum, Nully1 ));
        
        NoNullRet(0, NoNull0.Coalesce(                    NullNum, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: false, NullNum, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(             false, NullNum, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NullNum, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NullNum, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(             true , NullNum, NoNull0));
        
        NoNullRet(1, NoNull0.Coalesce(                    NullNum, NoNull1));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, NullNum, NoNull1));
        NoNullRet(1, NoNull0.Coalesce(             false, NullNum, NoNull1));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NullNum, NoNull1));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NullNum, NoNull1));
        NoNullRet(0, NoNull0.Coalesce(             true , NullNum, NoNull1));

        NoNullRet(0, NoNull0.Coalesce(                    Nully0,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: false, Nully0,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(             false, Nully0,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully0,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully0,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully0,  NullNum));
        
        NoNullRet(1, NoNull0.Coalesce(                    Nully0,  Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, Nully0,  Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(             false, Nully0,  Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully0,  Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully0,  Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully0,  Nully1 ));
        
        NoNullRet(0, NoNull0.Coalesce(                    Nully0,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: false, Nully0,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(             false, Nully0,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully0,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully0,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully0,  NoNull0));
        
        NoNullRet(1, NoNull0.Coalesce(                    Nully0,  NoNull1));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, Nully0,  NoNull1));
        NoNullRet(1, NoNull0.Coalesce(             false, Nully0,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully0,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully0,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully0,  NoNull1));
        
        NoNullRet(1, NoNull0.Coalesce(                    Nully1,  NullNum));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, Nully1,  NullNum));
        NoNullRet(1, NoNull0.Coalesce(             false, Nully1,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully1,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully1,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully1,  NullNum));
        
        NoNullRet(1, NoNull0.Coalesce(                    Nully1,  Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, Nully1,  Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(             false, Nully1,  Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully1,  Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully1,  Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully1,  Nully0 ));
        
        NoNullRet(1, NoNull0.Coalesce(                    Nully1,  NoNull0));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, Nully1,  NoNull0));
        NoNullRet(1, NoNull0.Coalesce(             false, Nully1,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully1,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully1,  NoNull0));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully1,  NoNull0));
        
        NoNullRet(1, NoNull0.Coalesce(                    Nully1,  NoNull1));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, Nully1,  NoNull1));
        NoNullRet(1, NoNull0.Coalesce(             false, Nully1,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , Nully1,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , Nully1,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(             true , Nully1,  NoNull1));
        
        NoNullRet(1, NoNull0.Coalesce(                    NoNull1, NullNum));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, NoNull1, NullNum));
        NoNullRet(1, NoNull0.Coalesce(             false, NoNull1, NullNum));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NoNull1, NullNum));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NoNull1, NullNum));
        NoNullRet(0, NoNull0.Coalesce(             true , NoNull1, NullNum));
        
        NoNullRet(1, NoNull0.Coalesce(                    NoNull1, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, NoNull1, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(             false, NoNull1, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NoNull1, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NoNull1, Nully0 ));
        NoNullRet(0, NoNull0.Coalesce(             true , NoNull1, Nully0 ));
        
        NoNullRet(1, NoNull0.Coalesce(                    NoNull1, Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, NoNull1, Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(             false, NoNull1, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NoNull1, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NoNull1, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(             true , NoNull1, Nully1 ));
        
        NoNullRet(1, NoNull0.Coalesce(                    NoNull1, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(zeroMatters: false, NoNull1, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(             false, NoNull1, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters       , NoNull1, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(zeroMatters: true , NoNull1, NoNull0));
        NoNullRet(0, NoNull0.Coalesce(             true , NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInFront_Batch5()
    {
        NoNullRet(1, NoNull1.Coalesce(                    NullNum, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NullNum, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(             false, NullNum, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NullNum, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NullNum, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(             true , NullNum, Nully0 ));
        
        NoNullRet(1, NoNull1.Coalesce(                    NullNum, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NullNum, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(             false, NullNum, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NullNum, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NullNum, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(             true , NullNum, Nully1 ));
        
        NoNullRet(1, NoNull1.Coalesce(                    NullNum, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NullNum, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(             false, NullNum, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NullNum, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NullNum, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(             true , NullNum, NoNull0));
        
        NoNullRet(1, NoNull1.Coalesce(                    NullNum, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NullNum, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             false, NullNum, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NullNum, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NullNum, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             true , NullNum, NoNull1));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully0,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully0,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully0,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully0,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully0,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully0,  NullNum));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully0,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully0,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully0,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully0,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully0,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully0,  Nully1 ));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully0,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully0,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully0,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully0,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully0,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully0,  NoNull0));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully0,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully0,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully0,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully0,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully0,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully0,  NoNull1));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully1,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully1,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully1,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully1,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully1,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully1,  NullNum));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully1,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully1,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully1,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully1,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully1,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully1,  Nully0 ));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully1,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully1,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully1,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully1,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully1,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully1,  NoNull0));
        
        NoNullRet(1, NoNull1.Coalesce(                    Nully1,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, Nully1,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             false, Nully1,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , Nully1,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , Nully1,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             true , Nully1,  NoNull1));
        
        NoNullRet(1, NoNull1.Coalesce(                    NoNull0, NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NoNull0, NullNum));
        NoNullRet(1, NoNull1.Coalesce(             false, NoNull0, NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NoNull0, NullNum));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NoNull0, NullNum));
        NoNullRet(1, NoNull1.Coalesce(             true , NoNull0, NullNum));
        
        NoNullRet(1, NoNull1.Coalesce(                    NoNull0, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NoNull0, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(             false, NoNull0, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NoNull0, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NoNull0, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(             true , NoNull0, Nully0 ));
        
        NoNullRet(1, NoNull1.Coalesce(                    NoNull0, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NoNull0, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(             false, NoNull0, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NoNull0, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NoNull0, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(             true , NoNull0, Nully1 ));
        
        NoNullRet(1, NoNull1.Coalesce(                    NoNull0, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: false, NoNull0, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             false, NoNull0, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters       , NoNull0, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(zeroMatters: true , NoNull0, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(             true , NoNull0, NoNull1));
    }
}