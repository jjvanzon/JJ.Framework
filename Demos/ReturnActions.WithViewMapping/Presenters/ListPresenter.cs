using JJ.Demos.ReturnActions.WithViewMapping.Helpers;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;
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

		public DetailsViewModel Details(int id)
		{
			var presenter = new DetailsPresenter();
			return presenter.Show(id);
		}

		public object Edit(int id, string authenticatedUserName)
		{
			var presenter = new EditPresenter(authenticatedUserName);

			return presenter.Show(id, returnAction: ActionDispatcher.CreateActionInfo<ListPresenter>(x => x.Show()));
		}

		public LoginViewModel Logout()
		{
			var presenter2 = new LoginPresenter();
			return presenter2.Show();
		}
	}
}
