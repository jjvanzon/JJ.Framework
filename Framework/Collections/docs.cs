#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0130 // Namespace != folder
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Collections.docs;

/// <summary> AddRange is a member of List&lt;T&gt;. Here is an overload for ICollection&lt;T&gt;. </summary>
public struct _addrange;

/// <summary>
/// Add multiple items to a collection by means of a comma separated argument list, e.g. myCollection.Add(1, 5,
/// 12);
/// </summary>
public struct _addwithparams;

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
/// Allow specifying 1 value as a list, but turn it into two repeating ones,
/// as a helper for post and fence problems.
/// </summary> 
public struct _onebecomestwo;

/// <summary> 
/// Works similar to Sum, but instead of adding up all the numbers, all the numbers are multiplied.
/// If the collection is empty, returns 1 (the null-operation for a multiplication).
/// </summary> 
public struct _product;

/// <summary>
/// An overload of the Sum LINQ method that takes TimeSpans.
/// </summary>
public struct _sumoftimespan;
