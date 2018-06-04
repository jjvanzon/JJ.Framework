using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;

// ReSharper disable MemberCanBeMadeStatic.Global

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