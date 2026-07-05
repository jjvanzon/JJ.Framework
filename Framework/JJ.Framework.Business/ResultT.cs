namespace JJ.Framework.Business.Legacy;

/// <inheritdoc cref="_resultoft" />
public class Result<T> : ResultBase
{
    /// <inheritdoc cref="_resultoft" />
    public Result() { }
    /// <inheritdoc cref="_resultoft" />
    public Result(bool success) : base(success) { }
    /// <inheritdoc cref="_resultoft" />
    public Result(params IEnumerable<string> messages) : base(messages) { }
    /// <inheritdoc cref="_resultoft" />
    public Result(IEnumerable<string> messages, bool success) : base(messages, success) { }
    /// <inheritdoc cref="_resultoft" />
    public Result(bool success, params IEnumerable<string> messages) : base(success, messages) { }

    /// <inheritdoc cref="_data" />
    public T? Data { get; set; }
}