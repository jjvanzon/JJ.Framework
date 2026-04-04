// ReSharper disable ReturnTypeCanBeNotNullable
// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_notnullwhentests" />
[TestClass]
public class Existence_NotNullWhen_Tests : TestBase
{
    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_Has_NotNullWhen()
    {
        string       ? Text() => NullyFilledText;
        StringBuilder? SB  () => NullyFilledSB;
        int          ? Num () => Nully1;
        bool         ? Bool() => NullyTrue;

        { string?        text = Text(); if ( Has     (text              )) text.ToString(); }
        { string?        text = Text(); if ( Has     (text, true        )) text.ToString(); }
        { string?        text = Text(); if ( Has     (text, spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb                )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb,   true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb,   spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( Has     (boo               )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (boo,  true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (boo,  zeroMatters )) boo = boo.Value; }
        { int?           num  = Num (); if ( Has     (num               )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (num,  true        )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (num,  zeroMatters )) num = num.Value; }
        { string?        text = Text(); if ( Has     (              text)) text.ToString(); }
        { string?        text = Text(); if ( Has     (true,         text)) text.ToString(); }
        { string?        text = Text(); if ( Has     (spaceMatters, text)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (              sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (true,         sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (spaceMatters, sb  )) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( Has     (              boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (true,         boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (zeroMatters,  boo )) boo = boo.Value; }
        { int?           num  = Num (); if ( Has     (              num )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (true,         num )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (zeroMatters,  num )) num = num.Value; }
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_FilledIn_NotNullWhen()
    {
        string       ? Text() => NullyFilledText;
        StringBuilder? SB  () => NullyFilledSB;
        int          ? Num () => Nully1;
        bool         ? Bool() => NullyTrue;

        { string?        text = Text(); if ( FilledIn(text              )) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(text, true        )) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(text, spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(sb                )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(sb,   true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(sb,   spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( FilledIn(boo               )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(boo,  true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(boo,  zeroMatters )) boo = boo.Value; }
        { int?           num  = Num (); if ( FilledIn(num               )) num = num.Value; }
        { int?           num  = Num (); if ( FilledIn(num,  true        )) num = num.Value; }
        { int?           num  = Num (); if ( FilledIn(num,  zeroMatters )) num = num.Value; }
        { string?        text = Text(); if ( FilledIn(              text)) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(true,         text)) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(spaceMatters, text)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(              sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(true,         sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(spaceMatters, sb  )) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( FilledIn(              boo )) boo =boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(true,         boo )) boo =boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(zeroMatters,  boo )) boo =boo.Value; }
        { int?           num  = Num (); if ( FilledIn(              num )) num =num.Value; }
        { int?           num  = Num (); if ( FilledIn(true,         num )) num =num.Value; }
        { int?           num  = Num (); if ( FilledIn(zeroMatters,  num )) num =num.Value; }
        { string?        text = Text(); if ( text.FilledIn(             )) text.ToString(); }
        { string?        text = Text(); if ( text.FilledIn( true        )) text.ToString(); }
        { string?        text = Text(); if ( text.FilledIn( spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( sb  .FilledIn(             )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( sb  .FilledIn( true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( sb  .FilledIn( spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( boo .FilledIn(             )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( boo .FilledIn( true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( boo .FilledIn(             )) boo = boo.Value; }
        { int?           num  = Num (); if ( num .FilledIn(             )) num = num.Value; }
        { int?           num  = Num (); if ( num .FilledIn( true        )) num = num.Value; }
        { int?           num  = Num (); if ( num .FilledIn(             )) num = num.Value; }
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_IsNully_NotNullWhen()
    {
        string       ? Text() => NullyFilledText;
        StringBuilder? SB  () => NullyFilledSB;
        int          ? Num () => Nully1;
        bool         ? Bool() => NullyTrue;

        { string?        text = Text(); if (!IsNully (text              )) text.ToString(); }
        { string?        text = Text(); if (!IsNully (text, true        )) text.ToString(); }
        { string?        text = Text(); if (!IsNully (text, spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (sb                )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (sb,   true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (sb,   spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if (!IsNully (boo               )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (boo,  true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (boo,  zeroMatters )) boo = boo.Value; }
        { int?           num  = Num (); if (!IsNully (num               )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (num,  true        )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (num,  zeroMatters )) num = num.Value; }
        { string?        text = Text(); if (!IsNully (              text)) text.ToString(); }
        { string?        text = Text(); if (!IsNully (true,         text)) text.ToString(); }
        { string?        text = Text(); if (!IsNully (spaceMatters, text)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (              sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (true,         sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (spaceMatters, sb  )) sb  .ToString(); }
        { bool?          boo  = Bool(); if (!IsNully (              boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (true,         boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (zeroMatters,  boo )) boo = boo.Value; }
        { int?           num  = Num (); if (!IsNully (              num )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (true,         num )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (zeroMatters,  num )) num = num.Value; }
        { string?        text = Text(); if (!text .IsNully(             )) text.ToString(); }
        { string?        text = Text(); if (!text .IsNully( true        )) text.ToString(); }
        { string?        text = Text(); if (!text .IsNully( spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if (!sb   .IsNully(             )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!sb   .IsNully( true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!sb   .IsNully( spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if (!boo  .IsNully(             )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!boo  .IsNully( true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!boo  .IsNully(             )) boo = boo.Value; }
        { int?           num  = Num (); if (!num  .IsNully(             )) num = num.Value; }
        { int?           num  = Num (); if (!num  .IsNully( true        )) num = num.Value; }
        { int?           num  = Num (); if (!num  .IsNully(             )) num = num.Value; }
    }

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