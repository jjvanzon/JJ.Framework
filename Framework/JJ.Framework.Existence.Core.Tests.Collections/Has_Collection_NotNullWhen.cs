// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Collections.Tests;

[TestClass]
public class Has_Collection_NotNullWhen : TestBase
{
    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_Has_Collection_NotNullWhen()
    {
        { var coll = NullyFilledArray                        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIList                        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledISet                         ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIDict                        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIColl                        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIEnumerable                  ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledILookup                      ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledList                         ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledHashSet                      ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledStack                        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledQueue                        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledLinkedList                   ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledSortedList                   ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledSortedSet                    ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledDict                         ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledDictKeyColl                  ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledDictValColl                  ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableList               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableSet                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableStack              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableQueue              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIImmutableDict               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableArray               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableArrayBuilder        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableList                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableListBuilder         ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSet             ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableHashSetBuilder      ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableStack               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableQueue               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableDict                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableDictBuilder         ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSet           ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedSetBuilder    ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDict          ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledImmutableSortedDictBuilder   ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyColl                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyList                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlyDict                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyColl                 ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDict                 ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictKeys             ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyDictVals             ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledArraySegment                 ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledMemory                       ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyMemory               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlySequence             ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentBag                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentQueue              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentStack              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledConcurrentDict               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledBlockingColl                 ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIProducerConsumerColl        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDict                   ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDictKeys               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledSortedDictVals               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledColl                         ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledKeyedColl                    ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledObservableColl               ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyObservableColl       ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledArrayList                    ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledBitArray                     ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledCollBase                     ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledDictBase                     ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledHashtable                    ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledQueueNonGeneric              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlyCollBase             ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledSortedListNonGeneric         ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledStackNonGeneric              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledHybridDict                   ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledListDict                     ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBase           ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledNameObjectCollBaseKeys       ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledNameValueColl                ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictNonGeneric        ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledStringColl                   ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledStringDict                   ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIOrderedDict                 ; if (Has     (coll)) coll.ToString(); }
        #if NET9_0_OR_GREATER                                                                        
        { var coll = NullyFilledOrderedDict                  ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictKeys              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledOrderedDictVals              ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledIReadOnlySet                 ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledReadOnlySet                  ; if (Has     (coll)) coll.ToString(); }
        #endif
        { var coll = NullyFilledFrozenSet                    ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledFrozenDictionary             ; if (Has     (coll)) coll.ToString(); }
        #if NET6_0_OR_GREATER                                                                             
        { var coll = NullyFilledPrioQueue                    ; if (Has     (coll)) coll.ToString(); }
        { var coll = NullyFilledPrioQueueUnorderedColl       ; if (Has     (coll)) coll.ToString(); }
        #endif                                                                                       
    }
}