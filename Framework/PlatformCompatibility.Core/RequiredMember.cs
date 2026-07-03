// ReSharper disable UnusedType.Global

// ncrunch: no coverage start
#if !NET7_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Runtime.CompilerServices;

/// <inheritdoc cref="_requiredmember" />
[AttributeUsage(
    AttributeTargets.Class | 
    AttributeTargets.Struct | 
    AttributeTargets.Property | 
    AttributeTargets.Field,
    Inherited = false)]
internal class RequiredMemberAttribute : Attribute;

#endif
// ncrunch: no coverage end