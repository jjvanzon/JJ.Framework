using JJ.Framework.Presentation.Mvc.Tests.Names;
using JJ.Framework.Presentation.Mvc.Tests.ViewModels;

namespace JJ.Framework.Presentation.Mvc.Tests.ViewMappings
{
    public class LoginIndexViewMapping : ViewMapping<LoginViewModel>
    {
        public LoginIndexViewMapping()
        {
            MapPresenter(PresenterNames.LoginPresenter, PresenterActionNames.Show);
            MapController(ControllerNames.Login, ActionNames.Index, ViewNames.Index);
        }
    }
}