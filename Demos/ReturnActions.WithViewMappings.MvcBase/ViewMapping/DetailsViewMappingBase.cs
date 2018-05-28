using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names;
using JJ.Framework.Mvc;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMappings.MvcBase.ViewMapping
{
	public abstract class DetailsViewMappingBase : ViewMapping<DetailsViewModel>
	{
		public DetailsViewMappingBase()
		{
			MapController(nameof(ControllerNames.Demo), nameof(ActionNamesBase.Details), nameof(ActionNamesBase.Details));
			MapPresenter(nameof(PresenterNames.DetailsPresenter), nameof(PresenterActionNames.Show));
		}

		protected sealed override object GetRouteValues(DetailsViewModel viewModel) => new { id = viewModel.Entity.ID };
	}
}