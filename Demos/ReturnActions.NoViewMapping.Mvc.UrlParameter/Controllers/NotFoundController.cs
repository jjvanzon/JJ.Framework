using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;
using JJ.Framework.Web;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
    public class NotFoundController : MasterController
    {
        public ActionResult Index()
        {
            Response.StatusCode = HttpStatusCodes.NOT_FOUND_404;
            return View(nameof(ViewNames.NotFound));
        }
    }
}