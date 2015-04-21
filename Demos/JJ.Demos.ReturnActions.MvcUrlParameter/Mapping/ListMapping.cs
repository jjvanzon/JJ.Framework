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
    public class ListMapping : ViewMapping<ListViewModel>
    {
        public ListMapping()
            : base(ViewNames.Index)
        {
            MapController(ControllerNames.Demo, ActionNames.Index);
            MapPresenter(PresenterNames.ListPresenter, PresenterActionNames.Show);
        }
    }
}