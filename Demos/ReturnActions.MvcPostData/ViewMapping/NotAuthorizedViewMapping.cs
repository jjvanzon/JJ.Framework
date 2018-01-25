using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Framework.Mvc;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.MvcPostData.ViewMapping
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