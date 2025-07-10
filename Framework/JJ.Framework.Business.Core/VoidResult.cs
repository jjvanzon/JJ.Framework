namespace JJ.Framework.Business.Core;

public class VoidResult : ResultBase
{
    public VoidResult() : base() { }
    public VoidResult(bool successful) : base(successful) { }
    public VoidResult(params IEnumerable<string> messages) : base(messages) { }
    public VoidResult(IEnumerable<string> messages, bool successful) : base(messages, successful) { }
    public VoidResult(bool successful, params IEnumerable<string> messages) : base(successful, messages) { }
}