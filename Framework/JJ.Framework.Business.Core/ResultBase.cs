namespace JJ.Framework.Business.Core;

public abstract class ResultBase : IResult
{
    public override string ToString() => DebuggerDisplay(this);

    public bool Successful { get; set; }

    private IList<string> _messages;

    public ResultBase() => _messages = [ ];
    public ResultBase(params string[] messages) => _messages = NotNull(messages);

    /// <inheritdoc />
    public IList<string> Messages
    {
        get => _messages;
        set => _messages = NotNull(value);
    }
}