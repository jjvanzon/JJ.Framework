// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
namespace JJ.Framework.Reflection.Legacy.docs;

// NOTE: These are structs, so their syntax colorings are unobtrusive.

/// <summary>
/// GetItemType - Gets the item type of a collection type.<br/>
/// TryGetItemType - Returns null if there is no item type.
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
/// <para>This exception signals null being filled in.
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
///     private int Private(int arg) =&gt; 3;
/// }
/// </code>
///
/// <para>You can run that private method, that would otherwise not be available:</para>
/// 
/// <code>
/// var obj = new MyClass();
/// var acc = new MyAccessor(obj);
/// int num = acc.Private(1);
/// </code>
/// 
/// <para>You can do that by writing the following wrapper class:</para>
/// 
/// <code>
/// class MyAccessor(MyClass myObject)
/// {
///     Accessor _accessor = new(myObject);
/// 
///     public int Private(int arg) 
///         => _accessor.InvokeMethod(
///             () => Private((arg)));
/// }
/// </code>
///
/// <para>
/// <i>Limitations</i><br/>
/// <c>Accessor</c> may suffice for most use cases, but there are some cases where it might be an idea to use <c>System.Reflection</c> directly or <c>PrivateObject</c> and <c>PrivateType</c> from a test framework you might use. Those may have slightly more complex syntax, but may offer a diversion where this <c>Accessor</c> class might not be able to help you.
/// </para>
/// </remarks>
public struct _accessor;

/// <summary>
/// <para>For instance:</para>
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