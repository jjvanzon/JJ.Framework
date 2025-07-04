// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Common.Core.Tests.docs;

/// <summary>
/// It may be arbitrary that null input returns an empty collection,
/// but this is the behavior of the legacy code and can't be changed.
/// </summary>
public struct _keyvaluepairnulltest;

/// <summary>
/// Throwing when null is a bit harsh since it's just a text manipulation,
/// and the difference with empty string or white space is too trivial.
/// It's what usually happens in APIs though, and it's what this legacy code does,
/// so we're verifying that here.
/// </summary>
public struct _harshnullstringtest;