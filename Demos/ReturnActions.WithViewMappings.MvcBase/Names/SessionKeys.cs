using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names
{
	public static class SessionKeys
	{
		public static void AuthenticatedUserName() => throw new NameOfOnlyException();
	}
}