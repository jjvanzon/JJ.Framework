using JJ.Framework.Presentation.Mvc.Tests.Names;
using JJ.Framework.Presentation.Mvc.Tests.ViewModels;

namespace JJ.Framework.Presentation.Mvc.Tests.ViewMappings
{
    public class QuestionEditViewMapping : ViewMapping<QuestionEditViewModel>
    {
        public QuestionEditViewMapping()
        {
            MapPresenter(PresenterNames.QuestionEditPresenter, PresenterActionNames.Edit);
            MapController(ControllerNames.Questions, ActionNames.Edit, ViewNames.Edit);
            MapParameter(PresenterParameterNames.id, ActionParameterNames.id);
        }
    }
}