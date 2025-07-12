using System.Diagnostics.CodeAnalysis;
using JJ.Framework.SharedProject.Core.docs;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace JJ.Framework.SharedProject.Core;

/// <inheritdoc cref="_dynamicallyaccessedmembertypesex" />
internal static class DynamicallyAccessedMemberTypesEx
{
    /// <inheritdoc cref="_properties" />
    public const DynamicallyAccessedMemberTypes AllProperties = PublicProperties | NonPublicProperties;
    public const DynamicallyAccessedMemberTypes AllFields = PublicFields | NonPublicFields;
    public const DynamicallyAccessedMemberTypes AllConstructors = PublicConstructors | NonPublicConstructors;
    public const DynamicallyAccessedMemberTypes AllCtors = PublicConstructors | NonPublicConstructors;
    public const DynamicallyAccessedMemberTypes New = PublicParameterlessConstructor;
    public const DynamicallyAccessedMemberTypes PublicCtors = PublicConstructors;
    public const DynamicallyAccessedMemberTypes AllMethods = PublicMethods | NonPublicMethods;
    public const DynamicallyAccessedMemberTypes PropsFieldsMethods = AllProperties | AllFields | AllMethods;
}

