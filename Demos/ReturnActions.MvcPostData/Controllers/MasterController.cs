using System.Web.Mvc;
using JJ.Demos.ReturnActions.MvcPostData.Names;

namespace JJ.Demos.ReturnActions.MvcPostData.Controllers
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