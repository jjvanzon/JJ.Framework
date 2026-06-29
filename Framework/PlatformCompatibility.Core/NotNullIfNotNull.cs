// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#if NETFRAMEWORK || NETSTANDARD2_0

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

using static AttributeTargets;

/// <inheritdoc cref="_notnullifnotnull" />
[AttributeUsage(Parameter | Property | ReturnValue, AllowMultiple = true)]
internal sealed class NotNullIfNotNullAttribute(string parameterName) : Attribute
{
    public string ParameterName { get; } = parameterName;
}

#endif