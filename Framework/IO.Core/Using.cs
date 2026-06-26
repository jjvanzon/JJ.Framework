global using JJ.Framework.Common.Legacy;
global using JJ.Framework.Reflection.Legacy;
#if NETFRAMEWORK || NETSTANDARD
global using static JJ.Framework.PlatformCompatibility.Core.OperatingSystemSupport;
#else
global using static System.OperatingSystem;
#endif