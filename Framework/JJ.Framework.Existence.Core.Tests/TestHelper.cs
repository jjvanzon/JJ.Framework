﻿using DictKeyColl                = System.Collections.Generic.Dictionary<int, int>.KeyCollection;
using DictValColl                = System.Collections.Generic.Dictionary<int, int>.ValueCollection;
using ImmutableDictBuilder       = System.Collections.Immutable.ImmutableDictionary<int, int>.Builder;
using ImmutableSortedDict        = System.Collections.Immutable.ImmutableSortedDictionary<int, int>;
using ImmutableSortedDictBuilder = System.Collections.Immutable.ImmutableSortedDictionary<int, int>.Builder;
using ReadOnlyDictVals           = System.Collections.ObjectModel.ReadOnlyDictionary<int,int>.ValueCollection;
using ReadOnlyDictKeys           = System.Collections.ObjectModel.ReadOnlyDictionary<int,int>.KeyCollection;
using SortedDict                 = System.Collections.Generic.SortedDictionary<int,int>;
using SortedDictVals             = System.Collections.Generic.SortedDictionary<int,int>.ValueCollection;
using SortedDictKeys             = System.Collections.Generic.SortedDictionary<int,int>.KeyCollection;
using NameObjCollBase            = System.Collections.Specialized.NameObjectCollectionBase;
using NameObjCollBaseKeys        = System.Collections.Specialized.NameObjectCollectionBase.KeysCollection;
#if NET9_0_OR_GREATER                                                                                        
using OrderedDict                = System.Collections.Generic.OrderedDictionary<int,int>;
using OrderedDictVals            = System.Collections.Generic.OrderedDictionary<int,int>.ValueCollection;
using OrderedDictKeys            = System.Collections.Generic.OrderedDictionary<int,int>.KeyCollection;
#endif                                                                                                       
#if NET6_0_OR_GREATER               
using PrioQueueUnorderedColl     = System.Collections.Generic.PriorityQueue<int,int>.UnorderedItemsCollection;
#endif
// ReSharper disable UseCollectionExpression

namespace JJ.Framework.Existence.Core.Tests;

internal static class TestHelper
{
    public static string? NullText    = null;
    public static string  Empty       = "";
    public static string  Space       = " ";
    public static string  Text        = "Hi";
    public static string? NullyEmpty  = "";
    public static string? NullySpace  = " ";
    public static string? NullyText   = "Hi";
    
    public static int? NullNum = null;
    public static int? Nully0  = 0;
    public static int? Nully1  = 1;
    public static int? Nully2  = 2;
    public static int? Nully3  = 3;
    public static int? Nully4  = 4;
    public static int  NoNull0 = 0;
    public static int  NoNull1 = 1;
    public static int  NoNull2 = 2;
    public static int  NoNull3 = 3;
    public static int  NoNull4 = 4;
    
    public static StringBuilder? NullObj     = null;
    public static StringBuilder  NoNullObj   = new("NoNull");
    public static StringBuilder? NullyFilled = new("Filled");

