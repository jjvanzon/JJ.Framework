using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;
using JJ.Framework.Web;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
    public class ErrorController : MasterController
    {
        public void Index()
        {
            Response.StatusCode = HttpStatusCodes.INTERNAL_SERVER_ERROR_500;
            View(nameof(ViewNames.Error));
        }
    }
}