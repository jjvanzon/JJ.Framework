#pragma warning disable IDE1006 // Naming
// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Compilation.Core.docs;

// Commands

/// <summary>
/// Main facade class providing static methods for executing dotnet.exe commands.
/// Offers convenient shortcuts for common commands like Build, Rebuild, Restore, etc.,
/// with optional configuration through DotNetOptions and string arguments.
/// </summary>
public struct _dotnet;

/// <summary>
/// Runs a dotnet.exe command with optional string arguments and configuration options.
/// </summary>
/// <param name="command">E.g., "build", "add", "msbuild"</param>
public struct _exe;

/// <summary>
/// Uniquely identifies distinct commands
/// in the JJ.Framework's DotNet utility.
/// like <c>build</c> and <c>restore</c>,
/// that map (non-uniquely) to dotnet.exe commands.
/// Intentionally lower-case to be much like the command line is usually typed,
/// look like a parameter name and sort of like a flag attribute in HTML,
/// and also to not clash with actual method names.
/// </summary>
public struct _dotnetcommandenum;

/// <remarks>
/// Pass a DotNetOptions or custom arguments to specify a path and other options.
/// </remarks>
public struct _dotnetcommand;

/// <summary>
/// Compiles the project or solution. 
/// </summary>
/// <inheritdoc cref="_dotnetcommand" />
public struct _build;

/// <summary>
/// Rebuilds the project or solution (clean followed by build).
/// </summary>
/// <inheritdoc cref="_dotnetcommand" />
public struct _rebuild;

/// <summary>
/// Runs the MSBuild command directly on a project file.
/// This differs from the Build command, using (legacy) parameterization
/// and behavior from msbuild.exe.
/// </summary>
/// <inheritdoc cref="_dotnetcommand" />
public struct _msbuild;

/// <summary>
/// Runs the MSBuild command to rebuild a project file (clean + build).
/// This differs from the Rebuild comman using (legacy) parameterization 
/// and behavior from from msbuild.exe.
/// </summary>
/// <inheritdoc cref="_dotnetcommand" />
public struct _msrebuild;

/// <summary>
/// Restores NuGet packages and project dependencies.
/// </summary>
/// <inheritdoc cref="_dotnetcommand" />
public struct _restore;

/// <summary>
/// Installs or updates a NuGet package in the project.
/// </summary>
/// <inheritdoc cref="_dotnetcommand" />
public struct _installpackage;

/// <summary>
/// Removes a NuGet package from the project.
/// </summary>
/// <inheritdoc cref="_dotnetcommand" />
public struct _uninstallpackage;

// Helper Types

/// <summary>
/// Captures the result of a dotnet.exe command execution,
/// including exit code, standard output, standard error, derived status indicators, arguments and options used.
/// Provides methods for assertions and implicit conversion to string for informative readable diagnostics.
/// </summary>
public struct _dotnetresult;

/// <summary>
/// Represents arguments for a dotnet.exe command, tracking the command type, package info, and custom arguments.
/// Used internally to build the complete command line for execution,
/// available read-only in a <see cref="DotNetResult">DotNetResult</see>.
/// </summary>
public struct _dotnetargs;

/// <summary>
/// Returns an informative string representation with dotnet command-related info.
/// </summary>
public struct _tostring;

/// <summary>
/// Options for configurating dotnet.exe command execution, including file/directory paths, build configuration, logging verbosity and timeouts.
/// Example uses:
/// <code>
/// var opt = new DotNetOptions { BuildConf = "Release", Dir = "C:/MyRepo" };
/// Build(opt);
/// </code>
/// <code>
/// Build(new { Dir = "C:/MyRepo", BuildConf = "Release" })
/// </code>
/// <code>
/// Build(opt with { BuildConf = "Release" }
/// </code>
/// </summary>
public struct _dotnetoptions;

// Option Members

/// <summary> 
/// Build configuration. Typically "Release" or "Debug", and "" for default behavior.
/// </summary>
public struct _buildconf;

/// <summary>
/// Additional command-line arguments to append to the dotnet.exe command.
/// </summary>
public struct _args;

/// <summary>
/// The directory where the dotnet.exe command will be executed.
/// An empty string indicates the current working directory.
/// Can also be left empty if the File option contains the full path.
/// </summary>
public struct _dir;

/// <summary>
/// The project or solution file path for the command.
/// An empty string uses the Dir property instead, or otherwise the current directory's project.
/// </summary>
public struct _file;

