using JJ.Demos.ReturnActions.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.Extensions;
using JJ.Demos.ReturnActions.NoViewMapping.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Exceptions.Basic;

// ReSharper disable RedundantIfElseBlock

namespace JJ.Demos.ReturnActions.NoViewMapping.Presenters
{
    public class EditPresenter
    {
        private readonly SecurityAsserter _securityAsserter = new SecurityAsserter();
        private readonly string _authenticatedUserName;

        /// <param name="authenticatedUserName">nullable</param>
        public EditPresenter(string authenticatedUserName) => _authenticatedUserName = authenticatedUserName;

        public EditViewModel Show(int id)
        {
            _securityAsserter.Assert(_authenticatedUserName);

            return new EditViewModel
            {
                Entity = MockViewModelFactory.CreateEntityViewModel(id),
            };
        }

        public EditViewModel Save(EditViewModel viewModel)
        {
            if (viewModel == null) throw new NullException(() => viewModel);
            viewModel.NullCoalesce();

            _securityAsserter.Assert(_authenticatedUserName);

            // Fake Save
            viewModel.Successful = true;

            return viewModel;
        }
    }
}