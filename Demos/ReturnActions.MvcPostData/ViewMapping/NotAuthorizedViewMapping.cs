using JJ.Demos.ReturnActions.MvcPostDataViewMappings.Names;
using JJ.Framework.Mvc;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings.ViewMapping
{
	public class NotAuthorizedViewMapping : ViewMapping<NotAuthorizedViewModel>
	{
		public NotAuthorizedViewMapping()
			: base()
		{
			ViewName = ViewNames.NotAuthorized;
		}
	}
}