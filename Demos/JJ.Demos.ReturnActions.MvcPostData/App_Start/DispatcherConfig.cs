using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
using JJ.Demos.ReturnActions.MvcPostData.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActionDispatcher = JJ.Framework.Presentation.Mvc.ActionDispatcher;
using System.Reflection;

namespace JJ.Demos.ReturnActions.MvcPostData.App_Start
{
    internal static class DispatcherConfig
    {
        public static void AddMappings()
        {
            ActionDispatcher.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}