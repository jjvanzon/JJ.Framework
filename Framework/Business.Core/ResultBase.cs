
namespace JJ.Framework.Business.Core;

public abstract class ResultBase : IResult
{
    public override string ToString() => DebuggerDisplay(this);

    private const bool DefaultSuccess = true;

    public bool Success { get; set; }

    private IList<string> _messages;

    public ResultBase() : this(DefaultSuccess, [ ]) { }
    public ResultBase(bool success) : this(success, [ ]) { }
    public ResultBase(params IEnumerable<string> messages) : this(DefaultSuccess, messages) { }
    public ResultBase(IEnumerable<string> messages, bool success) : this(success, messages) { }
    public ResultBase(bool success, params IEnumerable<string> messages)
    {
        Success = success;
        _messages = NotNull(messages).ToList();
    }

    /// <inheritdoc />
    public IList<string> Messages
    {
        get => _messages;
        set => _messages = NotNull(value);
    }
}