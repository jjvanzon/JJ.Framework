// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedType.Global
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
    public const DynamicallyAccessedMemberTypes AllProps = PublicProperties | NonPublicProperties | (DynamicallyAccessedMemberTypes)0x40000;
    public const DynamicallyAccessedMemberTypes NonPublicProps = NonPublicProperties;
    public const DynamicallyAccessedMemberTypes Intf = (DynamicallyAccessedMemberTypes)0x2000;
    public const DynamicallyAccessedMemberTypes New = PublicParameterlessConstructor;
    public const DynamicallyAccessedMemberTypes PublicCtors = PublicConstructors;
    public const DynamicallyAccessedMemberTypes Ctors = AllCtors;
    public const DynamicallyAccessedMemberTypes AllCtors = PublicConstructors | NonPublicConstructors;
    public const DynamicallyAccessedMemberTypes PropsFieldsMethods = AllProps | PublicFields | NonPublicFields | (DynamicallyAccessedMemberTypes)0x10000 | PublicMethods | NonPublicMethods | (DynamicallyAccessedMemberTypes)0x8000;
}
