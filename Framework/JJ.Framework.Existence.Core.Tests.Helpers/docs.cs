// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Existence.Core.Tests.Helpers.docs;

/// <summary>
/// ToString() would trigger a nullability compiler error,
/// if Has/FilledIn/IsNully NotNullWhen attribute set wrong.
/// </summary>
public struct _notnullwhentests;