    public static int[]                              FilledArray                             =                              [1, 2, 3];
    public static IList<int>                         FilledIList                             =                              [1, 2, 3];
    public static ISet<int>                          FilledISet                              = NewHashSet                   (1, 2, 3);
    public static IDictionary<int, int>              FilledIDict                             = NewDict                      (1, 2, 3);
    public static ICollection<int>                   FilledIColl                             =                              [1, 2, 3];
    public static IEnumerable<int>                   FilledIEnumerable                       =                              [1, 2, 3];
    public static ILookup<int,int>                   FilledILookup                           = NewLookup                    (1, 2, 3);
    public static List<int>                          FilledList                              =                              [1, 2, 3];
    public static HashSet<int>                       FilledHashSet                           =                              [1, 2, 3];
    public static Stack<int>                         FilledStack                             = NewStack                     (1, 2, 3);
    public static Queue<int>                         FilledQueue                             = NewQueue                     (1, 2, 3);
    public static LinkedList<int>                    FilledLinkedList                        = NewLinkedList                (1, 2, 3);
    public static SortedList<int, int>               FilledSortedList                        = NewSortedList                (1, 2, 3);
    public static SortedSet<int>                     FilledSortedSet                         = NewSortedSet                 (1, 2, 3);
    public static Dictionary<int, int>               FilledDict                              = NewDict                      (1, 2, 3);
    public static DictKeyColl                        FilledDictKeyColl                       = NewDictKeys                  (1, 2, 3);
    public static DictValColl                        FilledDictValColl                       = NewDictVals                  (1, 2, 3);
    public static IImmutableList<int>                FilledIImmutableList                    = NewImmutableList             (1, 2, 3);
    public static IImmutableSet<int>                 FilledIImmutableSet                     = NewImmutableHashSet          (1, 2, 3);
    public static IImmutableStack<int>               FilledIImmutableStack                   = NewImmutableStack            (1, 2, 3);
    public static IImmutableQueue<int>               FilledIImmutableQueue                   = NewImmutableQueue            (1, 2, 3);
    public static IImmutableDictionary<int, int>     FilledIImmutableDict                    = NewImmutableDict             (1, 2, 3);
    public static ImmutableArray<int>                FilledImmutableArray                    = NewImmutableArray            (1, 2, 3);
    public static ImmutableArray<int>.Builder        FilledImmutableArrayBuilder             = NewImmutableArrayBuilder     (1, 2, 3);
    public static ImmutableList<int>                 FilledImmutableList                     = NewImmutableList             (1, 2, 3);
    public static ImmutableList<int>.Builder         FilledImmutableListBuilder              = NewImmutableListBuilder      (1, 2, 3);
    public static ImmutableHashSet<int>              FilledImmutableHashSet                  = NewImmutableHashSet          (1, 2, 3);
    public static ImmutableHashSet<int>.Builder      FilledImmutableHashSetBuilder           = NewImmutableHashSetBuilder   (1, 2, 3);
    public static ImmutableStack<int>                FilledImmutableStack                    = NewImmutableStack            (1, 2, 3);
    public static ImmutableQueue<int>                FilledImmutableQueue                    = NewImmutableQueue            (1, 2, 3);
    public static ImmutableDictionary<int, int>      FilledImmutableDict                     = NewImmutableDict             (1, 2, 3);
    public static ImmutableDictBuilder               FilledImmutableDictBuilder              = NewImmutableDictBuilder      (1, 2, 3);
    public static ImmutableSortedSet<int>            FilledImmutableSortedSet                = NewImmutableSortedSet        (1, 2, 3);
    public static ImmutableSortedSet<int>.Builder    FilledImmutableSortedSetBuilder         = NewImmutableSortedSetBuilder (1, 2, 3);
    public static ImmutableSortedDict                FilledImmutableSortedDict               = NewImmutableSortedDict       (1, 2, 3);
    public static ImmutableSortedDictBuilder         FilledImmutableSortedDictBuilder        = NewImmutableSortedDictBuilder(1, 2, 3);
    public static IReadOnlyCollection<int>           FilledIReadOnlyColl                     =                              [1, 2, 3];
    public static IReadOnlyList<int>                 FilledIReadOnlyList                     =                              [1, 2, 3];
    public static IReadOnlyDictionary<int,int>       FilledIReadOnlyDict                     = NewReadOnlyDict              (1, 2, 3);
    public static ReadOnlyCollection<int>            FilledReadOnlyColl                      = NewReadOnlyColl              (1, 2, 3);
    public static ReadOnlyDictionary<int,int>        FilledReadOnlyDict                      = NewReadOnlyDict              (1, 2, 3);
    public static ReadOnlyDictKeys                   FilledReadOnlyDictKeys                  = NewReadOnlyDictKeys          (1, 2, 3);
    public static ReadOnlyDictVals                   FilledReadOnlyDictVals                  = NewReadOnlyDictVals          (1, 2, 3);
    public static ArraySegment<int>                  FilledArraySegment                      = NewArraySegment              (1, 2, 3);
    public static Memory<int>                        FilledMemory                            = NewMemory                    (1, 2, 3);
    public static ReadOnlyMemory<int>                FilledReadOnlyMemory                    = NewReadOnlyMemory            (1, 2, 3);
    public static ReadOnlySequence<int>              FilledReadOnlySequence                  = NewReadOnlySequence          (1, 2, 3);
    public static ConcurrentBag<int>                 FilledConcurrentBag                     =                              [1, 2, 3];
    public static ConcurrentQueue<int>               FilledConcurrentQueue                   = NewConcurrentQueue           (1, 2, 3);
    public static ConcurrentStack<int>               FilledConcurrentStack                   = NewConcurrentStack           (1, 2, 3);
    public static ConcurrentDictionary<int,int>      FilledConcurrentDict                    = NewConcurrentDict            (1, 2, 3);
    public static BlockingCollection<int>            FilledBlockingColl                      =                              [1, 2, 3];
    public static IProducerConsumerCollection<int>   FilledIProducerConsumerColl             = NewProducerConsumerColl      (1, 2, 3);
    public static SortedDict                         FilledSortedDict                        = NewSortedDict                (1, 2, 3);
    public static SortedDictKeys                     FilledSortedDictKeys                    = NewSortedDictKeys            (1, 2, 3);
    public static SortedDictVals                     FilledSortedDictVals                    = NewSortedDictVals            (1, 2, 3);
    public static Collection<int>                    FilledColl                              =                              [1, 2, 3];
    public static KeyedCollection<int,int>           FilledKeyedColl                         = NewKeyedColl                 (1, 2, 3);
    public static ObservableCollection<int>          FilledObservableColl                    =                              [1, 2, 3];
    public static ReadOnlyObservableCollection<int>  FilledReadOnlyObservableColl            = NewReadOnlyObservableColl    (1, 2, 3);
    public static ArrayList                          FilledArrayList                         =                              [1, 2, 3];    
    public static BitArray                           FilledBitArray                          = NewBitArray                  (1, 2, 3);
    public static CollectionBase                     FilledCollBase                          = NewCollectionBase            (1, 2, 3);
    public static DictionaryBase                     FilledDictBase                          = NewDictionaryBase            (1, 2, 3);
    public static Hashtable                          FilledHashtable                         = NewHashtable                 (1, 2, 3);
    public static Queue                              FilledQueueNonGeneric                   = NewQueueNonGeneric           (1, 2, 3);
    public static ReadOnlyCollectionBase             FilledReadOnlyCollBase                  = NewReadOnlyCollBase          (1, 2, 3);
    public static SortedList                         FilledSortedListNonGeneric              = NewSortedListNonGeneric      (1, 2, 3);
    public static Stack                              FilledStackNonGeneric                   = NewStackNonGeneric           (1, 2, 3);
    public static HybridDictionary                   FilledHybridDict                        = NewHybridDict                (1, 2, 3);
    public static ListDictionary                     FilledListDict                          = NewListDict                  (1, 2, 3);
    public static NameObjCollBase                    FilledNameObjectCollBase                = NewNameObjectCollBase        (1, 2, 3);
    public static NameObjCollBaseKeys                FilledNameObjectCollBaseKeys            = NewNameObjectCollBaseKeys    (1, 2, 3);
    public static NameValueCollection                FilledNameValueColl                     = NewNameValueColl             (1, 2, 3);
    public static OrderedDictionary                  FilledOrderedDictNonGeneric             = NewOrderedDictNonGeneric     (1, 2, 3);
    public static StringCollection                   FilledStringColl                        = NewStringColl                (1, 2, 3);
    public static StringDictionary                   FilledStringDict                        = NewStringDict                (1, 2, 3);
    public static IOrderedDictionary                 FilledIOrderedDict                      = NewOrderedDictNonGeneric     (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                                                                 
    public static OrderedDict                        FilledOrderedDict                       = NewOrderedDict               (1, 2, 3);
    public static OrderedDictKeys                    FilledOrderedDictKeys                   = NewOrderedDictKeys           (1, 2, 3);
    public static OrderedDictVals                    FilledOrderedDictVals                   = NewOrderedDictVals           (1, 2, 3);
    public static IReadOnlySet<int>                  FilledIReadOnlySet                      = NewReadOnlySet               (1, 2, 3);
    public static ReadOnlySet<int>                   FilledReadOnlySet                       = NewReadOnlySet               (1, 2, 3);
    #endif                                                                                            
    #if NET8_0_OR_GREATER                                                                       
    public static FrozenSet<int>                     FilledFrozenSet                         = NewFrozenSet                 (1, 2, 3);
    public static FrozenDictionary<int, int>         FilledFrozenDictionary                  = NewFrozenDictionary          (1, 2, 3);
    #endif                                                                                      
    #if NET6_0_OR_GREATER                                                                             
    public static PriorityQueue<int,int>             FilledPrioQueue                         = NewPrioQueue                 (1, 2, 3);
    public static PrioQueueUnorderedColl             FilledPrioQueueUnorderedColl            = NewPrioQueueUnorderedColl    (1, 2, 3);
    #endif                                                                                            
    
    public static int[]                            ? NullyFilledArray                        =                              [1, 2, 3];
    public static IList<int>                       ? NullyFilledIList                        =                              [1, 2, 3];
    public static ISet<int>                        ? NullyFilledISet                         = NewHashSet                   (1, 2, 3);
    public static IDictionary<int, int>            ? NullyFilledIDict                        = NewDict                      (1, 2, 3);
    public static ICollection<int>                 ? NullyFilledIColl                        =                              [1, 2, 3];
    public static IEnumerable<int>                 ? NullyFilledIEnumerable                  =                              [1, 2, 3];
    public static ILookup<int,int>                 ? NullyFilledILookup                      = NewLookup                    (1, 2, 3);
    public static List<int>                        ? NullyFilledList                         =                              [1, 2, 3];
    public static HashSet<int>                     ? NullyFilledHashSet                      =                              [1, 2, 3];
    public static Stack<int>                       ? NullyFilledStack                        = NewStack                     (1, 2, 3);
    public static Queue<int>                       ? NullyFilledQueue                        = NewQueue                     (1, 2, 3);
    public static LinkedList<int>                  ? NullyFilledLinkedList                   = NewLinkedList                (1, 2, 3);
    public static SortedList<int, int>             ? NullyFilledSortedList                   = NewSortedList                (1, 2, 3);
    public static SortedSet<int>                   ? NullyFilledSortedSet                    = NewSortedSet                 (1, 2, 3);
    public static Dictionary<int, int>             ? NullyFilledDict                         = NewDict                      (1, 2, 3);
    public static DictKeyColl                      ? NullyFilledDictKeyColl                  = NewDictKeys                  (1, 2, 3);
    public static DictValColl                      ? NullyFilledDictValColl                  = NewDictVals                  (1, 2, 3);
    public static IImmutableList<int>              ? NullyFilledIImmutableList               = NewImmutableList             (1, 2, 3);
    public static IImmutableSet<int>               ? NullyFilledIImmutableSet                = NewImmutableHashSet          (1, 2, 3);
    public static IImmutableStack<int>             ? NullyFilledIImmutableStack              = NewImmutableStack            (1, 2, 3);
    public static IImmutableQueue<int>             ? NullyFilledIImmutableQueue              = NewImmutableQueue            (1, 2, 3);
    public static IImmutableDictionary<int, int>   ? NullyFilledIImmutableDict               = NewImmutableDict             (1, 2, 3);
    public static ImmutableArray<int>              ? NullyFilledImmutableArray               = NewImmutableArray            (1, 2, 3);
    public static ImmutableArray<int>.Builder      ? NullyFilledImmutableArrayBuilder        = NewImmutableArrayBuilder     (1, 2, 3);
    public static ImmutableList<int>               ? NullyFilledImmutableList                = NewImmutableList             (1, 2, 3);
    public static ImmutableList<int>.Builder       ? NullyFilledImmutableListBuilder         = NewImmutableListBuilder      (1, 2, 3);
    public static ImmutableHashSet<int>            ? NullyFilledImmutableHashSet             = NewImmutableHashSet          (1, 2, 3);
    public static ImmutableHashSet<int>.Builder    ? NullyFilledImmutableHashSetBuilder      = NewImmutableHashSetBuilder   (1, 2, 3);
    public static ImmutableStack<int>              ? NullyFilledImmutableStack               = NewImmutableStack            (1, 2, 3);
    public static ImmutableQueue<int>              ? NullyFilledImmutableQueue               = NewImmutableQueue            (1, 2, 3);
    public static ImmutableDictionary<int, int>    ? NullyFilledImmutableDict                = NewImmutableDict             (1, 2, 3);
    public static ImmutableDictBuilder             ? NullyFilledImmutableDictBuilder         = NewImmutableDictBuilder      (1, 2, 3);
    public static ImmutableSortedSet<int>          ? NullyFilledImmutableSortedSet           = NewImmutableSortedSet        (1, 2, 3);
    public static ImmutableSortedSet<int>.Builder  ? NullyFilledImmutableSortedSetBuilder    = NewImmutableSortedSetBuilder (1, 2, 3);
    public static ImmutableSortedDict              ? NullyFilledImmutableSortedDict          = NewImmutableSortedDict       (1, 2, 3);
    public static ImmutableSortedDictBuilder       ? NullyFilledImmutableSortedDictBuilder   = NewImmutableSortedDictBuilder(1, 2, 3);
    public static IReadOnlyCollection<int>         ? NullyFilledIReadOnlyColl                =                              [1, 2, 3];
    public static IReadOnlyList<int>               ? NullyFilledIReadOnlyList                =                              [1, 2, 3];
    public static IReadOnlyDictionary<int,int>     ? NullyFilledIReadOnlyDict                = NewReadOnlyDict              (1, 2, 3);
    public static ReadOnlyCollection<int>          ? NullyFilledReadOnlyColl                 = NewReadOnlyColl              (1, 2, 3);
    public static ReadOnlyDictionary<int,int>      ? NullyFilledReadOnlyDict                 = NewReadOnlyDict              (1, 2, 3);
    public static ReadOnlyDictKeys                 ? NullyFilledReadOnlyDictKeys             = NewReadOnlyDictKeys          (1, 2, 3);
    public static ReadOnlyDictVals                 ? NullyFilledReadOnlyDictVals             = NewReadOnlyDictVals          (1, 2, 3);
    public static ArraySegment<int>                ? NullyFilledArraySegment                 = NewArraySegment              (1, 2, 3);
    public static Memory<int>                      ? NullyFilledMemory                       = NewMemory                    (1, 2, 3);
    public static ReadOnlyMemory<int>              ? NullyFilledReadOnlyMemory               = NewReadOnlyMemory            (1, 2, 3);
    public static ReadOnlySequence<int>            ? NullyFilledReadOnlySequence             = NewReadOnlySequence          (1, 2, 3);
    public static ConcurrentBag<int>               ? NullyFilledConcurrentBag                =                              [1, 2, 3];
    public static ConcurrentQueue<int>             ? NullyFilledConcurrentQueue              = NewConcurrentQueue           (1, 2, 3);
    public static ConcurrentStack<int>             ? NullyFilledConcurrentStack              = NewConcurrentStack           (1, 2, 3);
    public static ConcurrentDictionary<int,int>    ? NullyFilledConcurrentDict               = NewConcurrentDict            (1, 2, 3);
    public static BlockingCollection<int>          ? NullyFilledBlockingColl                 =                              [1, 2, 3];
    public static IProducerConsumerCollection<int> ? NullyFilledIProducerConsumerColl        = NewProducerConsumerColl      (1, 2, 3);
    public static SortedDict                       ? NullyFilledSortedDict                   = NewSortedDict                (1, 2, 3);
    public static SortedDictKeys                   ? NullyFilledSortedDictKeys               = NewSortedDictKeys            (1, 2, 3);
    public static SortedDictVals                   ? NullyFilledSortedDictVals               = NewSortedDictVals            (1, 2, 3);
    public static Collection<int>                  ? NullyFilledColl                         =                              [1, 2, 3];
    public static KeyedCollection<int,int>         ? NullyFilledKeyedColl                    = NewKeyedColl                 (1, 2, 3);
    public static ObservableCollection<int>        ? NullyFilledObservableColl               =                              [1, 2, 3];
    public static ReadOnlyObservableCollection<int>? NullyFilledReadOnlyObservableColl       = NewReadOnlyObservableColl    (1, 2, 3);
    public static ArrayList                        ? NullyFilledArrayList                    =                              [1, 2, 3];    
    public static BitArray                         ? NullyFilledBitArray                     = NewBitArray                  (1, 2, 3);
    public static CollectionBase                   ? NullyFilledCollBase                     = NewCollectionBase            (1, 2, 3);
    public static DictionaryBase                   ? NullyFilledDictBase                     = NewDictionaryBase            (1, 2, 3);
    public static Hashtable                        ? NullyFilledHashtable                    = NewHashtable                 (1, 2, 3);
    public static Queue                            ? NullyFilledQueueNonGeneric              = NewQueueNonGeneric           (1, 2, 3);
    public static ReadOnlyCollectionBase           ? NullyFilledReadOnlyCollBase             = NewReadOnlyCollBase          (1, 2, 3);
    public static SortedList                       ? NullyFilledSortedListNonGeneric         = NewSortedListNonGeneric      (1, 2, 3);
    public static Stack                            ? NullyFilledStackNonGeneric              = NewStackNonGeneric           (1, 2, 3);
    public static HybridDictionary                 ? NullyFilledHybridDict                   = NewHybridDict                (1, 2, 3);
    public static ListDictionary                   ? NullyFilledListDict                     = NewListDict                  (1, 2, 3);
    public static NameObjCollBase                  ? NullyFilledNameObjectCollBase           = NewNameObjectCollBase        (1, 2, 3);
    public static NameObjCollBaseKeys              ? NullyFilledNameObjectCollBaseKeys       = NewNameObjectCollBaseKeys    (1, 2, 3);
    public static NameValueCollection              ? NullyFilledNameValueColl                = NewNameValueColl             (1, 2, 3);
    public static OrderedDictionary                ? NullyFilledOrderedDictNonGeneric        = NewOrderedDictNonGeneric     (1, 2, 3);
    public static StringCollection                 ? NullyFilledStringColl                   = NewStringColl                (1, 2, 3);
    public static StringDictionary                 ? NullyFilledStringDict                   = NewStringDict                (1, 2, 3);
    public static IOrderedDictionary               ? NullyFilledIOrderedDict                 = NewOrderedDictNonGeneric     (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                        
    public static OrderedDict                      ? NullyFilledOrderedDict                  = NewOrderedDict               (1, 2, 3);
    public static OrderedDictKeys                  ? NullyFilledOrderedDictKeys              = NewOrderedDictKeys           (1, 2, 3);
    public static OrderedDictVals                  ? NullyFilledOrderedDictVals              = NewOrderedDictVals           (1, 2, 3);
    public static IReadOnlySet<int>                ? NullyFilledIReadOnlySet                 = NewReadOnlySet               (1, 2, 3);
    public static ReadOnlySet<int>                 ? NullyFilledReadOnlySet                  = NewReadOnlySet               (1, 2, 3);
    #endif
    #if NET8_0_OR_GREATER                                                                  
    public static FrozenSet<int>                   ? NullyFilledFrozenSet                    = NewFrozenSet                 (1, 2, 3);
    public static FrozenDictionary<int, int>       ? NullyFilledFrozenDictionary             = NewFrozenDictionary          (1, 2, 3);
    #endif                                                                                 
    #if NET6_0_OR_GREATER                                                                             
    public static PriorityQueue<int,int>           ? NullyFilledPrioQueue                    = NewPrioQueue                 (1, 2, 3);
    public static PrioQueueUnorderedColl           ? NullyFilledPrioQueueUnorderedColl       = NewPrioQueueUnorderedColl    (1, 2, 3);
    #endif                                                                                       
    
    public static int[]                              EmptyArray                              =                              [];
    public static IList<int>                         EmptyIList                              =                              [];
    public static ISet<int>                          EmptyISet                               = NewHashSet                   ();
    public static IDictionary<int, int>              EmptyIDict                              = NewDict                      ();
    public static ICollection<int>                   EmptyIColl                              =                              [];
    public static IEnumerable<int>                   EmptyIEnumerable                        =                              [];
    public static ILookup<int,int>                   EmptyILookup                            = NewLookup                    ();
    public static List<int>                          EmptyList                               =                              [];
    public static HashSet<int>                       EmptyHashSet                            =                              [];
    public static Stack<int>                         EmptyStack                              = NewStack                     ();
    public static Queue<int>                         EmptyQueue                              = NewQueue                     ();
    public static LinkedList<int>                    EmptyLinkedList                         = NewLinkedList                ();
    public static SortedList<int, int>               EmptySortedList                         = NewSortedList                ();
    public static SortedSet<int>                     EmptySortedSet                          = NewSortedSet                 ();
    public static Dictionary<int, int>               EmptyDict                               = NewDict                      ();
    public static DictKeyColl                        EmptyDictKeyColl                        = NewDictKeys                  ();
    public static DictValColl                        EmptyDictValColl                        = NewDictVals                  ();
    public static IImmutableList<int>                EmptyIImmutableList                     = NewImmutableList             ();
    public static IImmutableSet<int>                 EmptyIImmutableSet                      = NewImmutableHashSet          ();
    public static IImmutableStack<int>               EmptyIImmutableStack                    = NewImmutableStack            ();
    public static IImmutableQueue<int>               EmptyIImmutableQueue                    = NewImmutableQueue            ();
    public static IImmutableDictionary<int, int>     EmptyIImmutableDict                     = NewImmutableDict             ();
    public static ImmutableArray<int>                EmptyImmutableArray                     = NewImmutableArray            ();
    public static ImmutableArray<int>.Builder        EmptyImmutableArrayBuilder              = NewImmutableArrayBuilder     ();
    public static ImmutableList<int>                 EmptyImmutableList                      = NewImmutableList             ();
    public static ImmutableList<int>.Builder         EmptyImmutableListBuilder               = NewImmutableListBuilder      ();
    public static ImmutableHashSet<int>              EmptyImmutableHashSet                   = NewImmutableHashSet          ();
    public static ImmutableHashSet<int>.Builder      EmptyImmutableHashSetBuilder            = NewImmutableHashSetBuilder   ();
    public static ImmutableStack<int>                EmptyImmutableStack                     = NewImmutableStack            ();
    public static ImmutableQueue<int>                EmptyImmutableQueue                     = NewImmutableQueue            ();
    public static ImmutableDictionary<int, int>      EmptyImmutableDict                      = NewImmutableDict             ();
    public static ImmutableDictBuilder               EmptyImmutableDictBuilder               = NewImmutableDictBuilder      ();
    public static ImmutableSortedSet<int>            EmptyImmutableSortedSet                 = NewImmutableSortedSet        ();
    public static ImmutableSortedSet<int>.Builder    EmptyImmutableSortedSetBuilder          = NewImmutableSortedSetBuilder ();
    public static ImmutableSortedDict                EmptyImmutableSortedDict                = NewImmutableSortedDict       ();
    public static ImmutableSortedDictBuilder         EmptyImmutableSortedDictBuilder         = NewImmutableSortedDictBuilder();
    public static IReadOnlyCollection<int>           EmptyIReadOnlyColl                      =                              [];
    public static IReadOnlyList<int>                 EmptyIReadOnlyList                      =                              [];
    public static IReadOnlyDictionary<int,int>       EmptyIReadOnlyDict                      = NewReadOnlyDict              ();
    public static ReadOnlyCollection<int>            EmptyReadOnlyColl                       = NewReadOnlyColl              ();
    public static ReadOnlyDictionary<int,int>        EmptyReadOnlyDict                       = NewReadOnlyDict              ();
    public static ReadOnlyDictKeys                   EmptyReadOnlyDictKeys                   = NewReadOnlyDictKeys          ();
    public static ReadOnlyDictVals                   EmptyReadOnlyDictVals                   = NewReadOnlyDictVals          ();
    public static ArraySegment<int>                  EmptyArraySegment                       = NewArraySegment              ();
    public static Memory<int>                        EmptyMemory                             = NewMemory                    ();
    public static ReadOnlyMemory<int>                EmptyReadOnlyMemory                     = NewReadOnlyMemory            ();
    public static ReadOnlySequence<int>              EmptyReadOnlySequence                   = NewReadOnlySequence          ();
    public static ConcurrentBag<int>                 EmptyConcurrentBag                      =                              [];
    public static ConcurrentQueue<int>               EmptyConcurrentQueue                    =                              [];
    public static ConcurrentStack<int>               EmptyConcurrentStack                    =                              [];
    public static ConcurrentDictionary<int,int>      EmptyConcurrentDict                     =                              [];
    public static BlockingCollection<int>            EmptyBlockingColl                       =                              [];
    public static IProducerConsumerCollection<int>   EmptyIProducerConsumerColl              = NewProducerConsumerColl      ();
    public static SortedDict                         EmptySortedDict                         =                              [];
    public static SortedDictKeys                     EmptySortedDictKeys                     = NewSortedDictKeys            ();
    public static SortedDictVals                     EmptySortedDictVals                     = NewSortedDictVals            ();
    public static Collection<int>                    EmptyColl                               =                              [];
    public static KeyedCollection<int,int>           EmptyKeyedColl                          = NewKeyedColl                 ();
    public static ObservableCollection<int>          EmptyObservableColl                     =                              [];
    public static ReadOnlyObservableCollection<int>  EmptyReadOnlyObservableColl             = NewReadOnlyObservableColl    ();
    public static ArrayList                          EmptyArrayList                          =                              [];    
    public static BitArray                           EmptyBitArray                           = NewBitArray                  ();
    public static CollectionBase                     EmptyCollBase                           = NewCollectionBase            ();
    public static DictionaryBase                     EmptyDictBase                           = NewDictionaryBase            ();
    public static Hashtable                          EmptyHashtable                          =                              [];    
    public static Queue                              EmptyQueueNonGeneric                    =                              [];    
    public static ReadOnlyCollectionBase             EmptyReadOnlyCollBase                   = NewReadOnlyCollBase          ();
    public static SortedList                         EmptySortedListNonGeneric               =                              [];    
    public static Stack                              EmptyStackNonGeneric                    =                              [];    
    public static HybridDictionary                   EmptyHybridDict                         =                              [];
    public static ListDictionary                     EmptyListDict                           =                              [];
    public static NameObjCollBase                    EmptyNameObjectCollBase                 = NewNameObjectCollBase        ();
    public static NameObjCollBaseKeys                EmptyNameObjectCollBaseKeys             = NewNameObjectCollBaseKeys    ();
    public static NameValueCollection                EmptyNameValueColl                      =                              [];
    public static OrderedDictionary                  EmptyOrderedDictNonGeneric              =                              [];
    public static StringCollection                   EmptyStringColl                         =                              [];
    public static StringDictionary                   EmptyStringDict                         =                              [];
    public static IOrderedDictionary                 EmptyIOrderedDict                       = NewOrderedDictNonGeneric     ();
    #if NET9_0_OR_GREATER                                                                                                                       
    public static OrderedDict                        EmptyOrderedDict                        =                              [];
    public static OrderedDictKeys                    EmptyOrderedDictKeys                    = NewOrderedDictKeys           ();
    public static OrderedDictVals                    EmptyOrderedDictVals                    = NewOrderedDictVals           ();
    public static IReadOnlySet<int>                  EmptyIReadOnlySet                       = NewReadOnlySet               ();
    public static ReadOnlySet<int>                   EmptyReadOnlySet                        = NewReadOnlySet               ();
    #endif                                                    
    #if NET8_0_OR_GREATER                                                                       
    public static FrozenSet<int>                   ? EmptyFrozenSet                          = NewFrozenSet                 ();
    public static FrozenDictionary<int, int>       ? EmptyFrozenDictionary                   = NewFrozenDictionary          ();
    #endif                                                                                      
    #if NET6_0_OR_GREATER                                                                                     
    public static PriorityQueue<int,int>             EmptyPrioQueue                          = NewPrioQueue                 ();
    public static PrioQueueUnorderedColl             EmptyPrioQueueUnorderedColl             = NewPrioQueueUnorderedColl    ();
    #endif                                                                                            
    
    public static int[]                            ? NullableEmptyArray                      =                              [];
    public static IList<int>                       ? NullableEmptyIList                      =                              [];
    public static ISet<int>                        ? NullableEmptyISet                       = NewHashSet                   ();
    public static IDictionary<int, int>            ? NullableEmptyIDict                      = NewDict                      ();
    public static ICollection<int>                 ? NullableEmptyIColl                      =                              [];
    public static IEnumerable<int>                 ? NullableEmptyIEnumerable                =                              [];
    public static ILookup<int,int>                 ? NullableEmptyILookup                    = NewLookup                    ();
    public static List<int>                        ? NullableEmptyList                       =                              [];
    public static HashSet<int>                     ? NullableEmptyHashSet                    =                              [];
    public static Stack<int>                       ? NullableEmptyStack                      = NewStack                     ();
    public static Queue<int>                       ? NullableEmptyQueue                      = NewQueue                     ();
    public static LinkedList<int>                  ? NullableEmptyLinkedList                 = NewLinkedList                ();
    public static SortedList<int, int>             ? NullableEmptySortedList                 = NewSortedList                ();
    public static SortedSet<int>                   ? NullableEmptySortedSet                  = NewSortedSet                 ();
    public static Dictionary<int, int>             ? NullableEmptyDict                       = NewDict                      ();
    public static DictKeyColl                      ? NullableEmptyDictKeyColl                = NewDictKeys                  ();
    public static DictValColl                      ? NullableEmptyDictValColl                = NewDictVals                  ();
    public static IImmutableList<int>              ? NullableEmptyIImmutableList             = NewImmutableList             ();
    public static IImmutableSet<int>               ? NullableEmptyIImmutableSet              = NewImmutableHashSet          ();
    public static IImmutableStack<int>             ? NullableEmptyIImmutableStack            = NewImmutableStack            ();
    public static IImmutableQueue<int>             ? NullableEmptyIImmutableQueue            = NewImmutableQueue            ();
    public static IImmutableDictionary<int, int>   ? NullableEmptyIImmutableDict             = NewImmutableDict             ();
    public static ImmutableArray<int>              ? NullableEmptyImmutableArray             = NewImmutableArray            ();
    public static ImmutableArray<int>.Builder      ? NullableEmptyImmutableArrayBuilder      = NewImmutableArrayBuilder     ();
    public static ImmutableList<int>               ? NullableEmptyImmutableList              = NewImmutableList             ();
    public static ImmutableList<int>.Builder       ? NullableEmptyImmutableListBuilder       = NewImmutableListBuilder      ();
    public static ImmutableHashSet<int>            ? NullableEmptyImmutableHashSet           = NewImmutableHashSet          ();
    public static ImmutableHashSet<int>.Builder    ? NullableEmptyImmutableHashSetBuilder    = NewImmutableHashSetBuilder   ();
    public static ImmutableStack<int>              ? NullableEmptyImmutableStack             = NewImmutableStack            ();
    public static ImmutableQueue<int>              ? NullableEmptyImmutableQueue             = NewImmutableQueue            ();
    public static ImmutableDictionary<int, int>    ? NullableEmptyImmutableDict              = NewImmutableDict             ();
    public static ImmutableDictBuilder             ? NullableEmptyImmutableDictBuilder       = NewImmutableDictBuilder      ();
    public static ImmutableSortedSet<int>          ? NullableEmptyImmutableSortedSet         = NewImmutableSortedSet        ();
    public static ImmutableSortedSet<int>.Builder  ? NullableEmptyImmutableSortedSetBuilder  = NewImmutableSortedSetBuilder ();
    public static ImmutableSortedDict              ? NullableEmptyImmutableSortedDict        = NewImmutableSortedDict       ();
    public static ImmutableSortedDictBuilder       ? NullableEmptyImmutableSortedDictBuilder = NewImmutableSortedDictBuilder();
    public static IReadOnlyCollection<int>         ? NullableEmptyIReadOnlyColl              =                              [];
    public static IReadOnlyList<int>               ? NullableEmptyIReadOnlyList              =                              [];
    public static IReadOnlyDictionary<int,int>     ? NullableEmptyIReadOnlyDict              = NewReadOnlyDict              ();
    public static ReadOnlyCollection<int>          ? NullableEmptyReadOnlyColl               = NewReadOnlyColl              ();
    public static ReadOnlyDictionary<int,int>      ? NullableEmptyReadOnlyDict               = NewReadOnlyDict              ();
    public static ReadOnlyDictKeys                 ? NullableEmptyReadOnlyDictKeys           = NewReadOnlyDictKeys          ();
    public static ReadOnlyDictVals                 ? NullableEmptyReadOnlyDictVals           = NewReadOnlyDictVals          ();
    public static ArraySegment<int>                ? NullableEmptyArraySegment               = NewArraySegment              ();
    public static Memory<int>                      ? NullableEmptyMemory                     = NewMemory                    ();
    public static ReadOnlyMemory<int>              ? NullableEmptyReadOnlyMemory             = NewReadOnlyMemory            ();
    public static ReadOnlySequence<int>            ? NullableEmptyReadOnlySequence           = NewReadOnlySequence          ();
    public static ConcurrentBag<int>               ? NullableEmptyConcurrentBag              =                              [];
    public static ConcurrentQueue<int>             ? NullableEmptyConcurrentQueue            =                              [];
    public static ConcurrentStack<int>             ? NullableEmptyConcurrentStack            =                              [];
    public static ConcurrentDictionary<int,int>    ? NullableEmptyConcurrentDict             =                              [];
    public static BlockingCollection<int>          ? NullableEmptyBlockingColl               =                              [];
    public static IProducerConsumerCollection<int> ? NullableEmptyIProducerConsumerColl      = NewProducerConsumerColl      ();
    public static SortedDict                       ? NullableEmptySortedDict                 =                              [];
    public static SortedDictKeys                   ? NullableEmptySortedDictKeys             = NewSortedDictKeys            ();
    public static SortedDictVals                   ? NullableEmptySortedDictVals             = NewSortedDictVals            ();
    public static Collection<int>                  ? NullableEmptyColl                       =                              [];
    public static KeyedCollection<int,int>         ? NullableEmptyKeyedColl                  = NewKeyedColl                 ();
    public static ObservableCollection<int>        ? NullableEmptyObservableColl             =                              [];
    public static ReadOnlyObservableCollection<int>? NullableEmptyReadOnlyObservableColl     = NewReadOnlyObservableColl    ();
    public static ArrayList                        ? NullableEmptyArrayList                  =                              [];    
    public static BitArray                         ? NullableEmptyBitArray                   = NewBitArray                  ();
    public static CollectionBase                   ? NullableEmptyCollBase                   = NewCollectionBase            ();
    public static DictionaryBase                   ? NullableEmptyDictBase                   = NewDictionaryBase            ();
    public static Hashtable                        ? NullableEmptyHashtable                  =                              [];    
    public static Queue                            ? NullableEmptyQueueNonGeneric            =                              [];    
    public static ReadOnlyCollectionBase           ? NullableEmptyReadOnlyCollBase           = NewReadOnlyCollBase          ();
    public static SortedList                       ? NullableEmptySortedListNonGeneric       =                              [];    
    public static Stack                            ? NullableEmptyStackNonGeneric            =                              [];    
    public static HybridDictionary                 ? NullableEmptyHybridDict                 =                              [];
    public static ListDictionary                   ? NullableEmptyListDict                   =                              [];
    public static NameObjCollBase                  ? NullableEmptyNameObjectCollBase         = NewNameObjectCollBase        ();
    public static NameObjCollBaseKeys              ? NullableEmptyNameObjectCollBaseKeys     = NewNameObjectCollBaseKeys    ();
    public static NameValueCollection              ? NullableEmptyNameValueColl              =                              [];
    public static OrderedDictionary                ? NullableEmptyOrderedDictNonGeneric      =                              [];
    public static StringCollection                 ? NullableEmptyStringColl                 =                              [];
    public static StringDictionary                 ? NullableEmptyStringDict                 =                              [];
    public static IOrderedDictionary               ? NullableEmptyIOrderedDict               = NewOrderedDictNonGeneric     ();
    #if NET9_0_OR_GREATER                                                                                                                       
    public static OrderedDict                      ? NullableEmptyOrderedDict                =                              [];
    public static OrderedDictKeys                  ? NullableEmptyOrderedDictKeys            = NewOrderedDictKeys           ();
    public static OrderedDictVals                  ? NullableEmptyOrderedDictVals            = NewOrderedDictVals           ();
    public static IReadOnlySet<int>                ? NullableEmptyIReadOnlySet               = NewReadOnlySet               ();
    public static ReadOnlySet<int>                 ? NullableEmptyReadOnlySet                = NewReadOnlySet               ();
    #endif
    #if NET8_0_OR_GREATER                                                               
    public static FrozenSet<int>                   ? NullableEmptyFrozenSet                  = NewFrozenSet                 ();
    public static FrozenDictionary<int, int>       ? NullableEmptyFrozenDictionary           = NewFrozenDictionary          ();
    #endif                                                                              
    #if NET6_0_OR_GREATER                                                                             
    public static PriorityQueue<int,int>           ? NullableEmptyPrioQueue                  = NewPrioQueue                 ();
    public static PrioQueueUnorderedColl           ? NullableEmptyPrioQueueUnorderedColl     = NewPrioQueueUnorderedColl    ();
    #endif                                                                                            

    public static int[]                            ? NullArray                               = null;
    public static IList<int>                       ? NullIList                               = null;
    public static ISet<int>                        ? NullISet                                = null;
    public static IDictionary<int, int>            ? NullIDict                               = null;
    public static ICollection<int>                 ? NullIColl                               = null;
    public static IEnumerable<int>                 ? NullIEnumerable                         = null;
    public static ILookup<int,int>                 ? NullILookup                             = null;
    public static List<int>                        ? NullList                                = null;
    public static HashSet<int>                     ? NullHashSet                             = null;
    public static Stack<int>                       ? NullStack                               = null;
    public static Queue<int>                       ? NullQueue                               = null;
    public static LinkedList<int>                  ? NullLinkedList                          = null;
    public static SortedList<int, int>             ? NullSortedList                          = null;
    public static SortedSet<int>                   ? NullSortedSet                           = null;
    public static Dictionary<int, int>             ? NullDict                                = null;
    public static DictKeyColl                      ? NullDictKeyColl                         = null;
    public static DictValColl                      ? NullDictValColl                         = null;
    public static IImmutableList<int>              ? NullIImmutableList                      = null;
    public static IImmutableSet<int>               ? NullIImmutableSet                       = null;
    public static IImmutableStack<int>             ? NullIImmutableStack                     = null;
    public static IImmutableQueue<int>             ? NullIImmutableQueue                     = null;
    public static IImmutableDictionary<int, int>   ? NullIImmutableDict                      = null;
    public static ImmutableArray<int>              ? NullImmutableArray                      = null;
    public static ImmutableArray<int>.Builder      ? NullImmutableArrayBuilder               = null;
    public static ImmutableList<int>               ? NullImmutableList                       = null;
    public static ImmutableList<int>.Builder       ? NullImmutableListBuilder                = null;
    public static ImmutableHashSet<int>            ? NullImmutableHashSet                    = null;
    public static ImmutableHashSet<int>.Builder    ? NullImmutableHashSetBuilder             = null;
    public static ImmutableStack<int>              ? NullImmutableStack                      = null;
    public static ImmutableQueue<int>              ? NullImmutableQueue                      = null;
    public static ImmutableDictionary<int, int>    ? NullImmutableDict                       = null;
    public static ImmutableDictBuilder             ? NullImmutableDictBuilder                = null;
    public static ImmutableSortedSet<int>          ? NullImmutableSortedSet                  = null;
    public static ImmutableSortedSet<int>.Builder  ? NullImmutableSortedSetBuilder           = null;
    public static ImmutableSortedDict              ? NullImmutableSortedDict                 = null;
    public static ImmutableSortedDictBuilder       ? NullImmutableSortedDictBuilder          = null;
    public static IReadOnlyCollection<int>         ? NullIReadOnlyColl                       = null;
    public static IReadOnlyList<int>               ? NullIReadOnlyList                       = null;
    public static IReadOnlyDictionary<int,int>     ? NullIReadOnlyDict                       = null;
    public static ReadOnlyCollection<int>          ? NullReadOnlyColl                        = null;
    public static ReadOnlyDictionary<int,int>      ? NullReadOnlyDict                        = null;
    public static ReadOnlyDictKeys                 ? NullReadOnlyDictKeys                    = null;
    public static ReadOnlyDictVals                 ? NullReadOnlyDictVals                    = null;
    public static ArraySegment<int>                ? NullArraySegment                        = null;
    public static Memory<int>                      ? NullMemory                              = null;
    public static ReadOnlyMemory<int>              ? NullReadOnlyMemory                      = null;
    public static ReadOnlySequence<int>            ? NullReadOnlySequence                    = null;
    public static ConcurrentBag<int>               ? NullConcurrentBag                       = null;
    public static ConcurrentQueue<int>             ? NullConcurrentQueue                     = null;
    public static ConcurrentStack<int>             ? NullConcurrentStack                     = null;
    public static ConcurrentDictionary<int,int>    ? NullConcurrentDict                      = null;
    public static BlockingCollection<int>          ? NullBlockingColl                        = null;
    public static IProducerConsumerCollection<int> ? NullIProducerConsumerColl               = null;
    public static SortedDict                       ? NullSortedDict                          = null;
    public static SortedDictKeys                   ? NullSortedDictKeys                      = null;
    public static SortedDictVals                   ? NullSortedDictVals                      = null;
    public static Collection<int>                  ? NullColl                                = null;
    public static KeyedCollection<int,int>         ? NullKeyedColl                           = null;
    public static ObservableCollection<int>        ? NullObservableColl                      = null;
    public static ReadOnlyObservableCollection<int>? NullReadOnlyObservableColl              = null;
    public static ArrayList                        ? NullArrayList                           = null;    
    public static BitArray                         ? NullBitArray                            = null;    
    public static CollectionBase                   ? NullCollBase                            = null;
    public static DictionaryBase                   ? NullDictBase                            = null;
    public static Hashtable                        ? NullHashtable                           = null;    
    public static Queue                            ? NullQueueNonGeneric                     = null;    
    public static ReadOnlyCollectionBase           ? NullReadOnlyCollBase                    = null;
    public static SortedList                       ? NullSortedListNonGeneric                = null;    
    public static Stack                            ? NullStackNonGeneric                     = null;    
    public static HybridDictionary                 ? NullHybridDict                          = null;
    public static ListDictionary                   ? NullListDict                            = null;
    public static NameObjCollBase                  ? NullNameObjectCollBase                  = null;
    public static NameObjCollBaseKeys              ? NullNameObjectCollBaseKeys              = null;
    public static NameValueCollection              ? NullNameValueColl                       = null;
    public static OrderedDictionary                ? NullOrderedDictNonGeneric               = null;
    public static StringCollection                 ? NullStringColl                          = null;
    public static StringDictionary                 ? NullStringDict                          = null;
    public static IOrderedDictionary               ? NullIOrderedDict                        = null;
    #if NET9_0_OR_GREATER                                                                                                                                
    public static OrderedDict                      ? NullOrderedDict                         = null;
    public static OrderedDictKeys                  ? NullOrderedDictKeys                     = null;
    public static OrderedDictVals                  ? NullOrderedDictVals                     = null;
    public static IReadOnlySet<int>                ? NullIReadOnlySet                        = null;
    public static ReadOnlySet<int>                 ? NullReadOnlySet                         = null;
    #endif                                                                                                 
    #if NET8_0_OR_GREATER                                                                                 
    public static FrozenSet<int>                   ? NullFrozenSet                           = null;
    public static FrozenDictionary<int, int>       ? NullFrozenDictionary                    = null;
    #endif                                                                                                                          
    #if NET6_0_OR_GREATER                                                                                  
    public static PriorityQueue<int,int>           ? NullPrioQueue                           = null;
    public static PrioQueueUnorderedColl           ? NullPrioQueueUnorderedColl              = null;
    #endif                                                                                                 

    // Additional States of Emptiness
    
    public static ImmutableArray<int>                ImmutableArrayWithDefault               = default;
    public static ImmutableArray<int>              ? ImmutableArrayWithDefaultNullable       = default;
    public static ImmutableArray<int>                ImmutableArrayWithNew                   = new();
    public static ImmutableArray<int>              ? ImmutableArrayWithNewNullable           = new();
  
    // TODO: These work differently. Declare inside method.
    //public static ReadOnlySpan<int>                DefaultReadOnlySpan                        = default;
    //public static Span<int>                        DefaultSpanWithDefault                     = default;

    // Collection Instantiation
    
    private static HashSet<int>         NewHashSet   (params int[] nums) => [..nums];
    private static Dictionary<int, int> NewDict      (params int[] nums) => nums.ToDictionary(num => num);
    private static DictKeyColl          NewDictKeys  (params int[] nums) => nums.ToDictionary(num => num).Keys;
    private static DictValColl          NewDictVals  (params int[] nums) => nums.ToDictionary(num => num).Values;
    private static Stack<int>           NewStack     (params int[] nums) => new(nums);
    private static Queue<int>           NewQueue     (params int[] nums) => new(nums);
    private static LinkedList<int>      NewLinkedList(params int[] nums) => new(nums);
    private static SortedSet<int>       NewSortedSet (params int[] nums) => new(nums);
    
    private static SortedList<int, int> NewSortedList(params int[] nums)
    {
        var coll = new SortedList<int, int>();
        foreach (var num in nums)
        {
            coll.Add(num, num);
        }
        return coll;
    }
    
    private static ImmutableStack<int> NewImmutableStack(params int[] nums) => ImmutableStack.Create(nums);
    private static ImmutableQueue<int> NewImmutableQueue(params int[] nums) => ImmutableQueue.Create(nums);
    
    private static ImmutableArray<int> NewImmutableArray(params int[] nums) => NewImmutableArrayBuilder(nums).ToImmutable();
    private static ImmutableArray<int>.Builder NewImmutableArrayBuilder(params int[] nums)
    {
        var builder = ImmutableArray.CreateBuilder<int>();
        foreach (var num in nums)
        {
            builder.Add(num);
        }
        return builder;
    }

    private static ImmutableList<int> NewImmutableList(params int[] nums) => NewImmutableListBuilder(nums).ToImmutable();
    private static ImmutableList<int>.Builder NewImmutableListBuilder(params int[] nums)
    {
        var builder = ImmutableList.CreateBuilder<int>();
        foreach (var num in nums)
        {
            builder.Add(num);
        }
        return builder;
    }
        
    private static ImmutableHashSet<int> NewImmutableHashSet(params int[] nums) => NewImmutableHashSetBuilder(nums).ToImmutable();
    private static ImmutableHashSet<int>.Builder NewImmutableHashSetBuilder(params int[] nums)
    {
        var builder = ImmutableHashSet.CreateBuilder<int>();
        foreach (var num in nums)
        {
            builder.Add(num);
        }
        return builder;
    }

    private static ImmutableDictionary<int, int> NewImmutableDict(params int[] nums) => NewImmutableDictBuilder(nums).ToImmutable();
    private static ImmutableDictBuilder NewImmutableDictBuilder(params int[] nums)
    {
        var builder = ImmutableDictionary.CreateBuilder<int, int>();
        foreach (var num in nums)
        {
            builder.Add(num, num);
        }

        return builder;
    }

    private static ImmutableSortedSet<int> NewImmutableSortedSet(params int[] nums) => NewImmutableSortedSetBuilder(nums).ToImmutable();
    private static ImmutableSortedSet<int>.Builder NewImmutableSortedSetBuilder(params int[] nums)
    {
        var builder = ImmutableSortedSet.CreateBuilder<int>();
        foreach (var num in nums)
        {
            builder.Add(num);
        }
        return builder;
    }
    
    private static ImmutableSortedDict NewImmutableSortedDict(params int[] nums) => NewImmutableSortedDictBuilder(nums).ToImmutable();
    private static ImmutableSortedDictBuilder NewImmutableSortedDictBuilder(params int[] nums)
    {
        var builder = ImmutableSortedDictionary.CreateBuilder<int, int>();
        foreach (var num in nums)
        {
            builder.Add(num, num);
        }
        return builder;
    }

    private static ReadOnlyDictionary<int, int> NewReadOnlyDict(params int[] nums) => new(nums.ToDictionary(num => num));
    private static ReadOnlyDictKeys NewReadOnlyDictKeys(params int[] nums) => NewReadOnlyDict(nums).Keys!;
    private static ReadOnlyDictVals NewReadOnlyDictVals(params int[] nums) => NewReadOnlyDict(nums).Values!;
    private static ReadOnlyCollection<int> NewReadOnlyColl(params int[] nums) => new(nums);
    #if NET9_0_OR_GREATER                                                                                                                           
    private static ReadOnlySet<int> NewReadOnlySet(params int[] nums) => new(new HashSet<int>(nums));
    #endif
    
    private static IProducerConsumerCollection<int> NewProducerConsumerColl(params int[] nums) => NewConcurrentQueue(nums);
    private static ConcurrentQueue<int> NewConcurrentQueue(params int[] nums) => new(nums);

    private static SortedDict NewSortedDict(params int[] nums)
    {
        var coll = new SortedDict();
        foreach (var num in nums)
        {
            coll.Add(num, num);
        }
        return coll;
    }
    
    private static SortedDictKeys NewSortedDictKeys(params int[] nums) => NewSortedDict(nums).Keys;
    private static SortedDictVals NewSortedDictVals(params int[] nums) => NewSortedDict(nums).Values;

    #if NET9_0_OR_GREATER                                                                             
    private static OrderedDict NewOrderedDict(params int[] nums)
    {
       var coll = new OrderedDict();
       foreach (int num in nums)
       {
           coll.Add(num, num);
       }
       return coll;
    }
    
    private static OrderedDictKeys NewOrderedDictKeys(params int[] nums) => NewOrderedDict(nums).Keys;
    private static OrderedDictVals NewOrderedDictVals(params int[] nums) => NewOrderedDict(nums).Values;
    #endif                                                                                            

    #if NET6_0_OR_GREATER
    private static PriorityQueue<int, int> NewPrioQueue(params int[] nums)
    {
        var coll = new PriorityQueue<int, int>();
        foreach (var num in nums)
        {
            coll.Enqueue(num, num);
        }
        return coll;
    }
    private static PrioQueueUnorderedColl NewPrioQueueUnorderedColl(params int[] nums) => NewPrioQueue(nums).UnorderedItems;
    #endif                                                                                            
    
    private static ConcurrentStack<int> NewConcurrentStack(params int[] nums)
    {
        var coll = new ConcurrentStack<int>();
        foreach (var num in nums)
        {
            coll.Push(num);
        }
        return coll;
    }

    private static ConcurrentDictionary<int, int> NewConcurrentDict(params int[] nums)
    {
        var coll = new ConcurrentDictionary<int, int>();
        foreach (var num in nums)
        {
            coll.TryAdd(num, num);
        }
        return coll;
    }

    private class IntKeyedCollection : KeyedCollection<int, int>
    {
        protected override int GetKeyForItem(int item) => item;
    }

    private static KeyedCollection<int, int> NewKeyedColl(params int[] nums)
    {
        var coll = new IntKeyedCollection();
        foreach (var num in nums)
        {
            coll.Add(num);
        }
        return coll;
    }    

    private static ObservableCollection<int> NewObservableColl(int[] nums) => new(nums);
    private static ReadOnlyObservableCollection<int> NewReadOnlyObservableColl(params int[] nums) => new(NewObservableColl(nums));

    private static BitArray NewBitArray(params int[] nums) => new(nums);

    private static IntCollectionBase NewCollectionBase(params int[] nums) => new(nums);
    private class IntCollectionBase : CollectionBase
    {
        public IntCollectionBase(IEnumerable<int> nums)
        {
            foreach (var num in nums)
            {
                List.Add(num);
            }
        }
    }

    private static IntDictionaryBase NewDictionaryBase(params int[] nums) => new(nums);
    private class IntDictionaryBase : DictionaryBase
    {
        public IntDictionaryBase(IEnumerable<int> nums)
        {
            foreach (var num in nums)
            {
                Dictionary[num] = num;
            }
        }
    }
    
    private static IntReadOnlyCollectionBase NewReadOnlyCollBase(params int[] nums) => new(nums);
    private class IntReadOnlyCollectionBase : ReadOnlyCollectionBase
    {
        public IntReadOnlyCollectionBase(IEnumerable<int> nums)
        {
            foreach (var num in nums)
            {
                InnerList.Add(num);
            }
        }
    }

    private static NameObjCollBaseKeys NewNameObjectCollBaseKeys(params int[] nums) => NewNameObjectCollBase(nums).Keys;
    private static IntNameObjectCollectionBase NewNameObjectCollBase(params int[] nums) => new(nums);
    private class IntNameObjectCollectionBase : NameObjCollBase
    {
        public IntNameObjectCollectionBase(IEnumerable<int> nums)
        {
            foreach (var num in nums)
            {
                BaseAdd($"{num}", num);
            }
        }
    }
    
    private static OrderedDictionary NewOrderedDictNonGeneric(params int[] nums)
    {
        var coll = new OrderedDictionary();
        foreach (int num in nums)
        {
           coll.Add(num, num);
        }
        return coll;
    }
    
    private static Hashtable NewHashtable(params int[] nums)
    {
        var coll = new Hashtable();
        foreach (var num in nums)
        {
            coll[num] = num;
        }
        return coll;
    }

    private static Queue NewQueueNonGeneric(params int[] nums)
    {
        var coll = new Queue();
        foreach (var num in nums)
        {
            coll.Enqueue(num);
        }
        return coll;
    }

    private static SortedList NewSortedListNonGeneric(params int[] nums)
    {
        var coll = new SortedList();
        foreach (var num in nums)
        {
            coll.Add(num, num);
        }

        return coll;
    }
    
    private static Stack NewStackNonGeneric(params int[] nums)
    {
        var coll = new Stack();
        foreach (var num in nums)
        {
            coll.Push(num);
        }
        return coll;
    }

    private static HybridDictionary NewHybridDict(params int[] nums)
    {
        var coll = new HybridDictionary();
        foreach (var num in nums)
        {
            coll.Add(num, num);
        }
        return coll;
    }

    private static ListDictionary NewListDict(params int[] nums)
    {
        var coll = new ListDictionary();
        foreach (var num in nums)
        {
            coll.Add(num, num);
        }
        return coll;
    }
    
    private static NameValueCollection NewNameValueColl(params int[] nums)
    {
        var coll = new NameValueCollection();
        foreach (var num in nums)
        {
            coll.Add($"{num}", $"{num}");
        }
        return coll;
    }
    
    private static StringCollection NewStringColl(params int[] nums)
    {
        var coll = new StringCollection();
        foreach (var num in nums)
        {
            coll.Add($"{num}");
        }
        return coll;
    }

    private static StringDictionary NewStringDict(params int[] nums)
    {
        var coll = new StringDictionary();
        foreach (var num in nums)
        {
            coll.Add($"{num}", $"{num}");
        }
        return coll;
    }
    
    // Newer Additions       

    #if NET8_0_OR_GREATER                                                                    
    private static FrozenSet<int> NewFrozenSet(params int[] nums) => nums.ToHashSet().ToFrozenSet();
    private static FrozenDictionary<int, int> NewFrozenDictionary(params int[] nums) => nums.ToDictionary(num => num).ToFrozenDictionary();
    #endif                                                                                   
    
    private static ILookup<int, int> NewLookup(params int[] nums) => nums.ToLookup(num => num);
    private static ArraySegment<int> NewArraySegment(params int[] nums) => new(nums);
    private static Memory<int> NewMemory(params int[] nums) => new(nums);
    private static ReadOnlyMemory<int> NewReadOnlyMemory(params int[] nums) => new(nums);
    private static ReadOnlySequence<int> NewReadOnlySequence(params int[] nums) => new(nums);
    
    // NoNullRet
    
    // For objects

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(TRet ret)
        where TRet : class
    {
        NotNull(ret);
    }

    /// <inheritdoc cref="_nonullret" />
    // ReSharper disable once MethodOverloadWithOptionalParameter
    public static void NoNullRet<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : notnull
    {
        NotNull(ret, message);
    }

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(object? expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : class
    {
        NotNull(ret, message);
        AreEqual(expected, ret, message);
    }
    
    // For text

    /// <inheritdoc cref="_nonullret" />
    [Prio(1)]
    public static void NoNullRet(string? expected, string ret, [ArgExpress(nameof(ret))] string message = "")
    {
        NotNull(ret, message);
        AreEqual(expected, ret, message);
    }
    
    // For int
    
    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(int expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : struct
    {
        AreEqual(expected, ret, message);
        IsType(typeof(int), ret, message);
        NotType(typeof(int?), ret, message);
    }

    /// <inheritdoc cref="_nullret" />
    public static void NullRet<TRet>(int expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    {
        AreEqual(expected, ret, message);
        IsType(typeof(int?), ret, message);
        NotType(typeof(int), ret, message);
    }
    
    /// <inheritdoc cref="_nullret" />
    public static void NullRet<TRet>(int? expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    {
        AreEqual(expected, ret, message);
        IsType(typeof(int?), ret, message);
        NotType(typeof(int), ret, message);
    }

    /// <inheritdoc cref="_nullret" />
    public static void NullRet<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : struct
    {
        IsType(typeof(int?), ret, message);
        NotType(typeof(int), ret, message);
    }
}