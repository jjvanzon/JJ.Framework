namespace JJ.Framework.Business.Legacy;

/// <inheritdoc cref="_result" />
public class Result : ResultBase
{
    /// <inheritdoc cref="_result" />
    public Result() { }
    /// <inheritdoc cref="_result" />
    public Result(bool success) : base(success) { }
    /// <inheritdoc cref="_result" />
    public Result(params IEnumerable<string> messages) : base(messages) { }
    /// <inheritdoc cref="_result" />
    public Result(IEnumerable<string> messages, bool success) : base(messages, success) { }
    /// <inheritdoc cref="_result" />
    public Result(bool success, params IEnumerable<string> messages) : base(success, messages) { }
}