using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMapping.Names;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;
using JJ.Framework.Mvc;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping
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