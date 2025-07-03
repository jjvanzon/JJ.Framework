// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace
#pragma warning disable CS1711 // XML doc typeparam tag without type parameter
#pragma warning disable CS1574, CS1584, CS1581, CS1580
#pragma warning disable IDE1006
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name

namespace JJ.Framework.PlatformCompatibility.Legacy.docs;

// NOTE: These are structs, so their syntax colorings are unobtrusive.

/// <summary>
/// filled gaps between different platforms like Windows, iOS, Android, and Windows Phone 8.
/// Tech has changed since then, but these platform compatibility alternatives are still linked to by various projects.
/// </summary>
public struct _platformcompatibility;

/// <inheritdoc cref="_platformcompatibility" />
public struct _platformhelper;

/// <inheritdoc cref="_platformcompatibility" />
public struct _platformextensions;

/// <summary>
/// Gets a tuple element: <c>Item1</c> is the first element, <c>Item2</c> the second, and so on.
/// Provides tuple-like functionality on platforms predating native tuple support.
/// </summary>
public struct _item;

/// <remarks>
/// Represents a set of elements grouped together as a single object,
/// providing tuple-like functionality on platforms without native tuple support.
/// </remarks>
public struct _tuple;

/// <remarks>
/// Concatenates the elements of a sequence, using the specified separator between each element.
/// This is a platform stub implementation for platforms lacking native support for string.Join taking an IEnumerable&lt;T&gt;.
/// </remarks>
/// <typeparam name="T">The type of the elements of <paramref name="values"/>.</typeparam>
/// <param name="separator">The string to use as a separator.</param>
/// <param name="values">A sequence that contains the elements to concatenate.</param>
/// <returns>A string that consists of the elements in <paramref name="values"/> delimited by the separator string.</returns>
public struct _join;

/// <remarks>
/// Returns <see langword="true"/> when the <see langword="string"/> has no visible characters; otherwise, <see langword="false"/>.
/// This serves as a platform stub providing this check on platforms without native support (older than .NET 4).
/// </remarks>
public struct _isnullorwhitespace;


/// <remarks>
/// Transfers data from this stream to the provided destination stream, processing chunks based on the given buffer size.
/// Platform stub for this combination of parameters to work on tech older than .NET 4.
/// </remarks>
public struct _copyto;

/// <summary>
/// Windows Phone / Unity compatibility:
/// Don't switch on MemberInfo.MemberType. It produced a strange exception when deployed to Windows Phone using Unity:
/// "Method not found: 'System.Reflection.MemberTypes".
/// Use 'is PropertyInfo' and such or call this method instead.
/// </summary>
/// <remarks>
/// MemberType specifies flags for one or more language constructs to indicate the info of what type of code element we're talking about.
/// For instance: Method, Property, Field or Event. This is a platform safe alternative, where the original causes exceptions under Windows Phone 8 / Unity Game Engine.
/// </remarks>
public struct _membertype;

/// <summary>
/// Certain parameter combinations in the method of the Encoding class do not work on Windows Phone 8.
/// This provides a replacement for that.
/// </summary>
public struct _encoding;

/// <summary>
/// The overload with only byte[] does not work on Windows Phone 8.
/// </summary>
public struct _getstring;

/// <summary>
/// Windows Phone 8 compatibility:
/// Type.GetInterface(string name) is not supported on Windows Phone 8.
/// Use the overload 'Type.GetInterface(string name, bool ignoreCase)' or call this method instead.
/// </summary>
public struct _getinterface;

/// <summary>
/// Use PlatformHelper instead
/// </summary>
public struct _useplatformhelperinstead;

/// <summary>
/// Windows Phone 8 compatibility:
/// XDocument.Save(string fileName) does not exist on Windows Phone 8.
/// Use 'XElement.Save(TextWriter)' or call this method instead.
/// Beware that this overload simply saves the root node
/// and does not the features unique to XDocument.
/// </summary>
public struct _xdocumentsave;

/// <summary>
/// Windows Phone 8 compatibility:
/// This overload does not exist on Windows Phone 8.
/// Use 'XElement.Save(TextWriter)' or call this method instead.
/// </summary>
public struct _xelementsave;

/// <summary>
/// Windows Phone 8 compatibility:
/// CultureInfo.GetCultureInfo(string name) is not supported on Windows Phone 8.
/// Use 'new CultureInfo(string name)' or call this method instead.
/// </summary>
public struct _getcultureinfo;

/// <summary>
/// .Net 4.5 substitute.
/// GetCustomAttribute variant with type argument didn't exist before .NET 4.5.
/// This stub filled that gap, to make this syntax available in lower .NET Framework versions.
/// </summary>
public struct _getcustomattribute;

/// <summary>
/// .NET 4.5 substitute and for iOS compatibility: PropertyInfo.GetValue in Mono on a generic type may cause JIT compilation, which is not supported by iOS.
/// Use 'PropertyInfo.GetGetMethod().Invoke(object obj, params object[] parameters)' or call this method instead.
/// </summary>
public struct _getvalue;

/// <summary>
/// Sets the value of a property by means of reflection..
/// .NET 4.5 substitute. Before .NET 4.5 this parameter combination was not supported natively.
/// </summary>
public struct _setvalue;