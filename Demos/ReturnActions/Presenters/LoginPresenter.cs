using JJ.Demos.ReturnActions.Extensions;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Presentation;

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.Presenters
{
	public class LoginPresenter
	{
		private readonly ActionInfo _defaultReturnAction;

		public LoginPresenter() => _defaultReturnAction = ActionDispatcher.CreateActionInfo<ListPresenter>(x => x.Show());

		public object Logout() => new ListPresenter().Show();

		public LoginViewModel Show(ActionInfo returnAction = null)
			=> new LoginViewModel
			{
				ReturnAction = returnAction ?? _defaultReturnAction
			};

		public object Login(LoginViewModel viewModel)
		{
			if (viewModel == null) throw new NullException(() => viewModel);

			viewModel.NullCoalesce();

			viewModel.ReturnAction = viewModel.ReturnAction ?? _defaultReturnAction;

			// Fake authentication
			if (string.IsNullOrEmpty(viewModel.UserName))
			{
				return Show();
			}

			return ActionDispatcher.Dispatch(viewModel.ReturnAction, new { authenticatedUserName = viewModel.UserName });
		}
	}
}