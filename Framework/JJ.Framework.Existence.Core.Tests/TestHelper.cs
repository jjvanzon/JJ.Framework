using System.Collections;
using System.Diagnostics.CodeAnalysis;
using DicKeyColl = System.Collections.Generic.Dictionary<int, int>.KeyCollection;
using DicValColl = System.Collections.Generic.Dictionary<int, int>.ValueCollection;

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
    
    private static HashSet<int> NewHashSet(params int[] nums)
    {
        var coll = new HashSet<int>();
        foreach (var num in nums)
        {
            coll.Add(num);
        }
        return coll;

    }
    private static Dictionary<int, int> NewDic(params int[] nums) => nums.ToDictionary(num => num);

    private static Stack<int> NewStack(params int[] nums)
    {
        var coll = new Stack<int>();
        foreach (var num in nums)
        {
            coll.Push(num);
        }
        return coll;
    }

    private static Queue<int> NewQueue(params int[] nums)
    {
        var coll = new Queue<int>();
        foreach (var num in nums)
        {
            coll.Enqueue(num);
        }
        return coll;
    }
    
    private static LinkedList<int> NewLinkedList(params int[] nums)
    {
        var coll = new LinkedList<int>();
        foreach (var num in nums)
        {
            coll.AddLast(num);
        }
        return coll;
    }
    
    private static SortedList<int, int> NewSortedList(params int[] nums)
    {
        var coll = new SortedList<int, int>();
        foreach (var num in nums)
        {
            coll.Add(num, num);
        }
        return coll;
    }
    
    private static SortedSet<int> NewSortedSet(params int[] nums)
    {
        var coll = new SortedSet<int>();
        foreach (var num in nums)
        {
            coll.Add(num);
        }
        return coll;
    }

    public static readonly int[]                     FilledArray                      =              [1, 2, 3];
    public static readonly IList              <int>  FilledIList                      =              [1, 2, 3];
    public static readonly ISet               <int>  FilledISet                       = NewHashSet   (1, 2, 3);
    public static readonly IDictionary   <int, int>  FilledIDictionary                = NewDic       (1, 2, 3);
    public static readonly ICollection        <int>  FilledICollection                =              [1, 2, 3];
    public static readonly IEnumerable        <int>  FilledIEnumerable                =              [1, 2, 3];
    public static readonly List               <int>  FilledList                       =              [1, 2, 3];
    public static readonly HashSet            <int>  FilledHashSet                    =              [1, 2, 3];
    public static readonly Stack              <int>  FilledStack                      = NewStack     (1, 2, 3);
    public static readonly Queue              <int>  FilledQueue                      = NewQueue     (1, 2, 3);
    public static readonly LinkedList         <int>  FilledLinkedList                 = NewLinkedList(1, 2, 3);
    public static readonly SortedList    <int, int>  FilledSortedList                 = NewSortedList(1, 2, 3);
    public static readonly SortedSet          <int>  FilledSortedSet                  = NewSortedSet (1, 2, 3);
    public static readonly Dictionary    <int, int>  FilledDictionary                 = NewDic       (1, 2, 3);
    public static readonly DicKeyColl                FilledDicKeyColl                 = NewDic       (1, 2, 3).Keys;
    public static readonly DicValColl                FilledDicValColl                 = NewDic       (1, 2, 3).Values;
    public static readonly IReadOnlyList      <int>  FilledIReadOnlyList              =              [1, 2, 3];
    public static readonly IReadOnlyCollection<int>  FilledIReadOnlyCollection        =              [1, 2, 3];
    
    public static readonly int[]                   ? NullyFilledArray                 =              [1, 2, 3];
    public static readonly IList              <int>? NullyFilledIList                 =              [1, 2, 3];
    public static readonly ISet               <int>? NullyFilledISet                  = NewHashSet   (1, 2, 3);
    public static readonly IDictionary   <int, int>? NullyFilledIDictionary           = NewDic       (1, 2, 3);
    public static readonly ICollection        <int>? NullyFilledICollection           =              [1, 2, 3];
    public static readonly IEnumerable        <int>? NullyFilledIEnumerable           =              [1, 2, 3];
    public static readonly List               <int>? NullyFilledList                  =              [1, 2, 3];
    public static readonly HashSet            <int>? NullyFilledHashSet               =              [1, 2, 3];
    public static readonly Stack              <int>? NullyFilledStack                 = NewStack     (1, 2, 3);
    public static readonly Queue              <int>? NullyFilledQueue                 = NewQueue     (1, 2, 3);
    public static readonly LinkedList         <int>? NullyFilledLinkedList            = NewLinkedList(1, 2, 3);
    public static readonly SortedList    <int, int>? NullyFilledSortedList            = NewSortedList(1, 2, 3);
    public static readonly SortedSet          <int>? NullyFilledSortedSet             = NewSortedSet (1, 2, 3);
    public static readonly Dictionary    <int, int>? NullyFilledDictionary            = NewDic       (1, 2, 3);
    public static readonly DicKeyColl              ? NullyFilledDicKeyColl            = NewDic       (1, 2, 3).Keys;
    public static readonly DicValColl              ? NullyFilledDicValColl            = NewDic       (1, 2, 3).Values;
    public static readonly IReadOnlyList      <int>? NullyFilledIReadOnlyList         =              [1, 2, 3];
    public static readonly IReadOnlyCollection<int>? NullyFilledIReadOnlyCollection   =              [1, 2, 3];
    
    public static readonly int[]                     EmptyArray                       =              [];
    public static readonly IList              <int>  EmptyIList                       =              [];
    public static readonly ISet               <int>  EmptyISet                        = NewHashSet   ();
    public static readonly IDictionary   <int, int>  EmptyIDictionary                 = NewDic       ();
    public static readonly ICollection        <int>  EmptyICollection                 =              [];
    public static readonly IEnumerable        <int>  EmptyIEnumerable                 =              [];
    public static readonly List               <int>  EmptyList                        =              [];
    public static readonly HashSet            <int>  EmptyHashSet                     =              [];
    public static readonly Stack              <int>  EmptyStack                       = NewStack     ();
    public static readonly Queue              <int>  EmptyQueue                       = NewQueue     ();
    public static readonly LinkedList         <int>  EmptyLinkedList                  = NewLinkedList();
    public static readonly SortedList    <int, int>  EmptySortedList                  = NewSortedList();
    public static readonly SortedSet          <int>  EmptySortedSet                   = NewSortedSet ();
    public static readonly Dictionary    <int, int>  EmptyDictionary                  = NewDic       ();
    public static readonly DicKeyColl                EmptyDicKeyColl                  = NewDic       ().Keys;
    public static readonly DicValColl                EmptyDicValColl                  = NewDic       ().Values;
    public static readonly IReadOnlyList      <int>  EmptyIReadOnlyList               =              [];
    public static readonly IReadOnlyCollection<int>  EmptyIReadOnlyCollection         =              [];
    
    public static readonly int[]                   ? NullableEmptyArray               =              [];
    public static readonly IList              <int>? NullableEmptyIList               =              [];
    public static readonly ISet               <int>? NullableEmptyISet                = NewHashSet   ();
    public static readonly IDictionary   <int, int>? NullableEmptyIDictionary         = NewDic       ();
    public static readonly ICollection        <int>? NullableEmptyICollection         =              [];
    public static readonly IEnumerable        <int>? NullableEmptyIEnumerable         =              [];
    public static readonly List               <int>? NullableEmptyList                =              [];
    public static readonly HashSet            <int>? NullableEmptyHashSet             =              [];
    public static readonly Stack              <int>? NullableEmptyStack               = NewStack     ();
    public static readonly Queue              <int>? NullableEmptyQueue               = NewQueue     ();
    public static readonly LinkedList         <int>? NullableEmptyLinkedList          = NewLinkedList();
    public static readonly SortedList    <int, int>? NullableEmptySortedList          = NewSortedList();
    public static readonly SortedSet          <int>? NullableEmptySortedSet           = NewSortedSet ();
    public static readonly Dictionary    <int, int>? NullableEmptyDictionary          = NewDic       ();
    public static readonly DicKeyColl              ? NullableEmptyDicKeyColl          = NewDic       ().Keys;
    public static readonly DicValColl              ? NullableEmptyDicValColl          = NewDic       ().Values;
    public static readonly IReadOnlyList      <int>? NullableEmptyIReadOnlyList       =              [];
    public static readonly IReadOnlyCollection<int>? NullableEmptyIReadOnlyCollection =              [];
    
    public static readonly int[]                   ? NullArray                        = null;
    public static readonly IList              <int>? NullIList                        = null;
    public static readonly ISet               <int>? NullISet                         = null;
    public static readonly IDictionary   <int, int>? NullIDictionary                  = null;
    public static readonly ICollection        <int>? NullICollection                  = null;
    public static readonly IEnumerable        <int>? NullIEnumerable                  = null;
    public static readonly List               <int>? NullList                         = null;
    public static readonly HashSet            <int>? NullHashSet                      = null;
    public static readonly Stack              <int>? NullStack                        = null;
    public static readonly Queue              <int>? NullQueue                        = null;
    public static readonly LinkedList         <int>? NullLinkedList                   = null;
    public static readonly SortedList    <int, int>? NullSortedList                   = null;
    public static readonly SortedSet          <int>? NullSortedSet                    = null;
    public static readonly Dictionary    <int, int>? NullDictionary                   = null;
    public static readonly DicKeyColl              ? NullDicKeyColl                   = null;
    public static readonly DicValColl              ? NullDicValColl                   = null;
    public static readonly IReadOnlyList      <int>? NullIReadOnlyList                = null;
    public static readonly IReadOnlyCollection<int>? NullIReadOnlyCollection          = null;
    
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