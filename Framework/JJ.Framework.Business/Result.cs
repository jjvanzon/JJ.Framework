namespace JJ.Framework.Business.Legacy;

public class Result : ResultBase
{
    public Result() { }
    public Result(bool success) : base(success) { }
    public Result(params IEnumerable<string> messages) : base(messages) { }
    public Result(IEnumerable<string> messages, bool success) : base(messages, success) { }
    public Result(bool success, params IEnumerable<string> messages) : base(success, messages) { }
}