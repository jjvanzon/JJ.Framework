// ReSharper disable InconsistentNaming

using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Names
{
	internal static class SessionKeys
	{
		public static string AuthenticatedUserName => throw new NameOfOnlyException();
	}
}