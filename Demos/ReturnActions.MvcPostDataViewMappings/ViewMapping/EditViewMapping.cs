using JetBrains.Annotations;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.ViewMapping;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings.ViewMapping
{
	[UsedImplicitly]
	public class EditViewMapping : EditViewMappingBase
	{
		protected override object GetRouteValues(EditViewModel viewModel) => new { id = viewModel.Entity.ID };
	}
}