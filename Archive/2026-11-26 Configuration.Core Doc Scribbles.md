```cs
/// <list type="bullet">
///   <item>app.config</item>
///   <item>web.config</item>
///   <item>{YourProjectName}.dll.config</item>
///   <item>testhost.dll.config</item>
///   <item>nCrunch.TaskRunner.DotNetCore.20.x64.dll.config</item>
/// </list>

/// (It takes file names, xml strings, byte[], Stream and encoding options or simply the config object itself.)


/// Just like System.Configuration does.
/// 
/// <para>
/// Or use <c>SetSection</c> to provide the config object expliclty.
/// In that case case you can be more explicit about where the config is coming from.
/// </para>

/// <list type="bullet">
///   <item><c>sectionName</c> explicitly or</item>
///   <item><c>Assembly</c>'s name in lower case<br/>
///     <c>"MyAssembly.MyNamespace"</c> => <c>"myassembly.mynamespace"</c></item>
///   <item><c>TConfig</c>'s assembly name<br/>
///     (<c>MyAssembly.MyNamespace.MyConfigType</c> => <c>"myassembly.mynamespace"</c>)</item>
/// </list>


/// or an Assembly parameter whose lower-case name would then be used.
```