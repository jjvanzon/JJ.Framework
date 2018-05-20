using JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.MvcUrlParameterViewMappings.ViewMapping
{
	public class EditViewMapping : ViewMapping<EditViewModel>
	{
		public EditViewMapping()
		{
			MapController(ControllerNames.Demo, ActionNames.Edit, ViewNames.Edit);
			MapPresenter(PresenterNames.EditPresenter, PresenterActionNames.Show);
		}

		protected override object GetRouteValues(EditViewModel viewModel)
		{
			return new 
			{ 
				id = viewModel.Entity.ID, 
				ret = TryGetReturnUrl(viewModel.ReturnAction) 
			};
		}
	}
}