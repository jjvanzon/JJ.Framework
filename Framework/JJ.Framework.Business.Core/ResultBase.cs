
namespace JJ.Framework.Business.Core;

public abstract class ResultBase : IResult
{
    public override string ToString() => DebuggerDisplay(this);

    private const bool DefaultSuccessful = true;

    public bool Successful { get; set; }

    private IList<string> _messages;

    public ResultBase() : this(DefaultSuccessful, [ ]) { }
    public ResultBase(bool successful) : this(successful, [ ]) { }
    public ResultBase(params IEnumerable<string> messages) : this(DefaultSuccessful, messages) { }
    public ResultBase(IEnumerable<string> messages, bool successful) : this(successful, messages) { }
    public ResultBase(bool successful, params IEnumerable<string> messages)
    {
        Successful = successful;
        _messages = NotNull(messages).ToList();
    }

    /// <inheritdoc />
    public IList<string> Messages
    {
        get => _messages;
        set => _messages = NotNull(value);
    }
}