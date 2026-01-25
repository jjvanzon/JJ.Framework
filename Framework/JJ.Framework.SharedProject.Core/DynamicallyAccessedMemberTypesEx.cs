// ReSharper disable RedundantUsingDirective
using System.Diagnostics.CodeAnalysis;
using JJ.Framework.SharedProject.Core.docs;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace JJ.Framework.SharedProject.Core;

/// <inheritdoc cref="_dynamicallyaccessedmembertypesex" />
internal static class DynamicallyAccessedMemberTypesEx
{
    public const DynamicallyAccessedMemberTypes AllCtors = PublicConstructors | NonPublicConstructors;
    public const DynamicallyAccessedMemberTypes New = PublicParameterlessConstructor;
    public const DynamicallyAccessedMemberTypes PublicCtors = PublicConstructors;
    public const DynamicallyAccessedMemberTypes PropsFieldsMethods = AllProperties | AllFields | AllMethods;
    public const DynamicallyAccessedMemberTypes NonPublicProps = NonPublicProperties;
    // TODO: Replace by explicit NET5_0 || NET6_0, etc.
    #if NET5_0_OR_GREATER && !NET10_0
    /// <inheritdoc cref="_properties" />
    public const DynamicallyAccessedMemberTypes AllProperties = PublicProperties | NonPublicProperties;
    public const DynamicallyAccessedMemberTypes AllFields = PublicFields | NonPublicFields;
    public const DynamicallyAccessedMemberTypes AllConstructors = PublicConstructors | NonPublicConstructors;
    public const DynamicallyAccessedMemberTypes AllMethods = PublicMethods | NonPublicMethods;
    #endif
    #if NET5_0
    public const DynamicallyAccessedMemberTypes Interfaces = (DynamicallyAccessedMemberTypes)8192;
    #endif
    public const DynamicallyAccessedMemberTypes Intf = Interfaces;
}

