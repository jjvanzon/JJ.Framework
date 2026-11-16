#pragma warning disable IDE1006 // Naming Styles
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Collections.Legacy.docs;

/// <summary> AddRange is a member of List&lt;T&gt;. This is an overload for ICollection&lt;T&gt;. </summary>
public struct _addrange;

/// <summary>
/// Add multiple items to a collection by means of a comma separated argument list, 
/// e.g. myCollection.Add(1, 5, 12);
/// </summary>
public struct _addwithparams;

/// <summary>
/// Expanding .NET with extra LINQ methods for collections.
/// </summary>
public struct _collectionextensionsex;

/// <inheritdoc cref="_selectancestors" />
public struct _collectionextensionsrecursiveancestors;

/// <summary>
/// <para>
/// Variant of the <c>.ForEach</c> LINQ method that gives you access to an index number for each element you iterate over.
/// It also works with more collection types than .NET's original <c>List&lt;T&gt;</c> method.
/// </para>
/// 
/// <para>
/// Example:
/// </para>
/// 
/// <code>
/// myColl.ForEach((x, i) =&gt; WriteLine(x + "[" + i + "]"));
/// </code>
/// 
/// <para>
/// Output:
/// </para>
/// 
/// <code>
/// Apple[0]
/// Orange[1]
/// </code>
/// </summary>
public struct _foreachwithindex;

/// <summary> 
/// Allow specifying 1 value as a list, but turn it into 2 repeating ones,
/// as a helper for post and fence problems.
/// </summary> 
public struct _onebecomestwo;

/// <summary> 
/// Works similar to Sum, but instead of adding up all the numbers, all the numbers are multiplied.
/// If the collection is empty, returns 1 (the null-operation for a multiplication).
/// </summary> 
public struct _product;

/// <summary>
/// RemoveRange is a member of List&lt;T&gt;. 
/// Here is an overload for that works for any ICollection&lt;T&gt;, 
/// but it also takes items/collections instead of indices. Example:
/// <code>
/// list.RemoveRange("Orange", "Peach");
/// </code>
/// </summary>
public struct _removerange;

/// <summary>
/// Offers a single-line generally usable solution for gathering up 
/// parents and their parents in any tree structure.  
/// Example:
/// <code>
/// var ancestors = child.SelectAncestors(x => x.Parent);
/// </code>
/// </summary>
public struct _selectancestors;

/// <summary>
/// A single-line solution for getting all parents in a tree structure,
/// but includes the root item in the output collection too.
/// Example:
/// <code>var items = child.SelfAndAncestors(x => x.Parent);</code>
/// Output in that case contains all the <c>Parents</c> but also the <c>child</c>.
/// </summary>
public struct _selfandancestors;

/// <summary>
/// Provides "short static" notation for methods on enumerables e.g,
/// <code>
/// var result = Union(list1, list2);
/// </code>
/// This on top of the other syntaxes:
/// <code>
/// var result = list1.Union(list2);
/// var result = Enumerable.Union(list1, list2);
/// </code>
/// Short static notation isn't available for extension methods.
/// This class provides a way to use a static invoke on those extension methods
/// by introducing separate non-extension overloads.
/// </summary>
public struct _staticenumerableex;

/// <summary>
/// An overload of the Sum LINQ method that takes TimeSpans.
/// </summary>
public struct _sumoftimespan;
