// ReSharper disable RedundantUsingDirective.Global
global using Dyn = System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute;
// TODO: `TrimWarn` might be a better name for RequiresUnreferencedCode:
// While `NoTrim` could serve as an alias for DynamicDependency.
global using NoTrim = System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute;
global using Prio = System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute;
global using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using ArgExpress = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;
global using Suppress = System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute;
global using static JJ.Framework.PlatformCompatibility.Core.ArgumentNullExceptionSupport;
global using static JJ.Framework.PlatformCompatibility.Core.ArgumentExceptionSupport;
global using static System.ArgumentException;
global using static System.ArgumentNullException;
