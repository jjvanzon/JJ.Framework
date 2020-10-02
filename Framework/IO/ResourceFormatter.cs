using JJ.Framework.Resources;

namespace JJ.Framework.IO
{
	internal static class ResourceFormatter
	{
		private static readonly ResourceFormatterHelper _helper = new ResourceFormatterHelper(Resources.ResourceManager);

		public static string DeletingFiles_WithPercentage_AndFileName(decimal percentage, string fileName)
			=> _helper.GetText_WithTwoPlaceHolders(percentage, fileName);
		public static string DoneDeletingFiles_WithCount(int count) => _helper.GetText_WithOnePlaceHolder(count);
		public static string DoneScanning_WithDuplicatesFound(int duplicatesFound) => _helper.GetText_WithOnePlaceHolder(duplicatesFound);
		public static string ListingFiles => _helper.GetText();
		public static string ProcessingResult => _helper.GetText();
		public static string ScanningForDuplicates => _helper.GetText();
		public static string ScanningForDuplicates_WithPercentage(decimal percentage) => _helper.GetText_WithOnePlaceHolder(percentage);
	}
}
