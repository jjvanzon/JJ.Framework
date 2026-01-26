// ncrunch: no coverage start

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

enum DynamicallyAccessedMemberTypes
{
    None                               = 0b000000000000000000000000,
    PublicParameterlessConstructor     = 0b000000000000000000000001,
    PublicConstructors                 = 0b000000000000000000000011,
    NonPublicConstructors              = 0b000000000000000000000100,
    PublicMethods                      = 0b000000000000000000001000,
    NonPublicMethods                   = 0b000000000000000000010000,
    PublicFields                       = 0b000000000000000000100000,
    NonPublicFields                    = 0b000000000000000001000000,
    PublicNestedTypes                  = 0b000000000000000010000000,
    NonPublicNestedTypes               = 0b000000000000000100000000,
    PublicProperties                   = 0b000000000000001000000000,
    NonPublicProperties                = 0b000000000000010000000000,
    PublicEvents                       = 0b000000000000100000000000,
    NonPublicEvents                    = 0b000000000001000000000000,
    Interfaces                         = 0b000000000010000000000000,
    NonPublicConstructorsWithInherited = 0b000000000100000000000100,
    NonPublicMethodsWithInherited      = 0b000000001000000000010000,
    NonPublicFieldsWithInherited       = 0b000000010000000001000000,
    NonPublicNestedTypesWithInherited  = 0b000000100000000100000000,
    NonPublicPropertiesWithInherited   = 0b000001000000010000000000,
    NonPublicEventsWithInherited       = 0b000010000001000000000000,
    PublicConstructorsWithInherited    = 0b000100000000000000000011,
    PublicNestedTypesWithInherited     = 0b001000000000000010000000,
    AllConstructors                    = 0b000100000100000000000111,
    AllMethods                         = 0b000000001000000000011000,
    AllFields                          = 0b000000010000000001100000,
    AllNestedTypes                     = 0b001000100000000110000000,
    AllProperties                      = 0b000001000000011000000000,
    AllEvents                          = 0b000010000001100000000000,
    All                                = -0b00000000000000000000001
}

#endif

// ncrunch: no coverage end