// ReSharper disable UnusedParameter.Global

using System.Diagnostics;

namespace JJ.Framework.PlatformCompatibility.Core;

using docs;

/// <inheritdoc cref="_kill" />
internal static class ProcessSupport
{
    #if !NET5_0_OR_GREATER
    /// <inheritdoc cref="_kill" />
    public static void Kill(this Process process, bool entireProcessTree)
    {
        process.Kill();
    }
    #endif
}
