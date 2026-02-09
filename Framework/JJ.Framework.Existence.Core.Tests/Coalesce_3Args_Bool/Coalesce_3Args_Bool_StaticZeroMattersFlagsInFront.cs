namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront
{
    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch1()
    {
        NoNullRet(0, Coalesce(                    NullNum, Nully0,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters: false, NullNum, Nully0,  NullNum));
        NoNullRet(0, Coalesce(             false, NullNum, Nully0,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, Nully0,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, Nully0,  NullNum));
        NoNullRet(0, Coalesce(             true , NullNum, Nully0,  NullNum));

        NoNullRet(1, Coalesce(                    NullNum, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(             false, NullNum, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(             true , NullNum, Nully0,  Nully1 ));
        
        NoNullRet(0, Coalesce(                    NullNum, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: false, NullNum, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(             false, NullNum, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(             true , NullNum, Nully0,  NoNull0));
        
        NoNullRet(1, Coalesce(                    NullNum, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(             false, NullNum, Nully0,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, Nully0,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, Nully0,  NoNull1));
        NoNullRet(0, Coalesce(             true , NullNum, Nully0,  NoNull1));
        
        NoNullRet(1, Coalesce(                    NullNum, Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, Nully1,  NullNum));
        NoNullRet(1, Coalesce(             false, NullNum, Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, Nully1,  NullNum));
        NoNullRet(1, Coalesce(             true , NullNum, Nully1,  NullNum));
        
        NoNullRet(1, Coalesce(                    NullNum, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(             false, NullNum, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(             true , NullNum, Nully1,  Nully0 ));
        
        NoNullRet(1, Coalesce(                    NullNum, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(             false, NullNum, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(             true , NullNum, Nully1,  NoNull0));
        
        NoNullRet(1, Coalesce(                    NullNum, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(             false, NullNum, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(             true , NullNum, Nully1,  NoNull1));
        
        NoNullRet(0, Coalesce(                    NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: false, NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(             false, NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(             true , NullNum, NoNull0, Nully0 ));
        
        NoNullRet(0, Coalesce(                    NullNum, NoNull0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: false, NullNum, NoNull0, NullNum));
        NoNullRet(0, Coalesce(             false, NullNum, NoNull0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, NoNull0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, NoNull0, NullNum));
        NoNullRet(0, Coalesce(             true , NullNum, NoNull0, NullNum));
        
        NoNullRet(0, Coalesce(                    NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: false, NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(             false, NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(             true , NullNum, NoNull0, Nully0 ));
        
        NoNullRet(1, Coalesce(                    NullNum, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(             false, NullNum, NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(             true , NullNum, NoNull0, Nully1 ));
        
        NoNullRet(1, Coalesce(                    NullNum, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(             false, NullNum, NoNull0, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , NullNum, NoNull0, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , NullNum, NoNull0, NoNull1));
        NoNullRet(0, Coalesce(             true , NullNum, NoNull0, NoNull1));
                
        NoNullRet(1, Coalesce(                    NullNum, NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, NoNull1, NullNum));
        NoNullRet(1, Coalesce(             false, NullNum, NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, NoNull1, NullNum));
        NoNullRet(1, Coalesce(             true , NullNum, NoNull1, NullNum));

        NoNullRet(1, Coalesce(                    NullNum, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(             false, NullNum, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(             true , NullNum, NoNull1, Nully0 ));

        NoNullRet(1, Coalesce(                    NullNum, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(             false, NullNum, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(             true , NullNum, NoNull1, Nully1 ));
        
        NoNullRet(1, Coalesce(                    NullNum, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, NullNum, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(             false, NullNum, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , NullNum, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , NullNum, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(             true , NullNum, NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch2()
    {
        NoNullRet(0, Coalesce(                    Nully0,  NullNum, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: false, Nully0,  NullNum, Nully0 ));
        NoNullRet(0, Coalesce(             false, Nully0,  NullNum, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NullNum, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NullNum, Nully0 ));
        NoNullRet(0, Coalesce(             true , Nully0,  NullNum, Nully0 ));

        NoNullRet(1, Coalesce(                    Nully0,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(             false, Nully0,  NullNum, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NullNum, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NullNum, Nully1 ));
        NoNullRet(0, Coalesce(             true , Nully0,  NullNum, Nully1 ));
        
        NoNullRet(0, Coalesce(                    Nully0,  NullNum, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: false, Nully0,  NullNum, NoNull0));
        NoNullRet(0, Coalesce(             false, Nully0,  NullNum, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NullNum, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NullNum, NoNull0));
        NoNullRet(0, Coalesce(             true , Nully0,  NullNum, NoNull0));
        
        NoNullRet(1, Coalesce(                    Nully0,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(             false, Nully0,  NullNum, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NullNum, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NullNum, NoNull1));
        NoNullRet(0, Coalesce(             true , Nully0,  NullNum, NoNull1));
        
        NoNullRet(1, Coalesce(                    Nully0,  Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  Nully1,  NullNum));
        NoNullRet(1, Coalesce(             false, Nully0,  Nully1,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  Nully1,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  Nully1,  NullNum));
        NoNullRet(0, Coalesce(             true , Nully0,  Nully1,  NullNum));
        
        NoNullRet(1, Coalesce(                    Nully0,  Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(             false, Nully0,  Nully1,  Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  Nully1,  Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  Nully1,  Nully0 ));
        NoNullRet(0, Coalesce(             true , Nully0,  Nully1,  Nully0 ));
        
        NoNullRet(1, Coalesce(                    Nully0,  Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  Nully1,  NoNull0));
        NoNullRet(1, Coalesce(             false, Nully0,  Nully1,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  Nully1,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  Nully1,  NoNull0));
        NoNullRet(0, Coalesce(             true , Nully0,  Nully1,  NoNull0));
        
        NoNullRet(1, Coalesce(                    Nully0,  Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  Nully1,  NoNull1));
        NoNullRet(1, Coalesce(             false, Nully0,  Nully1,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  Nully1,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  Nully1,  NoNull1));
        NoNullRet(0, Coalesce(             true , Nully0,  Nully1,  NoNull1));
        
        NoNullRet(0, Coalesce(                    Nully0,  NoNull0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: false, Nully0,  NoNull0, NullNum));
        NoNullRet(0, Coalesce(             false, Nully0,  NoNull0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull0, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull0, NullNum));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull0, NullNum));
                
        NoNullRet(0, Coalesce(                    Nully0,  NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: false, Nully0,  NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(             false, Nully0,  NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull0, Nully0 ));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull0, Nully0 ));
        
        NoNullRet(1, Coalesce(                    Nully0,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(             false, Nully0,  NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull0, Nully1 ));
        
        NoNullRet(1, Coalesce(                    Nully0,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(             false, Nully0,  NoNull0, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull0, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull0, NoNull1));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull0, NoNull1));
        
        NoNullRet(1, Coalesce(                    Nully0,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(             false, Nully0,  NoNull1, NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull1, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull1, NullNum));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull1, NullNum));
        
        NoNullRet(1, Coalesce(                    Nully0,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(             false, Nully0,  NoNull1, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull1, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull1, Nully0 ));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull1, Nully0 ));
        
        NoNullRet(1, Coalesce(                    Nully0,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(             false, Nully0,  NoNull1, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull1, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull1, Nully1 ));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull1, Nully1 ));
        
        NoNullRet(1, Coalesce(                    Nully0,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully0,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(             false, Nully0,  NoNull1, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , Nully0,  NoNull1, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , Nully0,  NoNull1, NoNull0));
        NoNullRet(0, Coalesce(             true , Nully0,  NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch3()
    {
        NoNullRet(1, Coalesce(                    Nully1,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(             false, Nully1,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(             true , Nully1,  NullNum, Nully0 ));
        
        NoNullRet(1, Coalesce(                    Nully1,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(             false, Nully1,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(             true , Nully1,  NullNum, Nully1 ));
        
        NoNullRet(1, Coalesce(                    Nully1,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(             false, Nully1,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(             true , Nully1,  NullNum, NoNull0));
        
        NoNullRet(1, Coalesce(                    Nully1,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(             false, Nully1,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(             true , Nully1,  NullNum, NoNull1));
        
        NoNullRet(1, Coalesce(                    Nully1,  Nully0,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  Nully0,  NullNum));
        NoNullRet(1, Coalesce(             false, Nully1,  Nully0,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  Nully0,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  Nully0,  NullNum));
        NoNullRet(1, Coalesce(             true , Nully1,  Nully0,  NullNum));
                
        NoNullRet(1, Coalesce(                    Nully1,  Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(             false, Nully1,  Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(             true , Nully1,  Nully0,  Nully1 ));
        
        NoNullRet(1, Coalesce(                    Nully1,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(             false, Nully1,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(             true , Nully1,  Nully0,  NoNull0));
        
        NoNullRet(1, Coalesce(                    Nully1,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(             false, Nully1,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(             true , Nully1,  Nully0,  NoNull1));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull0, NullNum));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull0, NullNum));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull0, NullNum));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull0, Nully0 ));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull0, Nully1 ));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull0, NoNull1));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull1, NullNum));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull1, Nully0 ));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull1, Nully1 ));
        
        NoNullRet(1, Coalesce(                    Nully1,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, Nully1,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(             false, Nully1,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , Nully1,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , Nully1,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(             true , Nully1,  NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch4()
    {
        NoNullRet(0, Coalesce(                    NoNull0, NullNum, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: false, NoNull0, NullNum, Nully0 ));
        NoNullRet(0, Coalesce(             false, NoNull0, NullNum, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NullNum, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NullNum, Nully0 ));
        NoNullRet(0, Coalesce(             true , NoNull0, NullNum, Nully0 ));
        
        NoNullRet(1, Coalesce(                    NoNull0, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(             false, NoNull0, NullNum, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NullNum, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NullNum, Nully1 ));
        NoNullRet(0, Coalesce(             true , NoNull0, NullNum, Nully1 ));
                
        NoNullRet(0, Coalesce(                    NoNull0, NullNum, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: false, NoNull0, NullNum, NoNull0));
        NoNullRet(0, Coalesce(             false, NoNull0, NullNum, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NullNum, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NullNum, NoNull0));
        NoNullRet(0, Coalesce(             true , NoNull0, NullNum, NoNull0));

        NoNullRet(1, Coalesce(                    NoNull0, NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, NullNum, NoNull1));
        NoNullRet(1, Coalesce(             false, NoNull0, NullNum, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NullNum, NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NullNum, NoNull1));
        NoNullRet(0, Coalesce(             true , NoNull0, NullNum, NoNull1));
        
        NoNullRet(0, Coalesce(                    NoNull0, Nully0,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters: false, NoNull0, Nully0,  NullNum));
        NoNullRet(0, Coalesce(             false, NoNull0, Nully0,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully0,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully0,  NullNum));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully0,  NullNum));
        
        NoNullRet(1, Coalesce(                    NoNull0, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(             false, NoNull0, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully0,  Nully1 ));
                
        NoNullRet(0, Coalesce(                    NoNull0, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: false, NoNull0, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(             false, NoNull0, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully0,  NoNull0));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully0,  NoNull0));

        NoNullRet(1, Coalesce(                    NoNull0, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(             false, NoNull0, Nully0,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully0,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully0,  NoNull1));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully0,  NoNull1));
        
        NoNullRet(1, Coalesce(                    NoNull0, Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, Nully1,  NullNum));
        NoNullRet(1, Coalesce(             false, NoNull0, Nully1,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully1,  NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully1,  NullNum));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully1,  NullNum));
        
        NoNullRet(1, Coalesce(                    NoNull0, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(             false, NoNull0, Nully1,  Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully1,  Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully1,  Nully0 ));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully1,  Nully0 ));
                
        NoNullRet(1, Coalesce(                    NoNull0, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(             false, NoNull0, Nully1,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully1,  NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully1,  NoNull0));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully1,  NoNull0));

        NoNullRet(1, Coalesce(                    NoNull0, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(             false, NoNull0, Nully1,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, Nully1,  NoNull1));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, Nully1,  NoNull1));
        NoNullRet(0, Coalesce(             true , NoNull0, Nully1,  NoNull1));
        
        NoNullRet(1, Coalesce(                    NoNull0, NoNull1, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, NoNull1, NullNum));
        NoNullRet(1, Coalesce(             false, NoNull0, NoNull1, NullNum));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NoNull1, NullNum));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NoNull1, NullNum));
        NoNullRet(0, Coalesce(             true , NoNull0, NoNull1, NullNum));
        
        NoNullRet(1, Coalesce(                    NoNull0, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(             false, NoNull0, NoNull1, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NoNull1, Nully0 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NoNull1, Nully0 ));
        NoNullRet(0, Coalesce(             true , NoNull0, NoNull1, Nully0 ));
        
        NoNullRet(1, Coalesce(                    NoNull0, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(             false, NoNull0, NoNull1, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NoNull1, Nully1 ));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NoNull1, Nully1 ));
        NoNullRet(0, Coalesce(             true , NoNull0, NoNull1, Nully1 ));
        
        NoNullRet(1, Coalesce(                    NoNull0, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull0, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(             false, NoNull0, NoNull1, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters       , NoNull0, NoNull1, NoNull0));
        NoNullRet(0, Coalesce(zeroMatters: true , NoNull0, NoNull1, NoNull0));
        NoNullRet(0, Coalesce(             true , NoNull0, NoNull1, NoNull0));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront_Batch5()
    {
        NoNullRet(1, Coalesce(                    NoNull1, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(             false, NoNull1, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(             true , NoNull1, NullNum, Nully0 ));

        NoNullRet(1, Coalesce(                    NoNull1, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(             false, NoNull1, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(             true , NoNull1, NullNum, Nully1 ));

        NoNullRet(1, Coalesce(                    NoNull1, NullNum, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NullNum, NoNull0));
        NoNullRet(1, Coalesce(             false, NoNull1, NullNum, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NullNum, NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NullNum, NoNull0));
        NoNullRet(1, Coalesce(             true , NoNull1, NullNum, NoNull0));
        
        NoNullRet(1, Coalesce(                    NoNull1, NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NullNum, NoNull1));
        NoNullRet(1, Coalesce(             false, NoNull1, NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NullNum, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NullNum, NoNull1));
        NoNullRet(1, Coalesce(             true , NoNull1, NullNum, NoNull1));

        NoNullRet(1, Coalesce(                    NoNull1, Nully0,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully0,  NullNum));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully0,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully0,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully0,  NullNum));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully0,  NullNum));

        NoNullRet(1, Coalesce(                    NoNull1, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully0,  Nully1 ));

        NoNullRet(1, Coalesce(                    NoNull1, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully0,  NoNull0));
        
        NoNullRet(1, Coalesce(                    NoNull1, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully0,  NoNull1));

        NoNullRet(1, Coalesce(                    NoNull1, Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully1,  NullNum));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully1,  NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully1,  NullNum));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully1,  NullNum));

        NoNullRet(1, Coalesce(                    NoNull1, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully1,  Nully0 ));

        NoNullRet(1, Coalesce(                    NoNull1, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully1,  NoNull0));
        
        NoNullRet(1, Coalesce(                    NoNull1, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(             false, NoNull1, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(             true , NoNull1, Nully1,  NoNull1));

        NoNullRet(1, Coalesce(                    NoNull1, NoNull0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NoNull0, NullNum));
        NoNullRet(1, Coalesce(             false, NoNull1, NoNull0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NoNull0, NullNum));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NoNull0, NullNum));
        NoNullRet(1, Coalesce(             true , NoNull1, NoNull0, NullNum));

        NoNullRet(1, Coalesce(                    NoNull1, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(             false, NoNull1, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(             true , NoNull1, NoNull0, Nully0 ));

        NoNullRet(1, Coalesce(                    NoNull1, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(             false, NoNull1, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(             true , NoNull1, NoNull0, Nully1 ));
         
        NoNullRet(1, Coalesce(                    NoNull1, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: false, NoNull1, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(             false, NoNull1, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters       , NoNull1, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(zeroMatters: true , NoNull1, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(             true , NoNull1, NoNull0, NoNull1));
   }
}