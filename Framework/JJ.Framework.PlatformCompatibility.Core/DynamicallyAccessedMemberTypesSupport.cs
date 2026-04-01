#pragma warning disable IDE0005 // Unused Using
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System.Diagnostics.CodeAnalysis;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace JJ.Framework.PlatformCompatibility.Core;

internal static class DynamicallyAccessedMemberTypesSupport
{
    #if NET5_0_OR_GREATER && !NET10_0_OR_GREATER
    public const DynamicallyAccessedMemberTypes AllFields       = PublicFields | NonPublicFieldsWithInherited;
    public const DynamicallyAccessedMemberTypes AllProperties   = PublicProperties | NonPublicPropertiesWithInherited;
    public const DynamicallyAccessedMemberTypes AllMethods      = PublicMethods | NonPublicMethodsWithInherited;
    public const DynamicallyAccessedMemberTypes AllConstructors = PublicConstructorsWithInherited | NonPublicConstructorsWithInherited;
    #endif

    #if !NET6_0_OR_GREATER
    public const DynamicallyAccessedMemberTypes Interfaces = (DynamicallyAccessedMemberTypes)8192;
    #endif

    #if !NET10_0_OR_GREATER
    public const DynamicallyAccessedMemberTypes AllNestedTypes                     = (DynamicallyAccessedMemberTypes)0b001000100000000110000000;
    public const DynamicallyAccessedMemberTypes AllEvents                          = (DynamicallyAccessedMemberTypes)0b000010000001100000000000;
    public const DynamicallyAccessedMemberTypes PublicConstructorsWithInherited    = (DynamicallyAccessedMemberTypes)0b000100000000000000000011;
    public const DynamicallyAccessedMemberTypes PublicNestedTypesWithInherited     = (DynamicallyAccessedMemberTypes)0b001000000000000010000000;
    public const DynamicallyAccessedMemberTypes NonPublicConstructorsWithInherited = (DynamicallyAccessedMemberTypes)0b000000000100000000000100;
    public const DynamicallyAccessedMemberTypes NonPublicMethodsWithInherited      = (DynamicallyAccessedMemberTypes)0b000000001000000000010000;
    public const DynamicallyAccessedMemberTypes NonPublicFieldsWithInherited       = (DynamicallyAccessedMemberTypes)0b000000010000000001000000;
    public const DynamicallyAccessedMemberTypes NonPublicNestedTypesWithInherited  = (DynamicallyAccessedMemberTypes)0b000000100000000100000000;
    public const DynamicallyAccessedMemberTypes NonPublicPropertiesWithInherited   = (DynamicallyAccessedMemberTypes)0b000001000000010000000000;
    public const DynamicallyAccessedMemberTypes NonPublicEventsWithInherited       = (DynamicallyAccessedMemberTypes)0b000010000001000000000000;
    #endif
}
