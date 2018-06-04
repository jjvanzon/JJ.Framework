using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
    public class ListPresenter
    {
        public ListViewModel Show()
            => new ListViewModel
            {
                List = new[]
                {
                    MockViewModelFactory.CreateEntityViewModel(),
                    MockViewModelFactory.CreateEntityViewModel2()
                }
            };
    }
}