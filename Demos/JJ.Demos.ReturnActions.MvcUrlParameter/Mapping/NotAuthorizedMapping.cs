using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Framework.Presentation;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Mapping
{
    public class NotAuthorizedMapping : ViewMapping<NotAuthorizedViewModel>
    {
        public NotAuthorizedMapping()
            : base(ViewNames.NotAuthorized)
        { }
    }
}