// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#if NETSTANDARD || NETFRAMEWORK

namespace JJ.Framework.PlatformCompatibility.Core;

using docs;

/// <inheritdoc cref="_operatingsystemsupport" />
internal static class OperatingSystemSupport
{
    /// <inheritdoc cref="_iswindows" />
    public static bool IsWindows() 
    {
        #if WINDOWS || TARGET_WINDOWS
            return true;
        #else
            return false;
        #endif
    }
}
#endif