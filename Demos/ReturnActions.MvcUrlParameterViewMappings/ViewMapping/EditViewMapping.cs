using JetBrains.Annotations;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.ViewMapping;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.ViewMapping
{
	[UsedImplicitly]
	public class EditViewMapping : EditViewMappingBase
	{
		protected override object GetRouteValues(EditViewModel viewModel)
			=> new
			{
				id = viewModel.Entity.ID,
				ret = TryGetReturnUrl(viewModel.ReturnAction)
			};
	}
}