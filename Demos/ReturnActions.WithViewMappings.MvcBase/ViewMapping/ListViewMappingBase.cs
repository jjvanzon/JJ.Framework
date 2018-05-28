using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names;
using JJ.Framework.Mvc;
// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.ViewMapping
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