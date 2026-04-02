#pragma warning disable IDE1006 // naming rule violation
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global

namespace JJ.Framework.PlatformCompatibility.Core.docs;

/// <summary>
/// <para>
/// Specifies the members of a type that are dynamically accessed during runtime.
/// </para>
/// 
/// <para>
/// This attribute is used to indicate which members of a type are accessed dynamically,
/// typically for scenarios involving reflection or dynamic code generation. It helps tools
/// like analyzers and linkers to understand the usage of members and to preserve them
/// during optimization processes.
/// </para>
/// </summary>
public struct _dynamicallyaccessedmembers;

/// <summary>
/// Flags for defining which types of members are accessed dynamically, i.e. via reflection,
/// so code analysis can figure out to not optimize those members away that are reflected upon.
/// </summary>
public struct _dynamicallyaccessedmembertypes;

/// <summary>
/// Substitute for <c>ArgumentException.ThrowIfNullOrWhiteSpace</c> (introduced in .NET 8).
/// Throws when the argument is <c>null</c> or white space.
/// </summary>
public struct _argumentexceptionsupport;

/// <summary>
/// Substitute for <c>ArgumentNullException.ThrowIfNull</c> (introduced in .NET 6).
/// Throws when the argument is <c>null</c>.
/// </summary>
public struct _argumentnullexceptionsupport;

/// <summary>
/// Substitute for <c>[CallerArgumentExpression]</c> (introduced in .NET 6 / C# 10).
/// Captures the expression passed to a parameter as a string, useful for error messages.
/// </summary>
public struct _callerargumentexpression;

/// <summary>
/// Compiler-internal marker. Signals that a language feature is required to use this member.
/// </summary>
public struct _compilerfeaturerequired;

/// <summary>
/// Substitute for <c>[DynamicDependency]</c> (introduced in .NET 5).
/// Tells the linker to preserve a member even if it is not referenced directly.
/// </summary>
public struct _dynamicdependency;

/// <summary>
/// Substitute for <c>System.HashCode</c> (introduced in .NET Standard 2.1).
/// Combines multiple values into a single hash code.
/// </summary>
public struct _hashcode;

/// <summary>
/// Required marker type for <c>init</c>-only setters (C# 9, introduced in .NET 5).
/// </summary>
public struct _isexternalinit;

/// <summary>
/// Substitute for <c>System.Threading.Lock</c> (introduced in .NET 9).
/// Lightweight lock with a <c>using</c>-scoped entry via <c>EnterScope()</c>.
/// </summary>
public struct _lock;

/// <summary>
/// Substitute for <c>[NotNull]</c> (introduced in .NET Standard 2.1).
/// Marks that an output is never <c>null</c> even when the declared type allows it.
/// </summary>
public struct _notnullattribute;

/// <summary>
/// Substitute for <c>[NotNullWhen(bool)]</c>.
/// Marks that a parameter is not <c>null</c> when the method returns a specific <c>bool</c> value.
/// </summary>
public struct _notnullwhen;

/// <summary>
/// Substitute for <c>[OverloadResolutionPriority]</c> (introduced in .NET 9 / C# 13).
/// Lets you prefer one overload over another when multiple overloads match.
/// </summary>
public struct _overloadresolutionpriority;

/// <summary>
/// Substitute for <c>[RequiredMember]</c> (introduced in .NET 7 / C# 11).
/// Marks a member as required to be set during object initialization.
/// </summary>
public struct _requiredmember;

/// <summary>
/// Substitute for <c>[RequiresDynamicCode]</c> (introduced in .NET 7).
/// Marks methods that need dynamic code generation and are not AOT-safe.
/// </summary>
public struct _requiresdynamiccode;

/// <summary>
/// Substitute for <c>[RequiresUnreferencedCode]</c> (introduced in .NET 5).
/// Marks code that may break when the linker trims unused members.
/// </summary>
public struct _requiresunreferencedcode;

/// <summary>
/// Substitute for <c>[UnconditionalSuppressMessage]</c> (introduced in .NET 5).
/// Suppresses an analysis warning unconditionally, even after trimming.
/// </summary>
public struct _unconditionalsuppressmessage;
