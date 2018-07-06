using JJ.Demos.ReturnActions.Framework.Mvc;
using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMapping.Names;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping
{
    public abstract class ListViewMappingBase : ViewMapping<ListViewModel>
    {
        public ListViewMappingBase()
        {
            MapController(nameof(ControllerNames.Demo), nameof(ActionNamesBase.Index), nameof(ViewNamesBase.Index));
            MapPresenter(nameof(PresenterNames.ListPresenter), nameof(PresenterActionNames.Show));
        }
    }
}