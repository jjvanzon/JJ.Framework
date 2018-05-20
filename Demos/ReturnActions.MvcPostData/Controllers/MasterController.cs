using System.Web.Mvc;
using JJ.Demos.ReturnActions.MvcPostDataViewMappings.Names;

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings.Controllers
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