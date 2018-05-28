using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names
{
	public static class ControllerNames
	{
		public static void Demo() => throw new NameOfOnlyException();
		public static void Login() => throw new NameOfOnlyException();
	}
}