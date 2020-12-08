using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JJ.Framework.Text;
using JJ.Framework.Validation;

namespace JJ.Utilities.FileNameExclusion.WinForms
{
	public class FileNameExclusionPresenter
	{
		public FileNameExclusionViewModel ViewModel { get; set; }

		public void RunProcess()
		{
			IValidator validator = new FileNameExclusionViewModelValidator(ViewModel);

			if (!validator.IsValid)
			{
				ViewModel.ValidationMessages = validator.Messages;
				return;
			}

			IList<string> inputListSplit = ViewModel.InputList.Split(Environment.NewLine);
			IList<string> formattedExclusionList = FormatExclusionList();
			IList<string> outputList = new List<string>();

			foreach (string inputFilePath in inputListSplit)
			{
				string inputFileName = GetInputFileName(inputFilePath);

				bool isExcluded =
					formattedExclusionList.Any(x => string.Equals(x, inputFileName, StringComparison.OrdinalIgnoreCase));

				if (!isExcluded)
				{
					outputList.Add(inputFilePath);
				}
			}

			ViewModel.OutputList = string.Join(Environment.NewLine, outputList);
		}

		private IList<string> FormatExclusionList()
			=> ViewModel.InputList
			            .Split(Environment.NewLine)
			            .Select(x => Path.GetFileName(FormatPath(x)))
			            .ToList();

		private static string GetInputFileName(string inputFilePath) => Path.GetFileName(FormatPath(inputFilePath));

		private static string FormatPath(string inputFilePath)
			=> inputFilePath.Trim()
			                .TrimStart(@"""")
			                .TrimEnd(@"""");
	}
}
