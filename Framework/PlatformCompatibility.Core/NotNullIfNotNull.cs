// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#if NETFRAMEWORK || NETSTANDARD2_0

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_notnullifnotnull" />
[AttributeUsage(AttributeTargets.Parameter | 
                AttributeTargets.Property | 
                AttributeTargets.ReturnValue, 
                AllowMultiple = true,
                Inherited = false)]
internal sealed class NotNullIfNotNullAttribute : Attribute
{
    /// <inheritdoc cref="_notnullifnotnull" />
    public NotNullIfNotNullAttribute(string parameterName) => ParameterName = parameterName;

    /// <inheritdoc cref="_notnullifnotnullparameter" />
    public string ParameterName { get; }
}

#endif
