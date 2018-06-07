using System;
using JJ.Demos.ReturnActions.NoViewMapping.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Presentation;
// ReSharper disable RedundantIfElseBlock

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
    public class LoginPresenter
    {
        private readonly SecurityAsserter _securityAsserter = new SecurityAsserter();

        public ListViewModel Logout() => new ListPresenter().Show();

        public LoginViewModel Show(string returnAction = null)
            => new LoginViewModel
            {
                ReturnAction = returnAction
            };

        public AuthenticatedViewModel Login(LoginViewModel viewModel)
        {
            if (viewModel == null) throw new NullException(() => viewModel);

            // Fake authentication
            _securityAsserter.Assert(viewModel.UserName);

            return new AuthenticatedViewModel { AuthenticatedUserName = viewModel.UserName };
        }
    }
}