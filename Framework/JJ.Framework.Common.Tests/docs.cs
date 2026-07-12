// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Common.Legacy.Tests.docs;

/// <summary>
/// Throwing when null is a bit harsh since it's just a text manipulation,
/// and the difference with empty string or white space is too trivial.
/// It's what usually happens in APIs though, and it's what this legacy code does,
/// so we're verifying that here.
/// </summary>
public struct _harshnullstringtest;