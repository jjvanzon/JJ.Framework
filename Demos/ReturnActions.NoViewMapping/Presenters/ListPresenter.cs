using System;
using JJ.Demos.ReturnActions.NoViewMapping.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
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

			throw new NotImplementedException();

			//object returnAction = ActionDispatcher.CreateActionInfo<ListPresenter>(x => x.Show());
			//return presenter.Show(id, returnAction);
		}

		public LoginViewModel Logout()
		{
			var presenter2 = new LoginPresenter();
			return presenter2.Show();
		}
	}
}
