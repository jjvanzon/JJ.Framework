using System.Web.Mvc;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData.Controllers
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