// ReSharper disable ReturnTypeCanBeNotNullable
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_NotNullWhen_Tests
{
    private string           ? Text => "Hi!";
    private StringBuilder    ? SB   => new("Hi!");
    private int              ? Num  => 1;
    private int[]            ? Arr  => [ 1, 2, 3 ];
    private T                ? Coll<T>() where T: new() => new();
    private ILookup<int, int>? Lookup => new [] { 1, 2, 3 }.ToLookup(x => x);

    [TestMethod]
    public void Test_Has_NotNullWhen()
    {
        // ToString() would trigger a nullability compiler error, if Has/FilledIn/UsNully NotNulWhen attribute set wrong.

        { string?        text = Text; if ( FilledIn(text         )) text.ToString(); }
        { string?        text = Text; if ( FilledIn(text, default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if ( FilledIn(sb           )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if ( FilledIn(sb,   default)) sb  .ToString(); }
        { int?           num  = Num ; if ( FilledIn(num          )) num .ToString(); }
        { string?        text = Text; if ( Has     (text         )) text.ToString(); }
        { string?        text = Text; if ( Has     (text, default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if ( Has     (sb           )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if ( Has     (sb,   default)) sb  .ToString(); }
        { int?           num  = Num ; if ( Has     (num          )) num .ToString(); }
        { string?        text = Text; if (!IsNully (text         )) text.ToString(); }
        { string?        text = Text; if (!IsNully (text, default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if (!IsNully (sb           )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if (!IsNully (sb,   default)) sb  .ToString(); }
        { int?           num  = Num ; if (!IsNully (num          )) num .ToString(); }
        { string?        text = Text; if ( text.FilledIn(        )) text.ToString(); }
        { string?        text = Text; if ( text.FilledIn( default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if ( sb  .FilledIn(        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if ( sb  .FilledIn( default)) sb  .ToString(); }
        { int?           num  = Num ; if ( num .FilledIn(        )) num .ToString(); }
        { string?        text = Text; if (!text.IsNully(         )) text.ToString(); }
        { string?        text = Text; if (!text.IsNully(  default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if (!sb  .IsNully(         )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if (!sb  .IsNully(  default)) sb  .ToString(); }
        { int?           num  = Num ; if (!num .IsNully(         )) num .ToString(); }
    }

    // TODO: For Collections
    [TestMethod]
    public void Test_Has_Collection_NotNullWhen()
    {
        // ToString() would trigger a nullability compiler error, if Has/FilledIn/UsNully NotNulWhen attribute set wrong.

        { int[]                ? coll = Arr                         ; if (FilledIn(coll)) coll.ToString(); }
        { IList      <int>     ? coll = Coll<List      <int>>     (); if (FilledIn(coll)) coll.ToString(); }
        { ISet       <int>     ? coll = Coll<HashSet   <int>>     (); if (FilledIn(coll)) coll.ToString(); }
        { IDictionary<int, int>? coll = Coll<Dictionary<int, int>>(); if (FilledIn(coll)) coll.ToString(); }
        { ICollection<int>     ? coll = Arr                         ; if (FilledIn(coll)) coll.ToString(); }
        { ILookup    <int, int>? coll = Lookup                      ; if (FilledIn(coll)) coll.ToString(); }
        { IEnumerable<int>     ? coll = Arr                         ; if (FilledIn(coll)) coll.ToString(); }
        { List       <int>     ? coll = Coll<List      <int>>     (); if (FilledIn(coll)) coll.ToString(); }
        { HashSet    <int>     ? coll = Coll<HashSet   <int>>     (); if (FilledIn(coll)) coll.ToString(); }
        { Stack      <int>     ? coll = Coll<Stack     <int>>     (); if (FilledIn(coll)) coll.ToString(); }
        { Queue      <int>     ? coll = Coll<Queue     <int>>     (); if (FilledIn(coll)) coll.ToString(); }
        { LinkedList <int>     ? coll = Coll<LinkedList<int>>     (); if (FilledIn(coll)) coll.ToString(); }
        { SortedList <int, int>? coll = Coll<SortedList<int, int>>(); if (FilledIn(coll)) coll.ToString(); }
        { Dictionary <int, int>? coll = Coll<Dictionary<int, int>>(); if (FilledIn(coll)) coll.ToString(); }
        // TODO: Dictionary<T,U>.KeyCollection
    }
}