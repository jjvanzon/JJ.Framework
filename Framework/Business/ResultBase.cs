// ReSharper disable PossibleMultipleEnumeration
namespace JJ.Framework.Business;

/// <inheritdoc cref="_resultbase" />
[DebuggerDisplay("{DebuggerDisplay}")]
public abstract class ResultBase : IResult
{
    private string DebuggerDisplay => DebuggerDisplay(this);

    /// <inheritdoc cref="_tostring" />
    public override string ToString() => Stringify(this);

    private const bool DEFAULT_SUCCESS = false;

    /// <inheritdoc cref="_success" />
    public bool Success { get; set; }

    /// <inheritdoc cref="_successful" />
    [Obsolete("Use Success instead.")]
    public bool Successful { get => Success; set => Success = value; } 

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
        Messages = messages.ToList();
    }

    /// <inheritdoc cref="docs._messages" />
    public IList<string> Messages
    {
        get;
        set
        {
            ThrowIfNull(value, nameof(Messages));
            field = value.ToList();
        }
    }

    /// <inheritdoc cref="_assert" />
    public void Assert()
    {
        if (!Success) throw new Exception(ExceptionMessage(this));
    }
    
    /// <summary> Compatibility stub </summary>
    private void ThrowIfNull(IEnumerable<string>? messages, string? paramName = null)
    {
        paramName ??= nameof(messages);
        if (messages == null) throw new ArgumentNullException(paramName);
    }
}