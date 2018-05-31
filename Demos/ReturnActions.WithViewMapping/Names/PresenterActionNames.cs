using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.WithViewMapping.Names
{
	public abstract class PresenterActionNames
	{
		public static void Show() => throw new NameOfOnlyException();
	}
}
