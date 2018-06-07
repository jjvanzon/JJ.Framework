using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
    public class ErrorController : MasterController
    {
        public void Index() => View(nameof(ViewNames.Error));
    }
}