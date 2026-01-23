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
    public void BUG_Coalesce_CollectionTypes_NotSupported()
    {
      //NoNullRet(1,     Coalesce(FilledILookup                   ));
      //NoNullRet(1,     Coalesce(FilledImmutableArray            ));
      //NoNullRet(1,     Coalesce(FilledArraySegment              ));
      //NoNullRet(1,     Coalesce(FilledMemory                    ));
      //NoNullRet(1,     Coalesce(FilledReadOnlyMemory            ));
      //NoNullRet(1,     Coalesce(FilledReadOnlySequence          ));
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
        #if NET6_0_OR_GREATER                                                                              
      //NoNullRet(1,     Coalesce(FilledPrioQueue                 ));   
      //NoNullRet(1,     Coalesce(FilledPrioQueueUnorderedColl    ));   
        #endif                                                                                            
    }
    
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
    public void Coalesce_Collections_Static_Filled()
    {
        var entry = new KeyValuePair<int, int>(1, 1);
        NoNullRet(1,     Coalesce(FilledArray                     ));
        NoNullRet(1,     Coalesce(FilledIList                     ));
        NoNullRet(1,     Coalesce(FilledISet                      ));
        NoNullRet(entry, Coalesce(FilledIDict                     ));
        NoNullRet(1,     Coalesce(FilledIColl                     ));
        NoNullRet(1,     Coalesce(FilledIEnumerable               ));
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
    }

    [TestMethod]
    public void Coalesce_Collections_Static_NullyFilled()
    {
        var entry = new KeyValuePair<int, int>(1, 1);
        NoNullRet(1,     Coalesce(NullyFilledArray                     ));
        NoNullRet(1,     Coalesce(NullyFilledIList                     ));
        NoNullRet(1,     Coalesce(NullyFilledISet                      ));
        NoNullRet(entry, Coalesce(NullyFilledIDict                     ));
        NoNullRet(1,     Coalesce(NullyFilledIColl                     ));
        NoNullRet(1,     Coalesce(NullyFilledIEnumerable               ));
        NoNullRet(1,     Coalesce(NullyFilledList                      ));
        NoNullRet(1,     Coalesce(NullyFilledHashSet                   ));
        NoNullRet(1,     Coalesce(NullyFilledStack                     ));
        NoNullRet(1,     Coalesce(NullyFilledQueue                     ));
        NoNullRet(1,     Coalesce(NullyFilledLinkedList                ));
        NoNullRet(entry, Coalesce(NullyFilledSortedList                ));
        NoNullRet(1,     Coalesce(NullyFilledSortedSet                 ));
        NoNullRet(entry, Coalesce(NullyFilledDict                      ));
        NoNullRet(1,     Coalesce(NullyFilledDictKeyColl               ));
        NoNullRet(1,     Coalesce(NullyFilledDictValColl               ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableList            ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableSet             ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableStack           ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableQueue           ));
        NoNullRet(entry, Coalesce(NullyFilledIImmutableDict            ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableArrayBuilder     ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableList             ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableListBuilder      ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableHashSet          ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableHashSetBuilder   ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableStack            ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableQueue            ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableDict             ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableDictBuilder      ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableSortedSet        ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableSortedSetBuilder ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableSortedDict       ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableSortedDictBuilder));
        NoNullRet(1,     Coalesce(NullyFilledIReadOnlyColl             ));
        NoNullRet(1,     Coalesce(NullyFilledIReadOnlyList             ));
        NoNullRet(entry, Coalesce(NullyFilledIReadOnlyDict             ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyColl              ));
        NoNullRet(entry, Coalesce(NullyFilledReadOnlyDict              ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyDictKeys          ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyDictVals          ));
        NoNullRet(1,     Coalesce(NullyFilledConcurrentBag             ));
        NoNullRet(1,     Coalesce(NullyFilledConcurrentQueue           ));
        NoNullRet(1,     Coalesce(NullyFilledConcurrentStack           ));
        NoNullRet(entry, Coalesce(NullyFilledConcurrentDict            ));
        NoNullRet(1,     Coalesce(NullyFilledBlockingColl              ));
        NoNullRet(1,     Coalesce(NullyFilledIProducerConsumerColl     ));
        NoNullRet(entry, Coalesce(NullyFilledSortedDict                ));
        NoNullRet(1,     Coalesce(NullyFilledSortedDictKeys            ));
        NoNullRet(1,     Coalesce(NullyFilledSortedDictVals            ));
        NoNullRet(1,     Coalesce(NullyFilledColl                      ));
        NoNullRet(1,     Coalesce(NullyFilledKeyedColl                 ));
        NoNullRet(1,     Coalesce(NullyFilledObservableColl            ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyObservableColl    ));
        #if NET9_0_OR_GREATER                                                                                                                  
        NoNullRet(entry, Coalesce(NullyFilledOrderedDict               ));
        NoNullRet(1,     Coalesce(NullyFilledOrderedDictKeys           ));
        NoNullRet(1,     Coalesce(NullyFilledOrderedDictVals           ));
        NoNullRet(1,     Coalesce(NullyFilledIReadOnlySet              ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlySet               ));
        #endif                                                                                             
        #if NET8_0_OR_GREATER                                                                        
        NoNullRet(1,     Coalesce(NullyFilledFrozenSet                 ));          
        NoNullRet(entry, Coalesce(NullyFilledFrozenDictionary          ));          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Static_Empty()
    {
        KeyValuePair<int, int> entry = default;
        NoNullRet(0,     Coalesce(EmptyArray                     ));
        NoNullRet(0,     Coalesce(EmptyIList                     ));
        NoNullRet(0,     Coalesce(EmptyISet                      ));
        NoNullRet(entry, Coalesce(EmptyIDict                     ));
        NoNullRet(0,     Coalesce(EmptyIColl                     ));
        NoNullRet(0,     Coalesce(EmptyIEnumerable               ));
        NoNullRet(0,     Coalesce(EmptyList                      ));
        NoNullRet(0,     Coalesce(EmptyHashSet                   ));
        NoNullRet(0,     Coalesce(EmptyStack                     ));
        NoNullRet(0,     Coalesce(EmptyQueue                     ));
        NoNullRet(0,     Coalesce(EmptyLinkedList                ));
        NoNullRet(entry, Coalesce(EmptySortedList                ));
        NoNullRet(0,     Coalesce(EmptySortedSet                 ));
        NoNullRet(entry, Coalesce(EmptyDict                      ));
        NoNullRet(0,     Coalesce(EmptyDictKeyColl               ));
        NoNullRet(0,     Coalesce(EmptyDictValColl               ));
        NoNullRet(0,     Coalesce(EmptyIImmutableList            ));
        NoNullRet(0,     Coalesce(EmptyIImmutableSet             ));
        NoNullRet(0,     Coalesce(EmptyIImmutableStack           ));
        NoNullRet(0,     Coalesce(EmptyIImmutableQueue           ));
        NoNullRet(entry, Coalesce(EmptyIImmutableDict            ));
        NoNullRet(0,     Coalesce(EmptyImmutableArrayBuilder     ));
        NoNullRet(0,     Coalesce(EmptyImmutableList             ));
        NoNullRet(0,     Coalesce(EmptyImmutableListBuilder      ));
        NoNullRet(0,     Coalesce(EmptyImmutableHashSet          ));
        NoNullRet(0,     Coalesce(EmptyImmutableHashSetBuilder   ));
        NoNullRet(0,     Coalesce(EmptyImmutableStack            ));
        NoNullRet(0,     Coalesce(EmptyImmutableQueue            ));
        NoNullRet(entry, Coalesce(EmptyImmutableDict             ));
        NoNullRet(entry, Coalesce(EmptyImmutableDictBuilder      ));
        NoNullRet(0,     Coalesce(EmptyImmutableSortedSet        ));
        NoNullRet(0,     Coalesce(EmptyImmutableSortedSetBuilder ));
        NoNullRet(entry, Coalesce(EmptyImmutableSortedDict       ));
        NoNullRet(entry, Coalesce(EmptyImmutableSortedDictBuilder));
        NoNullRet(0,     Coalesce(EmptyIReadOnlyColl             ));
        NoNullRet(0,     Coalesce(EmptyIReadOnlyList             ));
        NoNullRet(entry, Coalesce(EmptyIReadOnlyDict             ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyColl              ));
        NoNullRet(entry, Coalesce(EmptyReadOnlyDict              ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyDictKeys          ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyDictVals          ));
        NoNullRet(0,     Coalesce(EmptyConcurrentBag             ));
        NoNullRet(0,     Coalesce(EmptyConcurrentQueue           ));
        NoNullRet(0,     Coalesce(EmptyConcurrentStack           ));
        NoNullRet(entry, Coalesce(EmptyConcurrentDict            ));
        NoNullRet(0,     Coalesce(EmptyBlockingColl              ));
        NoNullRet(0,     Coalesce(EmptyIProducerConsumerColl     ));
        NoNullRet(entry, Coalesce(EmptySortedDict                ));
        NoNullRet(0,     Coalesce(EmptySortedDictKeys            ));
        NoNullRet(0,     Coalesce(EmptySortedDictVals            ));
        NoNullRet(0,     Coalesce(EmptyColl                      ));
        NoNullRet(0,     Coalesce(EmptyKeyedColl                 ));
        NoNullRet(0,     Coalesce(EmptyObservableColl            ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyObservableColl    ));
        #if NET9_0_OR_GREATER                                                                                                                  
        NoNullRet(entry, Coalesce(EmptyOrderedDict               ));
        NoNullRet(0,     Coalesce(EmptyOrderedDictKeys           ));
        NoNullRet(0,     Coalesce(EmptyOrderedDictVals           ));
        NoNullRet(0,     Coalesce(EmptyIReadOnlySet              ));
        NoNullRet(0,     Coalesce(EmptyReadOnlySet               ));
        #endif                                                                                             
        #if NET8_0_OR_GREATER                                                                        
        NoNullRet(0,     Coalesce(EmptyFrozenSet                 ));          
        NoNullRet(entry, Coalesce(EmptyFrozenDictionary          ));          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Static_NullableEmpty()
    {
        KeyValuePair<int, int> entry = default;
        NoNullRet(0,     Coalesce(NullableEmptyArray                     ));
        NoNullRet(0,     Coalesce(NullableEmptyIList                     ));
        NoNullRet(0,     Coalesce(NullableEmptyISet                      ));
        NoNullRet(entry, Coalesce(NullableEmptyIDict                     ));
        NoNullRet(0,     Coalesce(NullableEmptyIColl                     ));
        NoNullRet(0,     Coalesce(NullableEmptyIEnumerable               ));
        NoNullRet(0,     Coalesce(NullableEmptyList                      ));
        NoNullRet(0,     Coalesce(NullableEmptyHashSet                   ));
        NoNullRet(0,     Coalesce(NullableEmptyStack                     ));
        NoNullRet(0,     Coalesce(NullableEmptyQueue                     ));
        NoNullRet(0,     Coalesce(NullableEmptyLinkedList                ));
        NoNullRet(entry, Coalesce(NullableEmptySortedList                ));
        NoNullRet(0,     Coalesce(NullableEmptySortedSet                 ));
        NoNullRet(entry, Coalesce(NullableEmptyDict                      ));
        NoNullRet(0,     Coalesce(NullableEmptyDictKeyColl               ));
        NoNullRet(0,     Coalesce(NullableEmptyDictValColl               ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableList            ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableSet             ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableStack           ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableQueue           ));
        NoNullRet(entry, Coalesce(NullableEmptyIImmutableDict            ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableArrayBuilder     ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableList             ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableListBuilder      ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableHashSet          ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableHashSetBuilder   ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableStack            ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableQueue            ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableDict             ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableDictBuilder      ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableSortedSet        ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableSortedSetBuilder ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableSortedDict       ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableSortedDictBuilder));
        NoNullRet(0,     Coalesce(NullableEmptyIReadOnlyColl             ));
        NoNullRet(0,     Coalesce(NullableEmptyIReadOnlyList             ));
        NoNullRet(entry, Coalesce(NullableEmptyIReadOnlyDict             ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyColl              ));
        NoNullRet(entry, Coalesce(NullableEmptyReadOnlyDict              ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyDictKeys          ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyDictVals          ));
        NoNullRet(0,     Coalesce(NullableEmptyConcurrentBag             ));
        NoNullRet(0,     Coalesce(NullableEmptyConcurrentQueue           ));
        NoNullRet(0,     Coalesce(NullableEmptyConcurrentStack           ));
        NoNullRet(entry, Coalesce(NullableEmptyConcurrentDict            ));
        NoNullRet(0,     Coalesce(NullableEmptyBlockingColl              ));
        NoNullRet(0,     Coalesce(NullableEmptyIProducerConsumerColl     ));
        NoNullRet(entry, Coalesce(NullableEmptySortedDict                ));
        NoNullRet(0,     Coalesce(NullableEmptySortedDictKeys            ));
        NoNullRet(0,     Coalesce(NullableEmptySortedDictVals            ));
        NoNullRet(0,     Coalesce(NullableEmptyColl                      ));
        NoNullRet(0,     Coalesce(NullableEmptyKeyedColl                 ));
        NoNullRet(0,     Coalesce(NullableEmptyObservableColl            ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyObservableColl    ));
        #if NET9_0_OR_GREATER                                                                                                                  
        NoNullRet(entry, Coalesce(NullableEmptyOrderedDict               ));
        NoNullRet(0,     Coalesce(NullableEmptyOrderedDictKeys           ));
        NoNullRet(0,     Coalesce(NullableEmptyOrderedDictVals           ));
        NoNullRet(0,     Coalesce(NullableEmptyIReadOnlySet              ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlySet               ));
        #endif                                                                                             
        #if NET8_0_OR_GREATER                                                                        
        NoNullRet(0,     Coalesce(NullableEmptyFrozenSet                 ));          
        NoNullRet(entry, Coalesce(NullableEmptyFrozenDictionary          ));          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Static_Null()
    {
        KeyValuePair<int, int> entry = default;
        NoNullRet(0,     Coalesce(NullArray                     ));
        NoNullRet(0,     Coalesce(NullIList                     ));
        NoNullRet(0,     Coalesce(NullISet                      ));
        NoNullRet(entry, Coalesce(NullIDict                     ));
        NoNullRet(0,     Coalesce(NullIColl                     ));
        NoNullRet(0,     Coalesce(NullIEnumerable               ));
        NoNullRet(0,     Coalesce(NullList                      ));
        NoNullRet(0,     Coalesce(NullHashSet                   ));
        NoNullRet(0,     Coalesce(NullStack                     ));
        NoNullRet(0,     Coalesce(NullQueue                     ));
        NoNullRet(0,     Coalesce(NullLinkedList                ));
        NoNullRet(entry, Coalesce(NullSortedList                ));
        NoNullRet(0,     Coalesce(NullSortedSet                 ));
        NoNullRet(entry, Coalesce(NullDict                      ));
        NoNullRet(0,     Coalesce(NullDictKeyColl               ));
        NoNullRet(0,     Coalesce(NullDictValColl               ));
        NoNullRet(0,     Coalesce(NullIImmutableList            ));
        NoNullRet(0,     Coalesce(NullIImmutableSet             ));
        NoNullRet(0,     Coalesce(NullIImmutableStack           ));
        NoNullRet(0,     Coalesce(NullIImmutableQueue           ));
        NoNullRet(entry, Coalesce(NullIImmutableDict            ));
        NoNullRet(0,     Coalesce(NullImmutableArrayBuilder     ));
        NoNullRet(0,     Coalesce(NullImmutableList             ));
        NoNullRet(0,     Coalesce(NullImmutableListBuilder      ));
        NoNullRet(0,     Coalesce(NullImmutableHashSet          ));
        NoNullRet(0,     Coalesce(NullImmutableHashSetBuilder   ));
        NoNullRet(0,     Coalesce(NullImmutableStack            ));
        NoNullRet(0,     Coalesce(NullImmutableQueue            ));
        NoNullRet(entry, Coalesce(NullImmutableDict             ));
        NoNullRet(entry, Coalesce(NullImmutableDictBuilder      ));
        NoNullRet(0,     Coalesce(NullImmutableSortedSet        ));
        NoNullRet(0,     Coalesce(NullImmutableSortedSetBuilder ));
        NoNullRet(entry, Coalesce(NullImmutableSortedDict       ));
        NoNullRet(entry, Coalesce(NullImmutableSortedDictBuilder));
        NoNullRet(0,     Coalesce(NullIReadOnlyColl             ));
        NoNullRet(0,     Coalesce(NullIReadOnlyList             ));
        NoNullRet(entry, Coalesce(NullIReadOnlyDict             ));
        NoNullRet(0,     Coalesce(NullReadOnlyColl              ));
        NoNullRet(entry, Coalesce(NullReadOnlyDict              ));
        NoNullRet(0,     Coalesce(NullReadOnlyDictKeys          ));
        NoNullRet(0,     Coalesce(NullReadOnlyDictVals          ));
        NoNullRet(0,     Coalesce(NullConcurrentBag             ));
        NoNullRet(0,     Coalesce(NullConcurrentQueue           ));
        NoNullRet(0,     Coalesce(NullConcurrentStack           ));
        NoNullRet(entry, Coalesce(NullConcurrentDict            ));
        NoNullRet(0,     Coalesce(NullBlockingColl              ));
        NoNullRet(0,     Coalesce(NullIProducerConsumerColl     ));
        NoNullRet(entry, Coalesce(NullSortedDict                ));
        NoNullRet(0,     Coalesce(NullSortedDictKeys            ));
        NoNullRet(0,     Coalesce(NullSortedDictVals            ));
        NoNullRet(0,     Coalesce(NullColl                      ));
        NoNullRet(0,     Coalesce(NullKeyedColl                 ));
        NoNullRet(0,     Coalesce(NullObservableColl            ));
        NoNullRet(0,     Coalesce(NullReadOnlyObservableColl    ));
        #if NET9_0_OR_GREATER                                                                                                                  
        NoNullRet(entry, Coalesce(NullOrderedDict               ));
        NoNullRet(0,     Coalesce(NullOrderedDictKeys           ));
        NoNullRet(0,     Coalesce(NullOrderedDictVals           ));
        NoNullRet(0,     Coalesce(NullIReadOnlySet              ));
        NoNullRet(0,     Coalesce(NullReadOnlySet               ));
        #endif                                                                                             
        #if NET8_0_OR_GREATER                                                                        
        NoNullRet(0,     Coalesce(NullFrozenSet                 ));          
        NoNullRet(entry, Coalesce(NullFrozenDictionary          ));          
        #endif                                                                                       
    }
    
    // TODO: Add more collection types

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
