namespace JJ.Framework.Exceptions.Core;

public static class Throw
{
    public static T NotNull<T>([NotNull] T? x, [ArgExpress(nameof(x))] string expression = "")
    {
        if (x == null)
        {
            throw new ArgumentNullException(expression, $"'{expression}' is null.");
        }
        return x;
    }
}