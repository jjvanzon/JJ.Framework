
namespace JJ.Framework.Business.Core;

public abstract class ResultBase : IResult
{
    public override string ToString() => DebuggerDisplay(this);

    public bool Successful { get; set; }

    private IList<string> _messages = new List<string>();

    public ResultBase() { }
    public ResultBase(params string[] messages) => Messages = messages;

    /// <inheritdoc />
    public IList<string> Messages
    {
        get => _messages;
        set => _messages = value ?? throw new ArgumentNullException(nameof(value));
    }
}