using System.Diagnostics.CodeAnalysis;
using JJ.Framework.SharedProject.Core.docs;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace JJ.Framework.SharedProject.Core;

/// <inheritdoc cref="_dynamicallyaccessedmembertypesex" />
internal static class DynamicallyAccessedMemberTypesEx
{
    /// <inheritdoc cref="_properties" />
    public const DynamicallyAccessedMemberTypes Properties = PublicProperties | NonPublicProperties;
    public const DynamicallyAccessedMemberTypes DefaultCtor = PublicParameterlessConstructor;
    public const DynamicallyAccessedMemberTypes PublicCtor = PublicConstructors;
    public const DynamicallyAccessedMemberTypes Methods = PublicMethods | NonPublicMethods;
}

