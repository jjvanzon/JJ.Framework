// ReSharper disable UnusedType.Global
// ReSharper disable RedundantNameQualifier

#if !NET5_0_OR_GREATER && !NETSTANDARD2_1

namespace System.Diagnostics.CodeAnalysis;

using JJ.Framework.PlatformCompatibility.Core.docs;
using static System.AttributeTargets;

/// <inheritdoc cref="_notnullattribute" />
[AttributeUsage(Property | Field | Parameter | ReturnValue)]
internal sealed class NotNullAttribute : Attribute;

#endif
