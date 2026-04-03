// ReSharper disable UnusedMember.Global

namespace Microsoft.VisualStudio.TestTools.UnitTesting;

/// <inheritdoc cref="_assert" />
public static class Assert
{
    /// <inheritdoc cref="_areequal" />
    public static void AreEqual<T>(T? expected, T? actual)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
        {
            throw new Exception($"Assert.AreEqual failed. Expected: {expected}, Actual: {actual}");
        }
    }
    
    /// <inheritdoc cref="_aresame" />
    public static void AreSame<T>(T expected, T actual)
    {
        if (!ReferenceEquals(expected, actual))
        {
            throw new Exception("Assert.AreSame failed. Expected same instance, but got different.");
        }
    }
    
    /// <inheritdoc cref="_istrue" />
    public static void IsTrue(bool value)
    {
        if (!value)
        {
            throw new Exception("Assert.IsTrue failed.");
        }
    }
}