using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Mapping
{
    public class EditMapping : ViewMapping<EditViewModel>
    {
        public EditMapping()
            : base(ViewNames.Edit)
        {
            MapController(ControllerNames.Demo, ActionNames.Edit);
            MapPresenter(PresenterNames.EditPresenter, PresenterActionNames.Show);
        }

        protected override object GetRouteValues(EditViewModel viewModel)
        {
            return new { id = viewModel.Entity.ID };
        }
    }
}