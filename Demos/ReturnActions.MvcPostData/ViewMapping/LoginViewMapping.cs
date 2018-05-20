using JJ.Demos.ReturnActions.MvcPostDataViewMappings.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings.ViewMapping
{
	public class LoginViewMapping : ViewMapping<LoginViewModel>
	{
		public LoginViewMapping()
		{
			MapController(ControllerNames.Login, ActionNames.Index, ViewNames.Index);
			MapPresenter(PresenterNames.LoginPresenter, PresenterActionNames.Show);
		}
	}
}