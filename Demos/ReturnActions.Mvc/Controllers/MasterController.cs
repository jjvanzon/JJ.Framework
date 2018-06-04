using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Names;

namespace JJ.Demos.ReturnActions.Mvc.Controllers
{
	public class MasterController : Controller
	{
		protected string GetAuthenticatedUserName() => (string)Session[nameof(SessionKeys.AuthenticatedUserName)];
	    protected void SetAuthenticatedUserName(string value) => Session[nameof(SessionKeys.AuthenticatedUserName)] = value;
	}
}