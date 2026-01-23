namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Collections_Tests
{
    [TestMethod]
    public void BUG_Coalesce_CollectionZeroMatters_FailsToResolve()
    {
      //NoNullRet(0, Coalesce(zeroMatters, FilledArray));
      //NoNullRet(0, NullIColl.Coalesce(zeroMatters));
    }

    [TestMethod]
    public void Coalesce_1Arg_Collections()
    {
        List<string>? coll = null;
        List<string> result = Coalesce( [ coll ] );
        IsNull(coll);
        NoNullRet(Coalesce(coll));
    }

    [TestMethod]
    public void Coalesce_Collections_Static_Filled()
    {
        var entry = new KeyValuePair<int, int>(1, 1);
                                                               
        NoNullRet(1,     Coalesce(FilledArray                     ));
        NoNullRet(1,     Coalesce(FilledIList                     ));
        NoNullRet(1,     Coalesce(FilledISet                      ));
        NoNullRet(entry, Coalesce(FilledIDict                     ));
        NoNullRet(1,     Coalesce(FilledIColl                     ));
        NoNullRet(1,     Coalesce(FilledIEnumerable               ));
      //NoNullRet(1,     Coalesce(FilledILookup                   ));
        NoNullRet(1,     Coalesce(FilledList                      ));
        NoNullRet(1,     Coalesce(FilledHashSet                   ));
        NoNullRet(1,     Coalesce(FilledStack                     ));
        NoNullRet(1,     Coalesce(FilledQueue                     ));
        NoNullRet(1,     Coalesce(FilledLinkedList                ));
        NoNullRet(entry, Coalesce(FilledSortedList                ));
        NoNullRet(1,     Coalesce(FilledSortedSet                 ));
        NoNullRet(entry, Coalesce(FilledDict                      ));
        NoNullRet(1,     Coalesce(FilledDictKeyColl               ));
        NoNullRet(1,     Coalesce(FilledDictValColl               ));
        NoNullRet(1,     Coalesce(FilledIImmutableList            ));
        NoNullRet(1,     Coalesce(FilledIImmutableSet             ));
        NoNullRet(1,     Coalesce(FilledIImmutableStack           ));
        NoNullRet(1,     Coalesce(FilledIImmutableQueue           ));
        NoNullRet(entry, Coalesce(FilledIImmutableDict            ));
      //NoNullRet(1,     Coalesce(FilledImmutableArray            ));
        NoNullRet(1,     Coalesce(FilledImmutableArrayBuilder     ));
        NoNullRet(1,     Coalesce(FilledImmutableList             ));
        NoNullRet(1,     Coalesce(FilledImmutableListBuilder      ));
        NoNullRet(1,     Coalesce(FilledImmutableHashSet          ));
        NoNullRet(1,     Coalesce(FilledImmutableHashSetBuilder   ));
        NoNullRet(1,     Coalesce(FilledImmutableStack            ));
        NoNullRet(1,     Coalesce(FilledImmutableQueue            ));
        NoNullRet(entry, Coalesce(FilledImmutableDict             ));
        NoNullRet(entry, Coalesce(FilledImmutableDictBuilder      ));
        NoNullRet(1,     Coalesce(FilledImmutableSortedSet        ));
        NoNullRet(1,     Coalesce(FilledImmutableSortedSetBuilder ));
        NoNullRet(entry, Coalesce(FilledImmutableSortedDict       ));
        NoNullRet(entry, Coalesce(FilledImmutableSortedDictBuilder));
        NoNullRet(1,     Coalesce(FilledIReadOnlyColl             ));
        NoNullRet(1,     Coalesce(FilledIReadOnlyList             ));
        NoNullRet(entry, Coalesce(FilledIReadOnlyDict             ));
        NoNullRet(1,     Coalesce(FilledReadOnlyColl              ));
        NoNullRet(entry, Coalesce(FilledReadOnlyDict              ));
        NoNullRet(1,     Coalesce(FilledReadOnlyDictKeys          ));
        NoNullRet(1,     Coalesce(FilledReadOnlyDictVals          ));
      //NoNullRet(1,     Coalesce(FilledArraySegment              ));
      //NoNullRet(1,     Coalesce(FilledMemory                    ));
      //NoNullRet(1,     Coalesce(FilledReadOnlyMemory            ));
      //NoNullRet(1,     Coalesce(FilledReadOnlySequence          ));
        NoNullRet(1,     Coalesce(FilledConcurrentBag             ));
        NoNullRet(1,     Coalesce(FilledConcurrentQueue           ));
        NoNullRet(1,     Coalesce(FilledConcurrentStack           ));
        NoNullRet(entry, Coalesce(FilledConcurrentDict            ));
        NoNullRet(1,     Coalesce(FilledBlockingColl              ));
        NoNullRet(1,     Coalesce(FilledIProducerConsumerColl     ));
        NoNullRet(entry, Coalesce(FilledSortedDict                ));
        NoNullRet(1,     Coalesce(FilledSortedDictKeys            ));
        NoNullRet(1,     Coalesce(FilledSortedDictVals            ));
        NoNullRet(1,     Coalesce(FilledColl                      ));
        NoNullRet(1,     Coalesce(FilledKeyedColl                 ));
        NoNullRet(1,     Coalesce(FilledObservableColl            ));
        NoNullRet(1,     Coalesce(FilledReadOnlyObservableColl    ));
      //NoNullRet(1,     Coalesce(FilledArrayList                 ));
      //NoNullRet(1,     Coalesce(FilledBitArray                  ));
      //NoNullRet(1,     Coalesce(FilledCollBase                  ));
      //NoNullRet(1,     Coalesce(FilledDictBase                  ));
      //NoNullRet(1,     Coalesce(FilledHashtable                 ));
      //NoNullRet(1,     Coalesce(FilledQueueNonGeneric           ));
      //NoNullRet(1,     Coalesce(FilledReadOnlyCollBase          ));
      //NoNullRet(1,     Coalesce(FilledSortedListNonGeneric      ));
      //NoNullRet(1,     Coalesce(FilledStackNonGeneric           ));
      //NoNullRet(1,     Coalesce(FilledHybridDict                ));
      //NoNullRet(1,     Coalesce(FilledListDict                  ));
      //NoNullRet(1,     Coalesce(FilledNameObjectCollBase        ));
      //NoNullRet(1,     Coalesce(FilledNameObjectCollBaseKeys    ));
      //NoNullRet(1,     Coalesce(FilledNameValueColl             ));
      //NoNullRet(1,     Coalesce(FilledOrderedDictNonGeneric     ));
      //NoNullRet(1,     Coalesce(FilledStringColl                ));
      //NoNullRet(1,     Coalesce(FilledStringDict                ));
      //NoNullRet(1,     Coalesce(FilledIOrderedDict              ));
        #if NET9_0_OR_GREATER                                                                                                                  
        NoNullRet(entry, Coalesce(FilledOrderedDict               ));
        NoNullRet(1,     Coalesce(FilledOrderedDictKeys           ));
        NoNullRet(1,     Coalesce(FilledOrderedDictVals           ));
        NoNullRet(1,     Coalesce(FilledIReadOnlySet              ));
        NoNullRet(1,     Coalesce(FilledReadOnlySet               ));
        #endif                                                                                             
        #if NET8_0_OR_GREATER                                                                        
        NoNullRet(1,     Coalesce(FilledFrozenSet                 ));          
        NoNullRet(entry, Coalesce(FilledFrozenDictionary          ));          
        #endif                                                                                       
        #if NET6_0_OR_GREATER                                                                              
      //NoNullRet(1,     Coalesce(FilledPrioQueue                 ));   
      //NoNullRet(1,     Coalesce(FilledPrioQueueUnorderedColl    ));   
        #endif                                                                                            
    }

    [TestMethod]
    public void Coalesce_Collections_Static_NullyFilled()
    {
        NoNullRet(1, Coalesce(NullyFilledArray                ));
        NoNullRet(1, Coalesce(NullyFilledList                 ));
        NoNullRet(1, Coalesce(NullyFilledHashSet              ));
        NoNullRet(1, Coalesce(NullyFilledIList                ));
        NoNullRet(1, Coalesce(NullyFilledISet                 ));
        NoNullRet(1, Coalesce(NullyFilledIColl                ));
        NoNullRet(1, Coalesce(NullyFilledIReadOnlyList        ));
        NoNullRet(1, Coalesce(NullyFilledIReadOnlyColl        ));
        NoNullRet(1, Coalesce(NullyFilledIEnumerable          ));
    }

    [TestMethod]
    public void Coalesce_Collections_Static_Empty()
    {
        NoNullRet(0, Coalesce(EmptyArray                      ));
        NoNullRet(0, Coalesce(EmptyList                       ));
        NoNullRet(0, Coalesce(EmptyHashSet                    ));
        NoNullRet(0, Coalesce(EmptyIList                      ));
        NoNullRet(0, Coalesce(EmptyISet                       ));
        NoNullRet(0, Coalesce(EmptyIColl                      ));
        NoNullRet(0, Coalesce(EmptyIReadOnlyList              ));
        NoNullRet(0, Coalesce(EmptyIReadOnlyColl              ));
        NoNullRet(0, Coalesce(EmptyIEnumerable                ));
    }

    [TestMethod]
    public void Coalesce_Collections_Static_NullableEmpty()
    {
        NoNullRet(0, Coalesce(NullableEmptyArray              ));
        NoNullRet(0, Coalesce(NullableEmptyList               ));
        NoNullRet(0, Coalesce(NullableEmptyHashSet            ));
        NoNullRet(0, Coalesce(NullableEmptyIList              ));
        NoNullRet(0, Coalesce(NullableEmptyISet               ));
        NoNullRet(0, Coalesce(NullableEmptyIColl              ));
        NoNullRet(0, Coalesce(NullableEmptyIReadOnlyList      ));
        NoNullRet(0, Coalesce(NullableEmptyIReadOnlyColl      ));
        NoNullRet(0, Coalesce(NullableEmptyIEnumerable        ));
    }

    [TestMethod]
    public void Coalesce_Collections_Static_Null()
    {
        NoNullRet(0, Coalesce(NullArray                       ));
        NoNullRet(0, Coalesce(NullList                        ));
        NoNullRet(0, Coalesce(NullHashSet                     ));
        NoNullRet(0, Coalesce(NullIList                       ));
        NoNullRet(0, Coalesce(NullISet                        ));
        NoNullRet(0, Coalesce(NullIColl                       ));
        NoNullRet(0, Coalesce(NullIReadOnlyList               ));
        NoNullRet(0, Coalesce(NullIReadOnlyColl               ));
        NoNullRet(0, Coalesce(NullIEnumerable                 ));
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_Filled()
    {
        NoNullRet(1, FilledArray                     .Coalesce());
        NoNullRet(1, FilledList                      .Coalesce());
        NoNullRet(1, FilledHashSet                   .Coalesce());
        NoNullRet(1, FilledIList                     .Coalesce());
        NoNullRet(1, FilledISet                      .Coalesce());
        NoNullRet(1, FilledIColl                     .Coalesce());
        NoNullRet(1, FilledIReadOnlyList             .Coalesce());
        NoNullRet(1, FilledIReadOnlyColl             .Coalesce());
        NoNullRet(1, FilledIEnumerable               .Coalesce());
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_NullyFilled()
    {
        NoNullRet(1, NullyFilledArray                .Coalesce());
        NoNullRet(1, NullyFilledList                 .Coalesce());
        NoNullRet(1, NullyFilledHashSet              .Coalesce());
        NoNullRet(1, NullyFilledIList                .Coalesce());
        NoNullRet(1, NullyFilledISet                 .Coalesce());
        NoNullRet(1, NullyFilledIColl                .Coalesce());
        NoNullRet(1, NullyFilledIReadOnlyList        .Coalesce());
        NoNullRet(1, NullyFilledIReadOnlyColl        .Coalesce());
        NoNullRet(1, NullyFilledIEnumerable          .Coalesce());
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_Empty()
    {
        NoNullRet(0, EmptyArray                      .Coalesce());
        NoNullRet(0, EmptyList                       .Coalesce());
        NoNullRet(0, EmptyHashSet                    .Coalesce());
        NoNullRet(0, EmptyIList                      .Coalesce());
        NoNullRet(0, EmptyISet                       .Coalesce());
        NoNullRet(0, EmptyIColl                      .Coalesce());
        NoNullRet(0, EmptyIReadOnlyList              .Coalesce());
        NoNullRet(0, EmptyIReadOnlyColl              .Coalesce());
        NoNullRet(0, EmptyIEnumerable                .Coalesce());
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_NullableEmpty()
    {
        NoNullRet(0, NullableEmptyArray              .Coalesce());
        NoNullRet(0, NullableEmptyList               .Coalesce());
        NoNullRet(0, NullableEmptyHashSet            .Coalesce());
        NoNullRet(0, NullableEmptyIList              .Coalesce());
        NoNullRet(0, NullableEmptyISet               .Coalesce());
        NoNullRet(0, NullableEmptyIColl              .Coalesce());
        NoNullRet(0, NullableEmptyIReadOnlyList      .Coalesce());
        NoNullRet(0, NullableEmptyIReadOnlyColl      .Coalesce());
        NoNullRet(0, NullableEmptyIEnumerable        .Coalesce());
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_Null()
    {
        NoNullRet(0, NullArray                       .Coalesce());
        NoNullRet(0, NullList                        .Coalesce());
        NoNullRet(0, NullHashSet                     .Coalesce());
        NoNullRet(0, NullIList                       .Coalesce());
        NoNullRet(0, NullISet                        .Coalesce());
        NoNullRet(0, NullIColl                       .Coalesce());
        NoNullRet(0, NullIReadOnlyList               .Coalesce());
        NoNullRet(0, NullIReadOnlyColl               .Coalesce());
        NoNullRet(0, NullIEnumerable                 .Coalesce());
    }
}
