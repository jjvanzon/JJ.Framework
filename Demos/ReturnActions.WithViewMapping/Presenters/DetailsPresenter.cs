using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.WithViewMapping.Presenters
{
	public class DetailsPresenter
	{
		public DetailsViewModel Show(int id) => new DetailsViewModel { Entity = MockViewModelFactory.CreateEntityViewModel(id) };

		public object Edit(int id, string authenticatedUserName)
		{
			var presenter2 = new EditPresenter(authenticatedUserName);
			return presenter2.Show(id, returnAction: ActionDispatcher.CreateActionInfo<DetailsPresenter>(x => x.Show(id)));
		}
	}
}