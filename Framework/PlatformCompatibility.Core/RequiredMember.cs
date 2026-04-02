// ReSharper disable UnusedType.Global

// ncrunch: no coverage start
#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

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