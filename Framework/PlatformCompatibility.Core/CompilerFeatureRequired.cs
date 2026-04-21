#pragma warning disable IDE0051 // Unused member
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

// ncrunch: no coverage start

#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Runtime.CompilerServices;

/// <inheritdoc cref="_compilerfeaturerequired" />
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
internal class CompilerFeatureRequiredAttribute(string featureName) : Attribute
{
    public string FeatureName { get; } = featureName;
    public bool IsOptional { get; set; }
    public const string RefStructs = nameof(RefStructs);
    public const string RequiredMembers = nameof(RequiredMembers);
}

#endif

// ncrunch: no coverage end
