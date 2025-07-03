// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
namespace JJ.Framework.Reflection.Legacy.docs;

/// <summary>
/// GetItemType - Gets the item type of a collection type.<br/>
/// TryGetItemType - Returns null if there is no item type.
/// </summary>
public struct _getitemtype;

/// <summary>
/// <para>
/// Makes using reflection much faster in certain cases.
/// For instance the `GetProperties` method can be expensive,
/// which is much faster through the `ReflectionCache` class.
/// </para>
/// 
/// Example:
/// 
/// <code>
/// private static readonly ReflectionCache _reflectionCache 
///     = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);
/// 
/// PropertyInfo[] properties 
///     = _reflectionCache.GetProperties(typeof(MyClass));
/// </code>
/// 
/// <para>You can also get other types of constructs in a fast way:</para>
///
/// - <c>Methods</c> <br/>
/// - <c>Indexers</c> <br/>
/// - <c>Fields</c> <br/>
/// - <c>Constructor</c> <br/>
/// - <c>GetTypeByShortName</c>
/// 
/// <para>In this version, some of the options may only be available in the <c>StaticReflectionCache</c> variant. That variant may perform slightly less fast.</para>
///
/// <para>
/// There are <c>Get</c> and <c>TryGet</c> methods (e.g. <c>GetField</c> and <c>TryGetField</c>).
/// The <c>Try</c> variants can return null when not found. The <c>Get</c> methods always return an object, or otherwise they throw an exception as a safety net.
/// </para>
/// </summary>
public struct _reflectioncache;