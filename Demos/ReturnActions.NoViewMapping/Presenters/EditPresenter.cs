using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.Extensions;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Presentation;
// ReSharper disable RedundantIfElseBlock

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
    public class EditPresenter
    {
        private readonly string _authenticatedUserName;

        /// <param name="authenticatedUserName">nullable</param>
        public EditPresenter(string authenticatedUserName) => _authenticatedUserName = authenticatedUserName;

        public object Show(int id, string returnAction = null, string thisAction = null)
        {
            if (string.IsNullOrEmpty(_authenticatedUserName))
            {
                return new LoginPresenter().Show(thisAction);
            }
            else
            {
                return new EditViewModel
                {
                    Entity = MockViewModelFactory.CreateEntityViewModel(id),
                    ReturnAction = returnAction
                };
            }
        }

        public object Save(EditViewModel viewModel)
        {
            if (viewModel == null) throw new NullException(() => viewModel);

            viewModel.NullCoalesce();

            viewModel.ReturnAction = viewModel.ReturnAction;

            if (string.IsNullOrEmpty(_authenticatedUserName))
            {
                return new NotAuthorizedViewModel();
            }
            else
            {
                return new AuthenticatedViewModel { AuthenticatedUserName = _authenticatedUserName };
            }
        }
    }
}