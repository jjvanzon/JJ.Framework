using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.Mvc.Names
{
	public static class SessionKeys
	{
		public static void AuthenticatedUserName() => throw new NameOfOnlyException();
	}
}