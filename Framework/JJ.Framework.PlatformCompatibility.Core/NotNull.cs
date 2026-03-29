// ReSharper disable UnusedType.Global
// ReSharper disable RedundantNameQualifier

// ncrunch: no coverage start
#if !NET5_0_OR_GREATER && !NETSTANDARD2_1

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

using static System.AttributeTargets;

/// <inheritdoc cref="_notnullattribute" />
[AttributeUsage(Property | Field | Parameter | ReturnValue)]
internal sealed class NotNullAttribute : Attribute;

#endif
// ncrunch: no coverage end
