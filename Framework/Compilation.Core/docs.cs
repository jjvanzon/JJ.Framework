#pragma warning disable IDE1006 // Naming
// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Compilation.Core.docs;

/// <param name="command">E.g., "build", "add", "msbuild"</param>
public struct _exe;

/// <summary>
/// Uniquely identifies distinct commands
/// in the JJ.Framework's DotNet utility.
/// like <c>build</c> and <c>restore</c>,
/// that map (non-uniquely) to dotnet.exe commands.
/// Intentionally lower-case to be much like the command line is usually typed,
/// look like a parameter name and sort of like a flag attribute in HTML,
/// and also to not clash with actual method names.
/// </summary>
public struct _dotnetcommandenum;