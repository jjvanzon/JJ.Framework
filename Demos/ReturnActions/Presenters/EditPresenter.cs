using JJ.Demos.ReturnActions.Extensions;
using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.Presenters
{
	public class EditPresenter
	{
		private static readonly ActionInfo _defaultReturnAction;
		private readonly string _authenticatedUserName;

		static EditPresenter() => _defaultReturnAction = ActionDispatcher.CreateActionInfo<ListPresenter>(x => x.Show());

		/// <param name="authenticatedUserName">nullable</param>
		public EditPresenter(string authenticatedUserName) => _authenticatedUserName = authenticatedUserName;

		public object Show(int id, ActionInfo returnAction = null)
		{
			if (string.IsNullOrEmpty(_authenticatedUserName))
			{
				var presenter2 = new LoginPresenter();
				object viewModel = presenter2.Show(ActionDispatcher.CreateActionInfo<EditPresenter>(x => x.Show(id, returnAction)));
				return viewModel;
			}

			return new EditViewModel
			{
				Entity = MockViewModelFactory.CreateEntityViewModel(id),
				ReturnAction = returnAction ?? _defaultReturnAction
			};
		}

		public object Save(EditViewModel viewModel)
		{
			if (viewModel == null) throw new NullException(() => viewModel);

			viewModel.NullCoalesce();

			viewModel.ReturnAction = viewModel.ReturnAction ?? _defaultReturnAction;

			if (string.IsNullOrEmpty(_authenticatedUserName))
			{
				return new NotAuthorizedViewModel();
			}

			return ActionDispatcher.Dispatch(viewModel.ReturnAction, new { authenticatedUserName = _authenticatedUserName });
		}

		public LoginViewModel Logout() => new LoginPresenter().Show();
	}
}