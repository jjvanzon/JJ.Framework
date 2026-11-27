// ReSharper disable UnusedType.Global
#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE1006 // Naming rule

namespace JJ.Framework.Configuration.Core.docs;

/// <summary>
/// <para>
/// Provides <c>System.Configuration</c>-like behavior,
/// so we can use <c>XML</c> configs like we're used to,
/// without legacy baggage nor painful migration to JSON.
/// </para>
/// 
/// <para>
/// Will not provide everything <c>System.Configuration</c> did.
/// Will find configs where you're used to.
/// And map to objects using <c>JJ.Framework.Xml</c>'s convenient mapping style.
/// </para>
/// </summary>
public struct _customconfigmanagercore;

/// <summary>
/// <para>
/// Gets an object with the config's data in it.<br/>
/// Returns what's provided using <c>SetSection</c> (with explicit options).
/// </para>
/// 
/// <para>
/// Or reads automatically from common files:<br/>
/// <c>app.config | web.config | {YourProjectName}.dll.config | 
/// testhost.dll.config | nCrunch.TaskRunner.DotNetCore.20.x64.dll.config</c>
/// </para>
/// 
/// <para>
/// Config sections optional. (You can simply map any XML.)<br/>
/// Or you can use config sections with:
/// </para>
/// <list type="bullet">
///   <item><c>sectionName</c> or</item>
///   <item><c>Assembly</c> name in lower case<br/>
///     <c>"MyAssembly.MyNamespace"</c> => <c>"myassembly.mynamespace"</c></item>
///   <item><c>TConfig</c>'s assembly name<br/>
///     (<c>MyAssembly.MyNamespace.MyConfigType</c> => <c>"myassembly.mynamespace"</c>)</item>
/// </list>
/// 
/// </summary>
/// <inheritdoc cref="_parameters" />
public struct _getsection;

/// <param name= "sectionName">
/// The name of the configuration section.
/// </param>
/// <param name= "assembly">
/// The Assembly provided would only
/// be used to derive the section name:
/// the assembly name converted to lower case letters.
/// </param>
/// <param name="obj">
/// An explicit config object, which omits XML parsing or reading out files altogether.
/// </param>
/// <param name="xml">
/// The XML content as string data, whose content will be parsed to a config object.
/// Providing this omits reading out files.
/// </param>
/// <param name="bytes">
/// The byte array from which XML can be read and parsed to a config object.
/// Providing this omits reading out an XML file and just uses the provided bytes.
/// </param>
/// <param name="stream">
/// The stream from which to read out the config XML which is then parsed to an object.
/// Providing this omits reading out an XML file and just uses the provided stream data.
/// </param>
/// <param name="filePath">
/// The relative or absolue file name or path.
/// This allows you to decide where your file is, instead of relying on assumptions about
/// standard names and locations.
/// </param>
/// <typeparam name="TConfig">
/// The object type to which the XML content will be mapped.
/// The properties are set to the content of the XML,
/// The section name is assumed to be this mapper type's
/// assembly name converted to lowercase,
/// unless a section name or Assembly parameter are provided explicitly.
/// </typeparam>
public struct _parameters;

/// <summary>
/// Drops a cached configuration.
/// When you call <c>(Try)GetSecton</c> the XML will be re-read from disk.
/// Or call <c>SetSection</c> to provide the new config object.
/// </summary>
public struct _refreshsection;

/// <summary>
/// Configs are read from files automatically unless you provide 
/// a config object explicitly using <c>SetSection</c>.
/// You can directly provide a config object that is hashed under its type and (optional) section name.
/// You can also provide string, byte[] or Stream data or a file name to explicitly say where the config's coming from.
/// </summary>
/// <inheritdoc cref="_parameters" />
public struct _setsection;

/// <remarks>The <c>TryGetSection</c> variant returns null in case no config section was found.</remarks>
/// <inheritdoc cref="_getsection" />
public struct _trygetsection;
