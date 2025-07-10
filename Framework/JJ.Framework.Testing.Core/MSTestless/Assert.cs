namespace JJ.Framework.Testing.Core.MSTestless;

public static class Assert
{
    public static void AreEqual<T>(T expected, T actual)
        => AssertCore.AreEqual(expected, actual);
}