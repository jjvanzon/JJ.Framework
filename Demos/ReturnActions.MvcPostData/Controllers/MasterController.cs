using JJ.Demos.ReturnActions.MvcPostData.Names;
using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostData.Controllers
{
	public class MasterController : Controller
	{
		protected string GetAuthenticatedUserName()
		{
			return (string)Session[SessionKeys.AuthenticatedUserName];
		}

		protected void SetAuthenticatedUserName(string value)
		{
			Session[SessionKeys.AuthenticatedUserName] = value;
		}
	}
}