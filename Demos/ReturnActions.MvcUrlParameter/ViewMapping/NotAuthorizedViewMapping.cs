using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Framework.Presentation;
using JJ.Framework.Presentation.Mvc;

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