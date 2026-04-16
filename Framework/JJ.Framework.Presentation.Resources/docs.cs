#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE1006 // Naming rules
// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global

namespace JJ.Framework.StringResources.Legacy.docs;

/// <summary>
/// Ported stubs prevent making more changes than necessary and prevent porting more code
/// than necessary by copying tiny bits of dependency code here,
/// and keeping those internal.
///
/// This way StringResourceTestBase can be ported
/// with minimal changes and prevent future merge conflicts.
/// </summary>
/// <param name="actualFunc">Is Expression&lt;Func&lt;T&gt;&gt; in legacy code. Func here for syntax compatibility.</param>
public struct _portedstubs;

/// <summary>
/// Formats <see cref="JJ.Framework.StringResources.Legacy.CommonTitles"/> resources
/// by filling in placeholders with supplied arguments.
/// </summary>
/// <param name="entityNamePlural">The plural display name of the entity type.</param>
public struct _commontitlesformatter;

/// <summary>
/// Sentinel enum used to select a constructor overload
/// that suppresses diagnostic trace output.
/// </summary>
public struct _nolog;

/// <summary>
/// Asserts every public property and method of the resource class
/// returns a non-empty string for each known culture.
/// </summary>
public struct _assertallmembers;

/// <summary>
/// Asserts that an unknown culture falls back
/// to the default culture for every resource member.
/// </summary>
public struct _assertunknownculture;

/// <summary>
/// Determines whether a member should be included in the resource test.
/// Override to exclude additional members.
/// </summary>
public struct _include;
