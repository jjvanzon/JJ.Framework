using System;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
namespace JJ.Framework.Reflection.Legacy.docs;

// NOTE: These are structs, so their syntax colorings are unobtrusive.

/// <summary>
/// GetItemType - Gets the item type of a collection type.<br/>
/// TryGetItemType - Same, but returns null if there is no item type.
/// </summary>
public struct _getitemtype;

/// <summary>
/// <para>
/// Makes using reflection much faster in certain cases.
/// For instance the <c>GetProperties</c> method can be expensive,
/// which is much faster through the <c>ReflectionCache</c> class.
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

/// <summary>
/// <para>Superseded by .NET's own <c>ThrowIfNull</c>, but still used in several projects.</para>
/// 
/// <para>This exception signals something is null.
/// You can pass an expression, whose text becomes part of the message.
/// For example:</para>
///
/// <code>throw new NullException(() =&gt; myParent.MyChildren[0].MyProperty);</code>
/// 
/// <para>Will produce an exception message:</para>
/// 
/// <code>"myParent.MyChildren[0].MyProperty is null."</code>
/// </summary>
public struct _nullexception;

/// <remarks>
/// <para>Allows easy access to the internal, private or protected elements of an assembly or class.</para>
/// 
/// <para>For instance if you have the following private method in a class:</para>
/// 
/// <code>
/// class MyClass
/// {
///     private int Private =&gt; 3;
/// }
/// </code>
///
/// <para>You can run that private method, that would otherwise not be available:</para>
/// 
/// <code>
/// var obj = new MyClass();
/// var acc = new MyAccessor(obj);
/// int num = acc.Private;
/// </code>
/// 
/// <para>You can do that by writing the following wrapper class:</para>
/// 
/// <code>
/// class MyAccessor(MyClass myObject)
/// {
///     Accessor _accessor = new(myObject);
/// 
///     public int Private 
///         =&gt; _accessor.GetPropertyValue(() =&gt; Private);
/// }
/// </code>
///
/// <para>
/// <i>Limitations</i><br/>
/// <c>Accessor</c> may suffice for most use cases,
/// but there are some cases where it might be an idea to use
/// <c>System.Reflection</c> directly or <c>PrivateObject</c> and
/// <c>PrivateType</c> from a test framework you might use.
/// Those may have slightly more complex syntax,
/// but may offer a diversion where this <c>Accessor</c> class
/// might not be able to help you.
/// </para>
/// </remarks>
public struct _accessor;

/// <summary>
/// <b>[Deprecated]</b> Use: <c>NameHelper.TextOf</c> in <c>JJ.Framework.Common.Core</c> instead.
/// 
/// <code>
/// GetText(() =&gt; myParam.MyProperty.MyList[i].MySomething)
/// </code>
/// 
/// <para>Will return the string:</para>
/// 
/// <code>
/// "myParam.MyProperty.MyList[i].MySomething"
/// </code>
/// </summary>
public struct _gettext;

/// <summary>
/// Gets a value from an expression.
/// Supports field access, property access, method calls with parameters,
/// indexers, array lengths, conversion expressions, params (variable amount of arguments),
/// and both static and instance member access.
/// </summary>
/// <remarks>
/// <para>You can retrieve values from expressions:</para>
/// 
/// <code>
///     GetValue(() =&gt; myParam.MyProperty.MyList[i].MySomething)
/// </code>
/// 
/// <para>which can return:</para>
/// 
/// <code>
///     3
/// </code>
///
/// <para>This can be useful in conjunction with <c>GetText</c> which takes an expression too,
/// or in other places where you are dealing with expressions.</para>
/// </remarks>
public struct _getvalue;

/// <remarks>
/// <para>Returns method info, parameter names and parameter value info from lambda expressions.
/// For instance:</para>
/// 
/// <code>
///     GetMethodCallInfo(() =&gt; MyMethod(3));
/// </code>
/// 
/// <para>Will return:</para>
/// 
/// <code>
///     MethodCallInfo
///     {
///         Name = "MyMethod",
///         Parameters = 
///         {
///             ParameterType = typeof(int),
///             Name = "myParameter",
///             Value = 3
///         }
///     };
/// </code>
/// </remarks>
public struct _methodcallinfo;

