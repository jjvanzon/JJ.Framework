// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#pragma warning disable IDE0051 // Member never used

using System.Diagnostics.CodeAnalysis;
using JJ.Framework.SharedProject.Core.docs;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace JJ.Framework.SharedProject.Core;

/// <inheritdoc cref="_dynamicallyaccessedmembertypesex" />
internal static class DynamicallyAccessedMemberTypesEx
{
    // Aliases

    /// <inheritdoc cref="_properties" />
    public const DynamicallyAccessedMemberTypes AllProps = AllProperties;
    public const DynamicallyAccessedMemberTypes PubPropMethod = PublicProperties | PublicMethods;
    public const DynamicallyAccessedMemberTypes PubProps = PublicProperties;
    public const DynamicallyAccessedMemberTypes PubMethods = PublicMethods;
    public const DynamicallyAccessedMemberTypes NonPublicProps = NonPublicProperties;
    public const DynamicallyAccessedMemberTypes Intf = Interfaces;
    public const DynamicallyAccessedMemberTypes New = PublicParameterlessConstructor;
    public const DynamicallyAccessedMemberTypes PublicCtors = PublicConstructors;
    public const DynamicallyAccessedMemberTypes Ctors = AllCtors;
    public const DynamicallyAccessedMemberTypes AllCtors = PublicConstructors | NonPublicConstructors;
    public const DynamicallyAccessedMemberTypes PropsFieldsMethods = AllProps | AllFields | AllMethods;

    // Private helpers

    // (Not defined in every framework, and this code can't reach the shim values from PlatformCompatibility.Core.)

    private const DynamicallyAccessedMemberTypes Interfaces 
        = (DynamicallyAccessedMemberTypes)0x2000;

    private const DynamicallyAccessedMemberTypes InheritedNonPublicFields
        = (DynamicallyAccessedMemberTypes)0x10000;

    private const DynamicallyAccessedMemberTypes InheritedNonPublicProperties
        = (DynamicallyAccessedMemberTypes)0x40000;

    private const DynamicallyAccessedMemberTypes InheritedNonPublicMethods 
        = (DynamicallyAccessedMemberTypes)0x8000;

    private const DynamicallyAccessedMemberTypes AllFields
        = PublicFields | NonPublicFields | InheritedNonPublicFields;

    private const DynamicallyAccessedMemberTypes AllProperties
        = PublicProperties | (NonPublicProperties | InheritedNonPublicProperties);

    private const DynamicallyAccessedMemberTypes AllMethods 
        = PublicMethods | NonPublicMethods | InheritedNonPublicMethods;
}
