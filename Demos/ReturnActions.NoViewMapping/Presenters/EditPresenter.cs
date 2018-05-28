using System;
using JJ.Demos.ReturnActions.NoViewMapping.Extensions;
using JJ.Demos.ReturnActions.NoViewMapping.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Presentation;

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
	public class EditPresenter
	{
		private static readonly string _defaultReturnAction;
		private readonly string _authenticatedUserName;

		static EditPresenter() => _defaultReturnAction = "List/Show";

		/// <param name="authenticatedUserName">nullable</param>
		public EditPresenter(string authenticatedUserName) => _authenticatedUserName = authenticatedUserName;

		public object Show(int id, string returnAction = null)
		{
			if (string.IsNullOrEmpty(_authenticatedUserName))
			{
				var presenter2 = new LoginPresenter();
				throw new NotImplementedException();
				//object viewModel = presenter2.Show(ActionDispatcher.CreateActionInfo<EditPresenter>(x => x.Show(id, returnAction)));
				//return viewModel;
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

			throw new NotImplementedException();
			//return ActionDispatcher.Dispatch(viewModel.ReturnAction, new { authenticatedUserName = _authenticatedUserName });
		}

		public LoginViewModel Logout() => new LoginPresenter().Show();
	}
}