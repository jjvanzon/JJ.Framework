namespace JJ.Framework.Business;

public class VoidResult : Result;

public static class ResultCompatibilityExtensions
{
    public static bool Successful(IResult result) => result.Success;
}
