using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;

// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.WithViewMapping.Presenters
{
	public class ListPresenter
	{
		public ListViewModel Show() => new ListViewModel
		{
		    List = new []
		    {
		        MockViewModelFactory.CreateEntityViewModel(),
		        MockViewModelFactory.CreateEntityViewModel2()
		    }
		};

	    public object Edit(int id, string authenticatedUserName)
		{
			var presenter = new EditPresenter(authenticatedUserName);
			return presenter.Show(id, returnAction: ActionDispatcher.CreateActionInfo<ListPresenter>(x => x.Show()));
		}
	}
}
