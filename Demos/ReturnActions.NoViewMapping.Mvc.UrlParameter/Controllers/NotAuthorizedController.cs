using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
    public class NotAuthorizedController : MasterController
    {
        public void Index() => View(nameof(ViewNames.NotAuthorized));
    }
}