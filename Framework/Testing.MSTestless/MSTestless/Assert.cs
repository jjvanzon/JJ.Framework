// ReSharper disable UnusedMember.Global

using JJ.Framework.Testing.Core;

namespace Microsoft.VisualStudio.TestTools.UnitTesting;

/// <inheritdoc cref="_assert" />
public static class Assert
{
    /// <inheritdoc cref="_areequal" />
    public static void AreEqual<T>(T? expected, T? actual)
        => AssertCore.AreEqual(expected, actual);
    
    /// <inheritdoc cref="_aresame" />
    public static void AreSame<T>(T expected, T actual)
        => AssertCore.AreSame(expected, actual);
    
    /// <inheritdoc cref="_istrue" />
    public static void IsTrue(bool value)
        => AssertCore.IsTrue(value);
}