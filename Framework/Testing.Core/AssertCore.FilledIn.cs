namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Prios - Overload with explicitly passed message comes first, which includes the argument expression as well.

    // Null

    public static void IsNotNull([NotNull] object? value, [ArgExpress(nameof(value))] string expression = "")
        => NotNull(value, expression);

    [Prio(1)]
    public static void IsNotNull([NotNull] object? value, string message, [ArgExpress(nameof(value))] string expression = "")
        => NotNull(value, message, expression);

    public static void NotNull([NotNull] object? value, [ArgExpress(nameof(value))] string expression = "")
    {
        Check(value != null, message: expression);
        ThrowIfNull(value);
    }

    [Prio(1)]
    public static void NotNull([NotNull] object? value, string message, [ArgExpress(nameof(value))] string expression = "")
    {
        Check(value != null, message: expression + " " + message);
        ThrowIfNull(value);
    }

    public static void IsNull(object? value, [ArgExpress(nameof(value))] string expression = "") 
        => Check(value == null, message: expression);

    [Prio(1)]
    public static void IsNull(object? value, string message, [ArgExpress(nameof(value))] string expression = "") 
        => Check(value == null, message: expression + " " + message);

    // NullOrEmpty

    public static void IsNotNullOrEmpty([NotNull] string? value, [ArgExpress(nameof(value))] string expression = "")
        => NotNullOrEmpty(value, expression);

    [Prio(1)]
    public static void IsNotNullOrEmpty([NotNull] string? value, string message, [ArgExpress(nameof(value))] string expression = "")
        => NotNullOrEmpty(value, message, expression);

    public static void NotNullOrEmpty([NotNull] string? value, [ArgExpress(nameof(value))] string expression = "")
    {
        Check(!string.IsNullOrEmpty(value), message: expression);
        ThrowIfNull(value);
    }

    [Prio(1)]
    public static void NotNullOrEmpty([NotNull] string? value, string message, [ArgExpress(nameof(value))] string expression = "")
    {
        Check(!string.IsNullOrEmpty(value), message: expression + " " + message);
        ThrowIfNull(value);
    }

    public static void IsNullOrEmpty(string? value, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrEmpty(value), message: expression);

    [Prio(1)]
    public static void IsNullOrEmpty(string? value, string message, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrEmpty(value), message: expression + " " + message);

    public static void NullOrEmpty(string? value, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrEmpty(value), message: expression);

    [Prio(1)]
    public static void NullOrEmpty(string? value, string message, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrEmpty(value), message: expression + " " + message);

    // NullOrWhiteSpace

    public static void IsNotNullOrWhiteSpace([NotNull] string? value, [ArgExpress(nameof(value))] string expression = "")
        => NotNullOrWhiteSpace(value, expression);

    [Prio(1)]
    public static void IsNotNullOrWhiteSpace([NotNull] string? value, string message, [ArgExpress(nameof(value))] string expression = "")
        => NotNullOrWhiteSpace(value, message, expression);

    public static void NotNullOrWhiteSpace([NotNull] string? value, [ArgExpress(nameof(value))] string expression = "")
    {
        Check(!string.IsNullOrWhiteSpace(value), message: expression);
        ThrowIfNull(value);
    }

    [Prio(1)]
    public static void NotNullOrWhiteSpace([NotNull] string? value, string message, [ArgExpress(nameof(value))] string expression = "")
    {
        Check(!string.IsNullOrWhiteSpace(value), message: expression + " " + message);
        ThrowIfNull(value);
    }

    public static void IsNullOrWhiteSpace(string? value, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrWhiteSpace(value), message: expression);

    [Prio(1)]
    public static void IsNullOrWhiteSpace(string? value, string message, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrWhiteSpace(value), message: expression + " " + message);

    public static void NullOrWhiteSpace(string? value, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrWhiteSpace(value), message: expression);

    [Prio(1)]
    public static void NullOrWhiteSpace(string? value, string message, [ArgExpress(nameof(value))] string expression = "") 
        => Check(string.IsNullOrWhiteSpace(value), message: expression + " " + message);

    // FilledIn

    // TODO: Many overloads

    //public static void IsFilledIn<T>([NotNull] T? value, [ArgExpress(nameof(value))] string message = "")
    //{
    //    Check(value.FilledIn(), message: message);
    //    ThrowIfNull(value);
    //}
}