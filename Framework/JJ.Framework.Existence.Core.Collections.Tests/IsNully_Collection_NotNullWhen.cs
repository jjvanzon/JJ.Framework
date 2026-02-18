// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Collections.Tests;

[TestClass]
public class IsNully_Collection_NotNullWhen : TestBase
{
    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_IsNully_Collection_NotNullWhen_Static()
    {
        { var coll = NullyFilledArray                        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIList                        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledISet                         ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIDict                        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIColl                        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIEnumerable                  ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledILookup                      ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledList                         ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledHashSet                      ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledStack                        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledQueue                        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledLinkedList                   ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedList                   ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedSet                    ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledDict                         ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledDictKeyColl                  ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledDictValColl                  ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableList               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableSet                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableStack              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableQueue              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableDict               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableArray               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableArrayBuilder        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableList                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableListBuilder         ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSet             ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSetBuilder      ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableStack               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableQueue               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableDict                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableDictBuilder         ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSet           ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSetBuilder    ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDict          ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDictBuilder   ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyColl                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyList                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyDict                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyColl                 ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDict                 ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictKeys             ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictVals             ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledArraySegment                 ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledMemory                       ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyMemory               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlySequence             ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentBag                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentQueue              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentStack              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentDict               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledBlockingColl                 ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIProducerConsumerColl        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDict                   ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDictKeys               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDictVals               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledColl                         ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledKeyedColl                    ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledObservableColl               ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyObservableColl       ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledArrayList                    ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledBitArray                     ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledCollBase                     ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledDictBase                     ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledHashtable                    ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledQueueNonGeneric              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyCollBase             ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedListNonGeneric         ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledStackNonGeneric              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledHybridDict                   ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledListDict                     ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBase           ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBaseKeys       ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledNameValueColl                ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictNonGeneric        ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledStringColl                   ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledStringDict                   ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIOrderedDict                 ; if (!IsNully(coll)) coll.ToString(); }
        #if NET9_0_OR_GREATER                                                                        
        { var coll = NullyFilledOrderedDict                  ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictKeys              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictVals              ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlySet                 ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlySet                  ; if (!IsNully(coll)) coll.ToString(); }
        #endif
        { var coll = NullyFilledFrozenSet                    ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledFrozenDictionary             ; if (!IsNully(coll)) coll.ToString(); }
        #if NET6_0_OR_GREATER                                                                             
        { var coll = NullyFilledPrioQueue                    ; if (!IsNully(coll)) coll.ToString(); }
        { var coll = NullyFilledPrioQueueUnorderedColl       ; if (!IsNully(coll)) coll.ToString(); }
        #endif                                                                                       
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_IsNully_Collection_NotNullWhen_Extensions()
    {
        { var coll = NullyFilledArray                        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIList                        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledISet                         ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIDict                        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIColl                        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIEnumerable                  ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledILookup                      ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledList                         ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledHashSet                      ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledStack                        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledQueue                        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledLinkedList                   ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledSortedList                   ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledSortedSet                    ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledDict                         ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledDictKeyColl                  ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledDictValColl                  ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIImmutableList               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIImmutableSet                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIImmutableStack              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIImmutableQueue              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIImmutableDict               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableArray               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableArrayBuilder        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableList                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableListBuilder         ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSet             ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSetBuilder      ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableStack               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableQueue               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableDict                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableDictBuilder         ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSet           ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSetBuilder    ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDict          ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDictBuilder   ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyColl                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyList                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyDict                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyColl                 ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDict                 ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictKeys             ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictVals             ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledArraySegment                 ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledMemory                       ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyMemory               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlySequence             ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledConcurrentBag                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledConcurrentQueue              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledConcurrentStack              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledConcurrentDict               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledBlockingColl                 ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIProducerConsumerColl        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledSortedDict                   ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledSortedDictKeys               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledSortedDictVals               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledColl                         ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledKeyedColl                    ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledObservableColl               ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyObservableColl       ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledArrayList                    ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledBitArray                     ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledCollBase                     ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledDictBase                     ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledHashtable                    ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledQueueNonGeneric              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyCollBase             ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledSortedListNonGeneric         ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledStackNonGeneric              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledHybridDict                   ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledListDict                     ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBase           ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBaseKeys       ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledNameValueColl                ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledOrderedDictNonGeneric        ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledStringColl                   ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledStringDict                   ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIOrderedDict                 ; if (!coll.IsNully()) coll.ToString(); }
        #if NET9_0_OR_GREATER                                                                        
        { var coll = NullyFilledOrderedDict                  ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledOrderedDictKeys              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledOrderedDictVals              ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlySet                 ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledReadOnlySet                  ; if (!coll.IsNully()) coll.ToString(); }
        #endif
        { var coll = NullyFilledFrozenSet                    ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledFrozenDictionary             ; if (!coll.IsNully()) coll.ToString(); }
        #if NET6_0_OR_GREATER                                                                             
        { var coll = NullyFilledPrioQueue                    ; if (!coll.IsNully()) coll.ToString(); }
        { var coll = NullyFilledPrioQueueUnorderedColl       ; if (!coll.IsNully()) coll.ToString(); }
        #endif                                                                                       
    }
}