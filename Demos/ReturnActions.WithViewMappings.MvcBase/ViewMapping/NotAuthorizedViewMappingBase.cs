using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names;
using JJ.Framework.Mvc;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.WithViewMappings.MvcBase.ViewMapping
{
	public abstract class NotAuthorizedViewMappingBase : ViewMapping<NotAuthorizedViewModel>
	{
		public NotAuthorizedViewMappingBase() => ViewName = nameof(ViewNamesBase.NotAuthorized);
	}
}