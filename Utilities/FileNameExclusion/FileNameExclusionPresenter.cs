using System;
using System.Collections.Generic;
using JJ.Framework.IO;
using JJ.Framework.ResourceStrings;
using JJ.Framework.Text;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileNameExclusion
{
    public class FileNameExclusionPresenter
    {
        private readonly IFileNameExcluder _fileNameExcluder;

        public FileNameExclusionPresenter(IFileNameExcluder fileNameExcluder)
            => _fileNameExcluder = fileNameExcluder;

        public FileNameExclusionViewModel ViewModel { get; } = CreateEmptyViewModel();

        // Actions

        public void RunProcess()
        {
            ClearMessages(ViewModel);

            IValidator validator = new FileNameExclusionViewModelValidator(ViewModel);
            if (!validator.IsValid)
            {
                ViewModel.ValidationMessages = validator.Messages;
                return;
            }

            if (!string.IsNullOrWhiteSpace(ViewModel.OutputList))
            {
                ViewModel.AreYouSureQuestion = CommonResourceFormatter.AreYouSure;
            }
            else
            {
                AreYouSureYes();
            }
        }

        public void AreYouSureYes()
        {
            IList<string> inputListSplit = ViewModel.InputList.Split(Environment.NewLine);
            IList<string> exclusionListSplit = ViewModel.ExclusionList.Split(Environment.NewLine);

            IList<string> outputList = _fileNameExcluder.Execute(inputListSplit, exclusionListSplit);

            ViewModel.OutputList = string.Join(Environment.NewLine, outputList);
            ViewModel.DonePopupMessage = CommonResourceFormatter.Done;
        }

        // Helpers

        private static FileNameExclusionViewModel CreateEmptyViewModel()
            => new FileNameExclusionViewModel
            {
                DonePopupMessage = "",
                ValidationMessages = new List<string>()
            };

        private static void ClearMessages(FileNameExclusionViewModel viewModel)
        {
            viewModel.DonePopupMessage = "";
            viewModel.ValidationMessages = new List<string>();
        }
    }
}
