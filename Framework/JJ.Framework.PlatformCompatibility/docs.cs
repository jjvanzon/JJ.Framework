﻿#pragma warning disable CS1574
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

namespace JJ.Framework.PlatformCompatibility.Legacy.docs;

// These are structs, so their syntax colorings are unobtrusive.

/// <summary>
/// <b>[Deprecated]</b>
/// Fills gaps between different platforms like Windows, iOS, Android, and Windows Phone 8.
/// Tech has changed since then, but these platform compatibility alternatives are still linked to by various projects.
/// </summary>
public struct _platformcompatibility;

/// <inheritdoc cref="_platformcompatibility" />
public struct _platformhelper;

/// <inheritdoc cref="_platformcompatibility" />
public struct _platformextensions;

/// <summary>
/// <b>[Deprecated]</b>
/// Gets a tuple element: <c>Item1</c> is the first element, <c>Item2</c> the second, and so on.
/// Provides tuple-like functionality on platforms predating native tuple support.
/// </summary>
public struct _item;

/// <remarks>
/// <b>[Deprecated]</b>
/// Represents a set of elements grouped together as a single object,
/// providing tuple-like functionality on platforms without native tuple support.
/// </remarks>
public struct _tuple;

/// <remarks>
/// <b>[Deprecated]</b>
/// Concatenates the elements of a sequence, using the specified separator between each element.
/// This is a platform stub implementation for platforms lacking native support for string.Join taking an IEnumerable&lt;T&gt;.
/// </remarks>
/// <param name="values">A sequence that contains the elements to concatenate.</param>
/// <returns>A string that consists of the <paramref name="values"/> delimited by the separator string.</returns>
public struct _join;

/// <remarks>
/// <b>[Deprecated]</b>
/// Returns <see langword="true"/> when the <see langword="string"/> has no visible characters; otherwise, <see langword="false"/>.
/// This serves as a platform stub providing this check on platforms without native support (older than .NET 4).
/// </remarks>
public struct _isnullorwhitespace;

/// <remarks>
/// <b>[Deprecated]</b>
/// Platform stub for this combination of parameters to work on tech older than .NET 4. <br/>
/// Transfers data from the source stream to the provided destination stream, processing chunks based on the given buffer size.
/// </remarks>
public struct _copyto;

/// <summary>
/// <b>[Deprecated]</b>
/// Windows Phone / Unity compatibility:
/// Don't switch on MemberInfo.MemberType. It produced a strange exception when deployed to Windows Phone using Unity:
/// "Method not found: 'System.Reflection.MemberTypes".
/// Use 'is PropertyInfo' and such or call this method instead.
/// </summary>
/// <remarks>
/// <b>[Deprecated]</b>
/// MemberType specifies flags for one or more language constructs to indicate the info of what type of code element we're talking about.
/// For instance: Method, Property, Field or Event. This is a platform-safe alternative, where the original causes exceptions under Windows Phone 8 / Unity Game Engine.
/// </remarks>
public struct _membertype;

/// <summary>
/// <b>[Deprecated]</b>
/// Certain parameter combinations of methods in the Encoding class do not work on Windows Phone 8.
/// This provides a replacement for that.
/// </summary>
public struct _encoding;

/// <summary>
/// <b>[Deprecated]</b>
/// The overload with only byte[] does not work on Windows Phone 8.
/// </summary>
public struct _getstring;

/// <summary>
/// <b>[Deprecated]</b>
/// Windows Phone 8 compatibility:
/// Type.GetInterface(string name) is not supported on Windows Phone 8.
/// Use the overload 'Type.GetInterface(string name, bool ignoreCase)' or call this method instead.
/// </summary>
public struct _getinterface;

/// <summary>
/// <b>[Deprecated]</b>
/// Windows Phone 8 compatibility:
/// XDocument.Save(string fileName) does not exist on Windows Phone 8.
/// Use 'XElement.Save(TextWriter)' or call this method instead.
/// Beware that this overload simply saves the root node
/// and does not the features unique to XDocument.
/// </summary>
public struct _xdocumentsave;

/// <summary>
/// <b>[Deprecated]</b>
/// Windows Phone 8 compatibility:
/// This overload does not exist on Windows Phone 8.
/// Use 'XElement.Save(TextWriter)' or call this method instead.
/// </summary>
public struct _xelementsave;

/// <summary>
/// <b>[Deprecated]</b>
/// Windows Phone 8 compatibility:
/// CultureInfo.GetCultureInfo(string name) is not supported on Windows Phone 8.
/// Use 'new CultureInfo(string name)' or call this method instead.
/// </summary>
public struct _getcultureinfo;

/// <summary>
/// <b>[Deprecated]</b>
/// GetCustomAttribute variant with type argument didn't exist before .NET 4.5.
/// This stub filled that gap, to make this syntax available in lower .NET Framework versions.
/// </summary>
public struct _getcustomattribute;

/// <summary>
/// <b>[Deprecated]</b>
/// .NET 4.5 substitute and for iOS compatibility: PropertyInfo.GetValue in Mono on a generic type may cause JIT compilation, which is not supported by iOS.
/// Use 'PropertyInfo.GetGetMethod().Invoke(object obj, params object[] parameters)' or call this method instead.
/// </summary>
public struct _getvalue;

/// <summary>
/// <b>[Deprecated]</b>
/// Sets the value of a property by means of reflection.
/// Before .NET 4.5 this parameter combination was not supported natively.
/// </summary>
public struct _setvalue;
