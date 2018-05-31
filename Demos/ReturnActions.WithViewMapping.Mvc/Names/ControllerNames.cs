using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names
{
	public static class ControllerNames
	{
		public static void Demo() => throw new NameOfOnlyException();
		public static void Login() => throw new NameOfOnlyException();
	}
}