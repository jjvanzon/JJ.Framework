// ReSharper disable UnusedType.Global
#pragma warning disable IDE0130 // Namespace != folder

namespace JJ.Framework.Configuration.Core.docs;

/// <summary>
/// <para>
/// Gets an object with the config's data in it.<br/>
/// Returns what's provided using <c>SetSection</c>. 
/// </para>
/// 
/// <para>
/// Or reads automatically from common files:<br/>
/// <c>app.config | web.config | {YourProjectName}.dll.config | testhost.dll.config | nCrunch.TaskRunner.DotNetCore.20.x64.dll.config
/// </c>
/// </para>
/// 
/// <para>
/// The configuration section name is either the:
/// <list type="bullet">
///   <item>name supplied explicitly</item>
///   <item>Assembly parameter's name in lower case<br/>
///     <c>"MyAssembly.MyNamespace"</c> => <c>"myassembly.mynamespace"</c></item>
///   <item>TMapper's assembly name<br/>
///     (<c>MyAssembly.MyNamespace.MyConfigType</c> => <c>"myassembly.mynamespace"</c>)</item>
/// </list>
/// </para>
/// </summary>
/// <inheritdoc cref="_parameters" />
public struct _getsection;

/// <param name= "name">
/// The name of the configuration section.
/// </param>
/// <param name= "asm">
/// The Assembly provided would only
/// be used to derive the section name,
/// which will be the assembly name converted to lower case letters.
/// </param>
/// <typeparam name="TConfig">
/// The object type to which the XML content will be mapped.
/// The properties are set to the content of the XML,
/// The section name is assumed to be this mapper type's
/// assembly name converted to lowercase,
/// unless a section name is provided explicitly,
/// or an Assembly parameter whose lower-case name would then be used.
/// </typeparam>
public struct _parameters;


/// <summary>
/// </summary>
/// <inheritdoc cref="_parameters" />
public struct _trygetsection;
