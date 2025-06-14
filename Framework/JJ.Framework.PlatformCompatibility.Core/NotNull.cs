#if NETFRAMEWORK || NETSTANDARD2_0

namespace System.Diagnostics.CodeAnalysis;

using static System.AttributeTargets;

[AttributeUsage(Property | Field | Parameter | ReturnValue)]
internal sealed class NotNullAttribute : Attribute;

#endif
