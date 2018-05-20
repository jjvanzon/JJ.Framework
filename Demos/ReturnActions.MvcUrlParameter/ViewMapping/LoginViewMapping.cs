using JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.ViewMapping
{
	public class LoginViewMapping : ViewMapping<LoginViewModel>
	{
		public LoginViewMapping()
		{
			MapController(ControllerNames.Login, ActionNames.Index, ViewNames.Index);
			MapPresenter(PresenterNames.LoginPresenter, PresenterActionNames.Show);
		}

		protected override object GetRouteValues(LoginViewModel viewModel)
		{
			return new
			{
				ret = TryGetReturnUrl(viewModel.ReturnAction)
			};
		}
	}
}