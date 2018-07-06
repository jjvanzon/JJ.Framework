using JJ.Demos.ReturnActions.Framework.Mvc;
using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Demos.ReturnActions.Mvc.Names;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping
{
	public abstract class NotAuthorizedViewMappingBase : ViewMapping<NotAuthorizedViewModel>
	{
		public NotAuthorizedViewMappingBase() => ViewName = nameof(ViewNamesBase.NotAuthorized);
	}
}