﻿using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
using JJ.Framework.Exceptions;
using JJ.Demos.ReturnActions.Extensions;
using System;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Demos.ReturnActions.Presenters
{
	public class LoginPresenter
	{
		private ActionInfo _defaultReturnAction;

		public LoginPresenter()
		{
			_defaultReturnAction = ActionDispatcher.CreateActionInfo<ListPresenter>(x => x.Show());
		}

		public object Logout()
		{
			var presenter2 = new ListPresenter();
			object viewModel = presenter2.Show();
			return viewModel;
		}
					
		public LoginViewModel Show(ActionInfo returnAction = null)
		{
			return new LoginViewModel
			{
				ReturnAction = returnAction ?? _defaultReturnAction
			};
		}

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
