
namespace JJ.Framework.Business.Legacy;

/// <inheritdoc cref="_resultbase" />
public abstract class ResultBase : IResult
{
    /// <inheritdoc cref="_tostring" />
    public override string ToString() => DebuggerDisplay(this);

    private const bool DEFAULT_SUCCESS = true;

    /// <inheritdoc cref="_success" />
    public bool Success { get; set; }

    /// <inheritdoc cref="docs._messages" />
    private List<string> _messages;

    /// <inheritdoc cref="_resultbase" />
    public ResultBase() : this(DEFAULT_SUCCESS, [ ]) { }
    /// <inheritdoc cref="_resultbase" />
    public ResultBase(bool success) : this(success, [ ]) { }
    /// <inheritdoc cref="_resultbase" />
    public ResultBase(params IEnumerable<string> messages) : this(DEFAULT_SUCCESS, messages) { }
    /// <inheritdoc cref="_resultbase" />
    public ResultBase(IEnumerable<string> messages, bool success) : this(success, messages) { }
    /// <inheritdoc cref="_resultbase" />
    public ResultBase(bool success, params IEnumerable<string> messages)
    {
        ThrowIfNull(messages);
        Success = success;
        _messages = messages.ToList();
    }

    /// <inheritdoc cref="docs._messages" />
    public IList<string> Messages
    {
        get => _messages;
        set 
        {
            ThrowIfNull(value, nameof(Messages));
            _messages = value.ToList(); 
        }
    }

    /// <inheritdoc cref="_assert" />
    public void Assert()
    {
        if (!Success) throw new Exception(ExceptionMessage(this));
    }
}