/// <summary>
/// <para>
/// <c>AutoRestore</c> is set to 
/// <see langword="false" /> by default for build-related actions.
/// As you are scripting, you are expected to either call 
/// <see cref="DotNet.Restore()">Restore</see> yourself explicitly,
/// or set <c>AutoRestore</c> set to <see langword="true" />.
/// </para>
/// <para>
/// NOTE: <see cref="DotNet.InstallPackage(string, string)">InstallPackage</see> still does an auto-restore by default.
/// To omit restore for package-related actions, 
/// pass <c>"--no-restore"</c> as the <c>args</c> parameter.
/// It requires more explicit handling, because it is unusual to install without.
/// </para>
/// </summary>
public struct _autorestore;

/// <summary>
/// Many NuGet restores firing off at the same time,
/// are unfortunately prone to time-outs and perhaps even dead-locks.
/// Parallel restores will be disabled by default to prevent this.
/// You can re-enabled it by setting ParallelRestore to true.
/// </summary>
public struct _parallelrestore;

/// <summary>
/// Limits the amount of dotnet.exe processes spun up.
/// If many compilations are run in parallel,
/// NodeReuse = true might reuse too little dotnet.exe instances
/// (bug after after Visual Studio 2026 update to 18.6.0 and 18.6.2.)
/// Trying NodeReuse = false as a default for that reason.
/// Set to true explicitly to restore original behavior.
/// </summary>
public struct _nodereuse;

/// <summary>
/// The timeout in seconds for a single dotnet.exe process execution.
/// Defaults to 300 seconds (5 minutes). If exceeded, the process is forcefully terminated
/// and reported as an error.
/// </summary>
public struct _timeoutsec;

/// <summary>
/// <para>
/// The verbosity level for logging.
/// Controls how much information is captured and logged during command execution.
/// </para>
/// Plus:<br/>
/// - <c>Diagnostic</c> or <c>Detailed</c> will log all build output 
///   through the LogAction delegate (which can call Console.WriteLine or Trace.WriteLine etc, depending on your preference..<br/>
/// - <c>Normal</c> and <c>Minimal</c> will only check silently for errors internally.<br/>
/// - <c>Quiet</c> usually won't work, because it'll swallow diagnostics essential for error handling the logic.
/// </summary>
public struct _verbosity;

/// <summary>
/// The file path for writing detailed build logs.
/// An empty string disables text log file output.
/// </summary>
public struct _logfile;

/// <summary>
/// The file path for writing a binary log file (.binlog) for later analysis.
/// An empty string disables binary log file output.
/// </summary>
public struct _binlog;

/// <summary>
/// An action delegate invoked for each line of output during command execution.
/// Use this for real-time logging or monitoring of command progress.
/// </summary>
public struct _logaction;

/// <summary>
/// Serves as the default LogAction, to stand in for an empty delegate.
/// </summary>
public struct _nullaction;

/// <summary>
/// The default values for options. Can be compared directly with any DotNetOptions instance
/// to check if defaults were altered.
/// </summary>
public struct _defaultoptions;

// Result Members

/// <summary>
/// When <see langword="true"/>, indicates the dotnet.exe command completed successfully
/// (no errors, no error in output, and no timeout).
/// </summary>
public struct _successful;

/// <summary>
/// A string representation of the result, combining options, arguments, exit code, and error/output information via Text, ToString() or implicit string conversion.
/// </summary>
public struct _text;

/// <summary>
/// Throws an exception if the command did not complete successfully.
/// Redundant for now, since currenly dotnet commands already throw an exception in case of an error.
/// </summary>
public struct _assert;

/// <summary>
/// The exit code returned by the dotnet.exe process execution.
/// A non-zero value typically indicates an error condition.
/// But a 0 value does not mean all went wel.
/// HasExitCode is the boolean variant, that just says yes/no there was an error-indicating exit code.
/// </summary>
public struct _exitcode;

/// <inheritdoc cref="_exitcode" />
public struct _hasexitcode;

/// <summary>
/// The standard error text (stderr) output from the dotnet.exe process.
/// May contain error messages and diagnostic information.
/// But in <c>dotnet</c> land it can also contain a welcome message: no error actually will have occurred.
/// Use HasErrorText as a quicker check if this text is filled. When <see langword="true"/>, indicates the standard error stream contained output.
/// In case of dotnet.exe this doesn't mean there was an error at all (sneeky).
/// </summary>
public struct _errortext;

/// <inheritdoc cref="_errortext" />
public struct _haserrortext;

/// <summary>
/// The standard output (stdout) from the dotnet.exe process.
/// Contains build output, messages, and diagnostic information.
/// <see cref="DotNetOptions.Verbosity">DotNetOptions.Verbosity</see> 
/// controls the level of detail.
/// It can contain "[error]" markers that indicate a (compilation) errors.
/// An exit code of 0 and an empty stderr doesn't mean success at all. (Tricky!)
/// Instead, use the <see cref="DotNetResult.Successful">Successful</see> property
/// or rely on the utility's default behavior of throwing an exception upon error.
/// </summary>
public struct _outputtext;

