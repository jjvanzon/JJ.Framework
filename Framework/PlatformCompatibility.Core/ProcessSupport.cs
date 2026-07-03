// ncrunch: no coverage start

// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantUsingDirective.Global
// ReSharper disable RedundantUsingDirective.Local

namespace JJ.Framework.PlatformCompatibility.Core;

using docs;

/// <inheritdoc cref="_kill" />
internal static class ProcessSupport
{
    // ncrunch: no coverage start

    #if !NET5_0_OR_GREATER
    /// <inheritdoc cref="_kill" />
    public static void Kill(this System.Diagnostics.Process process, bool entireProcessTree)
    {
        process.Kill();
    }
    #endif

    // ncrunch: no coverage end
}

// ncrunch: no coverage end
