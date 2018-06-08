using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names
{
	public abstract class ActionNames : ActionNamesBase
	{
	    public static void GenerateArbitraryError() => throw new NameOfOnlyException();
	    public static void GenerateAthenticationError() => throw new NameOfOnlyException();
	    public static void GenerateAuthorizationError() => throw new NameOfOnlyException();
	    public static void GenerateNotFoundError() => throw new NameOfOnlyException();
    }
}