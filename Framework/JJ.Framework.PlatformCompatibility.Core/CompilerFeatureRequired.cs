// ncrunch: no coverage start

#if NETFRAMEWORK || NETSTANDARD2_0 || NETSTANDARD2_1

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
internal class CompilerFeatureRequiredAttribute(string featureName) : Attribute
{
    public string FeatureName { get; } = featureName;
    public bool IsOptional { get; init; }
    public const string RefStructs = nameof(RefStructs);
    public const string RequiredMembers = nameof(RequiredMembers);
}

#endif

// ncrunch: no coverage end