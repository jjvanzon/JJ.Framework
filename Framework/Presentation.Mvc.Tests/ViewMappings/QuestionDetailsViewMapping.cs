using JJ.Framework.Presentation.Mvc.Tests.Names;
using JJ.Framework.Presentation.Mvc.Tests.ViewModels;

namespace JJ.Framework.Presentation.Mvc.Tests.ViewMappings
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
