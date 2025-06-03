using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using DictKeyColl = System.Collections.Generic.Dictionary<int, int>.KeyCollection;
using DictValColl = System.Collections.Generic.Dictionary<int, int>.ValueCollection;
using ImmutableDictBuilder = System.Collections.Immutable.ImmutableDictionary<int, int>.Builder;
using ImmutableSortedDict = System.Collections.Immutable.ImmutableSortedDictionary<int, int>;
using ImmutableSortedDictBuilder = System.Collections.Immutable.ImmutableSortedDictionary<int, int>.Builder;
using ReadOnlyDictVals = System.Collections.ObjectModel.ReadOnlyDictionary<int,int>.ValueCollection;
using ReadOnlyDictKeys = System.Collections.ObjectModel.ReadOnlyDictionary<int,int>.KeyCollection;
using SortedDict = System.Collections.Generic.SortedDictionary<int,int>;
using SortedDictVals = System.Collections.Generic.SortedDictionary<int,int>.ValueCollection;
using SortedDictKeys = System.Collections.Generic.SortedDictionary<int,int>.KeyCollection;
using NameObjCollBase = System.Collections.Specialized.NameObjectCollectionBase;
using NameObjCollBaseKeys = System.Collections.Specialized.NameObjectCollectionBase.KeysCollection;
#if NET9_0_OR_GREATER                                                                                        
using OrderedDict = System.Collections.Generic.OrderedDictionary<int,int>;
using OrderedDictVals = System.Collections.Generic.OrderedDictionary<int,int>.ValueCollection;
using OrderedDictKeys = System.Collections.Generic.OrderedDictionary<int,int>.KeyCollection;
#endif                                                                                                       
#if NET6_0_OR_GREATER               
using PrioQueueUnorderedColl = System.Collections.Generic.PriorityQueue<int,int>.UnorderedItemsCollection;
#endif
// ReSharper disable UseCollectionExpression

namespace JJ.Framework.Existence.Core.Tests;

internal static class TestHelper
{
    public static readonly string? NullText    = null;
    public static readonly string  Empty       = "";
    public static readonly string  Space       = " ";
    public static readonly string  Text        = "Hi";
    public static readonly string? NullyEmpty  = "";
    public static readonly string? NullySpace  = " ";
    public static readonly string? NullyText   = "Hi";
    
    public static readonly int? NullNum = null;
    public static readonly int? Nully0  = 0;
    public static readonly int? Nully1  = 1;
    public static readonly int? Nully2  = 2;
    public static readonly int? Nully3  = 3;
    public static readonly int? Nully4  = 4;
    public static readonly int  NoNull0 = 0;
    public static readonly int  NoNull1 = 1;
    public static readonly int  NoNull2 = 2;
    public static readonly int  NoNull3 = 3;
    public static readonly int  NoNull4 = 4;
    
    public static readonly StringBuilder? NullObj     = null;
    public static readonly StringBuilder  NoNullObj   = new("NoNull");
    public static readonly StringBuilder? NullyFilled = new("Filled");
    
    public static readonly ImmutableArray<int>                ImmutableArrayWithDefault               = default;
    public static readonly ImmutableArray<int>              ? ImmutableArrayWithDefaultNullable       = default;
    public static readonly ImmutableArray<int>                ImmutableArrayWithNew                   = new();
    public static readonly ImmutableArray<int>              ? ImmutableArrayWithNewNullable           = new();

