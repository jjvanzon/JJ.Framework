// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace
#pragma warning disable IDE1006 // Naming rule violation

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Common.Core.docs;

/// <summary>
/// Compensates for missing null-tolerant version in ConfigurationHelper.
/// </summary>
public struct _configurationhelpercore;

/// <summary>
/// Shorthand to check if an environment variable is defined with a specific key and value.
/// </summary>
public struct _environmentvariableisdefined;

/// <summary>
/// <para>
/// Sets or gets flags from bit fields (ints) and flag enums.
/// These otherwise require (hard to remember) bit operations.
/// These helpers can help you out in a moment of confusion.
/// </para>
/// <c>HasFlag</c> to ask: "Is this bit or flag set?" <br/>
/// <c>SetFlag</c> / <c>ClearFlag</c> toggles a single flag <br/>
/// <c>SetFlags</c> / <c>ClearFlags</c> when you’ve got a collection of flags <br/>
/// </summary>
public struct _flagging;

/// <summary> 
/// Returns the current method name or current property name.
/// </summary> 
public struct _name;

/// <summary>
/// Helper for conversion from code elements to text (a supplement to the <see langword="nameof" /> keyword).
/// </summary> 
public struct _namehelper;

/// <summary>
/// <para>
/// Not intended for direct use. Do not assign directly.
/// </para>
/// 
/// <para>
/// Allows a certain kind of overloading by parameter name,
/// which you can normally not do.
/// </para>
/// 
/// <para>
/// This allows situations like:
/// <code>
/// MyMethod(10, arg: true);
/// MyMethod(10, differentArg: true);
/// </code>
/// One of those methods has a hidden optional parameter:
/// <code>
/// void MyMethod(int num, bool arg);
/// void MyMethod(int num, bool differentArg, OverloadByName ovl = default);
/// </code>
/// </para>
/// 
/// Calls with unnamed parameters: <c>MyMethod(10, true);</c><br/>
/// Would lead to the first method: <c>MyMethod(int num, bool arg)</c><br/>
/// (The one without the <c>OverloadByName</c> parameter.)
/// 
/// <para>
/// (When brevity is required <c>NameOvl</c> can serve as a synonym for <c>OverloadByName</c>.)
/// </para>
/// </summary>
public struct _overloadbyname;

/// <summary>
/// Gets the string representation of an expression.
/// </summary>
/// <param name="expression">What you pass here, gets converted to text, that is returned.</param>
/// <param name="expressionString">Do not set this parameter. It is for internal use.</param>
/// <returns>What you pass as expression will be returned as text for further processing.</returns>
public struct _textof;

/// <summary>
/// Returns if the code is running inside Azure Pipelines,
/// by chacking if the environment variable <c>"TF_BUILD"</c> equals <c>"True"</c>.
/// </summary>
public struct _isazurepipelines;

/// <summary>
/// Returns if the code is running inside NCrunch,
/// by chacking if the environment variable <c>"NCrunch"</c> equals <c>"1"</c>.
/// </summary>
public struct _isncrunch;

/// <summary>
/// <para>
/// Not intended for direct use. Do not assign directly.
/// </para>
/// 
/// <para>
/// Dummy type used to differentiate generic method overloads 
/// that only differ by generic constraints 
/// (e.g., <c>where T : struct</c> vs <c>where T : class</c>). 
/// C# does not always allow overloading based 
/// solely on generic constraints, 
/// so this marker type enables the the use of such overloads anyway,
/// by showing distinct signatures to the compiler.
/// (e.g., <c>MyMethod() where T : struct</c> vs <c>MyMethod(GenOvl _ = default) where T : class</c>). 
/// The the calls to the generic overloads will differentiate just fine.
/// </para>
/// 
/// <para>
/// (When brevity is required <c>GenOvl</c> can serve as a synonym for <c>GenericOverload</c>.)
/// </para>
/// </summary>
public struct _genericoverload;