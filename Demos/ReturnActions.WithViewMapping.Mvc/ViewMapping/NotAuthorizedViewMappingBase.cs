using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;
using JJ.Framework.Mvc;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping
{
	public abstract class NotAuthorizedViewMappingBase : ViewMapping<NotAuthorizedViewModel>
	{
		public NotAuthorizedViewMappingBase() => ViewName = nameof(ViewNamesBase.NotAuthorized);
	}
}