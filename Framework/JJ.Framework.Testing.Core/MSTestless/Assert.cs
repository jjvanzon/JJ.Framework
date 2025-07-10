namespace JJ.Framework.Testing.Core.MSTestless;

/// <inheritdoc cref="_assert" />
public static class Assert
{
    /// <inheritdoc cref="_assert" />
    public static void AreEqual<T>(T? expected, T? actual)
        => AssertCore.AreEqual(expected, actual);
}