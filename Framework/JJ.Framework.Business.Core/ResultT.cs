namespace JJ.Framework.Business.Core;

public class Result<T> : ResultBase
{
    public Result() : base() { }
    public Result(bool successful) : base(successful) { }
    public Result(params IEnumerable<string> messages) : base(messages) { }
    public Result(IEnumerable<string> messages, bool successful) : base(messages, successful) { }
    public Result(bool successful, params IEnumerable<string> messages) : base(successful, messages) { }

    public required T Data { get; set; }
}