using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.WithViewMapping.Presenters
{
	public class ListPresenter
	{
		public ListViewModel Show()
		{
			return new ListViewModel
			{
				List = new []
				{
					MockViewModelFactory.CreateEntityViewModel(),
					MockViewModelFactory.CreateEntityViewModel2()
				}
			};
		}

		public object Edit(int id, string authenticatedUserName)
		{
			var presenter = new EditPresenter(authenticatedUserName);
			return presenter.Show(id, returnAction: ActionDispatcher.CreateActionInfo<ListPresenter>(x => x.Show()));
		}
	}
}
