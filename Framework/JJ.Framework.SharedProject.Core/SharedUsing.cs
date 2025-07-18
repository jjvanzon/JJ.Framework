global using Dyn = System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute;
global using NoTrim = System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute;
global using Prio = System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute;
global using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using ArgExpress = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;
global using Suppress = System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute;
//#if !NET8_0_OR_GREATER
//#if !NET7_0_OR_GREATER
global using static JJ.Framework.PlatformCompatibility.Core.ArgumentNullExceptionSupport;
global using static JJ.Framework.PlatformCompatibility.Core.ArgumentExceptionSupport;
//#else
global using static System.ArgumentException;
global using static System.ArgumentNullException;
//#endif
