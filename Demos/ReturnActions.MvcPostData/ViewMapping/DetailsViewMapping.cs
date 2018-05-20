using JetBrains.Annotations;
using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostData.ViewMapping
{
	[UsedImplicitly]
	public class DetailsViewMapping : ViewMapping<DetailsViewModel>
	{
		public DetailsViewMapping()
		{
			MapController(ControllerNames.Demo, ActionNames.Details, ViewNames.Details);
			MapPresenter(PresenterNames.DetailsPresenter, PresenterActionNames.Show);
		}

		protected override object GetRouteValues(DetailsViewModel viewModel) => new { id = viewModel.Entity.ID };
	}
}