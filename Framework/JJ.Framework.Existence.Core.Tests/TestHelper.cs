namespace JJ.Framework.Existence.Core.Tests;

internal static class TestHelper
{
    public static readonly string? NullText      = null;
    public static readonly string? NullyEmpty    = "";
    public static readonly string? NullySpace    = " ";
    public static readonly string? NullyWithText = "Hi";
    public static readonly string  NoNullEmpty   = "";
    public static readonly string  NoNullSpace   = " ";
    public static readonly string  NoNullText    = "Hi";
    
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
    public static readonly StringBuilder  NoNullObj   = new("NonNull");
    public static readonly StringBuilder? NullyFilled = new("Filled");
    
    public static readonly int[]?                    FilledArray                      = [ 1, 2, 3 ];
    public static readonly List               <int>  FilledList                       = [ 1, 2, 3 ];
    public static readonly HashSet            <int>  FilledHashSet                    = [ 1, 2, 3 ];
    public static readonly IList              <int>  FilledIList                      = [ 1, 2, 3 ];
    public static readonly ISet               <int>  FilledISet      = new HashSet<int> { 1, 2, 3 };
    public static readonly ICollection        <int>  FilledICollection                = [ 1, 2, 3 ];
    public static readonly IReadOnlyList      <int>  FilledIReadOnlyList              = [ 1, 2, 3 ];
    public static readonly IReadOnlyCollection<int>  FilledIReadOnlyCollection        = [ 1, 2, 3 ];
    public static readonly IEnumerable        <int>  FilledIEnumerable                = [ 1, 2, 3 ];
    
    public static readonly int[]?                    NullyFilledArray                 = [ 1, 2, 3 ];
    public static readonly List               <int>? NullyFilledList                  = [ 1, 2, 3 ];
    public static readonly HashSet            <int>? NullyFilledHashSet               = [ 1, 2, 3 ];
    public static readonly IList              <int>? NullyFilledIList                 = [ 1, 2, 3 ];
    public static readonly ISet               <int>? NullyFilledISet = new HashSet<int> { 1, 2, 3 };
    public static readonly ICollection        <int>? NullyFilledICollection           = [ 1, 2, 3 ];
    public static readonly IReadOnlyList      <int>? NullyFilledIReadOnlyList         = [ 1, 2, 3 ];
    public static readonly IReadOnlyCollection<int>? NullyFilledIReadOnlyCollection   = [ 1, 2, 3 ];
    public static readonly IEnumerable        <int>? NullyFilledIEnumerable           = [ 1, 2, 3 ];
    
    public static readonly int[]                     EmptyArray                          = [ ];
    public static readonly List               <int>  EmptyList                           = [ ];
    public static readonly HashSet            <int>  EmptyHashSet                        = [ ];
    public static readonly IList              <int>  EmptyIList                          = [ ];
    public static readonly ISet               <int>  EmptyISet          = new HashSet<int> { };
    public static readonly ICollection        <int>  EmptyICollection                    = [ ];
    public static readonly IReadOnlyList      <int>  EmptyIReadOnlyList                  = [ ];
    public static readonly IReadOnlyCollection<int>  EmptyIReadOnlyCollection            = [ ];
    public static readonly IEnumerable        <int>  EmptyIEnumerable                    = [ ];
    
    public static readonly int[]?                    NullableEmptyArray                  = [ ];
    public static readonly List               <int>? NullableEmptyList                   = [ ];
    public static readonly HashSet            <int>? NullableEmptyHashSet                = [ ];
    public static readonly IList              <int>? NullableEmptyIList                  = [ ];
    public static readonly ISet               <int>? NullableEmptyISet  = new HashSet<int> { };
    public static readonly ICollection        <int>? NullableEmptyICollection            = [ ];
    public static readonly IReadOnlyList      <int>? NullableEmptyIReadOnlyList          = [ ];
    public static readonly IReadOnlyCollection<int>? NullableEmptyIReadOnlyCollection    = [ ];
    public static readonly IEnumerable        <int>? NullableEmptyIEnumerable            = [ ];
    
    public static readonly int[]?                    NullArray                           = null;
    public static readonly List               <int>? NullList                            = null;
    public static readonly HashSet            <int>? NullHashSet                         = null;
    public static readonly IList              <int>? NullIList                           = null;
    public static readonly ISet               <int>? NullISet                            = null;
    public static readonly ICollection        <int>? NullICollection                     = null;
    public static readonly IReadOnlyList      <int>? NullIReadOnlyList                   = null;
    public static readonly IReadOnlyCollection<int>? NullIReadOnlyCollection             = null;
    public static readonly IEnumerable        <int>? NullIEnumerable                     = null;
    
    // For objects

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : notnull
        => NotNull(ret, message);

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
    {
        IsType(typeof(int?), ret, message);
        NotType(typeof(int), ret, message);
    }
}