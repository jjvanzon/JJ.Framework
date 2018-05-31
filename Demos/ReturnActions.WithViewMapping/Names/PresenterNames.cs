using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.WithViewMapping.Names
{
	public abstract class PresenterNames
	{
		public static void DetailsPresenter() => throw new NameOfOnlyException();
		public static void EditPresenter() => throw new NameOfOnlyException();
		public static void ListPresenter() => throw new NameOfOnlyException();
		public static void LoginPresenter() => throw new NameOfOnlyException();
	}
}