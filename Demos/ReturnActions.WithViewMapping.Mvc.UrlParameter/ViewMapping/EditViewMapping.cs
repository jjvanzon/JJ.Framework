using JetBrains.Annotations;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.UrlParameter.ViewMapping
{
	[UsedImplicitly]
	public class EditViewMapping : EditViewMappingBase
	{
		protected override object TryGetRouteValues(EditViewModel viewModel)
			=> new
			{
				id = viewModel.Entity.ID,
				ret = TryGetReturnUrl(viewModel.ReturnAction)
			};
	}
}