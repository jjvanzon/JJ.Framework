
namespace JJ.Framework.Business.Legacy;

public abstract class ResultBase : IResult
{
    public override string ToString() => DebuggerDisplay(this);

    private const bool DEFAULT_SUCCESS = true;

    public bool Success { get; set; }

    private List<string> _messages;

    public ResultBase() : this(DEFAULT_SUCCESS, [ ]) { }
    public ResultBase(bool success) : this(success, [ ]) { }
    public ResultBase(params IEnumerable<string> messages) : this(DEFAULT_SUCCESS, messages) { }
    public ResultBase(IEnumerable<string> messages, bool success) : this(success, messages) { }
    public ResultBase(bool success, params IEnumerable<string> messages)
    {
        ThrowIfNull(messages);
        Success = success;
        _messages = messages.ToList();
    }

    /// <inheritdoc />
    public IList<string> Messages
    {
        get => _messages;
        set 
        {
            ThrowIfNull(value, nameof(Messages));
            _messages = value.ToList(); 
        }
    }
}