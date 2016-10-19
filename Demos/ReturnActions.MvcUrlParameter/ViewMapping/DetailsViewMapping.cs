using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.ViewMapping
{
    public class DetailsViewMapping : ViewMapping<DetailsViewModel>
    {
        public DetailsViewMapping()
        {
            MapController(ControllerNames.Demo, ActionNames.Details, ViewNames.Details);
            MapPresenter(PresenterNames.DetailsPresenter, PresenterActionNames.Show);
        }

        protected override object GetRouteValues(DetailsViewModel viewModel)
        {
            return new { id = viewModel.Entity.ID };
        }
    }
}