namespace JJ.Framework.Business.Legacy;

public interface IResult
{
    bool Success { get; set; }
    IList<string> Messages { get; set; }
}