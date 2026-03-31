#pragma warning disable IDE0005 // Unused Using

using System.Diagnostics.CodeAnalysis;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace JJ.Framework.PlatformCompatibility.Core;

internal static class DynamicallyAccessedMemberTypesSupport
{
    #if !NET6_0_OR_GREATER
    public const DynamicallyAccessedMemberTypes Interfaces = (DynamicallyAccessedMemberTypes)8192;
    #endif
    #if NET5_0_OR_GREATER && !NET10_0
    public const DynamicallyAccessedMemberTypes AllProperties = PublicProperties | NonPublicProperties;
    public const DynamicallyAccessedMemberTypes AllFields = PublicFields | NonPublicFields;
    public const DynamicallyAccessedMemberTypes AllConstructors = PublicConstructors | NonPublicConstructors;
    public const DynamicallyAccessedMemberTypes AllMethods = PublicMethods | NonPublicMethods;
    #endif
    #if !NET10_0_OR_GREATER
    public const DynamicallyAccessedMemberTypes NonPublicConstructorsWithInherited = (DynamicallyAccessedMemberTypes)0b000000000100000000000100;
    public const DynamicallyAccessedMemberTypes NonPublicMethodsWithInherited      = (DynamicallyAccessedMemberTypes)0b000000001000000000010000;
    public const DynamicallyAccessedMemberTypes NonPublicFieldsWithInherited       = (DynamicallyAccessedMemberTypes)0b000000010000000001000000;
    public const DynamicallyAccessedMemberTypes NonPublicNestedTypesWithInherited  = (DynamicallyAccessedMemberTypes)0b000000100000000100000000;
    public const DynamicallyAccessedMemberTypes NonPublicPropertiesWithInherited   = (DynamicallyAccessedMemberTypes)0b000001000000010000000000;
    public const DynamicallyAccessedMemberTypes NonPublicEventsWithInherited       = (DynamicallyAccessedMemberTypes)0b000010000001000000000000;
    public const DynamicallyAccessedMemberTypes PublicConstructorsWithInherited    = (DynamicallyAccessedMemberTypes)0b000100000000000000000011;
    public const DynamicallyAccessedMemberTypes PublicNestedTypesWithInherited     = (DynamicallyAccessedMemberTypes)0b001000000000000010000000;
    #endif
}
