namespace JJ.Framework.Existence.Core.Tests;

internal static class TestHelper
{
    /// <summary>
    /// <para>
    /// Gives you the <c>Type</c> the compiler thought this <c>value</c> was,
    /// before any automatic conversions or boxing.
    /// This allows us to differentiate between <c>int?</c> and <c>int</c>.
    /// </para>
    /// <para>
    /// For: <c>int? x = 1</c><br/>
    /// This: <c>x.GetType()</c> gives back <c>typeof(int)</c><br/>
    /// This: <c>CompileTimeType(x)</c> still gives back <c>typeof(int?)</c>
    /// </para>
    /// <para>
    /// That way we can inspect the nullability of our returned type,
    /// while the runtime was already so kind to remove the nullable wrapper for us.
    /// </para>
    /// </summary>
    public static Type CompileTimeType<T>(T value) => typeof(T);

    public static readonly string? NullText      = null;
    public static readonly string? NullyEmpty    = "";
    public static readonly string? NullySpace    = " ";
    public static readonly string? NullyWithText = "Hi";
    public static readonly string  NonNullEmpty  = "";
    public static readonly string  NonNullSpace  = " ";
    public static readonly string  NonNullText   = "Hello";
    
    public static readonly int? NullNum  = null;
    public static readonly int? Nully0   = 0;
    public static readonly int? Nully1   = 1;
    public static readonly int? Nully2   = 2;
    public static readonly int? Nully3   = 3;
    public static readonly int? Nully4   = 4;
    public static readonly int  NonNull0 = 0;
    public static readonly int  NonNull1 = 1;
    public static readonly int  NonNull2 = 2;
    public static readonly int  NonNull3 = 3;
    public static readonly int  NonNull4 = 4;
    
    public static readonly StringBuilder? NullObject     = null;
    public static readonly StringBuilder  NonNullObject  = new();
    public static readonly StringBuilder? NullableFilled = new();

    
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
    
    public static readonly int[]                     EmptyArray                       = [ ];
    public static readonly List               <int>  EmptyList                        = [ ];
    public static readonly HashSet            <int>  EmptyHashSet                     = [ ];
    public static readonly IList              <int>  EmptyIList                       = [ ];
    public static readonly ISet               <int>  EmptyISet       = new HashSet<int> { };
    public static readonly ICollection        <int>  EmptyICollection                 = [ ];
    public static readonly IReadOnlyList      <int>  EmptyIReadOnlyList               = [ ];
    public static readonly IReadOnlyCollection<int>  EmptyIReadOnlyCollection         = [ ];
    public static readonly IEnumerable        <int>  EmptyIEnumerable                 = [ ];
    
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
}