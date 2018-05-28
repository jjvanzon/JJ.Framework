using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names;
using JJ.Framework.Mvc;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMappings.MvcBase.ViewMapping
{
	public abstract class LoginViewMappingBase : ViewMapping<LoginViewModel>
	{
		public LoginViewMappingBase()
		{
			MapController(nameof(ControllerNames.Login), nameof(ActionNamesBase.Index), nameof(ActionNamesBase.Index));
			MapPresenter(nameof(PresenterNames.LoginPresenter), nameof(PresenterActionNames.Show));
		}
	}
}