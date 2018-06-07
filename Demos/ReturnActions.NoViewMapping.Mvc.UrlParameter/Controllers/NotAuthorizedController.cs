using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;
using JJ.Framework.Web;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
    public class NotAuthorizedController : MasterController
    {
        public void Index()
        {
            Response.StatusCode = HttpStatusCodes.NOT_AUTHORIZED_403;
            View(nameof(ViewNames.NotAuthorized));
        }
    }
}