#if NETSTANDARD || NETFRAMEWORK

namespace JJ.Framework.PlatformCompatibility.Core;

using System.Runtime.InteropServices;

internal static class OperatingSystemSupport
{
    public static bool IsWindows() 
    {
        //#if WINDOWS
        //    return true;
        //#else
        //    return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        //#endif

        #if WINDOWS || TARGET_WINDOWS
            return true;
        #else
            return false;
        #endif
    }
}
#endif