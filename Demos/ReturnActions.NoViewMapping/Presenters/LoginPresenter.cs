using JJ.Demos.ReturnActions.NoViewMapping.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Exceptions.Basic;

// ReSharper disable RedundantIfElseBlock
// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
    public class LoginPresenter
    {
        private readonly SecurityAsserter _securityAsserter = new SecurityAsserter();

        public ListViewModel Logout() => new ListPresenter().Show();

        public LoginViewModel Show() => new LoginViewModel();

        public LoginViewModel Login(LoginViewModel userInput)
        {
            if (userInput == null) throw new NullException(() => userInput);

            _securityAsserter.Assert(userInput.UserName);

            var viewModel = new LoginViewModel { IsAuthenticated = true, UserName = userInput.UserName };

            return viewModel;
        }
    }
}