using JJ.Demos.ReturnActions.Framework.Mvc;
using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMapping.Names;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping
{
    public abstract class DetailsViewMappingBase : ViewMapping<DetailsViewModel>
    {
        public DetailsViewMappingBase()
        {
            MapController(nameof(ControllerNames.Demo), nameof(ActionNamesBase.Details), nameof(ActionNamesBase.Details));
            MapPresenter(nameof(PresenterNames.DetailsPresenter), nameof(PresenterActionNames.Show));
        }

        protected sealed override object TryGetRouteValues(DetailsViewModel viewModel) => new { id = viewModel.Entity.ID };
    }
}