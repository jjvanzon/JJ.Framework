// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#if NETFRAMEWORK || NETSTANDARD2_0

namespace System.Diagnostics.CodeAnalysis;

using static AttributeTargets;

[AttributeUsage(Parameter | Property | ReturnValue, AllowMultiple = true, Inherited = false)]
internal sealed class NotNullIfNotNullAttribute : Attribute
{
    public NotNullIfNotNullAttribute(string parameterName) => ParameterName = parameterName;
    public string ParameterName { get; }
}

#endif