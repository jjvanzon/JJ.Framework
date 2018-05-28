using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Demos.ReturnActions.WithViewMapping.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMappings.MvcBase.Names;
using JJ.Framework.Mvc;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMappings.MvcBase.ViewMapping
{
	public abstract class EditViewMappingBase : ViewMapping<EditViewModel>
	{
		public EditViewMappingBase()
		{
			MapController(nameof(ControllerNames.Demo), nameof(ActionNamesBase.Edit), nameof(ViewNamesBase.Edit));
			MapPresenter(nameof(PresenterNames.EditPresenter), nameof(PresenterActionNames.Show));
		}
	}
}