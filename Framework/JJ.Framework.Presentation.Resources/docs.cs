#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE1006 // Naming rules
// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global

namespace JJ.Framework.StringResources.Legacy.docs;

/// <summary>
/// This class can be used as a base class for unit tests to run on a Resources or ResourceFormatter class.
/// That ResourceFormatter would be be structured like CommonResourceFormatter from JJ.Framework.StringResources.
/// That means, that each public static member of the ResourceFormatter class returns a string.
/// That string may not be null or white space. The test can switch to different cultures and repeat the checks.
/// An unused culture is currently assumed to fall back to a default culture en-US.
/// Some of those requirements might seem quite specific for how our ResourceFormatter classes are structured.
/// But having this base class for tests, would allow testing integrity of
/// some other resource formatters the same way JJ.Framework.StringResources would do things.
///
/// <code>
/// An implementation might look something like:
/// [TestClass]
/// public class CommonResourceFormatterTests : StringResourceTester
/// {
///   public CommonResourceFormatterTests()
///     : base(
///         typeof(CommonResourceFormatter),
///         @default: "en-US",
///         known: [ "pl-PL", "nl-NL" ],
///         unknown: "zh-CN") { }
/// 
///   [TestMethod]
///   public void Test_CommonResourceFormatter_AssertResources_ReturnText_ForKnownCultures()
///     =&gt; base.AssertAllMembers();
/// 
///   [TestMethod]
///   public void Test_CommonResourceFormatter_UnknownCulture_DefaultsToEnUS()
///     =&gt; base.AssertUnknownCulture();
/// }
/// </code>
/// </summary>
public struct _stringresourcetester;

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
