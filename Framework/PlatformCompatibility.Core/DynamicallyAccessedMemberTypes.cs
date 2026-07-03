// ncrunch: no coverage start

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
[Flags]
internal enum DynamicallyAccessedMemberTypes
{
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    None                               = 0b000000000000000000000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicParameterlessConstructor     = 0b000000000000000000000001,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicConstructors                 = 0b000000000000000000000011,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicConstructors              = 0b000000000000000000000100,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicMethods                      = 0b000000000000000000001000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicMethods                   = 0b000000000000000000010000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicFields                       = 0b000000000000000000100000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicFields                    = 0b000000000000000001000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicNestedTypes                  = 0b000000000000000010000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicNestedTypes               = 0b000000000000000100000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicProperties                   = 0b000000000000001000000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicProperties                = 0b000000000000010000000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    PublicEvents                       = 0b000000000000100000000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    NonPublicEvents                    = 0b000000000001000000000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    AllConstructors                    = 0b000100000100000000000111,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    AllMethods                         = 0b000000001000000000011000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    AllFields                          = 0b000000010000000001100000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    AllProperties                      = 0b000001000000011000000000,
    /// <inheritdoc cref="_dynamicallyaccessedmembertypes" />
    All                                = -0b00000000000000000000001,
}

#endif

// ncrunch: no coverage end
