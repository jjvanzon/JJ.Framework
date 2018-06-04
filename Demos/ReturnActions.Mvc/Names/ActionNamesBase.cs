using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.Mvc.Names
{
	public abstract class ActionNamesBase
	{
		public static void Index() => throw new NameOfOnlyException();
		public static void Details() => throw new NameOfOnlyException();
		public static void Edit() => throw new NameOfOnlyException();
		public static void Logout() => throw new NameOfOnlyException();
	}
}