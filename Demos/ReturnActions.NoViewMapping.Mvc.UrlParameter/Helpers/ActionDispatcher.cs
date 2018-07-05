using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Helpers
{
    public class ActionDispatcher : ActionDispatcherBase
    {
        private static readonly ActionDispatcherBase _singleton = new ActionDispatcher();

        public new static ActionResult Dispatch(Controller sourceController, object viewModel, [CallerMemberName] string sourceActionName = "")
            => _singleton.Dispatch(sourceController, viewModel, sourceActionName);

        protected override IList<(Type viewModelType, string controllerName, string httpGetActionName, string viewName)> DispatchTuples { get; }
            = new[]
            {
                (typeof(ListViewModel), nameof(ControllerNames.Demo), nameof(ActionNames.Index), nameof(ViewNames.Index)),
                (typeof(DetailsViewModel), nameof(ControllerNames.Demo), nameof(ActionNames.Details), nameof(ViewNames.Details)),
                (typeof(EditViewModel), nameof(ControllerNames.Demo), nameof(ActionNames.Edit), nameof(ViewNames.Edit)),
                (typeof(LoginViewModel), nameof(ControllerNames.Login), nameof(ActionNames.Index), nameof(ViewNames.Index))
            };

        protected override object TryGetRouteValues(object viewModel)
        {
            switch (viewModel)
            {
                case DetailsViewModel castedViewModel: return new { id = castedViewModel.Entity.ID };
                case EditViewModel castedViewModel: return new { id = castedViewModel.Entity.ID };
            }

            return null;
        }

        protected override IList<string> GetValidationMesssages(object viewModel) => new string[0];
    }
}