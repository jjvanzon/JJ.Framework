using JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.Names;
using JJ.Framework.Mvc;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.ViewMapping
{
	public class NotAuthorizedViewMapping : ViewMapping<NotAuthorizedViewModel>
	{
		public NotAuthorizedViewMapping()
		{
			ViewName = ViewNames.NotAuthorized;
		}
	}
}