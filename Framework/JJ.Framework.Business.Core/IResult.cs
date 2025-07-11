namespace JJ.Framework.Business.Core;

public interface IResult
{
    bool Success { get; set; }
    IList<string> Messages { get; set; }
}