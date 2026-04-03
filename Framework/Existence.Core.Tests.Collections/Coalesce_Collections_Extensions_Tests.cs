namespace JJ.Framework.Existence.Core.Collections.Tests;

[TestClass]
public class Coalesce_Collections_Extensions_Tests : TestBase
{
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
        NoNullRet(1,     FilledFrozenSet                        .Coalesce());          
        NoNullRet(entry, FilledFrozenDictionary                 .Coalesce());          
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
        NoNullRet(1,     NullyFilledFrozenSet                   .Coalesce());          
        NoNullRet(entry, NullyFilledFrozenDictionary            .Coalesce());          
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
        NoNullRet(0,     EmptyFrozenSet                         .Coalesce());          
        NoNullRet(entry, EmptyFrozenDictionary                  .Coalesce());          
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
        NoNullRet(0,     NullableEmptyFrozenSet                 .Coalesce());          
        NoNullRet(entry, NullableEmptyFrozenDictionary          .Coalesce());          
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
        NoNullRet(0,     NullFrozenSet                          .Coalesce());          
        NoNullRet(entry, NullFrozenDictionary                   .Coalesce());          
    }
}