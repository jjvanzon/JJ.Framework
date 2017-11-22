using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.ViewModels.Entities;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.Presenters
{
	public class ListPresenter
	{
		public ListViewModel Show()
		{
			return new ListViewModel
			{
				List = new EntityViewModel[]
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
