using System;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Exceptions.Basic;

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
	public class LoginPresenter
	{
		private readonly string _defaultReturnAction;

		public LoginPresenter() => _defaultReturnAction = "List/Show";

		public object Logout() => new ListPresenter().Show();

		public LoginViewModel Show(string returnAction = null)
			=> new LoginViewModel
			{
				ReturnAction = returnAction ?? _defaultReturnAction
			};

		public object Login(LoginViewModel viewModel)
		{
			if (viewModel == null) throw new NullException(() => viewModel);

			viewModel.ReturnAction = viewModel.ReturnAction ?? _defaultReturnAction;

			// Fake authentication
			if (string.IsNullOrEmpty(viewModel.UserName))
			{
				return Show();
			}

			throw new NotImplementedException();
			//return ActionDispatcher.Dispatch(viewModel.ReturnAction, new { authenticatedUserName = viewModel.UserName });
		}
	}
}