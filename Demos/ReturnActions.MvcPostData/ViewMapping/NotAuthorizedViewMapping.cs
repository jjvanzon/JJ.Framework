using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Framework.Presentation;
using JJ.Framework.Presentation.Mvc;

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