/// <summary>
/// When <see langword="true"/>, indicates the standard output stream contained output.
/// </summary>
public struct _hasoutputtext;

/// <summary>
/// When <see langword="true"/>, indicates the output contains "[error]" markers from the build system. This can happen even without a non-zero exit code or stderr texts, so it's a decisive factor for determining error state.
/// </summary>
public struct _hasererrorinoutput;

/// <summary>
/// When <see langword="true"/>, indicates the dotnet.exe process exceeded the timeout and was forcefully terminated. The processes will be cleaned up and a ('clean') exception will be thrown with diagnostic info; DotNetResult properties will be filled.
/// </summary>
public struct _hastimeout;

// Verbosities

/// <summary>
/// Undefined or uninitialized enum value.
/// </summary>
public struct _undefined;

// TODO

/// <summary>
/// Logging verbosity Quiet: Shows nothing in the process output or LogAction delegate. Not recommended as it can hide diagnostic information. If an error occurs, it may even be ignored and your code will continue regardless, because the logic will have no way of detecting the error. Not even the process exit code can give the definitive answer about success.
/// </summary>
public struct _quiet;

/// <summary>
/// Log verbosity minimal will make LogAction (=> Console/Trace) only show minimal texts like as "Build", "Restore", etc. This can be great for quick overview in the output, but will lacks detailed diagnostics. OutputText will mostly just show which projects were built. You could write it explicitly to the console output it to augment the minimalistic form, because it won't be written there by default. Error messages will always be shown, but in its minimal form without extended diagnostics.
/// </summary>
public struct _minimal;

/// <summary>
/// Default verbosity. Normal build output detail level will be written to the OutputText about what's going in the (build) process.
/// The LogAction (=> Console/Trace) shows command names, like "Build" and "Restore" plus the command line as it was executed.
/// You can use OutputText or DotNetResult.Text to write to the console yourself to augment the minimalism of what's passed to the LogAction automatically.
/// </summary>
public struct _normal;

/// <summary>
/// Detailed output including diagnostic and informational messages.
/// Useful for troubleshooting build issues.
/// It's not the max amount of detail, but could be your go-to setting for troublesome build processes, that usually requires some deeper inspection immediately when an issue arises.
/// </summary>
public struct _detailed;

/// <summary>
/// Most verbose output including all diagnostic information.
/// Useful for detailed debugging of build problems.
/// The logs will be extensive, lenghty and storage-intensive,
/// but sometimes you need it when things go very wrong.
/// </summary>
public struct _diagnostic;

// FilledIn Helpers

/// <remarks>
/// Has and FilledIn are synonymous. IsNully is its inverse. They check whether an object or value has meaningful content (is not null, default, or empty, or its properties or fields all contain their default state). Usable as both extension methods or static calls e.g., <c>Has(result)</c> or <c>options.FilledIn()</c>.
/// </remarks>
public struct _filledin;

/// <inheritdoc cref="_filledin" />
public struct _has;

/// <inheritdoc cref="_filledin" />
public struct _isnully;

/// <summary>
/// Static helper class providing methods to check if objects have meaningful content.
/// </summary>
/// <inheritdoc cref="_filledin" />
public struct _dotnetfilledinhelper;

/// <summary>
/// Extension methods providing checks for "filled in" state of dotnet.exe-related helper objects.
/// </summary>
/// <inheritdoc cref="_filledin" />
public struct _dotnetfilledinextensions;

/// <summary> Returns the TFM string matching the currently-executing assembly, e.g. "net8.0" or "net461". </summary>
public struct _runningtargetframework;

// Internals

/// <summary>
/// NOTE:
/// We use <c>remove package</c> instead of <c>package remove</c> for backward compatibility prior to .NET 10.
/// For <c>dotnet remove package</c>, we need to squish the <c>File</c> arg in between 
/// <c>remove</c> and <c>package</c> e.g., <c>remove Temp.csproj package</c>.
/// </summary>
internal struct _tryformatcommandandfile;

/// <summary>
/// Command text could contain more than just "remove package",
/// but (as the Enricher matches it) it should start with it (white space/case insensitive)
/// </summary>
internal struct _formatremovepackage;

/// <summary>
/// Replace backslahes and double quotes by foreward slashes and single quotes
/// because it'd look bad in the debugger display.
/// (Replace afterwards preferred over "separator" parameter, because values can contain these chars too.
/// </summary>
internal struct _prettifyseparators;