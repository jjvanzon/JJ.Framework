using System.Web.Mvc;
using JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.Names;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.Controllers
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