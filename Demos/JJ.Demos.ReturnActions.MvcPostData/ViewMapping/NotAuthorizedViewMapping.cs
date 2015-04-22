using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Framework.Presentation;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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