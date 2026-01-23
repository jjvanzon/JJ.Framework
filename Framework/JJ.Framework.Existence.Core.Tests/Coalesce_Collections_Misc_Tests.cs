namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Collections_Misc_Tests
{
    // TODO: Split into files (for diffability and test perf)
    // TODO: Add more collections of collections tests.

    [TestMethod]
    public void Coalesce_CollectionOfCollections_1Arg()
    {
        List<string>? coll = null;
        List<string> result = Coalesce( [ coll ] );
        IsNull(coll);
        NoNullRet(Coalesce(coll));
    }

    [TestMethod]
    public void BUG_Coalesce_CollectionZeroMatters_FailsToResolve()
    {
        //NoNullRet(0, Coalesce(zeroMatters, FilledArray));
        //NoNullRet(0, NullIColl.Coalesce(zeroMatters));
    }

    [TestMethod]
    public void BUG_Coalesce_CollectionTypes_NotSupported()
    {
        //NoNullRet(1,     Coalesce(FilledILookup                           ));
        //NoNullRet(1,     Coalesce(FilledImmutableArray                    ));
        //NoNullRet(1,     Coalesce(FilledArraySegment                      ));
        //NoNullRet(1,     Coalesce(FilledMemory                            ));
        //NoNullRet(1,     Coalesce(FilledReadOnlyMemory                    ));
        //NoNullRet(1,     Coalesce(FilledReadOnlySequence                  ));
        //NoNullRet(1,     Coalesce(FilledArrayList                         ));
        //NoNullRet(1,     Coalesce(FilledBitArray                          ));
        //NoNullRet(1,     Coalesce(FilledCollBase                          ));
        //NoNullRet(1,     Coalesce(FilledDictBase                          ));
        //NoNullRet(1,     Coalesce(FilledHashtable                         ));
        //NoNullRet(1,     Coalesce(FilledQueueNonGeneric                   ));
        //NoNullRet(1,     Coalesce(FilledReadOnlyCollBase                  ));
        //NoNullRet(1,     Coalesce(FilledSortedListNonGeneric              ));
        //NoNullRet(1,     Coalesce(FilledStackNonGeneric                   ));
        //NoNullRet(1,     Coalesce(FilledHybridDict                        ));
        //NoNullRet(1,     Coalesce(FilledListDict                          ));
        //NoNullRet(1,     Coalesce(FilledNameObjectCollBase                ));
        //NoNullRet(1,     Coalesce(FilledNameObjectCollBaseKeys            ));
        //NoNullRet(1,     Coalesce(FilledNameValueColl                     ));
        //NoNullRet(1,     Coalesce(FilledOrderedDictNonGeneric             ));
        //NoNullRet(1,     Coalesce(FilledStringColl                        ));
        //NoNullRet(1,     Coalesce(FilledStringDict                        ));
        //NoNullRet(1,     Coalesce(FilledIOrderedDict                      ));
        #if NET6_0_OR_GREATER                                                                                      
        //NoNullRet(1,     Coalesce(FilledPrioQueue                         ));   
        //NoNullRet(1,     Coalesce(FilledPrioQueueUnorderedColl            ));   
        #endif                                                                                             
    }                                                                     
}