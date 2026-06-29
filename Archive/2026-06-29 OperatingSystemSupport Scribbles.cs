
using System.Runtime.InteropServices;
        //#if WINDOWS
        //    return true;
        //#else
        //    return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        //#endif

// TODO: Remove outcommented
//RunTests<Lock_Tests>() &&

#if NETFRAMEWORK || NETSTANDARD
global using static JJ.Framework.PlatformCompatibility.Core.OperatingSystemSupport;
#else
global using static System.OperatingSystem;
#endif