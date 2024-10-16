﻿using System.Reflection;
using ActionDispatcher = JJ.Demos.ReturnActions.Framework.Mvc.ActionDispatcher;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData
{
    public static class DispatcherConfig
    {
        public static void AddMappings() => ActionDispatcher.RegisterAssembly(Assembly.GetExecutingAssembly());
    }
}