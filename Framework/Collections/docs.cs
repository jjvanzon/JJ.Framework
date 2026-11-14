#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0130 // Namespace != folder
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Collections.docs;

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
