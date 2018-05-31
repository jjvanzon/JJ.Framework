using JetBrains.Annotations;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData.ViewMapping
{
	[UsedImplicitly]
	public class EditViewMapping : EditViewMappingBase
	{
		protected override object GetRouteValues(EditViewModel viewModel) => new { id = viewModel.Entity.ID };
	}
}