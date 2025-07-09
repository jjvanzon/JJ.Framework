// ReSharper disable IdentifierTypo

namespace JJ.Framework.PlatformCompatibility.Core.docs;

/// <summary>
/// <para>
/// Specifies the members of a type that are dynamically accessed during runtime.
/// </para>
/// 
/// <para>
/// This attribute is used to indicate which members of a type are accessed dynamically,
/// typically for scenarios involving reflection or dynamic code generation. It helps tools
/// like analyzers and linkers to understand the usage of members and to preserve them
/// during optimization processes.
/// </para>
/// </summary>
public struct _dynamicallyaccessedmembers;

/// <summary>
/// Flags for defining which types of members are accessed dynamically, i.e. via reflection,
/// so code analysis can figure out to not optimize those members away that are reflected upon.
/// </summary>
public struct _dynamicallyaccessedmembertypes;
