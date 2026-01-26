// ncrunch: no coverage start

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

enum DynamicallyAccessedMemberTypes
{
    None                               = 0b0,
    PublicParameterlessConstructor     = 0b1,
    PublicConstructors                 = 0b11,
    NonPublicConstructors              = 0b100,
    PublicMethods                      = 0b1000,
    NonPublicMethods                   = 0b10000,
    PublicFields                       = 0b100000,
    NonPublicFields                    = 0b1000000,
    PublicNestedTypes                  = 0b10000000,
    NonPublicNestedTypes               = 0b100000000,
    PublicProperties                   = 0b1000000000,
    NonPublicProperties                = 0b10000000000,
    PublicEvents                       = 0b100000000000,
    NonPublicEvents                    = 0b1000000000000,
    Interfaces                         = 0b10000000000000,
    NonPublicConstructorsWithInherited = 0b100000000000100,
    NonPublicMethodsWithInherited      = 0b1000000000010000,
    NonPublicFieldsWithInherited       = 0b10000000001000000,
    NonPublicNestedTypesWithInherited  = 0b100000000100000000,
    NonPublicPropertiesWithInherited   = 0b1000000010000000000,
    NonPublicEventsWithInherited       = 0b10000001000000000000,
    PublicConstructorsWithInherited    = 0b100000000000000000011,
    PublicNestedTypesWithInherited     = 0b1000000000000010000000,
    AllConstructors                    = 0b100000100000000000111,
    AllMethods                         = 0b1000000000011000,
    AllFields                          = 0b10000000001100000,
    AllNestedTypes                     = 0b1000100000000110000000,
    AllProperties                      = 0b1000000011000000000,
    AllEvents                          = 0b10000001100000000000,
    All                                = -0b1
}

#endif

// ncrunch: no coverage end