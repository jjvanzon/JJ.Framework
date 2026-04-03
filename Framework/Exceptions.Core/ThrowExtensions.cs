namespace JJ.Framework.Exceptions.Core;

public static class ThrowExtensions
{
    // ReSharper disable once UnusedParameter.Global
    public static T NotNull<T>(this object chainedFrom, [NotNull] T? x, [ArgExpress(nameof(x))] string expression = "")
        => Throw.NotNull(x, expression);
}