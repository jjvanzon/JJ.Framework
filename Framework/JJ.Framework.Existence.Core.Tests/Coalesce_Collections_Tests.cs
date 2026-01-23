namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Collections_Tests
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
                                                                          
    [TestMethod]                                                          
    public void Coalesce_Collections_Static_Filled()                      
    {                                                                     
        var entry = new KeyValuePair<int, int>(1, 1);                     
        NoNullRet(1,     Coalesce(FilledArray                             ));
        NoNullRet(1,     Coalesce(FilledIList                             ));
        NoNullRet(1,     Coalesce(FilledISet                              ));
        NoNullRet(entry, Coalesce(FilledIDict                             ));
        NoNullRet(1,     Coalesce(FilledIColl                             ));
        NoNullRet(1,     Coalesce(FilledIEnumerable                       ));
        NoNullRet(1,     Coalesce(FilledList                              ));
        NoNullRet(1,     Coalesce(FilledHashSet                           ));
        NoNullRet(1,     Coalesce(FilledStack                             ));
        NoNullRet(1,     Coalesce(FilledQueue                             ));
        NoNullRet(1,     Coalesce(FilledLinkedList                        ));
        NoNullRet(entry, Coalesce(FilledSortedList                        ));
        NoNullRet(1,     Coalesce(FilledSortedSet                         ));
        NoNullRet(entry, Coalesce(FilledDict                              ));
        NoNullRet(1,     Coalesce(FilledDictKeyColl                       ));
        NoNullRet(1,     Coalesce(FilledDictValColl                       ));
        NoNullRet(1,     Coalesce(FilledIImmutableList                    ));
        NoNullRet(1,     Coalesce(FilledIImmutableSet                     ));
        NoNullRet(1,     Coalesce(FilledIImmutableStack                   ));
        NoNullRet(1,     Coalesce(FilledIImmutableQueue                   ));
        NoNullRet(entry, Coalesce(FilledIImmutableDict                    ));
        NoNullRet(1,     Coalesce(FilledImmutableArrayBuilder             ));
        NoNullRet(1,     Coalesce(FilledImmutableList                     ));
        NoNullRet(1,     Coalesce(FilledImmutableListBuilder              ));
        NoNullRet(1,     Coalesce(FilledImmutableHashSet                  ));
        NoNullRet(1,     Coalesce(FilledImmutableHashSetBuilder           ));
        NoNullRet(1,     Coalesce(FilledImmutableStack                    ));
        NoNullRet(1,     Coalesce(FilledImmutableQueue                    ));
        NoNullRet(entry, Coalesce(FilledImmutableDict                     ));
        NoNullRet(entry, Coalesce(FilledImmutableDictBuilder              ));
        NoNullRet(1,     Coalesce(FilledImmutableSortedSet                ));
        NoNullRet(1,     Coalesce(FilledImmutableSortedSetBuilder         ));
        NoNullRet(entry, Coalesce(FilledImmutableSortedDict               ));
        NoNullRet(entry, Coalesce(FilledImmutableSortedDictBuilder        ));
        NoNullRet(1,     Coalesce(FilledIReadOnlyColl                     ));
        NoNullRet(1,     Coalesce(FilledIReadOnlyList                     ));
        NoNullRet(entry, Coalesce(FilledIReadOnlyDict                     ));
        NoNullRet(1,     Coalesce(FilledReadOnlyColl                      ));
        NoNullRet(entry, Coalesce(FilledReadOnlyDict                      ));
        NoNullRet(1,     Coalesce(FilledReadOnlyDictKeys                  ));
        NoNullRet(1,     Coalesce(FilledReadOnlyDictVals                  ));
        NoNullRet(1,     Coalesce(FilledConcurrentBag                     ));
        NoNullRet(1,     Coalesce(FilledConcurrentQueue                   ));
        NoNullRet(1,     Coalesce(FilledConcurrentStack                   ));
        NoNullRet(entry, Coalesce(FilledConcurrentDict                    ));
        NoNullRet(1,     Coalesce(FilledBlockingColl                      ));
        NoNullRet(1,     Coalesce(FilledIProducerConsumerColl             ));
        NoNullRet(entry, Coalesce(FilledSortedDict                        ));
        NoNullRet(1,     Coalesce(FilledSortedDictKeys                    ));
        NoNullRet(1,     Coalesce(FilledSortedDictVals                    ));
        NoNullRet(1,     Coalesce(FilledColl                              ));
        NoNullRet(1,     Coalesce(FilledKeyedColl                         ));
        NoNullRet(1,     Coalesce(FilledObservableColl                    ));
        NoNullRet(1,     Coalesce(FilledReadOnlyObservableColl            ));
        #if NET9_0_OR_GREATER                                                                                                                          
        NoNullRet(entry, Coalesce(FilledOrderedDict                       ));
        NoNullRet(1,     Coalesce(FilledOrderedDictKeys                   ));
        NoNullRet(1,     Coalesce(FilledOrderedDictVals                   ));
        NoNullRet(1,     Coalesce(FilledIReadOnlySet                      ));
        NoNullRet(1,     Coalesce(FilledReadOnlySet                       ));
        #endif                                                                                                     
        #if NET8_0_OR_GREATER                                                                                
        NoNullRet(1,     Coalesce(FilledFrozenSet                         ));          
        NoNullRet(entry, Coalesce(FilledFrozenDictionary                  ));          
        #endif                                                                                        
    }                                                                     
                                                                          
    [TestMethod]                                                          
    public void Coalesce_Collections_Static_NullyFilled()                 
    {                                                                     
        var entry = new KeyValuePair<int, int>(1, 1);                     
        NoNullRet(1,     Coalesce(NullyFilledArray                        ));
        NoNullRet(1,     Coalesce(NullyFilledIList                        ));
        NoNullRet(1,     Coalesce(NullyFilledISet                         ));
        NoNullRet(entry, Coalesce(NullyFilledIDict                        ));
        NoNullRet(1,     Coalesce(NullyFilledIColl                        ));
        NoNullRet(1,     Coalesce(NullyFilledIEnumerable                  ));
        NoNullRet(1,     Coalesce(NullyFilledList                         ));
        NoNullRet(1,     Coalesce(NullyFilledHashSet                      ));
        NoNullRet(1,     Coalesce(NullyFilledStack                        ));
        NoNullRet(1,     Coalesce(NullyFilledQueue                        ));
        NoNullRet(1,     Coalesce(NullyFilledLinkedList                   ));
        NoNullRet(entry, Coalesce(NullyFilledSortedList                   ));
        NoNullRet(1,     Coalesce(NullyFilledSortedSet                    ));
        NoNullRet(entry, Coalesce(NullyFilledDict                         ));
        NoNullRet(1,     Coalesce(NullyFilledDictKeyColl                  ));
        NoNullRet(1,     Coalesce(NullyFilledDictValColl                  ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableList               ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableSet                ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableStack              ));
        NoNullRet(1,     Coalesce(NullyFilledIImmutableQueue              ));
        NoNullRet(entry, Coalesce(NullyFilledIImmutableDict               ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableArrayBuilder        ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableList                ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableListBuilder         ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableHashSet             ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableHashSetBuilder      ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableStack               ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableQueue               ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableDict                ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableDictBuilder         ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableSortedSet           ));
        NoNullRet(1,     Coalesce(NullyFilledImmutableSortedSetBuilder    ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableSortedDict          ));
        NoNullRet(entry, Coalesce(NullyFilledImmutableSortedDictBuilder   ));
        NoNullRet(1,     Coalesce(NullyFilledIReadOnlyColl                ));
        NoNullRet(1,     Coalesce(NullyFilledIReadOnlyList                ));
        NoNullRet(entry, Coalesce(NullyFilledIReadOnlyDict                ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyColl                 ));
        NoNullRet(entry, Coalesce(NullyFilledReadOnlyDict                 ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyDictKeys             ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyDictVals             ));
        NoNullRet(1,     Coalesce(NullyFilledConcurrentBag                ));
        NoNullRet(1,     Coalesce(NullyFilledConcurrentQueue              ));
        NoNullRet(1,     Coalesce(NullyFilledConcurrentStack              ));
        NoNullRet(entry, Coalesce(NullyFilledConcurrentDict               ));
        NoNullRet(1,     Coalesce(NullyFilledBlockingColl                 ));
        NoNullRet(1,     Coalesce(NullyFilledIProducerConsumerColl        ));
        NoNullRet(entry, Coalesce(NullyFilledSortedDict                   ));
        NoNullRet(1,     Coalesce(NullyFilledSortedDictKeys               ));
        NoNullRet(1,     Coalesce(NullyFilledSortedDictVals               ));
        NoNullRet(1,     Coalesce(NullyFilledColl                         ));
        NoNullRet(1,     Coalesce(NullyFilledKeyedColl                    ));
        NoNullRet(1,     Coalesce(NullyFilledObservableColl               ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlyObservableColl       ));
        #if NET9_0_OR_GREATER                                                                                                                     
        NoNullRet(entry, Coalesce(NullyFilledOrderedDict                  ));
        NoNullRet(1,     Coalesce(NullyFilledOrderedDictKeys              ));
        NoNullRet(1,     Coalesce(NullyFilledOrderedDictVals              ));
        NoNullRet(1,     Coalesce(NullyFilledIReadOnlySet                 ));
        NoNullRet(1,     Coalesce(NullyFilledReadOnlySet                  ));
        #endif                                                                                                
        #if NET8_0_OR_GREATER                                                                           
        NoNullRet(1,     Coalesce(NullyFilledFrozenSet                    ));          
        NoNullRet(entry, Coalesce(NullyFilledFrozenDictionary             ));          
        #endif                                                                                        
    }                                                                     
                                                                          
    [TestMethod]                                                          
    public void Coalesce_Collections_Static_Empty()                       
    {                                                                     
        KeyValuePair<int, int> entry = default;                           
        NoNullRet(0,     Coalesce(EmptyArray                              ));
        NoNullRet(0,     Coalesce(EmptyIList                              ));
        NoNullRet(0,     Coalesce(EmptyISet                               ));
        NoNullRet(entry, Coalesce(EmptyIDict                              ));
        NoNullRet(0,     Coalesce(EmptyIColl                              ));
        NoNullRet(0,     Coalesce(EmptyIEnumerable                        ));
        NoNullRet(0,     Coalesce(EmptyList                               ));
        NoNullRet(0,     Coalesce(EmptyHashSet                            ));
        NoNullRet(0,     Coalesce(EmptyStack                              ));
        NoNullRet(0,     Coalesce(EmptyQueue                              ));
        NoNullRet(0,     Coalesce(EmptyLinkedList                         ));
        NoNullRet(entry, Coalesce(EmptySortedList                         ));
        NoNullRet(0,     Coalesce(EmptySortedSet                          ));
        NoNullRet(entry, Coalesce(EmptyDict                               ));
        NoNullRet(0,     Coalesce(EmptyDictKeyColl                        ));
        NoNullRet(0,     Coalesce(EmptyDictValColl                        ));
        NoNullRet(0,     Coalesce(EmptyIImmutableList                     ));
        NoNullRet(0,     Coalesce(EmptyIImmutableSet                      ));
        NoNullRet(0,     Coalesce(EmptyIImmutableStack                    ));
        NoNullRet(0,     Coalesce(EmptyIImmutableQueue                    ));
        NoNullRet(entry, Coalesce(EmptyIImmutableDict                     ));
        NoNullRet(0,     Coalesce(EmptyImmutableArrayBuilder              ));
        NoNullRet(0,     Coalesce(EmptyImmutableList                      ));
        NoNullRet(0,     Coalesce(EmptyImmutableListBuilder               ));
        NoNullRet(0,     Coalesce(EmptyImmutableHashSet                   ));
        NoNullRet(0,     Coalesce(EmptyImmutableHashSetBuilder            ));
        NoNullRet(0,     Coalesce(EmptyImmutableStack                     ));
        NoNullRet(0,     Coalesce(EmptyImmutableQueue                     ));
        NoNullRet(entry, Coalesce(EmptyImmutableDict                      ));
        NoNullRet(entry, Coalesce(EmptyImmutableDictBuilder               ));
        NoNullRet(0,     Coalesce(EmptyImmutableSortedSet                 ));
        NoNullRet(0,     Coalesce(EmptyImmutableSortedSetBuilder          ));
        NoNullRet(entry, Coalesce(EmptyImmutableSortedDict                ));
        NoNullRet(entry, Coalesce(EmptyImmutableSortedDictBuilder         ));
        NoNullRet(0,     Coalesce(EmptyIReadOnlyColl                      ));
        NoNullRet(0,     Coalesce(EmptyIReadOnlyList                      ));
        NoNullRet(entry, Coalesce(EmptyIReadOnlyDict                      ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyColl                       ));
        NoNullRet(entry, Coalesce(EmptyReadOnlyDict                       ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyDictKeys                   ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyDictVals                   ));
        NoNullRet(0,     Coalesce(EmptyConcurrentBag                      ));
        NoNullRet(0,     Coalesce(EmptyConcurrentQueue                    ));
        NoNullRet(0,     Coalesce(EmptyConcurrentStack                    ));
        NoNullRet(entry, Coalesce(EmptyConcurrentDict                     ));
        NoNullRet(0,     Coalesce(EmptyBlockingColl                       ));
        NoNullRet(0,     Coalesce(EmptyIProducerConsumerColl              ));
        NoNullRet(entry, Coalesce(EmptySortedDict                         ));
        NoNullRet(0,     Coalesce(EmptySortedDictKeys                     ));
        NoNullRet(0,     Coalesce(EmptySortedDictVals                     ));
        NoNullRet(0,     Coalesce(EmptyColl                               ));
        NoNullRet(0,     Coalesce(EmptyKeyedColl                          ));
        NoNullRet(0,     Coalesce(EmptyObservableColl                     ));
        NoNullRet(0,     Coalesce(EmptyReadOnlyObservableColl             ));
        #if NET9_0_OR_GREATER                                                                                                                           
        NoNullRet(entry, Coalesce(EmptyOrderedDict                        ));
        NoNullRet(0,     Coalesce(EmptyOrderedDictKeys                    ));
        NoNullRet(0,     Coalesce(EmptyOrderedDictVals                    ));
        NoNullRet(0,     Coalesce(EmptyIReadOnlySet                       ));
        NoNullRet(0,     Coalesce(EmptyReadOnlySet                        ));
        #endif                                                                                                      
        #if NET8_0_OR_GREATER                                                                                 
        NoNullRet(0,     Coalesce(EmptyFrozenSet                          ));          
        NoNullRet(entry, Coalesce(EmptyFrozenDictionary                   ));          
        #endif                                                                                        
    }                                                                     
                                                                          
    [TestMethod]                                                          
    public void Coalesce_Collections_Static_NullableEmpty()               
    {                                                                     
        KeyValuePair<int, int> entry = default;                           
        NoNullRet(0,     Coalesce(NullableEmptyArray                      ));
        NoNullRet(0,     Coalesce(NullableEmptyIList                      ));
        NoNullRet(0,     Coalesce(NullableEmptyISet                       ));
        NoNullRet(entry, Coalesce(NullableEmptyIDict                      ));
        NoNullRet(0,     Coalesce(NullableEmptyIColl                      ));
        NoNullRet(0,     Coalesce(NullableEmptyIEnumerable                ));
        NoNullRet(0,     Coalesce(NullableEmptyList                       ));
        NoNullRet(0,     Coalesce(NullableEmptyHashSet                    ));
        NoNullRet(0,     Coalesce(NullableEmptyStack                      ));
        NoNullRet(0,     Coalesce(NullableEmptyQueue                      ));
        NoNullRet(0,     Coalesce(NullableEmptyLinkedList                 ));
        NoNullRet(entry, Coalesce(NullableEmptySortedList                 ));
        NoNullRet(0,     Coalesce(NullableEmptySortedSet                  ));
        NoNullRet(entry, Coalesce(NullableEmptyDict                       ));
        NoNullRet(0,     Coalesce(NullableEmptyDictKeyColl                ));
        NoNullRet(0,     Coalesce(NullableEmptyDictValColl                ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableList             ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableSet              ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableStack            ));
        NoNullRet(0,     Coalesce(NullableEmptyIImmutableQueue            ));
        NoNullRet(entry, Coalesce(NullableEmptyIImmutableDict             ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableArrayBuilder      ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableList              ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableListBuilder       ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableHashSet           ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableHashSetBuilder    ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableStack             ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableQueue             ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableDict              ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableDictBuilder       ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableSortedSet         ));
        NoNullRet(0,     Coalesce(NullableEmptyImmutableSortedSetBuilder  ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableSortedDict        ));
        NoNullRet(entry, Coalesce(NullableEmptyImmutableSortedDictBuilder ));
        NoNullRet(0,     Coalesce(NullableEmptyIReadOnlyColl              ));
        NoNullRet(0,     Coalesce(NullableEmptyIReadOnlyList              ));
        NoNullRet(entry, Coalesce(NullableEmptyIReadOnlyDict              ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyColl               ));
        NoNullRet(entry, Coalesce(NullableEmptyReadOnlyDict               ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyDictKeys           ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyDictVals           ));
        NoNullRet(0,     Coalesce(NullableEmptyConcurrentBag              ));
        NoNullRet(0,     Coalesce(NullableEmptyConcurrentQueue            ));
        NoNullRet(0,     Coalesce(NullableEmptyConcurrentStack            ));
        NoNullRet(entry, Coalesce(NullableEmptyConcurrentDict             ));
        NoNullRet(0,     Coalesce(NullableEmptyBlockingColl               ));
        NoNullRet(0,     Coalesce(NullableEmptyIProducerConsumerColl      ));
        NoNullRet(entry, Coalesce(NullableEmptySortedDict                 ));
        NoNullRet(0,     Coalesce(NullableEmptySortedDictKeys             ));
        NoNullRet(0,     Coalesce(NullableEmptySortedDictVals             ));
        NoNullRet(0,     Coalesce(NullableEmptyColl                       ));
        NoNullRet(0,     Coalesce(NullableEmptyKeyedColl                  ));
        NoNullRet(0,     Coalesce(NullableEmptyObservableColl             ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlyObservableColl     ));
        #if NET9_0_OR_GREATER                                                                                                                   
        NoNullRet(entry, Coalesce(NullableEmptyOrderedDict                ));
        NoNullRet(0,     Coalesce(NullableEmptyOrderedDictKeys            ));
        NoNullRet(0,     Coalesce(NullableEmptyOrderedDictVals            ));
        NoNullRet(0,     Coalesce(NullableEmptyIReadOnlySet               ));
        NoNullRet(0,     Coalesce(NullableEmptyReadOnlySet                ));
        #endif                                                                                             
        #if NET8_0_OR_GREATER                                                                        
        NoNullRet(0,     Coalesce(NullableEmptyFrozenSet                  ));          
        NoNullRet(entry, Coalesce(NullableEmptyFrozenDictionary           ));          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Static_Null()
    {
        KeyValuePair<int, int> entry = default;
        NoNullRet(0,     Coalesce(NullArray                               ));
        NoNullRet(0,     Coalesce(NullIList                               ));
        NoNullRet(0,     Coalesce(NullISet                                ));
        NoNullRet(entry, Coalesce(NullIDict                               ));
        NoNullRet(0,     Coalesce(NullIColl                               ));
        NoNullRet(0,     Coalesce(NullIEnumerable                         ));
        NoNullRet(0,     Coalesce(NullList                                ));
        NoNullRet(0,     Coalesce(NullHashSet                             ));
        NoNullRet(0,     Coalesce(NullStack                               ));
        NoNullRet(0,     Coalesce(NullQueue                               ));
        NoNullRet(0,     Coalesce(NullLinkedList                          ));
        NoNullRet(entry, Coalesce(NullSortedList                          ));
        NoNullRet(0,     Coalesce(NullSortedSet                           ));
        NoNullRet(entry, Coalesce(NullDict                                ));
        NoNullRet(0,     Coalesce(NullDictKeyColl                         ));
        NoNullRet(0,     Coalesce(NullDictValColl                         ));
        NoNullRet(0,     Coalesce(NullIImmutableList                      ));
        NoNullRet(0,     Coalesce(NullIImmutableSet                       ));
        NoNullRet(0,     Coalesce(NullIImmutableStack                     ));
        NoNullRet(0,     Coalesce(NullIImmutableQueue                     ));
        NoNullRet(entry, Coalesce(NullIImmutableDict                      ));
        NoNullRet(0,     Coalesce(NullImmutableArrayBuilder               ));
        NoNullRet(0,     Coalesce(NullImmutableList                       ));
        NoNullRet(0,     Coalesce(NullImmutableListBuilder                ));
        NoNullRet(0,     Coalesce(NullImmutableHashSet                    ));
        NoNullRet(0,     Coalesce(NullImmutableHashSetBuilder             ));
        NoNullRet(0,     Coalesce(NullImmutableStack                      ));
        NoNullRet(0,     Coalesce(NullImmutableQueue                      ));
        NoNullRet(entry, Coalesce(NullImmutableDict                       ));
        NoNullRet(entry, Coalesce(NullImmutableDictBuilder                ));
        NoNullRet(0,     Coalesce(NullImmutableSortedSet                  ));
        NoNullRet(0,     Coalesce(NullImmutableSortedSetBuilder           ));
        NoNullRet(entry, Coalesce(NullImmutableSortedDict                 ));
        NoNullRet(entry, Coalesce(NullImmutableSortedDictBuilder          ));
        NoNullRet(0,     Coalesce(NullIReadOnlyColl                       ));
        NoNullRet(0,     Coalesce(NullIReadOnlyList                       ));
        NoNullRet(entry, Coalesce(NullIReadOnlyDict                       ));
        NoNullRet(0,     Coalesce(NullReadOnlyColl                        ));
        NoNullRet(entry, Coalesce(NullReadOnlyDict                        ));
        NoNullRet(0,     Coalesce(NullReadOnlyDictKeys                    ));
        NoNullRet(0,     Coalesce(NullReadOnlyDictVals                    ));
        NoNullRet(0,     Coalesce(NullConcurrentBag                       ));
        NoNullRet(0,     Coalesce(NullConcurrentQueue                     ));
        NoNullRet(0,     Coalesce(NullConcurrentStack                     ));
        NoNullRet(entry, Coalesce(NullConcurrentDict                      ));
        NoNullRet(0,     Coalesce(NullBlockingColl                        ));
        NoNullRet(0,     Coalesce(NullIProducerConsumerColl               ));
        NoNullRet(entry, Coalesce(NullSortedDict                          ));
        NoNullRet(0,     Coalesce(NullSortedDictKeys                      ));
        NoNullRet(0,     Coalesce(NullSortedDictVals                      ));
        NoNullRet(0,     Coalesce(NullColl                                ));
        NoNullRet(0,     Coalesce(NullKeyedColl                           ));
        NoNullRet(0,     Coalesce(NullObservableColl                      ));
        NoNullRet(0,     Coalesce(NullReadOnlyObservableColl              ));
        #if NET9_0_OR_GREATER                                                                                                                            
        NoNullRet(entry, Coalesce(NullOrderedDict                         ));
        NoNullRet(0,     Coalesce(NullOrderedDictKeys                     ));
        NoNullRet(0,     Coalesce(NullOrderedDictVals                     ));
        NoNullRet(0,     Coalesce(NullIReadOnlySet                        ));
        NoNullRet(0,     Coalesce(NullReadOnlySet                         ));
        #endif                                                                                                       
        #if NET8_0_OR_GREATER                                                                                  
        NoNullRet(0,     Coalesce(NullFrozenSet                           ));          
        NoNullRet(entry, Coalesce(NullFrozenDictionary                    ));          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_Filled()
    {
        var entry = new KeyValuePair<int, int>(1, 1);
        NoNullRet(1,     FilledArray                            .Coalesce());
        NoNullRet(1,     FilledIList                            .Coalesce());
        NoNullRet(1,     FilledISet                             .Coalesce());
        NoNullRet(entry, FilledIDict                            .Coalesce());
        NoNullRet(1,     FilledIColl                            .Coalesce());
        NoNullRet(1,     FilledIEnumerable                      .Coalesce());
        NoNullRet(1,     FilledList                             .Coalesce());
        NoNullRet(1,     FilledHashSet                          .Coalesce());
        NoNullRet(1,     FilledStack                            .Coalesce());
        NoNullRet(1,     FilledQueue                            .Coalesce());
        NoNullRet(1,     FilledLinkedList                       .Coalesce());
        NoNullRet(entry, FilledSortedList                       .Coalesce());
        NoNullRet(1,     FilledSortedSet                        .Coalesce());
        NoNullRet(entry, FilledDict                             .Coalesce());
        NoNullRet(1,     FilledDictKeyColl                      .Coalesce());
        NoNullRet(1,     FilledDictValColl                      .Coalesce());
        NoNullRet(1,     FilledIImmutableList                   .Coalesce());
        NoNullRet(1,     FilledIImmutableSet                    .Coalesce());
        NoNullRet(1,     FilledIImmutableStack                  .Coalesce());
        NoNullRet(1,     FilledIImmutableQueue                  .Coalesce());
        NoNullRet(entry, FilledIImmutableDict                   .Coalesce());
        NoNullRet(1,     FilledImmutableArrayBuilder            .Coalesce());
        NoNullRet(1,     FilledImmutableList                    .Coalesce());
        NoNullRet(1,     FilledImmutableListBuilder             .Coalesce());
        NoNullRet(1,     FilledImmutableHashSet                 .Coalesce());
        NoNullRet(1,     FilledImmutableHashSetBuilder          .Coalesce());
        NoNullRet(1,     FilledImmutableStack                   .Coalesce());
        NoNullRet(1,     FilledImmutableQueue                   .Coalesce());
        NoNullRet(entry, FilledImmutableDict                    .Coalesce());
        NoNullRet(entry, FilledImmutableDictBuilder             .Coalesce());
        NoNullRet(1,     FilledImmutableSortedSet               .Coalesce());
        NoNullRet(1,     FilledImmutableSortedSetBuilder        .Coalesce());
        NoNullRet(entry, FilledImmutableSortedDict              .Coalesce());
        NoNullRet(entry, FilledImmutableSortedDictBuilder       .Coalesce());
        NoNullRet(1,     FilledIReadOnlyColl                    .Coalesce());
        NoNullRet(1,     FilledIReadOnlyList                    .Coalesce());
        NoNullRet(entry, FilledIReadOnlyDict                    .Coalesce());
        NoNullRet(1,     FilledReadOnlyColl                     .Coalesce());
        NoNullRet(entry, FilledReadOnlyDict                     .Coalesce());
        NoNullRet(1,     FilledReadOnlyDictKeys                 .Coalesce());
        NoNullRet(1,     FilledReadOnlyDictVals                 .Coalesce());
        NoNullRet(1,     FilledConcurrentBag                    .Coalesce());
        NoNullRet(1,     FilledConcurrentQueue                  .Coalesce());
        NoNullRet(1,     FilledConcurrentStack                  .Coalesce());
        NoNullRet(entry, FilledConcurrentDict                   .Coalesce());
        NoNullRet(1,     FilledBlockingColl                     .Coalesce());
        NoNullRet(1,     FilledIProducerConsumerColl            .Coalesce());
        NoNullRet(entry, FilledSortedDict                       .Coalesce());
        NoNullRet(1,     FilledSortedDictKeys                   .Coalesce());
        NoNullRet(1,     FilledSortedDictVals                   .Coalesce());
        NoNullRet(1,     FilledColl                             .Coalesce());
        NoNullRet(1,     FilledKeyedColl                        .Coalesce());
        NoNullRet(1,     FilledObservableColl                   .Coalesce());
        NoNullRet(1,     FilledReadOnlyObservableColl           .Coalesce());
        #if NET9_0_OR_GREATER                                                                                                                         
        NoNullRet(entry, FilledOrderedDict                      .Coalesce());
        NoNullRet(1,     FilledOrderedDictKeys                  .Coalesce());
        NoNullRet(1,     FilledOrderedDictVals                  .Coalesce());
        NoNullRet(1,     FilledIReadOnlySet                     .Coalesce());
        NoNullRet(1,     FilledReadOnlySet                      .Coalesce());
        #endif                                                                                                    
        #if NET8_0_OR_GREATER                                                                               
        NoNullRet(1,     FilledFrozenSet                        .Coalesce());          
        NoNullRet(entry, FilledFrozenDictionary                 .Coalesce());          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_NullyFilled()
    {
        var entry = new KeyValuePair<int, int>(1, 1);
        NoNullRet(1,     NullyFilledArray                       .Coalesce());
        NoNullRet(1,     NullyFilledIList                       .Coalesce());
        NoNullRet(1,     NullyFilledISet                        .Coalesce());
        NoNullRet(entry, NullyFilledIDict                       .Coalesce());
        NoNullRet(1,     NullyFilledIColl                       .Coalesce());
        NoNullRet(1,     NullyFilledIEnumerable                 .Coalesce());
        NoNullRet(1,     NullyFilledList                        .Coalesce());
        NoNullRet(1,     NullyFilledHashSet                     .Coalesce());
        NoNullRet(1,     NullyFilledStack                       .Coalesce());
        NoNullRet(1,     NullyFilledQueue                       .Coalesce());
        NoNullRet(1,     NullyFilledLinkedList                  .Coalesce());
        NoNullRet(entry, NullyFilledSortedList                  .Coalesce());
        NoNullRet(1,     NullyFilledSortedSet                   .Coalesce());
        NoNullRet(entry, NullyFilledDict                        .Coalesce());
        NoNullRet(1,     NullyFilledDictKeyColl                 .Coalesce());
        NoNullRet(1,     NullyFilledDictValColl                 .Coalesce());
        NoNullRet(1,     NullyFilledIImmutableList              .Coalesce());
        NoNullRet(1,     NullyFilledIImmutableSet               .Coalesce());
        NoNullRet(1,     NullyFilledIImmutableStack             .Coalesce());
        NoNullRet(1,     NullyFilledIImmutableQueue             .Coalesce());
        NoNullRet(entry, NullyFilledIImmutableDict              .Coalesce());
        NoNullRet(1,     NullyFilledImmutableArrayBuilder       .Coalesce());
        NoNullRet(1,     NullyFilledImmutableList               .Coalesce());
        NoNullRet(1,     NullyFilledImmutableListBuilder        .Coalesce());
        NoNullRet(1,     NullyFilledImmutableHashSet            .Coalesce());
        NoNullRet(1,     NullyFilledImmutableHashSetBuilder     .Coalesce());
        NoNullRet(1,     NullyFilledImmutableStack              .Coalesce());
        NoNullRet(1,     NullyFilledImmutableQueue              .Coalesce());
        NoNullRet(entry, NullyFilledImmutableDict               .Coalesce());
        NoNullRet(entry, NullyFilledImmutableDictBuilder        .Coalesce());
        NoNullRet(1,     NullyFilledImmutableSortedSet          .Coalesce());
        NoNullRet(1,     NullyFilledImmutableSortedSetBuilder   .Coalesce());
        NoNullRet(entry, NullyFilledImmutableSortedDict         .Coalesce());
        NoNullRet(entry, NullyFilledImmutableSortedDictBuilder  .Coalesce());
        NoNullRet(1,     NullyFilledIReadOnlyColl               .Coalesce());
        NoNullRet(1,     NullyFilledIReadOnlyList               .Coalesce());
        NoNullRet(entry, NullyFilledIReadOnlyDict               .Coalesce());
        NoNullRet(1,     NullyFilledReadOnlyColl                .Coalesce());
        NoNullRet(entry, NullyFilledReadOnlyDict                .Coalesce());
        NoNullRet(1,     NullyFilledReadOnlyDictKeys            .Coalesce());
        NoNullRet(1,     NullyFilledReadOnlyDictVals            .Coalesce());
        NoNullRet(1,     NullyFilledConcurrentBag               .Coalesce());
        NoNullRet(1,     NullyFilledConcurrentQueue             .Coalesce());
        NoNullRet(1,     NullyFilledConcurrentStack             .Coalesce());
        NoNullRet(entry, NullyFilledConcurrentDict              .Coalesce());
        NoNullRet(1,     NullyFilledBlockingColl                .Coalesce());
        NoNullRet(1,     NullyFilledIProducerConsumerColl       .Coalesce());
        NoNullRet(entry, NullyFilledSortedDict                  .Coalesce());
        NoNullRet(1,     NullyFilledSortedDictKeys              .Coalesce());
        NoNullRet(1,     NullyFilledSortedDictVals              .Coalesce());
        NoNullRet(1,     NullyFilledColl                        .Coalesce());
        NoNullRet(1,     NullyFilledKeyedColl                   .Coalesce());
        NoNullRet(1,     NullyFilledObservableColl              .Coalesce());
        NoNullRet(1,     NullyFilledReadOnlyObservableColl      .Coalesce());
        #if NET9_0_OR_GREATER                                                                                                                    
        NoNullRet(entry, NullyFilledOrderedDict                 .Coalesce());
        NoNullRet(1,     NullyFilledOrderedDictKeys             .Coalesce());
        NoNullRet(1,     NullyFilledOrderedDictVals             .Coalesce());
        NoNullRet(1,     NullyFilledIReadOnlySet                .Coalesce());
        NoNullRet(1,     NullyFilledReadOnlySet                 .Coalesce());
        #endif                                                                                               
        #if NET8_0_OR_GREATER                                                                          
        NoNullRet(1,     NullyFilledFrozenSet                   .Coalesce());          
        NoNullRet(entry, NullyFilledFrozenDictionary            .Coalesce());          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_Empty()
    {
        KeyValuePair<int, int> entry = default;
        NoNullRet(0,     EmptyArray                             .Coalesce());
        NoNullRet(0,     EmptyIList                             .Coalesce());
        NoNullRet(0,     EmptyISet                              .Coalesce());
        NoNullRet(entry, EmptyIDict                             .Coalesce());
        NoNullRet(0,     EmptyIColl                             .Coalesce());
        NoNullRet(0,     EmptyIEnumerable                       .Coalesce());
        NoNullRet(0,     EmptyList                              .Coalesce());
        NoNullRet(0,     EmptyHashSet                           .Coalesce());
        NoNullRet(0,     EmptyStack                             .Coalesce());
        NoNullRet(0,     EmptyQueue                             .Coalesce());
        NoNullRet(0,     EmptyLinkedList                        .Coalesce());
        NoNullRet(entry, EmptySortedList                        .Coalesce());
        NoNullRet(0,     EmptySortedSet                         .Coalesce());
        NoNullRet(entry, EmptyDict                              .Coalesce());
        NoNullRet(0,     EmptyDictKeyColl                       .Coalesce());
        NoNullRet(0,     EmptyDictValColl                       .Coalesce());
        NoNullRet(0,     EmptyIImmutableList                    .Coalesce());
        NoNullRet(0,     EmptyIImmutableSet                     .Coalesce());
        NoNullRet(0,     EmptyIImmutableStack                   .Coalesce());
        NoNullRet(0,     EmptyIImmutableQueue                   .Coalesce());
        NoNullRet(entry, EmptyIImmutableDict                    .Coalesce());
        NoNullRet(0,     EmptyImmutableArrayBuilder             .Coalesce());
        NoNullRet(0,     EmptyImmutableList                     .Coalesce());
        NoNullRet(0,     EmptyImmutableListBuilder              .Coalesce());
        NoNullRet(0,     EmptyImmutableHashSet                  .Coalesce());
        NoNullRet(0,     EmptyImmutableHashSetBuilder           .Coalesce());
        NoNullRet(0,     EmptyImmutableStack                    .Coalesce());
        NoNullRet(0,     EmptyImmutableQueue                    .Coalesce());
        NoNullRet(entry, EmptyImmutableDict                     .Coalesce());
        NoNullRet(entry, EmptyImmutableDictBuilder              .Coalesce());
        NoNullRet(0,     EmptyImmutableSortedSet                .Coalesce());
        NoNullRet(0,     EmptyImmutableSortedSetBuilder         .Coalesce());
        NoNullRet(entry, EmptyImmutableSortedDict               .Coalesce());
        NoNullRet(entry, EmptyImmutableSortedDictBuilder        .Coalesce());
        NoNullRet(0,     EmptyIReadOnlyColl                     .Coalesce());
        NoNullRet(0,     EmptyIReadOnlyList                     .Coalesce());
        NoNullRet(entry, EmptyIReadOnlyDict                     .Coalesce());
        NoNullRet(0,     EmptyReadOnlyColl                      .Coalesce());
        NoNullRet(entry, EmptyReadOnlyDict                      .Coalesce());
        NoNullRet(0,     EmptyReadOnlyDictKeys                  .Coalesce());
        NoNullRet(0,     EmptyReadOnlyDictVals                  .Coalesce());
        NoNullRet(0,     EmptyConcurrentBag                     .Coalesce());
        NoNullRet(0,     EmptyConcurrentQueue                   .Coalesce());
        NoNullRet(0,     EmptyConcurrentStack                   .Coalesce());
        NoNullRet(entry, EmptyConcurrentDict                    .Coalesce());
        NoNullRet(0,     EmptyBlockingColl                      .Coalesce());
        NoNullRet(0,     EmptyIProducerConsumerColl             .Coalesce());
        NoNullRet(entry, EmptySortedDict                        .Coalesce());
        NoNullRet(0,     EmptySortedDictKeys                    .Coalesce());
        NoNullRet(0,     EmptySortedDictVals                    .Coalesce());
        NoNullRet(0,     EmptyColl                              .Coalesce());
        NoNullRet(0,     EmptyKeyedColl                         .Coalesce());
        NoNullRet(0,     EmptyObservableColl                    .Coalesce());
        NoNullRet(0,     EmptyReadOnlyObservableColl            .Coalesce());
        #if NET9_0_OR_GREATER                                                                                                                          
        NoNullRet(entry, EmptyOrderedDict                       .Coalesce());
        NoNullRet(0,     EmptyOrderedDictKeys                   .Coalesce());
        NoNullRet(0,     EmptyOrderedDictVals                   .Coalesce());
        NoNullRet(0,     EmptyIReadOnlySet                      .Coalesce());
        NoNullRet(0,     EmptyReadOnlySet                       .Coalesce());
        #endif                                                                                                     
        #if NET8_0_OR_GREATER                                                                                
        NoNullRet(0,     EmptyFrozenSet                         .Coalesce());          
        NoNullRet(entry, EmptyFrozenDictionary                  .Coalesce());          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_NullableEmpty()
    {
        KeyValuePair<int, int> entry = default;
        NoNullRet(0,     NullableEmptyArray                     .Coalesce());
        NoNullRet(0,     NullableEmptyIList                     .Coalesce());
        NoNullRet(0,     NullableEmptyISet                      .Coalesce());
        NoNullRet(entry, NullableEmptyIDict                     .Coalesce());
        NoNullRet(0,     NullableEmptyIColl                     .Coalesce());
        NoNullRet(0,     NullableEmptyIEnumerable               .Coalesce());
        NoNullRet(0,     NullableEmptyList                      .Coalesce());
        NoNullRet(0,     NullableEmptyHashSet                   .Coalesce());
        NoNullRet(0,     NullableEmptyStack                     .Coalesce());
        NoNullRet(0,     NullableEmptyQueue                     .Coalesce());
        NoNullRet(0,     NullableEmptyLinkedList                .Coalesce());
        NoNullRet(entry, NullableEmptySortedList                .Coalesce());
        NoNullRet(0,     NullableEmptySortedSet                 .Coalesce());
        NoNullRet(entry, NullableEmptyDict                      .Coalesce());
        NoNullRet(0,     NullableEmptyDictKeyColl               .Coalesce());
        NoNullRet(0,     NullableEmptyDictValColl               .Coalesce());
        NoNullRet(0,     NullableEmptyIImmutableList            .Coalesce());
        NoNullRet(0,     NullableEmptyIImmutableSet             .Coalesce());
        NoNullRet(0,     NullableEmptyIImmutableStack           .Coalesce());
        NoNullRet(0,     NullableEmptyIImmutableQueue           .Coalesce());
        NoNullRet(entry, NullableEmptyIImmutableDict            .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableArrayBuilder     .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableList             .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableListBuilder      .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableHashSet          .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableHashSetBuilder   .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableStack            .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableQueue            .Coalesce());
        NoNullRet(entry, NullableEmptyImmutableDict             .Coalesce());
        NoNullRet(entry, NullableEmptyImmutableDictBuilder      .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableSortedSet        .Coalesce());
        NoNullRet(0,     NullableEmptyImmutableSortedSetBuilder .Coalesce());
        NoNullRet(entry, NullableEmptyImmutableSortedDict       .Coalesce());
        NoNullRet(entry, NullableEmptyImmutableSortedDictBuilder.Coalesce());
        NoNullRet(0,     NullableEmptyIReadOnlyColl             .Coalesce());
        NoNullRet(0,     NullableEmptyIReadOnlyList             .Coalesce());
        NoNullRet(entry, NullableEmptyIReadOnlyDict             .Coalesce());
        NoNullRet(0,     NullableEmptyReadOnlyColl              .Coalesce());
        NoNullRet(entry, NullableEmptyReadOnlyDict              .Coalesce());
        NoNullRet(0,     NullableEmptyReadOnlyDictKeys          .Coalesce());
        NoNullRet(0,     NullableEmptyReadOnlyDictVals          .Coalesce());
        NoNullRet(0,     NullableEmptyConcurrentBag             .Coalesce());
        NoNullRet(0,     NullableEmptyConcurrentQueue           .Coalesce());
        NoNullRet(0,     NullableEmptyConcurrentStack           .Coalesce());
        NoNullRet(entry, NullableEmptyConcurrentDict            .Coalesce());
        NoNullRet(0,     NullableEmptyBlockingColl              .Coalesce());
        NoNullRet(0,     NullableEmptyIProducerConsumerColl     .Coalesce());
        NoNullRet(entry, NullableEmptySortedDict                .Coalesce());
        NoNullRet(0,     NullableEmptySortedDictKeys            .Coalesce());
        NoNullRet(0,     NullableEmptySortedDictVals            .Coalesce());
        NoNullRet(0,     NullableEmptyColl                      .Coalesce());
        NoNullRet(0,     NullableEmptyKeyedColl                 .Coalesce());
        NoNullRet(0,     NullableEmptyObservableColl            .Coalesce());
        NoNullRet(0,     NullableEmptyReadOnlyObservableColl    .Coalesce());
        #if NET9_0_OR_GREATER                                                                                                                  
        NoNullRet(entry, NullableEmptyOrderedDict               .Coalesce());
        NoNullRet(0,     NullableEmptyOrderedDictKeys           .Coalesce());
        NoNullRet(0,     NullableEmptyOrderedDictVals           .Coalesce());
        NoNullRet(0,     NullableEmptyIReadOnlySet              .Coalesce());
        NoNullRet(0,     NullableEmptyReadOnlySet               .Coalesce());
        #endif                                                                                             
        #if NET8_0_OR_GREATER                                                                        
        NoNullRet(0,     NullableEmptyFrozenSet                 .Coalesce());          
        NoNullRet(entry, NullableEmptyFrozenDictionary          .Coalesce());          
        #endif                                                                                       
    }

    [TestMethod]
    public void Coalesce_Collections_Extensions_Null()
    {
        KeyValuePair<int, int> entry = default;
        NoNullRet(0,     NullArray                              .Coalesce());
        NoNullRet(0,     NullIList                              .Coalesce());
        NoNullRet(0,     NullISet                               .Coalesce());
        NoNullRet(entry, NullIDict                              .Coalesce());
        NoNullRet(0,     NullIColl                              .Coalesce());
        NoNullRet(0,     NullIEnumerable                        .Coalesce());
        NoNullRet(0,     NullList                               .Coalesce());
        NoNullRet(0,     NullHashSet                            .Coalesce());
        NoNullRet(0,     NullStack                              .Coalesce());
        NoNullRet(0,     NullQueue                              .Coalesce());
        NoNullRet(0,     NullLinkedList                         .Coalesce());
        NoNullRet(entry, NullSortedList                         .Coalesce());
        NoNullRet(0,     NullSortedSet                          .Coalesce());
        NoNullRet(entry, NullDict                               .Coalesce());
        NoNullRet(0,     NullDictKeyColl                        .Coalesce());
        NoNullRet(0,     NullDictValColl                        .Coalesce());
        NoNullRet(0,     NullIImmutableList                     .Coalesce());
        NoNullRet(0,     NullIImmutableSet                      .Coalesce());
        NoNullRet(0,     NullIImmutableStack                    .Coalesce());
        NoNullRet(0,     NullIImmutableQueue                    .Coalesce());
        NoNullRet(entry, NullIImmutableDict                     .Coalesce());
        NoNullRet(0,     NullImmutableArrayBuilder              .Coalesce());
        NoNullRet(0,     NullImmutableList                      .Coalesce());
        NoNullRet(0,     NullImmutableListBuilder               .Coalesce());
        NoNullRet(0,     NullImmutableHashSet                   .Coalesce());
        NoNullRet(0,     NullImmutableHashSetBuilder            .Coalesce());
        NoNullRet(0,     NullImmutableStack                     .Coalesce());
        NoNullRet(0,     NullImmutableQueue                     .Coalesce());
        NoNullRet(entry, NullImmutableDict                      .Coalesce());
        NoNullRet(entry, NullImmutableDictBuilder               .Coalesce());
        NoNullRet(0,     NullImmutableSortedSet                 .Coalesce());
        NoNullRet(0,     NullImmutableSortedSetBuilder          .Coalesce());
        NoNullRet(entry, NullImmutableSortedDict                .Coalesce());
        NoNullRet(entry, NullImmutableSortedDictBuilder         .Coalesce());
        NoNullRet(0,     NullIReadOnlyColl                      .Coalesce());
        NoNullRet(0,     NullIReadOnlyList                      .Coalesce());
        NoNullRet(entry, NullIReadOnlyDict                      .Coalesce());
        NoNullRet(0,     NullReadOnlyColl                       .Coalesce());
        NoNullRet(entry, NullReadOnlyDict                       .Coalesce());
        NoNullRet(0,     NullReadOnlyDictKeys                   .Coalesce());
        NoNullRet(0,     NullReadOnlyDictVals                   .Coalesce());
        NoNullRet(0,     NullConcurrentBag                      .Coalesce());
        NoNullRet(0,     NullConcurrentQueue                    .Coalesce());
        NoNullRet(0,     NullConcurrentStack                    .Coalesce());
        NoNullRet(entry, NullConcurrentDict                     .Coalesce());
        NoNullRet(0,     NullBlockingColl                       .Coalesce());
        NoNullRet(0,     NullIProducerConsumerColl              .Coalesce());
        NoNullRet(entry, NullSortedDict                         .Coalesce());
        NoNullRet(0,     NullSortedDictKeys                     .Coalesce());
        NoNullRet(0,     NullSortedDictVals                     .Coalesce());
        NoNullRet(0,     NullColl                               .Coalesce());
        NoNullRet(0,     NullKeyedColl                          .Coalesce());
        NoNullRet(0,     NullObservableColl                     .Coalesce());
        NoNullRet(0,     NullReadOnlyObservableColl             .Coalesce());
        #if NET9_0_OR_GREATER                                                                                                                           
        NoNullRet(entry, NullOrderedDict                        .Coalesce());
        NoNullRet(0,     NullOrderedDictKeys                    .Coalesce());
        NoNullRet(0,     NullOrderedDictVals                    .Coalesce());
        NoNullRet(0,     NullIReadOnlySet                       .Coalesce());
        NoNullRet(0,     NullReadOnlySet                        .Coalesce());
        #endif                                                                                                      
        #if NET8_0_OR_GREATER                                                                                 
        NoNullRet(0,     NullFrozenSet                          .Coalesce());          
        NoNullRet(entry, NullFrozenDictionary                   .Coalesce());          
        #endif                                                                                       
    }
}
