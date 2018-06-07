using JetBrains.Annotations;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.UrlParameter.ViewMapping
{
	[UsedImplicitly]
	public class LoginViewMapping : LoginViewMappingBase
	{
		protected override object TryGetRouteValues(LoginViewModel viewModel) => new { ret = TryGetReturnUrl(viewModel.ReturnAction) };
	}
}