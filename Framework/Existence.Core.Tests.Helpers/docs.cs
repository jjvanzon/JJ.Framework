// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Existence.Core.Tests.Helpers.docs;

/// <summary>
/// ToString() would trigger a nullability compiler error,
/// if Has/FilledIn/IsNully NotNullWhen attribute set wrong.
/// </summary>
public struct _notnullwhentests;

/// <summary>
/// 4-arg bools have their own overloads for flag-free calls to Coalesce.
/// This is for overload resolution purposes specific to Booleans.
/// These tests check those overloads systematically.
/// </summary>
public struct _coalesce4argsbool;
