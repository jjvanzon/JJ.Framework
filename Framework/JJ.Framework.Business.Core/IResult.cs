namespace JJ.Framework.Business.Core;

public interface IResult
{
    bool Success { get; set; }

    /// <summary> not nullable, auto-instantiated </summary>
    IList<string> Messages { get; set; }
}