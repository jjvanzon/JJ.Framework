using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
using JJ.Demos.ReturnActions.MvcPostData.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActionDispatcher = JJ.Framework.Presentation.Mvc.ActionDispatcher;

namespace JJ.Demos.ReturnActions.MvcPostData.App_Start
{
    internal static class DispatcherConfig
    {
        public static void AddMappings()
        {
            throw new Exception(
                "Framework.Presentation.Mvc no longer supports this kind of view mapping. " + 
                "Use ViewMapping<TViewModel> implementations if you want to breathe new life into this demo code.");
            //ActionDispatcher.Map_Old<NotAuthorizedViewModel>(null, null, ViewNames.NotAuthorized);
            //ActionDispatcher.Map_Old<LoginViewModel>(ControllerNames.Login, ActionNames.Index, ViewNames.Index);
            //ActionDispatcher.Map_Old<ListViewModel>(ControllerNames.Demo, ActionNames.Index, ViewNames.Index);
            //ActionDispatcher.Map_Old<DetailsViewModel>(ControllerNames.Demo, ActionNames.Details, ViewNames.Details, x => new { id = x.Entity.ID });
            //ActionDispatcher.Map_Old<EditViewModel>(ControllerNames.Demo, ActionNames.Edit, ViewNames.Edit, x => new { id = x.Entity.ID });
        }
    }
}