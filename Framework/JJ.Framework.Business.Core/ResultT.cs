namespace JJ.Framework.Business.Core;

public class Result<T> : ResultBase
{
    public Result() { }
    public Result(params string[] messages) : base(messages) { }

    public required T Data { get; set; }
}