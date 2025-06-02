using System.Collections.ObjectModel;
using DictKeyColl = System.Collections.Generic.Dictionary<int, int>.KeyCollection;
using DictValColl = System.Collections.Generic.Dictionary<int, int>.ValueCollection;
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
    
    public static readonly ImmutableArray<int>                          ImmutableArrayWithDefault               = default;
    public static readonly ImmutableArray<int>                        ? ImmutableArrayWithDefaultNullable       = default;
    public static readonly ImmutableArray<int>                          ImmutableArrayWithNew                   = new();
    public static readonly ImmutableArray<int>                        ? ImmutableArrayWithNewNullable           = new();

    public static readonly int[]                                        FilledArray                             =                              [1, 2, 3];
    public static readonly IList<int>                                   FilledIList                             =                              [1, 2, 3];
    public static readonly ISet<int>                                    FilledISet                              = NewHashSet                   (1, 2, 3);
    public static readonly IDictionary<int, int>                        FilledIDict                             = NewDict                      (1, 2, 3);
    public static readonly ICollection<int>                             FilledICollection                       =                              [1, 2, 3];
    public static readonly IEnumerable<int>                             FilledIEnumerable                       =                              [1, 2, 3];
    public static readonly List<int>                                    FilledList                              =                              [1, 2, 3];
    public static readonly HashSet<int>                                 FilledHashSet                           =                              [1, 2, 3];
    public static readonly Stack<int>                                   FilledStack                             = NewStack                     (1, 2, 3);
    public static readonly Queue<int>                                   FilledQueue                             = NewQueue                     (1, 2, 3);
    public static readonly LinkedList<int>                              FilledLinkedList                        = NewLinkedList                (1, 2, 3);
    public static readonly SortedList<int, int>                         FilledSortedList                        = NewSortedList                (1, 2, 3);
    public static readonly SortedSet<int>                               FilledSortedSet                         = NewSortedSet                 (1, 2, 3);
    public static readonly Dictionary<int, int>                         FilledDict                              = NewDict                      (1, 2, 3);
    public static readonly DictKeyColl                                  FilledDictKeyColl                       = NewDictKeys                  (1, 2, 3);
    public static readonly DictValColl                                  FilledDictValColl                       = NewDictVals                  (1, 2, 3);
    public static readonly IImmutableList<int>                          FilledIImmutableList                    = NewImmutableList             (1, 2, 3);
    public static readonly IImmutableSet<int>                           FilledIImmutableSet                     = NewImmutableHashSet          (1, 2, 3);
    public static readonly IImmutableStack<int>                         FilledIImmutableStack                   = NewImmutableStack            (1, 2, 3);
    public static readonly IImmutableQueue<int>                         FilledIImmutableQueue                   = NewImmutableQueue            (1, 2, 3);
    public static readonly IImmutableDictionary<int, int>               FilledIImmutableDict                    = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableArray<int>                          FilledImmutableArray                    = NewImmutableArray            (1, 2, 3);
    public static readonly ImmutableArray<int>.Builder                  FilledImmutableArrayBuilder             = NewImmutableArrayBuilder     (1, 2, 3);
    public static readonly ImmutableList<int>                           FilledImmutableList                     = NewImmutableList             (1, 2, 3);
    public static readonly ImmutableList<int>.Builder                   FilledImmutableListBuilder              = NewImmutableListBuilder      (1, 2, 3);
    public static readonly ImmutableHashSet<int>                        FilledImmutableHashSet                  = NewImmutableHashSet          (1, 2, 3);
    public static readonly ImmutableHashSet<int>.Builder                FilledImmutableHashSetBuilder           = NewImmutableHashSetBuilder   (1, 2, 3);
    public static readonly ImmutableStack<int>                          FilledImmutableStack                    = NewImmutableStack            (1, 2, 3);
    public static readonly ImmutableQueue<int>                          FilledImmutableQueue                    = NewImmutableQueue            (1, 2, 3);
    public static readonly ImmutableDictionary<int, int>                FilledImmutableDict                     = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableDictionary<int, int>.Builder        FilledImmutableDictBuilder              = NewImmutableDictBuilder      (1, 2, 3);
    public static readonly ImmutableSortedSet<int>                      FilledImmutableSortedSet                = NewImmutableSortedSet        (1, 2, 3);
    public static readonly ImmutableSortedSet<int>.Builder              FilledImmutableSortedSetBuilder         = NewImmutableSortedSetBuilder (1, 2, 3);
    public static readonly ImmutableSortedDictionary<int, int>          FilledImmutableSortedDict               = NewImmutableSortedDict       (1, 2, 3);
    public static readonly ImmutableSortedDictionary<int, int>.Builder  FilledImmutableSortedDictBuilder        = NewImmutableSortedDictBuilder(1, 2, 3);
    public static readonly IReadOnlyCollection<int>                     FilledIReadOnlyCollection               =                              [1, 2, 3];
    public static readonly IReadOnlyList<int>                           FilledIReadOnlyList                     =                              [1, 2, 3];
    public static readonly IReadOnlyDictionary<int,int>                 FilledIReadOnlyDict                     = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyCollection<int>                      FilledReadOnlyCollection                = NewReadOnlyColl              (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>                  FilledReadOnlyDict                      = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>.KeyCollection    FilledReadOnlyDictKeys                  = NewReadOnlyDictKeys          (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>.ValueCollection  FilledReadOnlyDictVals                  = NewReadOnlyDictVals          (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                                                                           
    public static readonly IReadOnlySet<int>                            FilledIReadOnlySet                      = NewReadOnlySet               (1, 2, 3);
    public static readonly ReadOnlySet<int>                             FilledReadOnlySet                       = NewReadOnlySet               (1, 2, 3);
    #endif

    public static readonly int[]                                      ? NullyFilledArray                        =                              [1, 2, 3];
    public static readonly IList<int>                                 ? NullyFilledIList                        =                              [1, 2, 3];
    public static readonly ISet<int>                                  ? NullyFilledISet                         = NewHashSet                   (1, 2, 3);
    public static readonly IDictionary<int, int>                      ? NullyFilledIDict                        = NewDict                      (1, 2, 3);
    public static readonly ICollection<int>                           ? NullyFilledICollection                  =                              [1, 2, 3];
    public static readonly IEnumerable<int>                           ? NullyFilledIEnumerable                  =                              [1, 2, 3];
    public static readonly List<int>                                  ? NullyFilledList                         =                              [1, 2, 3];
    public static readonly HashSet<int>                               ? NullyFilledHashSet                      =                              [1, 2, 3];
    public static readonly Stack<int>                                 ? NullyFilledStack                        = NewStack                     (1, 2, 3);
    public static readonly Queue<int>                                 ? NullyFilledQueue                        = NewQueue                     (1, 2, 3);
    public static readonly LinkedList<int>                            ? NullyFilledLinkedList                   = NewLinkedList                (1, 2, 3);
    public static readonly SortedList<int, int>                       ? NullyFilledSortedList                   = NewSortedList                (1, 2, 3);
    public static readonly SortedSet<int>                             ? NullyFilledSortedSet                    = NewSortedSet                 (1, 2, 3);
    public static readonly Dictionary<int, int>                       ? NullyFilledDict                         = NewDict                      (1, 2, 3);
    public static readonly DictKeyColl                                ? NullyFilledDictKeyColl                  = NewDictKeys                  (1, 2, 3);
    public static readonly DictValColl                                ? NullyFilledDictValColl                  = NewDictVals                  (1, 2, 3);
    public static readonly IImmutableList<int>                        ? NullyFilledIImmutableList               = NewImmutableList             (1, 2, 3);
    public static readonly IImmutableSet<int>                         ? NullyFilledIImmutableSet                = NewImmutableHashSet          (1, 2, 3);
    public static readonly IImmutableStack<int>                       ? NullyFilledIImmutableStack              = NewImmutableStack            (1, 2, 3);
    public static readonly IImmutableQueue<int>                       ? NullyFilledIImmutableQueue              = NewImmutableQueue            (1, 2, 3);
    public static readonly IImmutableDictionary<int, int>             ? NullyFilledIImmutableDict               = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableArray<int>                        ? NullyFilledImmutableArray               = NewImmutableArray            (1, 2, 3);
    public static readonly ImmutableArray<int>.Builder                ? NullyFilledImmutableArrayBuilder        = NewImmutableArrayBuilder     (1, 2, 3);
    public static readonly ImmutableList<int>                         ? NullyFilledImmutableList                = NewImmutableList             (1, 2, 3);
    public static readonly ImmutableList<int>.Builder                 ? NullyFilledImmutableListBuilder         = NewImmutableListBuilder      (1, 2, 3);
    public static readonly ImmutableHashSet<int>                      ? NullyFilledImmutableHashSet             = NewImmutableHashSet          (1, 2, 3);
    public static readonly ImmutableHashSet<int>.Builder              ? NullyFilledImmutableHashSetBuilder      = NewImmutableHashSetBuilder   (1, 2, 3);
    public static readonly ImmutableStack<int>                        ? NullyFilledImmutableStack               = NewImmutableStack            (1, 2, 3);
    public static readonly ImmutableQueue<int>                        ? NullyFilledImmutableQueue               = NewImmutableQueue            (1, 2, 3);
    public static readonly ImmutableDictionary<int, int>              ? NullyFilledImmutableDict                = NewImmutableDict             (1, 2, 3);
    public static readonly ImmutableDictionary<int, int>.Builder      ? NullyFilledImmutableDictBuilder         = NewImmutableDictBuilder      (1, 2, 3);
    public static readonly ImmutableSortedSet<int>                    ? NullyFilledImmutableSortedSet           = NewImmutableSortedSet        (1, 2, 3);
    public static readonly ImmutableSortedSet<int>.Builder            ? NullyFilledImmutableSortedSetBuilder    = NewImmutableSortedSetBuilder (1, 2, 3);
    public static readonly ImmutableSortedDictionary<int, int>        ? NullyFilledImmutableSortedDict          = NewImmutableSortedDict       (1, 2, 3);
    public static readonly ImmutableSortedDictionary<int, int>.Builder? NullyFilledImmutableSortedDictBuilder   = NewImmutableSortedDictBuilder(1, 2, 3);
    public static readonly IReadOnlyCollection<int>                   ? NullyFilledIReadOnlyCollection          =                              [1, 2, 3];
    public static readonly IReadOnlyList<int>                         ? NullyFilledIReadOnlyList                =                              [1, 2, 3];
    public static readonly IReadOnlyDictionary<int,int>               ? NullyFilledIReadOnlyDict                = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyCollection<int>                    ? NullyFilledReadOnlyCollection           = NewReadOnlyColl              (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>                ? NullyFilledReadOnlyDict                 = NewReadOnlyDict              (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>.KeyCollection  ? NullyFilledReadOnlyDictKeys             = NewReadOnlyDictKeys          (1, 2, 3);
    public static readonly ReadOnlyDictionary<int,int>.ValueCollection? NullyFilledReadOnlyDictVals             = NewReadOnlyDictVals          (1, 2, 3);
    #if NET9_0_OR_GREATER                                                                                                                           
    public static readonly IReadOnlySet<int>                          ? NullyFilledIReadOnlySet                 = NewReadOnlySet               (1, 2, 3);
    public static readonly ReadOnlySet<int>                           ? NullyFilledReadOnlySet                  = NewReadOnlySet               (1, 2, 3);
    #endif
    
    public static readonly int[]                                        EmptyArray                              =                              [];
    public static readonly IList<int>                                   EmptyIList                              =                              [];
    public static readonly ISet<int>                                    EmptyISet                               = NewHashSet                   ();
    public static readonly IDictionary<int, int>                        EmptyIDict                              = NewDict                      ();
    public static readonly ICollection<int>                             EmptyICollection                        =                              [];
    public static readonly IEnumerable<int>                             EmptyIEnumerable                        =                              [];
    public static readonly List<int>                                    EmptyList                               =                              [];
    public static readonly HashSet<int>                                 EmptyHashSet                            =                              [];
    public static readonly Stack<int>                                   EmptyStack                              = NewStack                     ();
    public static readonly Queue<int>                                   EmptyQueue                              = NewQueue                     ();
    public static readonly LinkedList<int>                              EmptyLinkedList                         = NewLinkedList                ();
    public static readonly SortedList<int, int>                         EmptySortedList                         = NewSortedList                ();
    public static readonly SortedSet<int>                               EmptySortedSet                          = NewSortedSet                 ();
    public static readonly Dictionary<int, int>                         EmptyDict                               = NewDict                      ();
    public static readonly DictKeyColl                                  EmptyDictKeyColl                        = NewDictKeys                  ();
    public static readonly DictValColl                                  EmptyDictValColl                        = NewDictVals                  ();
    public static readonly IImmutableList<int>                          EmptyIImmutableList                     = NewImmutableList             ();
    public static readonly IImmutableSet<int>                           EmptyIImmutableSet                      = NewImmutableHashSet          ();
    public static readonly IImmutableStack<int>                         EmptyIImmutableStack                    = NewImmutableStack            ();
    public static readonly IImmutableQueue<int>                         EmptyIImmutableQueue                    = NewImmutableQueue            ();
    public static readonly IImmutableDictionary<int, int>               EmptyIImmutableDict                     = NewImmutableDict             ();
    public static readonly ImmutableArray<int>                          EmptyImmutableArray                     = NewImmutableArray            ();
    public static readonly ImmutableArray<int>.Builder                  EmptyImmutableArrayBuilder              = NewImmutableArrayBuilder     ();
    public static readonly ImmutableList<int>                           EmptyImmutableList                      = NewImmutableList             ();
    public static readonly ImmutableList<int>.Builder                   EmptyImmutableListBuilder               = NewImmutableListBuilder      ();
    public static readonly ImmutableHashSet<int>                        EmptyImmutableHashSet                   = NewImmutableHashSet          ();
    public static readonly ImmutableHashSet<int>.Builder                EmptyImmutableHashSetBuilder            = NewImmutableHashSetBuilder   ();
    public static readonly ImmutableStack<int>                          EmptyImmutableStack                     = NewImmutableStack            ();
    public static readonly ImmutableQueue<int>                          EmptyImmutableQueue                     = NewImmutableQueue            ();
    public static readonly ImmutableDictionary<int, int>                EmptyImmutableDict                      = NewImmutableDict             ();
    public static readonly ImmutableDictionary<int, int>.Builder        EmptyImmutableDictBuilder               = NewImmutableDictBuilder      ();
    public static readonly ImmutableSortedSet<int>                      EmptyImmutableSortedSet                 = NewImmutableSortedSet        ();
    public static readonly ImmutableSortedSet<int>.Builder              EmptyImmutableSortedSetBuilder          = NewImmutableSortedSetBuilder ();
    public static readonly ImmutableSortedDictionary<int, int>          EmptyImmutableSortedDict                = NewImmutableSortedDict       ();
    public static readonly ImmutableSortedDictionary<int, int>.Builder  EmptyImmutableSortedDictBuilder         = NewImmutableSortedDictBuilder();
    public static readonly IReadOnlyCollection<int>                     EmptyIReadOnlyCollection                =                              [];
    public static readonly IReadOnlyList<int>                           EmptyIReadOnlyList                      =                              [];
    public static readonly IReadOnlyDictionary<int,int>                 EmptyIReadOnlyDict                      = NewReadOnlyDict              ();
    public static readonly ReadOnlyCollection<int>                      EmptyReadOnlyCollection                 = NewReadOnlyColl              ();
    public static readonly ReadOnlyDictionary<int,int>                  EmptyReadOnlyDict                       = NewReadOnlyDict              ();
    public static readonly ReadOnlyDictionary<int,int>.KeyCollection    EmptyReadOnlyDictKeys                   = NewReadOnlyDictKeys          ();
    public static readonly ReadOnlyDictionary<int,int>.ValueCollection  EmptyReadOnlyDictVals                   = NewReadOnlyDictVals          ();
    #if NET9_0_OR_GREATER                                                                                                                                 
    public static readonly IReadOnlySet<int>                            EmptyIReadOnlySet                       = NewReadOnlySet               ();
    public static readonly ReadOnlySet<int>                             EmptyReadOnlySet                        = NewReadOnlySet               ();
    #endif
    
    public static readonly int[]                                      ? NullableEmptyArray                      =                              [];
    public static readonly IList<int>                                 ? NullableEmptyIList                      =                              [];
    public static readonly ISet<int>                                  ? NullableEmptyISet                       = NewHashSet                   ();
    public static readonly IDictionary<int, int>                      ? NullableEmptyIDict                      = NewDict                      ();
    public static readonly ICollection<int>                           ? NullableEmptyICollection                =                              [];
    public static readonly IEnumerable<int>                           ? NullableEmptyIEnumerable                =                              [];
    public static readonly List<int>                                  ? NullableEmptyList                       =                              [];
    public static readonly HashSet<int>                               ? NullableEmptyHashSet                    =                              [];
    public static readonly Stack<int>                                 ? NullableEmptyStack                      = NewStack                     ();
    public static readonly Queue<int>                                 ? NullableEmptyQueue                      = NewQueue                     ();
    public static readonly LinkedList<int>                            ? NullableEmptyLinkedList                 = NewLinkedList                ();
    public static readonly SortedList<int, int>                       ? NullableEmptySortedList                 = NewSortedList                ();
    public static readonly SortedSet<int>                             ? NullableEmptySortedSet                  = NewSortedSet                 ();
    public static readonly Dictionary<int, int>                       ? NullableEmptyDict                       = NewDict                      ();
    public static readonly DictKeyColl                                ? NullableEmptyDictKeyColl                = NewDictKeys                  ();
    public static readonly DictValColl                                ? NullableEmptyDictValColl                = NewDictVals                  ();
    public static readonly IImmutableList<int>                        ? NullableEmptyIImmutableList             = NewImmutableList             ();
    public static readonly IImmutableSet<int>                         ? NullableEmptyIImmutableSet              = NewImmutableHashSet          ();
    public static readonly IImmutableStack<int>                       ? NullableEmptyIImmutableStack            = NewImmutableStack            ();
    public static readonly IImmutableQueue<int>                       ? NullableEmptyIImmutableQueue            = NewImmutableQueue            ();
    public static readonly IImmutableDictionary<int, int>             ? NullableEmptyIImmutableDict             = NewImmutableDict             ();
    public static readonly ImmutableArray<int>                        ? NullableEmptyImmutableArray             = NewImmutableArray            ();
    public static readonly ImmutableArray<int>.Builder                ? NullableEmptyImmutableArrayBuilder      = NewImmutableArrayBuilder     ();
    public static readonly ImmutableList<int>                         ? NullableEmptyImmutableList              = NewImmutableList             ();
    public static readonly ImmutableList<int>.Builder                 ? NullableEmptyImmutableListBuilder       = NewImmutableListBuilder      ();
    public static readonly ImmutableHashSet<int>                      ? NullableEmptyImmutableHashSet           = NewImmutableHashSet          ();
    public static readonly ImmutableHashSet<int>.Builder              ? NullableEmptyImmutableHashSetBuilder    = NewImmutableHashSetBuilder   ();
    public static readonly ImmutableStack<int>                        ? NullableEmptyImmutableStack             = NewImmutableStack            ();
    public static readonly ImmutableQueue<int>                        ? NullableEmptyImmutableQueue             = NewImmutableQueue            ();
    public static readonly ImmutableDictionary<int, int>              ? NullableEmptyImmutableDict              = NewImmutableDict             ();
    public static readonly ImmutableDictionary<int, int>.Builder      ? NullableEmptyImmutableDictBuilder       = NewImmutableDictBuilder      ();
    public static readonly ImmutableSortedSet<int>                    ? NullableEmptyImmutableSortedSet         = NewImmutableSortedSet        ();
    public static readonly ImmutableSortedSet<int>.Builder            ? NullableEmptyImmutableSortedSetBuilder  = NewImmutableSortedSetBuilder ();
    public static readonly ImmutableSortedDictionary<int, int>        ? NullableEmptyImmutableSortedDict        = NewImmutableSortedDict       ();
    public static readonly ImmutableSortedDictionary<int, int>.Builder? NullableEmptyImmutableSortedDictBuilder = NewImmutableSortedDictBuilder();
    public static readonly IReadOnlyCollection<int>                   ? NullableEmptyIReadOnlyCollection        =                              [];
    public static readonly IReadOnlyList<int>                         ? NullableEmptyIReadOnlyList              =                              [];
    public static readonly IReadOnlyDictionary<int,int>               ? NullableEmptyIReadOnlyDict              = NewReadOnlyDict              ();
    public static readonly ReadOnlyCollection<int>                    ? NullableEmptyReadOnlyCollection         = NewReadOnlyColl              ();
    public static readonly ReadOnlyDictionary<int,int>                ? NullableEmptyReadOnlyDict               = NewReadOnlyDict              ();
    public static readonly ReadOnlyDictionary<int,int>.KeyCollection  ? NullableEmptyReadOnlyDictKeys           = NewReadOnlyDictKeys          ();
    public static readonly ReadOnlyDictionary<int,int>.ValueCollection? NullableEmptyReadOnlyDictVals           = NewReadOnlyDictVals          ();
    #if NET9_0_OR_GREATER                                                                                                                                 
    public static readonly IReadOnlySet<int>                          ? NullableEmptyIReadOnlySet               = NewReadOnlySet               ();
    public static readonly ReadOnlySet<int>                           ? NullableEmptyReadOnlySet                = NewReadOnlySet               ();
    #endif
        
    public static readonly int[]                                      ? NullArray                               = null;
    public static readonly IList<int>                                 ? NullIList                               = null;
    public static readonly ISet<int>                                  ? NullISet                                = null;
    public static readonly IDictionary<int, int>                      ? NullIDict                               = null;
    public static readonly ICollection<int>                           ? NullICollection                         = null;
    public static readonly IEnumerable<int>                           ? NullIEnumerable                         = null;
    public static readonly List<int>                                  ? NullList                                = null;
    public static readonly HashSet<int>                               ? NullHashSet                             = null;
    public static readonly Stack<int>                                 ? NullStack                               = null;
    public static readonly Queue<int>                                 ? NullQueue                               = null;
    public static readonly LinkedList<int>                            ? NullLinkedList                          = null;
    public static readonly SortedList<int, int>                       ? NullSortedList                          = null;
    public static readonly SortedSet<int>                             ? NullSortedSet                           = null;
    public static readonly Dictionary<int, int>                       ? NullDict                                = null;
    public static readonly DictKeyColl                                ? NullDictKeyColl                         = null;
    public static readonly DictValColl                                ? NullDictValColl                         = null;
    public static readonly IImmutableList<int>                        ? NullIImmutableList                      = null;
    public static readonly IImmutableSet<int>                         ? NullIImmutableSet                       = null;
    public static readonly IImmutableStack<int>                       ? NullIImmutableStack                     = null;
    public static readonly IImmutableQueue<int>                       ? NullIImmutableQueue                     = null;
    public static readonly IImmutableDictionary<int, int>             ? NullIImmutableDict                      = null;
    public static readonly ImmutableArray<int>                        ? NullImmutableArray                      = null;
    public static readonly ImmutableArray<int>.Builder                ? NullImmutableArrayBuilder               = null;
    public static readonly ImmutableList<int>                         ? NullImmutableList                       = null;
    public static readonly ImmutableList<int>.Builder                 ? NullImmutableListBuilder                = null;
    public static readonly ImmutableHashSet<int>                      ? NullImmutableHashSet                    = null;
    public static readonly ImmutableHashSet<int>.Builder              ? NullImmutableHashSetBuilder             = null;
    public static readonly ImmutableStack<int>                        ? NullImmutableStack                      = null;
    public static readonly ImmutableQueue<int>                        ? NullImmutableQueue                      = null;
    public static readonly ImmutableDictionary<int, int>              ? NullImmutableDict                       = null;
    public static readonly ImmutableDictionary<int, int>.Builder      ? NullImmutableDictBuilder                = null;
    public static readonly ImmutableSortedSet<int>                    ? NullImmutableSortedSet                  = null;
    public static readonly ImmutableSortedSet<int>.Builder            ? NullImmutableSortedSetBuilder           = null;
    public static readonly ImmutableSortedDictionary<int, int>        ? NullImmutableSortedDict                 = null;
    public static readonly ImmutableSortedDictionary<int, int>.Builder? NullImmutableSortedDictBuilder          = null;
    public static readonly IReadOnlyCollection<int>                   ? NullIReadOnlyCollection                 = null;
    public static readonly IReadOnlyList<int>                         ? NullIReadOnlyList                       = null;
    public static readonly IReadOnlyDictionary<int,int>               ? NullIReadOnlyDict                       = null;
    public static readonly ReadOnlyCollection<int>                    ? NullReadOnlyCollection                  = null;
    public static readonly ReadOnlyDictionary<int,int>                ? NullReadOnlyDict                        = null;
    public static readonly ReadOnlyDictionary<int,int>.KeyCollection  ? NullReadOnlyDictKeys                    = null;
    public static readonly ReadOnlyDictionary<int,int>.ValueCollection? NullReadOnlyDictVals                    = null;
    #if NET9_0_OR_GREATER                                                                                                                                          
    public static readonly IReadOnlySet<int>                          ? NullIReadOnlySet                        = null;
    public static readonly ReadOnlySet<int>                           ? NullReadOnlySet                         = null;
    #endif
    
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
    private static ImmutableDictionary<int, int>.Builder NewImmutableDictBuilder(params int[] nums)
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
    
    private static ImmutableSortedDictionary<int, int> NewImmutableSortedDict(params int[] nums) => NewImmutableSortedDictBuilder(nums).ToImmutable();
    private static ImmutableSortedDictionary<int, int>.Builder NewImmutableSortedDictBuilder(params int[] nums)
    {
        var builder = ImmutableSortedDictionary.CreateBuilder<int, int>();
        foreach (var num in nums)
        {
            builder.Add(num, num);
        }
        return builder;
    }

    private static ReadOnlyDictionary<int, int> NewReadOnlyDict(params int[] nums) => new(nums.ToDictionary(num => num));
    private static ReadOnlyDictionary<int, int>.KeyCollection NewReadOnlyDictKeys(params int[] nums) => NewReadOnlyDict(nums).Keys;
    private static ReadOnlyDictionary<int, int>.ValueCollection NewReadOnlyDictVals(params int[] nums) => NewReadOnlyDict(nums).Values;
    private static ReadOnlyCollection<int> NewReadOnlyColl(params int[] nums) => new(nums);
    #if NET9_0_OR_GREATER                                                                                                                           
    private static ReadOnlySet<int> NewReadOnlySet(params int[] nums) => new(new HashSet<int>(nums));
    #endif
  
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