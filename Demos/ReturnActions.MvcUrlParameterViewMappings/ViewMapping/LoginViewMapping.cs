using JetBrains.Annotations;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.ViewMapping;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.ViewMapping
{
	[UsedImplicitly]
	public class LoginViewMapping : LoginViewMappingBase
	{
		protected override object GetRouteValues(LoginViewModel viewModel) => new { ret = TryGetReturnUrl(viewModel.ReturnAction) };
	}
}