using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Demos.ReturnActions.WithViewMapping.Names;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;
using JJ.Framework.Mvc;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.ViewMapping
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