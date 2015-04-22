using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Demos.ReturnActions.MvcPostData.ViewMapping
{
    public class EditViewMapping : ViewMapping<EditViewModel>
    {
        public EditViewMapping()
        {
            MapController(ControllerNames.Demo, ActionNames.Edit, ViewNames.Edit);
            MapPresenter(PresenterNames.EditPresenter, PresenterActionNames.Show);
        }

        protected override object GetRouteValues(EditViewModel viewModel)
        {
            return new { id = viewModel.Entity.ID };
        }
    }
}