    public static readonly int[]                              FilledArray                             =                              [1, 2, 3];
    public static readonly IList<int>                         FilledIList                             =                              [1, 2, 3];
    public static readonly ISet<int>                          FilledISet                              = NewHashSet                   (1, 2, 3);
    public static readonly IDictionary<int, int>              FilledIDict                             = NewDict                      (1, 2, 3);
    public static readonly ICollection<int>                   FilledIColl                             =                              [1, 2, 3];
    public static readonly IEnumerable<int>                   FilledIEnumerable                       =                              [1, 2, 3];
    public static readonly List<int>                          FilledList                              =                              [1, 2, 3];
    public static readonly HashSet<int>                       FilledHashSet                           =                              [1, 2, 3];
    public static readonly Stack<int>                         FilledStack                             = NewStack                     (1, 2, 3);
    public static readonly Queue<int>                         FilledQueue                             = NewQueue                     (1, 2, 3);
    public static readonly LinkedList<int>                    FilledLinkedList                        = NewLinkedList                (1, 2, 3);
    public static readonly SortedList<int, int>               FilledSortedList                        = NewSortedList                (1, 2, 3);
    public static readonly SortedSet<int>                     FilledSortedSet                         = NewSortedSet                 (1, 2, 3);
    public static readonly Dictionary<int, int>               FilledDict                              = NewDict                      (1, 2, 3);
    public static readonly DictKeyColl                        FilledDictKeyColl                       = NewDictKeys                  (1, 2, 3);
    public static readonly DictValColl                        FilledDictValColl                       = NewDictVals                  (1, 2, 3);
    public static readonly IImmutableList<int>                FilledIImmutableList                    = NewImmutableList             (1, 2, 3);
    public static readonly IImmutableSet<int>                 FilledIImmutableSet                     = NewImmutableHashSet          (1, 2, 3);
    public static readonly IImmutableStack<int>               FilledIImmutableStack                   = NewImmutableStack            (1, 2, 3);
    public static readonly IImmutableQueue<int>               FilledIImmutableQueue                   = NewImmutableQueue            (1, 2, 3);
    public static readonly IImmutableDictionary<int, int>     FilledIImmutableDict                    = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableArray<int>                FilledImmutableArray                    = NewImmutableArray            (1, 2, 3);
    public static readonly ImmutableArray<int>.Builder        FilledImmutableArrayBuilder             = NewImmutableArrayBuilder     (1, 2, 3);
    public static readonly ImmutableList<int>                 FilledImmutableList                     = NewImmutableList             (1, 2, 3);
    public static readonly ImmutableList<int>.Builder         FilledImmutableListBuilder              = NewImmutableListBuilder      (1, 2, 3);
    public static readonly ImmutableHashSet<int>              FilledImmutableHashSet                  = NewImmutableHashSet          (1, 2, 3);
    public static readonly ImmutableHashSet<int>.Builder      FilledImmutableHashSetBuilder           = NewImmutableHashSetBuilder   (1, 2, 3);
    public static readonly ImmutableStack<int>                FilledImmutableStack                    = NewImmutableStack            (1, 2, 3);
    public static readonly ImmutableQueue<int>                FilledImmutableQueue                    = NewImmutableQueue            (1, 2, 3);
    public static readonly ImmutableDictionary<int, int>      FilledImmutableDict                     = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableDictBuilder               FilledImmutableDictBuilder              = NewImmutableDictBuilder      (1, 2, 3);
    public static readonly ImmutableSortedSet<int>            FilledImmutableSortedSet                = NewImmutableSortedSet        (1, 2, 3);
    public static readonly ImmutableSortedSet<int>.Builder    FilledImmutableSortedSetBuilder         = NewImmutableSortedSetBuilder (1, 2, 3);
    public static readonly ImmutableSortedDict                FilledImmutableSortedDict               = NewImmutableSortedDict       (1, 2, 3);
    public static readonly ImmutableSortedDictBuilder         FilledImmutableSortedDictBuilder        = NewImmutableSortedDictBuilder(1, 2, 3);
    public static readonly IReadOnlyCollection<int>           FilledIReadOnlyColl                     =                              [1, 2, 3];
    public static readonly IReadOnlyList<int>                 FilledIReadOnlyList                     =                              [1, 2, 3];
    public static readonly IReadOnlyDictionary<int,int>       FilledIReadOnlyDict                     = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyCollection<int>            FilledReadOnlyColl                      = NewReadOnlyColl              (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>        FilledReadOnlyDict                      = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyDictKeys                   FilledReadOnlyDictKeys                  = NewReadOnlyDictKeys          (1, 2, 3);
    public static readonly ReadOnlyDictVals                   FilledReadOnlyDictVals                  = NewReadOnlyDictVals          (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                                                                 
    public static readonly IReadOnlySet<int>                  FilledIReadOnlySet                      = NewReadOnlySet               (1, 2, 3);
    public static readonly ReadOnlySet<int>                   FilledReadOnlySet                       = NewReadOnlySet               (1, 2, 3);
    #endif
    public static readonly ConcurrentBag<int>                 FilledConcurrentBag                     =                              [1, 2, 3];
    public static readonly ConcurrentQueue<int>               FilledConcurrentQueue                   = NewConcurrentQueue           (1, 2, 3);
    public static readonly ConcurrentStack<int>               FilledConcurrentStack                   = NewConcurrentStack           (1, 2, 3);
    public static readonly ConcurrentDictionary<int,int>      FilledConcurrentDict                    = NewConcurrentDict            (1, 2, 3);
    public static readonly BlockingCollection<int>            FilledBlockingColl                      =                              [1, 2, 3];
    public static readonly IProducerConsumerCollection<int>   FilledIProducerConsumerColl             = NewProducerConsumerColl      (1, 2, 3);
    public static readonly SortedDict                         FilledSortedDict                        = NewSortedDict                (1, 2, 3);
    public static readonly SortedDictKeys                     FilledSortedDictKeys                    = NewSortedDictKeys            (1, 2, 3);
    public static readonly SortedDictVals                     FilledSortedDictVals                    = NewSortedDictVals            (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                             
    public static readonly OrderedDict                        FilledOrderedDict                       = NewOrderedDict               (1, 2, 3);
    public static readonly OrderedDictKeys                    FilledOrderedDictKeys                   = NewOrderedDictKeys           (1, 2, 3);
    public static readonly OrderedDictVals                    FilledOrderedDictVals                   = NewOrderedDictVals           (1, 2, 3);
    #endif                                                                                            
    #if NET6_0_OR_GREATER                                                                             
    public static readonly PriorityQueue<int,int>             FilledPrioQueue                         = NewPrioQueue                 (1, 2, 3);
    public static readonly PrioQueueUnorderedColl             FilledPrioQueueUnorderedColl            = NewPrioQueueUnorderedColl    (1, 2, 3);
    #endif                                                                                            
    public static readonly Collection<int>                    FilledColl                              =                              [1, 2, 3];
    public static readonly KeyedCollection<int,int>           FilledKeyedColl                         = NewKeyedColl                 (1, 2, 3);
    public static readonly ObservableCollection<int>          FilledObservableColl                    =                              [1, 2, 3];
    public static readonly ReadOnlyObservableCollection<int>  FilledReadOnlyObservableColl            = NewReadOnlyObservableColl    (1, 2, 3);
    public static readonly ArrayList                          FilledArrayList                         =                              [1, 2, 3];    
    public static readonly BitArray                           FilledBitArray                          = NewBitArray                  (1, 2, 3);
    public static readonly CollectionBase                     FilledCollBase                          = NewCollectionBase            (1, 2, 3);
    public static readonly DictionaryBase                     FilledDictBase                          = NewDictionaryBase            (1, 2, 3);
    public static readonly Hashtable                          FilledHashtable                         = NewHashtable                 (1, 2, 3);
    public static readonly Queue                              FilledQueueNonGeneric                   = NewQueueNonGeneric           (1, 2, 3);
    public static readonly ReadOnlyCollectionBase             FilledReadOnlyCollBase                  = NewReadOnlyCollBase          (1, 2, 3);
    public static readonly SortedList                         FilledSortedListNonGeneric              = NewSortedListNonGeneric      (1, 2, 3);
    public static readonly Stack                              FilledStackNonGeneric                   = NewStackNonGeneric           (1, 2, 3);
    public static readonly HybridDictionary                   FilledHybridDict                        = NewHybridDict                (1, 2, 3);
    public static readonly ListDictionary                     FilledListDict                          = NewListDict                  (1, 2, 3);
    public static readonly NameObjCollBase                    FilledNameObjectCollBase                = NewNameObjectCollBase        (1, 2, 3);
    public static readonly NameObjCollBaseKeys                FilledNameObjectCollBaseKeys            = NewNameObjectCollBaseKeys    (1, 2, 3);
    public static readonly NameValueCollection                FilledNameValueColl                     = NewNameValueColl             (1, 2, 3);
    public static readonly OrderedDictionary                  FilledOrderedDictNonGeneric             = NewOrderedDictNonGeneric     (1, 2, 3);
    public static readonly StringCollection                   FilledStringColl                        = NewStringColl                (1, 2, 3);
    public static readonly StringDictionary                   FilledStringDict                        = NewStringDict                (1, 2, 3);
    public static readonly IOrderedDictionary                 FilledIOrderedDict                      = NewOrderedDictNonGeneric     (1, 2, 3);
    
    public static readonly int[]                            ? NullyFilledArray                        =                              [1, 2, 3];
    public static readonly IList<int>                       ? NullyFilledIList                        =                              [1, 2, 3];
    public static readonly ISet<int>                        ? NullyFilledISet                         = NewHashSet                   (1, 2, 3);
    public static readonly IDictionary<int, int>            ? NullyFilledIDict                        = NewDict                      (1, 2, 3);
    public static readonly ICollection<int>                 ? NullyFilledIColl                        =                              [1, 2, 3];
    public static readonly IEnumerable<int>                 ? NullyFilledIEnumerable                  =                              [1, 2, 3];
    public static readonly List<int>                        ? NullyFilledList                         =                              [1, 2, 3];
    public static readonly HashSet<int>                     ? NullyFilledHashSet                      =                              [1, 2, 3];
    public static readonly Stack<int>                       ? NullyFilledStack                        = NewStack                     (1, 2, 3);
    public static readonly Queue<int>                       ? NullyFilledQueue                        = NewQueue                     (1, 2, 3);
    public static readonly LinkedList<int>                  ? NullyFilledLinkedList                   = NewLinkedList                (1, 2, 3);
    public static readonly SortedList<int, int>             ? NullyFilledSortedList                   = NewSortedList                (1, 2, 3);
    public static readonly SortedSet<int>                   ? NullyFilledSortedSet                    = NewSortedSet                 (1, 2, 3);
    public static readonly Dictionary<int, int>             ? NullyFilledDict                         = NewDict                      (1, 2, 3);
    public static readonly DictKeyColl                      ? NullyFilledDictKeyColl                  = NewDictKeys                  (1, 2, 3);
    public static readonly DictValColl                      ? NullyFilledDictValColl                  = NewDictVals                  (1, 2, 3);
    public static readonly IImmutableList<int>              ? NullyFilledIImmutableList               = NewImmutableList             (1, 2, 3);
    public static readonly IImmutableSet<int>               ? NullyFilledIImmutableSet                = NewImmutableHashSet          (1, 2, 3);
    public static readonly IImmutableStack<int>             ? NullyFilledIImmutableStack              = NewImmutableStack            (1, 2, 3);
    public static readonly IImmutableQueue<int>             ? NullyFilledIImmutableQueue              = NewImmutableQueue            (1, 2, 3);
    public static readonly IImmutableDictionary<int, int>   ? NullyFilledIImmutableDict               = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableArray<int>              ? NullyFilledImmutableArray               = NewImmutableArray            (1, 2, 3);
    public static readonly ImmutableArray<int>.Builder      ? NullyFilledImmutableArrayBuilder        = NewImmutableArrayBuilder     (1, 2, 3);
    public static readonly ImmutableList<int>               ? NullyFilledImmutableList                = NewImmutableList             (1, 2, 3);
    public static readonly ImmutableList<int>.Builder       ? NullyFilledImmutableListBuilder         = NewImmutableListBuilder      (1, 2, 3);
    public static readonly ImmutableHashSet<int>            ? NullyFilledImmutableHashSet             = NewImmutableHashSet          (1, 2, 3);
    public static readonly ImmutableHashSet<int>.Builder    ? NullyFilledImmutableHashSetBuilder      = NewImmutableHashSetBuilder   (1, 2, 3);
    public static readonly ImmutableStack<int>              ? NullyFilledImmutableStack               = NewImmutableStack            (1, 2, 3);
    public static readonly ImmutableQueue<int>              ? NullyFilledImmutableQueue               = NewImmutableQueue            (1, 2, 3);
    public static readonly ImmutableDictionary<int, int>    ? NullyFilledImmutableDict                = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableDictBuilder             ? NullyFilledImmutableDictBuilder         = NewImmutableDictBuilder      (1, 2, 3);
    public static readonly ImmutableSortedSet<int>          ? NullyFilledImmutableSortedSet           = NewImmutableSortedSet        (1, 2, 3);
    public static readonly ImmutableSortedSet<int>.Builder  ? NullyFilledImmutableSortedSetBuilder    = NewImmutableSortedSetBuilder (1, 2, 3);
    public static readonly ImmutableSortedDict              ? NullyFilledImmutableSortedDict          = NewImmutableSortedDict       (1, 2, 3);
    public static readonly ImmutableSortedDictBuilder       ? NullyFilledImmutableSortedDictBuilder   = NewImmutableSortedDictBuilder(1, 2, 3);
    public static readonly IReadOnlyCollection<int>         ? NullyFilledIReadOnlyColl                =                              [1, 2, 3];
    public static readonly IReadOnlyList<int>               ? NullyFilledIReadOnlyList                =                              [1, 2, 3];
    public static readonly IReadOnlyDictionary<int,int>     ? NullyFilledIReadOnlyDict                = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyCollection<int>          ? NullyFilledReadOnlyColl                 = NewReadOnlyColl              (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>      ? NullyFilledReadOnlyDict                 = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyDictKeys                 ? NullyFilledReadOnlyDictKeys             = NewReadOnlyDictKeys          (1, 2, 3);
    public static readonly ReadOnlyDictVals                 ? NullyFilledReadOnlyDictVals             = NewReadOnlyDictVals          (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                                                                 
    public static readonly IReadOnlySet<int>                ? NullyFilledIReadOnlySet                 = NewReadOnlySet               (1, 2, 3);
    public static readonly ReadOnlySet<int>                 ? NullyFilledReadOnlySet                  = NewReadOnlySet               (1, 2, 3);
    #endif
    public static readonly ConcurrentBag<int>               ? NullyFilledConcurrentBag                =                              [1, 2, 3];
    public static readonly ConcurrentQueue<int>             ? NullyFilledConcurrentQueue              = NewConcurrentQueue           (1, 2, 3);
    public static readonly ConcurrentStack<int>             ? NullyFilledConcurrentStack              = NewConcurrentStack           (1, 2, 3);
    public static readonly ConcurrentDictionary<int,int>    ? NullyFilledConcurrentDict               = NewConcurrentDict            (1, 2, 3);
    public static readonly BlockingCollection<int>          ? NullyFilledBlockingColl                 =                              [1, 2, 3];
    public static readonly IProducerConsumerCollection<int> ? NullyFilledIProducerConsumerColl        = NewProducerConsumerColl      (1, 2, 3);
    public static readonly SortedDict                       ? NullyFilledSortedDict                   = NewSortedDict                (1, 2, 3);
    public static readonly SortedDictKeys                   ? NullyFilledSortedDictKeys               = NewSortedDictKeys            (1, 2, 3);
    public static readonly SortedDictVals                   ? NullyFilledSortedDictVals               = NewSortedDictVals            (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                        
    public static readonly OrderedDict                      ? NullyFilledOrderedDict                  = NewOrderedDict               (1, 2, 3);
    public static readonly OrderedDictKeys                  ? NullyFilledOrderedDictKeys              = NewOrderedDictKeys           (1, 2, 3);
    public static readonly OrderedDictVals                  ? NullyFilledOrderedDictVals              = NewOrderedDictVals           (1, 2, 3);
    #endif                                                    
    #if NET6_0_OR_GREATER                                                                             
    public static readonly PriorityQueue<int,int>           ? NullyFilledPrioQueue                    = NewPrioQueue                 (1, 2, 3);
    public static readonly PrioQueueUnorderedColl           ? NullyFilledPrioQueueUnorderedColl       = NewPrioQueueUnorderedColl    (1, 2, 3);
    #endif                                                                                       
    public static readonly Collection<int>                  ? NullyFilledColl                         =                              [1, 2, 3];
    public static readonly KeyedCollection<int,int>         ? NullyFilledKeyedColl                    = NewKeyedColl                 (1, 2, 3);
    public static readonly ObservableCollection<int>        ? NullyFilledObservableColl               =                              [1, 2, 3];
    public static readonly ReadOnlyObservableCollection<int>? NullyFilledReadOnlyObservableColl       = NewReadOnlyObservableColl    (1, 2, 3);
    public static readonly ArrayList                        ? NullyFilledArrayList                    =                              [1, 2, 3];    
    public static readonly BitArray                         ? NullyFilledBitArray                     = NewBitArray                  (1, 2, 3);
    public static readonly CollectionBase                   ? NullyFilledCollBase                     = NewCollectionBase            (1, 2, 3);
    public static readonly DictionaryBase                   ? NullyFilledDictBase                     = NewDictionaryBase            (1, 2, 3);
    public static readonly Hashtable                        ? NullyFilledHashtable                    = NewHashtable                 (1, 2, 3);
    public static readonly Queue                            ? NullyFilledQueueNonGeneric              = NewQueueNonGeneric           (1, 2, 3);
    public static readonly ReadOnlyCollectionBase           ? NullyFilledReadOnlyCollBase             = NewReadOnlyCollBase          (1, 2, 3);
    public static readonly SortedList                       ? NullyFilledSortedListNonGeneric         = NewSortedListNonGeneric      (1, 2, 3);
    public static readonly Stack                            ? NullyFilledStackNonGeneric              = NewStackNonGeneric           (1, 2, 3);
    public static readonly HybridDictionary                 ? NullyFilledHybridDict                   = NewHybridDict                (1, 2, 3);
    public static readonly ListDictionary                   ? NullyFilledListDict                     = NewListDict                  (1, 2, 3);
    public static readonly NameObjCollBase                  ? NullyFilledNameObjectCollBase           = NewNameObjectCollBase        (1, 2, 3);
    public static readonly NameObjCollBaseKeys              ? NullyFilledNameObjectCollBaseKeys       = NewNameObjectCollBaseKeys    (1, 2, 3);
    public static readonly NameValueCollection              ? NullyFilledNameValueColl                = NewNameValueColl             (1, 2, 3);
    public static readonly OrderedDictionary                ? NullyFilledOrderedDictNonGeneric        = NewOrderedDictNonGeneric     (1, 2, 3);
    public static readonly StringCollection                 ? NullyFilledStringColl                   = NewStringColl                (1, 2, 3);
    public static readonly StringDictionary                 ? NullyFilledStringDict                   = NewStringDict                (1, 2, 3);
    public static readonly IOrderedDictionary               ? NullyFilledIOrderedDict                 = NewOrderedDictNonGeneric     (1, 2, 3);
    
    public static readonly int[]                              EmptyArray                              =                              [];
    public static readonly IList<int>                         EmptyIList                              =                              [];
    public static readonly ISet<int>                          EmptyISet                               = NewHashSet                   ();
    public static readonly IDictionary<int, int>              EmptyIDict                              = NewDict                      ();
    public static readonly ICollection<int>                   EmptyIColl                              =                              [];
    public static readonly IEnumerable<int>                   EmptyIEnumerable                        =                              [];
    public static readonly List<int>                          EmptyList                               =                              [];
    public static readonly HashSet<int>                       EmptyHashSet                            =                              [];
    public static readonly Stack<int>                         EmptyStack                              = NewStack                     ();
    public static readonly Queue<int>                         EmptyQueue                              = NewQueue                     ();
    public static readonly LinkedList<int>                    EmptyLinkedList                         = NewLinkedList                ();
    public static readonly SortedList<int, int>               EmptySortedList                         = NewSortedList                ();
    public static readonly SortedSet<int>                     EmptySortedSet                          = NewSortedSet                 ();
    public static readonly Dictionary<int, int>               EmptyDict                               = NewDict                      ();
    public static readonly DictKeyColl                        EmptyDictKeyColl                        = NewDictKeys                  ();
    public static readonly DictValColl                        EmptyDictValColl                        = NewDictVals                  ();
    public static readonly IImmutableList<int>                EmptyIImmutableList                     = NewImmutableList             ();
    public static readonly IImmutableSet<int>                 EmptyIImmutableSet                      = NewImmutableHashSet          ();
    public static readonly IImmutableStack<int>               EmptyIImmutableStack                    = NewImmutableStack            ();
    public static readonly IImmutableQueue<int>               EmptyIImmutableQueue                    = NewImmutableQueue            ();
    public static readonly IImmutableDictionary<int, int>     EmptyIImmutableDict                     = NewImmutableDict             ();
    public static readonly ImmutableArray<int>                EmptyImmutableArray                     = NewImmutableArray            ();
    public static readonly ImmutableArray<int>.Builder        EmptyImmutableArrayBuilder              = NewImmutableArrayBuilder     ();
    public static readonly ImmutableList<int>                 EmptyImmutableList                      = NewImmutableList             ();
    public static readonly ImmutableList<int>.Builder         EmptyImmutableListBuilder               = NewImmutableListBuilder      ();
    public static readonly ImmutableHashSet<int>              EmptyImmutableHashSet                   = NewImmutableHashSet          ();
    public static readonly ImmutableHashSet<int>.Builder      EmptyImmutableHashSetBuilder            = NewImmutableHashSetBuilder   ();
    public static readonly ImmutableStack<int>                EmptyImmutableStack                     = NewImmutableStack            ();
    public static readonly ImmutableQueue<int>                EmptyImmutableQueue                     = NewImmutableQueue            ();
    public static readonly ImmutableDictionary<int, int>      EmptyImmutableDict                      = NewImmutableDict             ();
    public static readonly ImmutableDictBuilder               EmptyImmutableDictBuilder               = NewImmutableDictBuilder      ();
    public static readonly ImmutableSortedSet<int>            EmptyImmutableSortedSet                 = NewImmutableSortedSet        ();
    public static readonly ImmutableSortedSet<int>.Builder    EmptyImmutableSortedSetBuilder          = NewImmutableSortedSetBuilder ();
    public static readonly ImmutableSortedDict                EmptyImmutableSortedDict                = NewImmutableSortedDict       ();
    public static readonly ImmutableSortedDictBuilder         EmptyImmutableSortedDictBuilder         = NewImmutableSortedDictBuilder();
    public static readonly IReadOnlyCollection<int>           EmptyIReadOnlyColl                      =                              [];
    public static readonly IReadOnlyList<int>                 EmptyIReadOnlyList                      =                              [];
    public static readonly IReadOnlyDictionary<int,int>       EmptyIReadOnlyDict                      = NewReadOnlyDict              ();
    public static readonly ReadOnlyCollection<int>            EmptyReadOnlyColl                       = NewReadOnlyColl              ();
    public static readonly ReadOnlyDictionary<int,int>        EmptyReadOnlyDict                       = NewReadOnlyDict              ();
    public static readonly ReadOnlyDictKeys                   EmptyReadOnlyDictKeys                   = NewReadOnlyDictKeys          ();
    public static readonly ReadOnlyDictVals                   EmptyReadOnlyDictVals                   = NewReadOnlyDictVals          ();
    #if NET9_0_OR_GREATER                                                                                                                       
    public static readonly IReadOnlySet<int>                  EmptyIReadOnlySet                       = NewReadOnlySet               ();
    public static readonly ReadOnlySet<int>                   EmptyReadOnlySet                        = NewReadOnlySet               ();
    #endif
    public static readonly ConcurrentBag<int>                 EmptyConcurrentBag                      =                              [];
    public static readonly ConcurrentQueue<int>               EmptyConcurrentQueue                    =                              [];
    public static readonly ConcurrentStack<int>               EmptyConcurrentStack                    =                              [];
    public static readonly ConcurrentDictionary<int,int>      EmptyConcurrentDict                     =                              [];
    public static readonly BlockingCollection<int>            EmptyBlockingColl                       =                              [];
    public static readonly IProducerConsumerCollection<int>   EmptyIProducerConsumerColl              = NewProducerConsumerColl      ();
    public static readonly SortedDict                         EmptySortedDict                         =                              [];
    public static readonly SortedDictKeys                     EmptySortedDictKeys                     = NewSortedDictKeys            ();
    public static readonly SortedDictVals                     EmptySortedDictVals                     = NewSortedDictVals            ();
    #if NET9_0_OR_GREATER                                                                             
    public static readonly OrderedDict                        EmptyOrderedDict                        =                              [];
    public static readonly OrderedDictKeys                    EmptyOrderedDictKeys                    = NewOrderedDictKeys           ();
    public static readonly OrderedDictVals                    EmptyOrderedDictVals                    = NewOrderedDictVals           ();
    #endif                                                    
    #if NET6_0_OR_GREATER                                                                                     
    public static readonly PriorityQueue<int,int>             EmptyPrioQueue                          = NewPrioQueue                 ();
    public static readonly PrioQueueUnorderedColl             EmptyPrioQueueUnorderedColl             = NewPrioQueueUnorderedColl    ();
    #endif                                                                                            
    public static readonly Collection<int>                    EmptyColl                               =                              [];
    public static readonly KeyedCollection<int,int>           EmptyKeyedColl                          = NewKeyedColl                 ();
    public static readonly ObservableCollection<int>          EmptyObservableColl                     =                              [];
    public static readonly ReadOnlyObservableCollection<int>  EmptyReadOnlyObservableColl             = NewReadOnlyObservableColl    ();
    public static readonly ArrayList                          EmptyArrayList                          =                              [];    
    public static readonly BitArray                           EmptyBitArray                           = NewBitArray                  ();
    public static readonly CollectionBase                     EmptyCollBase                           = NewCollectionBase            ();
    public static readonly DictionaryBase                     EmptyDictBase                           = NewDictionaryBase            ();
    public static readonly Hashtable                          EmptyHashtable                          =                              [];    
    public static readonly Queue                              EmptyQueueNonGeneric                    =                              [];    
    public static readonly ReadOnlyCollectionBase             EmptyReadOnlyCollBase                   = NewReadOnlyCollBase          ();
    public static readonly SortedList                         EmptySortedListNonGeneric               =                              [];    
    public static readonly Stack                              EmptyStackNonGeneric                    =                              [];    
    public static readonly HybridDictionary                   EmptyHybridDict                         =                              [];
    public static readonly ListDictionary                     EmptyListDict                           =                              [];
    public static readonly NameObjCollBase                    EmptyNameObjectCollBase                 = NewNameObjectCollBase        ();
    public static readonly NameObjCollBaseKeys                EmptyNameObjectCollBaseKeys             = NewNameObjectCollBaseKeys    ();
    public static readonly NameValueCollection                EmptyNameValueColl                      =                              [];
    public static readonly OrderedDictionary                  EmptyOrderedDictNonGeneric              =                              [];
    public static readonly StringCollection                   EmptyStringColl                         =                              [];
    public static readonly StringDictionary                   EmptyStringDict                         =                              [];
    public static readonly IOrderedDictionary                 EmptyIOrderedDict                       = NewOrderedDictNonGeneric     ();
    
    public static readonly int[]                            ? NullableEmptyArray                      =                              [];
    public static readonly IList<int>                       ? NullableEmptyIList                      =                              [];
    public static readonly ISet<int>                        ? NullableEmptyISet                       = NewHashSet                   ();
    public static readonly IDictionary<int, int>            ? NullableEmptyIDict                      = NewDict                      ();
    public static readonly ICollection<int>                 ? NullableEmptyIColl                      =                              [];
    public static readonly IEnumerable<int>                 ? NullableEmptyIEnumerable                =                              [];
    public static readonly List<int>                        ? NullableEmptyList                       =                              [];
    public static readonly HashSet<int>                     ? NullableEmptyHashSet                    =                              [];
    public static readonly Stack<int>                       ? NullableEmptyStack                      = NewStack                     ();
    public static readonly Queue<int>                       ? NullableEmptyQueue                      = NewQueue                     ();
    public static readonly LinkedList<int>                  ? NullableEmptyLinkedList                 = NewLinkedList                ();
    public static readonly SortedList<int, int>             ? NullableEmptySortedList                 = NewSortedList                ();
    public static readonly SortedSet<int>                   ? NullableEmptySortedSet                  = NewSortedSet                 ();
    public static readonly Dictionary<int, int>             ? NullableEmptyDict                       = NewDict                      ();
    public static readonly DictKeyColl                      ? NullableEmptyDictKeyColl                = NewDictKeys                  ();
    public static readonly DictValColl                      ? NullableEmptyDictValColl                = NewDictVals                  ();
    public static readonly IImmutableList<int>              ? NullableEmptyIImmutableList             = NewImmutableList             ();
    public static readonly IImmutableSet<int>               ? NullableEmptyIImmutableSet              = NewImmutableHashSet          ();
    public static readonly IImmutableStack<int>             ? NullableEmptyIImmutableStack            = NewImmutableStack            ();
    public static readonly IImmutableQueue<int>             ? NullableEmptyIImmutableQueue            = NewImmutableQueue            ();
    public static readonly IImmutableDictionary<int, int>   ? NullableEmptyIImmutableDict             = NewImmutableDict             ();
    public static readonly ImmutableArray<int>              ? NullableEmptyImmutableArray             = NewImmutableArray            ();
    public static readonly ImmutableArray<int>.Builder      ? NullableEmptyImmutableArrayBuilder      = NewImmutableArrayBuilder     ();
    public static readonly ImmutableList<int>               ? NullableEmptyImmutableList              = NewImmutableList             ();
    public static readonly ImmutableList<int>.Builder       ? NullableEmptyImmutableListBuilder       = NewImmutableListBuilder      ();
    public static readonly ImmutableHashSet<int>            ? NullableEmptyImmutableHashSet           = NewImmutableHashSet          ();
    public static readonly ImmutableHashSet<int>.Builder    ? NullableEmptyImmutableHashSetBuilder    = NewImmutableHashSetBuilder   ();
    public static readonly ImmutableStack<int>              ? NullableEmptyImmutableStack             = NewImmutableStack            ();
    public static readonly ImmutableQueue<int>              ? NullableEmptyImmutableQueue             = NewImmutableQueue            ();
    public static readonly ImmutableDictionary<int, int>    ? NullableEmptyImmutableDict              = NewImmutableDict             ();
    public static readonly ImmutableDictBuilder             ? NullableEmptyImmutableDictBuilder       = NewImmutableDictBuilder      ();
    public static readonly ImmutableSortedSet<int>          ? NullableEmptyImmutableSortedSet         = NewImmutableSortedSet        ();
    public static readonly ImmutableSortedSet<int>.Builder  ? NullableEmptyImmutableSortedSetBuilder  = NewImmutableSortedSetBuilder ();
    public static readonly ImmutableSortedDict              ? NullableEmptyImmutableSortedDict        = NewImmutableSortedDict       ();
    public static readonly ImmutableSortedDictBuilder       ? NullableEmptyImmutableSortedDictBuilder = NewImmutableSortedDictBuilder();
    public static readonly IReadOnlyCollection<int>         ? NullableEmptyIReadOnlyColl              =                              [];
    public static readonly IReadOnlyList<int>               ? NullableEmptyIReadOnlyList              =                              [];
    public static readonly IReadOnlyDictionary<int,int>     ? NullableEmptyIReadOnlyDict              = NewReadOnlyDict              ();
    public static readonly ReadOnlyCollection<int>          ? NullableEmptyReadOnlyColl               = NewReadOnlyColl              ();
    public static readonly ReadOnlyDictionary<int,int>      ? NullableEmptyReadOnlyDict               = NewReadOnlyDict              ();
    public static readonly ReadOnlyDictKeys                 ? NullableEmptyReadOnlyDictKeys           = NewReadOnlyDictKeys          ();
    public static readonly ReadOnlyDictVals                 ? NullableEmptyReadOnlyDictVals           = NewReadOnlyDictVals          ();
    #if NET9_0_OR_GREATER                                                                                                                       
    public static readonly IReadOnlySet<int>                ? NullableEmptyIReadOnlySet               = NewReadOnlySet               ();
    public static readonly ReadOnlySet<int>                 ? NullableEmptyReadOnlySet                = NewReadOnlySet               ();
    #endif
    public static readonly ConcurrentBag<int>               ? NullableEmptyConcurrentBag              =                              [];
    public static readonly ConcurrentQueue<int>             ? NullableEmptyConcurrentQueue            =                              [];
    public static readonly ConcurrentStack<int>             ? NullableEmptyConcurrentStack            =                              [];
    public static readonly ConcurrentDictionary<int,int>    ? NullableEmptyConcurrentDict             =                              [];
    public static readonly BlockingCollection<int>          ? NullableEmptyBlockingColl               =                              [];
    public static readonly IProducerConsumerCollection<int> ? NullableEmptyIProducerConsumerColl      = NewProducerConsumerColl      ();
    public static readonly SortedDict                       ? NullableEmptySortedDict                 =                              [];
    public static readonly SortedDictKeys                   ? NullableEmptySortedDictKeys             = NewSortedDictKeys            ();
    public static readonly SortedDictVals                   ? NullableEmptySortedDictVals             = NewSortedDictVals            ();
    #if NET9_0_OR_GREATER                                                                             
    public static readonly OrderedDict                      ? NullableEmptyOrderedDict                =                              [];
    public static readonly OrderedDictKeys                  ? NullableEmptyOrderedDictKeys            = NewOrderedDictKeys           ();
    public static readonly OrderedDictVals                  ? NullableEmptyOrderedDictVals            = NewOrderedDictVals           ();
    #endif
    #if NET6_0_OR_GREATER                                                                             
    public static readonly PriorityQueue<int,int>           ? NullableEmptyPrioQueue                  = NewPrioQueue                 ();
    public static readonly PrioQueueUnorderedColl           ? NullableEmptyPrioQueueUnorderedColl     = NewPrioQueueUnorderedColl    ();
    #endif                                                                                            
    public static readonly Collection<int>                  ? NullableEmptyColl                       =                              [];
    public static readonly KeyedCollection<int,int>         ? NullableEmptyKeyedColl                  = NewKeyedColl                 ();
    public static readonly ObservableCollection<int>        ? NullableEmptyObservableColl             =                              [];
    public static readonly ReadOnlyObservableCollection<int>? NullableEmptyReadOnlyObservableColl     = NewReadOnlyObservableColl    ();
    public static readonly ArrayList                        ? NullableEmptyArrayList                  =                              [];    
    public static readonly BitArray                         ? NullableEmptyBitArray                   = NewBitArray                  ();
    public static readonly CollectionBase                   ? NullableEmptyCollBase                   = NewCollectionBase            ();
    public static readonly DictionaryBase                   ? NullableEmptyDictBase                   = NewDictionaryBase            ();
    public static readonly Hashtable                        ? NullableEmptyHashtable                  =                              [];    
    public static readonly Queue                            ? NullableEmptyQueueNonGeneric            =                              [];    
    public static readonly ReadOnlyCollectionBase           ? NullableEmptyReadOnlyCollBase           = NewReadOnlyCollBase          ();
    public static readonly SortedList                       ? NullableEmptySortedListNonGeneric       =                              [];    
    public static readonly Stack                            ? NullableEmptyStackNonGeneric            =                              [];    
    public static readonly HybridDictionary                 ? NullableEmptyHybridDict                 =                              [];
    public static readonly ListDictionary                   ? NullableEmptyListDict                   =                              [];
    public static readonly NameObjCollBase                  ? NullableEmptyNameObjectCollBase         = NewNameObjectCollBase        ();
    public static readonly NameObjCollBaseKeys              ? NullableEmptyNameObjectCollBaseKeys     = NewNameObjectCollBaseKeys    ();
    public static readonly NameValueCollection              ? NullableEmptyNameValueColl              =                              [];
    public static readonly OrderedDictionary                ? NullableEmptyOrderedDictNonGeneric      =                              [];
    public static readonly StringCollection                 ? NullableEmptyStringColl                 =                              [];
    public static readonly StringDictionary                 ? NullableEmptyStringDict                 =                              [];
    public static readonly IOrderedDictionary               ? NullableEmptyIOrderedDict               = NewOrderedDictNonGeneric     ();

    public static readonly int[]                            ? NullArray                               = null;
    public static readonly IList<int>                       ? NullIList                               = null;
    public static readonly ISet<int>                        ? NullISet                                = null;
    public static readonly IDictionary<int, int>            ? NullIDict                               = null;
    public static readonly ICollection<int>                 ? NullIColl                               = null;
    public static readonly IEnumerable<int>                 ? NullIEnumerable                         = null;
    public static readonly List<int>                        ? NullList                                = null;
    public static readonly HashSet<int>                     ? NullHashSet                             = null;
    public static readonly Stack<int>                       ? NullStack                               = null;
    public static readonly Queue<int>                       ? NullQueue                               = null;
    public static readonly LinkedList<int>                  ? NullLinkedList                          = null;
    public static readonly SortedList<int, int>             ? NullSortedList                          = null;
    public static readonly SortedSet<int>                   ? NullSortedSet                           = null;
    public static readonly Dictionary<int, int>             ? NullDict                                = null;
    public static readonly DictKeyColl                      ? NullDictKeyColl                         = null;
    public static readonly DictValColl                      ? NullDictValColl                         = null;
    public static readonly IImmutableList<int>              ? NullIImmutableList                      = null;
    public static readonly IImmutableSet<int>               ? NullIImmutableSet                       = null;
    public static readonly IImmutableStack<int>             ? NullIImmutableStack                     = null;
    public static readonly IImmutableQueue<int>             ? NullIImmutableQueue                     = null;
    public static readonly IImmutableDictionary<int, int>   ? NullIImmutableDict                      = null;
    public static readonly ImmutableArray<int>              ? NullImmutableArray                      = null;
    public static readonly ImmutableArray<int>.Builder      ? NullImmutableArrayBuilder               = null;
    public static readonly ImmutableList<int>               ? NullImmutableList                       = null;
    public static readonly ImmutableList<int>.Builder       ? NullImmutableListBuilder                = null;
    public static readonly ImmutableHashSet<int>            ? NullImmutableHashSet                    = null;
    public static readonly ImmutableHashSet<int>.Builder    ? NullImmutableHashSetBuilder             = null;
    public static readonly ImmutableStack<int>              ? NullImmutableStack                      = null;
    public static readonly ImmutableQueue<int>              ? NullImmutableQueue                      = null;
    public static readonly ImmutableDictionary<int, int>    ? NullImmutableDict                       = null;
    public static readonly ImmutableDictBuilder             ? NullImmutableDictBuilder                = null;
    public static readonly ImmutableSortedSet<int>          ? NullImmutableSortedSet                  = null;
    public static readonly ImmutableSortedSet<int>.Builder  ? NullImmutableSortedSetBuilder           = null;
    public static readonly ImmutableSortedDict              ? NullImmutableSortedDict                 = null;
    public static readonly ImmutableSortedDictBuilder       ? NullImmutableSortedDictBuilder          = null;
    public static readonly IReadOnlyCollection<int>         ? NullIReadOnlyColl                       = null;
    public static readonly IReadOnlyList<int>               ? NullIReadOnlyList                       = null;
    public static readonly IReadOnlyDictionary<int,int>     ? NullIReadOnlyDict                       = null;
    public static readonly ReadOnlyCollection<int>          ? NullReadOnlyColl                        = null;
    public static readonly ReadOnlyDictionary<int,int>      ? NullReadOnlyDict                        = null;
    public static readonly ReadOnlyDictKeys                 ? NullReadOnlyDictKeys                    = null;
    public static readonly ReadOnlyDictVals                 ? NullReadOnlyDictVals                    = null;
    #if NET9_0_OR_GREATER                                                                                                                                
    public static readonly IReadOnlySet<int>                ? NullIReadOnlySet                        = null;
    public static readonly ReadOnlySet<int>                 ? NullReadOnlySet                         = null;
    #endif
    public static readonly ConcurrentBag<int>               ? NullConcurrentBag                       = null;
    public static readonly ConcurrentQueue<int>             ? NullConcurrentQueue                     = null;
    public static readonly ConcurrentStack<int>             ? NullConcurrentStack                     = null;
    public static readonly ConcurrentDictionary<int,int>    ? NullConcurrentDict                      = null;
    public static readonly BlockingCollection<int>          ? NullBlockingColl                        = null;
    public static readonly IProducerConsumerCollection<int> ? NullIProducerConsumerColl               = null;
    public static readonly SortedDict                       ? NullSortedDict                          = null;
    public static readonly SortedDictKeys                   ? NullSortedDictKeys                      = null;
    public static readonly SortedDictVals                   ? NullSortedDictVals                      = null;
    #if NET9_0_OR_GREATER                                                                              
    public static readonly OrderedDict                      ? NullOrderedDict                         = null;
    public static readonly OrderedDictKeys                  ? NullOrderedDictKeys                     = null;
    public static readonly OrderedDictVals                  ? NullOrderedDictVals                     = null;
    #endif                                                                                                 
    #if NET6_0_OR_GREATER                                                                                  
    public static readonly PriorityQueue<int,int>           ? NullPrioQueue                           = null;
    public static readonly PrioQueueUnorderedColl           ? NullPrioQueueUnorderedColl              = null;
    #endif                                                                                                 
    public static readonly Collection<int>                  ? NullColl                                = null;
    public static readonly KeyedCollection<int,int>         ? NullKeyedColl                           = null;
    public static readonly ObservableCollection<int>        ? NullObservableColl                      = null;
    public static readonly ReadOnlyObservableCollection<int>? NullReadOnlyObservableColl              = null;
    public static readonly ArrayList                        ? NullArrayList                           = null;    
    public static readonly BitArray                         ? NullBitArray                            = null;    
    public static readonly CollectionBase                   ? NullCollBase                            = null;
    public static readonly DictionaryBase                   ? NullDictBase                            = null;
    public static readonly Hashtable                        ? NullHashtable                           = null;    
    public static readonly Queue                            ? NullQueueNonGeneric                     = null;    
    public static readonly ReadOnlyCollectionBase           ? NullReadOnlyCollBase                    = null;
    public static readonly SortedList                       ? NullSortedListNonGeneric                = null;    
    public static readonly Stack                            ? NullStackNonGeneric                     = null;    
    public static readonly HybridDictionary                 ? NullHybridDict                          = null;
    public static readonly ListDictionary                   ? NullListDict                            = null;
    public static readonly NameObjCollBase                  ? NullNameObjectCollBase                  = null;
    public static readonly NameObjCollBaseKeys              ? NullNameObjectCollBaseKeys              = null;
    public static readonly NameValueCollection              ? NullNameValueColl                       = null;
    public static readonly OrderedDictionary                ? NullOrderedDictNonGeneric               = null;
    public static readonly StringCollection                 ? NullStringColl                          = null;
    public static readonly StringDictionary                 ? NullStringDict                          = null;
    public static readonly IOrderedDictionary               ? NullIOrderedDict                        = null;
    
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
    private static ReadOnlyDictKeys NewReadOnlyDictKeys(params int[] nums) => NewReadOnlyDict(nums).Keys;
    private static ReadOnlyDictVals NewReadOnlyDictVals(params int[] nums) => NewReadOnlyDict(nums).Values;
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