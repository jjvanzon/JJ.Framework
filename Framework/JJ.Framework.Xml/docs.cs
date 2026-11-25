#pragma warning disable IDE0130
// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InvalidXmlDocComment
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Xml.Legacy.docs;

/// <param name="data">Byte data is assumed to be UTF-8 encoded, when no specific encoding is provided..</param>
public struct _convertwithbytes;

/// <summary>
/// Sets the attribute value for an element by attribute name.
/// Insists that the attribute already is present,
/// which is a bit strict, but that's what the legacy did.
/// And it may incur some performance overhead otherwise.
/// </summary>
public struct _setattributevalue;

/// <summary>
/// A class that gives access to XML. It does so in a null-safe and multiplicity-safe way. It uses <c>XmlDocument</c> as the underlying .NET API.
/// </summary>
public struct _xmlhelper;