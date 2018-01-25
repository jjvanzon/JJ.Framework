using JJ.Framework.Mvc.Tests.Names;
using JJ.Framework.Mvc.Tests.ViewModels;

namespace JJ.Framework.Mvc.Tests.ViewMappings
{
	internal class QuestionDetailsViewMapping : ViewMapping<QuestionDetailsViewModel>
	{
		public QuestionDetailsViewMapping()
		{
			MapPresenter(PresenterNames.QuestionDetailsPresenter, PresenterActionNames.Show);
			MapController(ControllerNames.Questions, ActionNames.Details, ViewNames.Details);
			MapParameter(PresenterParameterNames.id, ActionParameterNames.id);
		}
	}
}
