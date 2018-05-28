using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.Names
{
	public abstract class PresenterActionNames
	{
		public static void Show() => throw new NameOfOnlyException();
	}
}
