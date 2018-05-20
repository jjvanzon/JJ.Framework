using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.Presenters
{
	public class DetailsPresenter
	{
		public DetailsViewModel Show(int id) => new DetailsViewModel { Entity = MockViewModelFactory.CreateEntityViewModel(id) };

		public object Edit(int id, string authenticatedUserName)
		{
			var presenter2 = new EditPresenter(authenticatedUserName);
			return presenter2.Show(id, returnAction: ActionDispatcher.CreateActionInfo<DetailsPresenter>(x => x.Show(id)));
		}

		public LoginViewModel Logout() => new LoginPresenter().Show();
	}
}