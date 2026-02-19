// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Collections.Tests;

[TestClass]
public class FilledIn_Collection_NotNullWhen : TestBase
{

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_FilledIn_Collection_NotNullWhen_Static()
    {
        { var coll = NullyFilledArray                        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIList                        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledISet                         ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIDict                        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIColl                        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIEnumerable                  ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledILookup                      ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledList                         ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledHashSet                      ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledStack                        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledQueue                        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledLinkedList                   ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedList                   ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedSet                    ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledDict                         ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledDictKeyColl                  ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledDictValColl                  ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableList               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableSet                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableStack              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableQueue              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableDict               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableArray               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableArrayBuilder        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableList                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableListBuilder         ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSet             ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSetBuilder      ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableStack               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableQueue               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableDict                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableDictBuilder         ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSet           ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSetBuilder    ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDict          ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDictBuilder   ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyColl                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyList                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyDict                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyColl                 ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDict                 ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictKeys             ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictVals             ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledArraySegment                 ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledMemory                       ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyMemory               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlySequence             ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentBag                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentQueue              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentStack              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentDict               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledBlockingColl                 ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIProducerConsumerColl        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDict                   ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDictKeys               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDictVals               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledColl                         ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledKeyedColl                    ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledObservableColl               ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyObservableColl       ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledArrayList                    ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledBitArray                     ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledCollBase                     ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledDictBase                     ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledHashtable                    ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledQueueNonGeneric              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyCollBase             ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledSortedListNonGeneric         ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledStackNonGeneric              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledHybridDict                   ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledListDict                     ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBase           ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBaseKeys       ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledNameValueColl                ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictNonGeneric        ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledStringColl                   ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledStringDict                   ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIOrderedDict                 ; if (FilledIn(coll)) coll.ToString(); }
        #if NET9_0_OR_GREATER                                                                        
        { var coll = NullyFilledOrderedDict                  ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictKeys              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictVals              ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlySet                 ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlySet                  ; if (FilledIn(coll)) coll.ToString(); }
        #endif
        { var coll = NullyFilledFrozenSet                    ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledFrozenDictionary             ; if (FilledIn(coll)) coll.ToString(); }
        #if NET6_0_OR_GREATER                                                                             
        { var coll = NullyFilledPrioQueue                    ; if (FilledIn(coll)) coll.ToString(); }
        { var coll = NullyFilledPrioQueueUnorderedColl       ; if (FilledIn(coll)) coll.ToString(); }
        #endif
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod] 
    public void Test_FilledIn_Collection_NotNullWhen_Extensions()
    {
        { var coll = NullyFilledArray                        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIList                        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledISet                         ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIDict                        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIColl                        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIEnumerable                  ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledILookup                      ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledList                         ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledHashSet                      ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledStack                        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledQueue                        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledLinkedList                   ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledSortedList                   ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledSortedSet                    ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledDict                         ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledDictKeyColl                  ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledDictValColl                  ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIImmutableList               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIImmutableSet                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIImmutableStack              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIImmutableQueue              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIImmutableDict               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableArray               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableArrayBuilder        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableList                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableListBuilder         ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSet             ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSetBuilder      ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableStack               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableQueue               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableDict                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableDictBuilder         ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSet           ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSetBuilder    ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDict          ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDictBuilder   ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyColl                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyList                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyDict                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyColl                 ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDict                 ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictKeys             ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictVals             ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledArraySegment                 ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledMemory                       ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyMemory               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlySequence             ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledConcurrentBag                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledConcurrentQueue              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledConcurrentStack              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledConcurrentDict               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledBlockingColl                 ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIProducerConsumerColl        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledSortedDict                   ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledSortedDictKeys               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledSortedDictVals               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledColl                         ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledKeyedColl                    ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledObservableColl               ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyObservableColl       ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledArrayList                    ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledBitArray                     ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledCollBase                     ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledDictBase                     ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledHashtable                    ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledQueueNonGeneric              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlyCollBase             ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledSortedListNonGeneric         ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledStackNonGeneric              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledHybridDict                   ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledListDict                     ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBase           ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBaseKeys       ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledNameValueColl                ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledOrderedDictNonGeneric        ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledStringColl                   ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledStringDict                   ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIOrderedDict                 ; if (coll.FilledIn()) coll.ToString(); }
        #if NET9_0_OR_GREATER                                                                        
        { var coll = NullyFilledOrderedDict                  ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledOrderedDictKeys              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledOrderedDictVals              ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledIReadOnlySet                 ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledReadOnlySet                  ; if (coll.FilledIn()) coll.ToString(); }
        #endif
        { var coll = NullyFilledFrozenSet                    ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledFrozenDictionary             ; if (coll.FilledIn()) coll.ToString(); }
        #if NET6_0_OR_GREATER                                                                             
        { var coll = NullyFilledPrioQueue                    ; if (coll.FilledIn()) coll.ToString(); }
        { var coll = NullyFilledPrioQueueUnorderedColl       ; if (coll.FilledIn()) coll.ToString(); }
        #endif                                                                                       
    }
}