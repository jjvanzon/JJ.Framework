using JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.ViewMapping
{
	public class ListViewMapping : ViewMapping<ListViewModel>
	{
		public ListViewMapping()
		{
			MapController(ControllerNames.Demo, ActionNames.Index, ViewNames.Index);
			MapPresenter(PresenterNames.ListPresenter, PresenterActionNames.Show);
		}
	}
}