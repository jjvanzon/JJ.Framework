﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JJ.Framework.Presentation.Mvc;
using JJ.Framework.Presentation;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using ActionDispatcher = JJ.Framework.Presentation.Mvc.ActionDispatcher;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.App_Start
{
    internal static class DispatcherConfig
    {
        public static void AddMappings()
        {
            ActionDispatcher.Map<NotAuthorizedViewModel>(null, null, ViewNames.NotAuthorized);

            ActionDispatcher.Map<LoginViewModel>(ControllerNames.Login, ActionNames.Index, ViewNames.Index, x => new 
            {
                ret = UrlHelpers.GetReturnUrl(x.ReturnAction) 
            });

            ActionDispatcher.Map<ListViewModel>(ControllerNames.Demo, ActionNames.Index, ViewNames.Index);

            ActionDispatcher.Map<DetailsViewModel>(ControllerNames.Demo, ActionNames.Details, ViewNames.Details, x => new 
            {
                id = x.Entity.ID 
            });

            ActionDispatcher.Map<EditViewModel>(ControllerNames.Demo, ActionNames.Edit, ViewNames.Edit, x => new 
            {
                id = x.Entity.ID, 
                ret = UrlHelpers.GetReturnUrl(x.ReturnAction) 
            });
        }
    }
}