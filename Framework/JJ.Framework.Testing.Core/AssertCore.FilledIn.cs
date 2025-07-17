namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Null

    public static void IsNotNull([NotNull] object? value, [ArgExpress(nameof(value))] string message = "")
        => NotNull(value, message);

    public static void NotNull([NotNull] object? value, [ArgExpress(nameof(value))] string message = "")
    {
        Check(value != null, message: message);
        ThrowIfNull(value);
    }

    public static void IsNull(object? value, [ArgExpress(nameof(value))] string message = "") 
        => Check(value == null, message: message);

    // NullOrEmpty

    public static void IsNotNullOrEmpty([NotNull] string? value, [ArgExpress(nameof(value))] string message = "")
        => NotNullOrEmpty(value, message);

    public static void NotNullOrEmpty([NotNull] string? value, [ArgExpress(nameof(value))] string message = "")
    {
        Check(!string.IsNullOrEmpty(value), message: message);
        ThrowIfNull(value);
    }

    public static void IsNullOrEmpty(string? value, [ArgExpress(nameof(value))] string message = "") 
        => Check(string.IsNullOrEmpty(value), message: message);

    public static void NullOrEmpty(string? value, [ArgExpress(nameof(value))] string message = "") 
        => Check(string.IsNullOrEmpty(value), message: message);

    // NullOrWhiteSpace

    public static void IsNotNullOrWhiteSpace([NotNull] string? value, [ArgExpress(nameof(value))] string message = "")
        => NotNullOrWhiteSpace(value, message);

    public static void NotNullOrWhiteSpace([NotNull] string? value, [ArgExpress(nameof(value))] string message = "")
    {
        Check(!string.IsNullOrWhiteSpace(value), message: message);
        ThrowIfNull(value);
    }

    public static void IsNullOrWhiteSpace(string? value, [ArgExpress(nameof(value))] string message = "") 
        => Check(string.IsNullOrWhiteSpace(value), message: message);

    public static void NullOrWhiteSpace(string? value, [ArgExpress(nameof(value))] string message = "") 
        => Check(string.IsNullOrWhiteSpace(value), message: message);

    // FilledIn

    // TODO: Many overloads

    //public static void IsFilledIn<T>([NotNull] T? value, [ArgExpress(nameof(value))] string message = "")
    //{
    //    Check(value.FilledIn(), message: message);
    //    ThrowIfNull(value);
    //}
}