/// <summary>
/// <para>Converts many types of lambda expressions into text or retrieves its resulting value.
/// Here are some of the things it can do. For instance:</para>
/// 
/// <code>
///     GetText(() =&gt; myParam.MyProperty.MyList[i].MySomething)
/// </code>
/// 
/// <para>Will return the string:</para>
/// 
/// <code>
///     "myParam.MyProperty.MyList[i].MySomething"
/// </code>
/// 
/// <para>Similarly you can retrieve its value:</para>
/// 
/// <code>
///     GetValue(() =&gt; myParam.MyProperty.MyList[i].MySomething)
/// </code>
/// 
/// <para>which can return:</para>
/// 
/// <code>
///     3
/// </code>
/// 
/// <para>It can also give you method info, parameter names and parameter value info from lambda expressions.
/// For instance:</para>
/// 
/// <code>
///     GetMethodCallInfo(() =&gt; MyMethod(3));
/// </code>
/// 
/// <para>Will return:</para>
/// 
/// <code>
///    MethodCallInfo
///    {
///        Name = "MyMethod",
///        Parameters = 
///        {
///            ParameterType = typeof(int),
///            Name = "myParameter",
///            Value = 3
///        }
///    };
/// </code>
/// </summary>
public struct _expressionhelper;

/// <summary>
/// Allows you to retrieve implementations of a specified base class or interface from an assembly,
/// which can be useful for plug-in development.
/// </summary>
public struct _getimplementations;

/// <summary>
/// You can pass objects to it, and it will return the concrete types of those objects, with some tolerance for nulls.
/// </summary>
public struct _typesfromobjects;

/// <summary>
/// Determines if a <c>MethodInfo</c> points to an indexer property.
/// </summary>
public struct _isindexermethod;

/// <summary>
/// Tells you if a <c>MemberInfo</c> is static.
/// </summary>
public struct _isstatic;

/// <summary>
/// Use this for reflection if you want basically all the members,
/// and don't want to think about BindingFlags,
/// when you have to provide BindingFlags.
/// </summary>
public struct _bindingflagsall;

/// <summary>
/// <para>
/// Various helper methods, but one of the most useful features
/// is the <c>GetImplementation</c> method and variations thereof,
/// which allow you to retrieve implementations
/// of a specified base class or interface from an assembly,
/// which is useful for plug-in development.
/// </para>
///
/// <para>
/// <c>GetImplementations</c> <br/>
/// Allows you to retrieve implementations of a specified base class or interface
/// from an assembly, which is useful for plug-in development.
/// </para>
///
/// <para>
/// <c>GetItemType</c> <br/>
/// Gets the item type of a collection type.
/// </para>
///
/// <para>
/// <c>IsIndexerMethod</c> <br/>
/// Can tell you if a <c>MethodInfo</c> points to an indexer property.
/// </para>
///
/// <para>
/// <c>IsStatic</c> <br/>
/// Can tell you if a <c>MemberInfo</c> is static.
/// </para>
///
/// <para>
/// <c>IsNullableType</c> <br/>
/// Returns <see langword="true"/> if the given type is a value type
/// that allows <see langword="null"/>, like <c>int?</c> or <c>Nullable&lt;bool?&gt;</c>.
/// </para>
///
/// <para>
/// <c>GetUnderlyingNullableType</c> <br/>
/// Slightly faster than <c>Nullable.GetUnderlyingType</c>.
/// </para>
/// 
/// <para>
/// <c>TypesFromObjects</c> <br/>
/// You can pass objects to it, and it will return the concrete types of those objects, with some tolerance for nulls.
/// </para>
///
/// <para>
/// <c>IsAssignableFrom</c> / <c>IsAssignableTo</c> <br/>
/// Similar to the original <c>Type.IsAssignableFrom</c>, but now also an <c>IsAssignableTo</c> variation, if you find that more intuitive.
/// </para>
/// </summary>
public struct _reflectionhelper;

/// <summary>
/// Similar to the original <c>Type.IsAssignableFrom</c>,
/// but now also the inverse <c>IsAssignableTo</c> variation,
/// if you find that more intuitive.
/// </summary>
public struct _isassignableto;

/// <summary>
/// Returns <see langword="true"/> for value types allowed to be <see langword="null"/>, like <c>int?</c> or <c>Nullable&lt;bool?&gt;</c>.
/// </summary>
public struct _isnullabletype;

/// <summary>
/// Slightly faster than <see cref="Nullable.GetUnderlyingType"/>.
/// </summary>
public struct _getunderlyingnullabletype;

/// <summary>
/// Returns <see langword="true"/> if the specified <see cref="Type"/> is a reference type,
/// such as a <see langword="class"/> or <see langword="interface"/>.
/// </summary>
public struct _isreferencetype;

/// <summary>
/// Provides extension methods for working with <see cref="Type"/> and reflection,
/// including checks for nullability, reference types and collection item types.
/// </summary>
public struct _typeextensions;