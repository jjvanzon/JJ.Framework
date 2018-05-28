using System.Web.Mvc;
using JJ.Demos.ReturnActions.MvcUrlParameter.Names;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Controllers
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