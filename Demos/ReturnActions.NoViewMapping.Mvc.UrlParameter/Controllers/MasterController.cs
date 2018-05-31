using System.Web.Mvc;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
	public class MasterController : Controller
	{
		protected string GetAuthenticatedUserName()
		{
			return (string)Session[nameof(SessionKeys.AuthenticatedUserName)];
		}

		protected void SetAuthenticatedUserName(string value)
		{
			Session[nameof(SessionKeys.AuthenticatedUserName)] = value;
		}
	}
}