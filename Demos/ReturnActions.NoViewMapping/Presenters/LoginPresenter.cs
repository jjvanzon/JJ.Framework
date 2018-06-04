using System;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Presentation;
// ReSharper disable RedundantIfElseBlock

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
    public class LoginPresenter
    {
        public object Logout() => new ListPresenter().Show();

        public LoginViewModel Show(string returnAction = null)
            => new LoginViewModel
            {
                ReturnAction = returnAction
            };

        public object Login(LoginViewModel viewModel)
        {
            if (viewModel == null) throw new NullException(() => viewModel);

            viewModel.ReturnAction = viewModel.ReturnAction;

            // Fake authentication
            if (string.IsNullOrEmpty(viewModel.UserName))
            {
                return Show();
            }
            else
            {
                return new AuthenticatedViewModel { AuthenticatedUserName = viewModel.UserName };
            }
        }
    }
}