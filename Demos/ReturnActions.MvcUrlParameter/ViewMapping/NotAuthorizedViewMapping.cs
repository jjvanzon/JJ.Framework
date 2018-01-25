using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Framework.Mvc;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.ViewMapping
{
	public class NotAuthorizedViewMapping : ViewMapping<NotAuthorizedViewModel>
	{
		public NotAuthorizedViewMapping()
		{
			ViewName = ViewNames.NotAuthorized;
		}
	}
}