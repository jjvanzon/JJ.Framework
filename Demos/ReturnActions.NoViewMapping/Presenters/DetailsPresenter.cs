using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
    public class DetailsPresenter
    {
        public DetailsViewModel Show(int id)
            => new DetailsViewModel { Entity = MockViewModelFactory.CreateEntityViewModel(id) };
    }
}