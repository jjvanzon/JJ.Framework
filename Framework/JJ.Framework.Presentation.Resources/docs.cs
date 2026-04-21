#pragma warning disable CS1574, CS1584, CS1581, CS1580 // Cannot find cref
#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE1006 // Naming rules
// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global

namespace JJ.Framework.StringResources.Legacy.docs;

/// <remarks>
/// Base class for testing that every resource member returns a non-empty string
/// across known cultures, and that unknown cultures fall back to the default.
/// For methods with parameters, it also verifies that placeholders are resolved
/// and that each argument appears in the resulting string.
/// <code>
/// [TestClass]
/// public class MyResourceTests() 
///   : StringResourceTester(
///     typeof(MyResources), 
///     known: ["pl-PL", "nl-NL"], 
///     unknown: "zh-CN", @default: "en-US")
/// {
///   [TestMethod] 
///   public void All() => AssertAllMembers();
///  
///   [TestMethod] 
///   public void Unknown() => AssertUnknownCultureFallback();
/// }
/// </code>
/// </remarks>
/// <param name="resourceClass">
/// The resource or formatter type whose public members will be tested.
/// </param>
/// <param name="resourceObject">
/// Instance to invoke non-static members on. Pass <c>null</c> for static-only classes.
/// </param>
/// <param name="known">
/// Culture names e.g. [ "en-US", "nl-NL"] that have their own translations.
/// </param>
/// <param name="unknown">
/// A culture name with no translations, expected to fall back to <paramref name="@default"/>.
/// </param>
/// <param name="default">
/// The default culture name, typically "en-US" or "" (invariant culture).
/// Automatically considered one of <paramref name="known"/> cultures
/// </param>
/// <param name="nolog">
/// Suppresses <see cref="Trace"/> output during the test run.
/// </param>
public struct _stringresourcetester;

/// <summary>
/// Generic syntax sugar over <see cref="StringResourceTester"/>
/// so you can write <c>new StringResourceTester&lt;MyResources&gt;(...)</c>
/// instead of <c>new StringResourceTester(typeof(MyResources), ...)</c>.
/// </summary>
/// <inheritdoc cref="_stringresourcetester" />
public struct _stringresourcetesteroft;

/// <summary>
/// Ported stubs prevent making more changes than necessary and prevent porting more code
/// than necessary by copying tiny bits of dependency code here,
/// and keeping those internal.
///
/// This way StringResourceTestBase can be ported
/// with minimal changes and prevent future merge conflicts.
/// </summary>
/// <param name="actualFunc">
/// Is Expression&lt;Func&lt;T&gt;&gt; in legacy code. Func here for syntax compatibility.
/// </param>
internal struct _portedstubs;

/// <summary>
/// Formats <see cref="CommonTitles"/> resources
/// by filling in placeholders with supplied arguments.
/// </summary>
public struct _commontitlesformatter;

/// <summary>
/// Returns a formatted "{0} count" string for a given entity name.
/// </summary>
/// <param name="entityNamePlural">The plural display name of the entity type.</param>
public struct _entitycount;

/// <summary>
/// Marker enum to pick a constructor overload that turns off trace logging.
/// </summary>
public struct _nolog;

/// <summary>
/// Checks that every public member returns a filled text for each known culture.
/// </summary>
public struct _assertallmembers;

/// <summary>
/// Checks that an unknown culture uses the default culture for every member's text.
/// </summary>
public struct _assertunknownculturefallback;

/// <summary>
/// Decides whether a member is included in the test.<br/>
/// <c>Culture</c> and <c>ResourceManager</c> are skipped by default.
/// Override to skip additional members.
/// </summary>
public struct _include;

/// <summary>
/// Creates a dummy argument value to fill in a parameter
/// to pass to a resource method.
/// Override to handle custom parameter types.
/// </summary>
public struct _getarg;

/// <summary>
/// Dispatches to the property or method assertion based on member type.
/// </summary>
internal struct _assertresourcetext;

/// <summary>
/// Asserts that a resource property returns a non-empty string.
/// </summary>
internal struct _assertresourceprop;

/// <summary>
/// Invokes a resource method with generated arguments,
/// checks that it returns a non-empty string,
/// that placeholders are resolved,
/// and that each argument appears in the result.
/// </summary>
internal struct _assertresourcemethod;

/// <summary>
/// Verifies that the returned value is a non-empty string.
/// </summary>
internal struct _assertreturnstext;

/// <summary>
/// Helper that returns the resource object for instance members,
/// or <c>null</c> for static members.
/// </summary>
internal struct _trygetresourceobject;
