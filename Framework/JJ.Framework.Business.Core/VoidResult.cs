namespace JJ.Framework.Business.Core;

public class VoidResult : ResultBase
{
    public VoidResult() { }
    public VoidResult(params string[] messages) : base(messages) { }
}