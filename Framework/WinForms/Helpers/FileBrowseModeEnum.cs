using JetBrains.Annotations;
using System;

namespace JJ.Framework.WinForms.Helpers
{
	/// <summary> Would indicate the type of file browse action to use: open file, save file, select folder or none at all. </summary>
	[PublicAPI]
	public enum FileBrowseModeEnum
	{
		/// <summary> In case the dialog is opened, this option would make it be in the style for the purpose of an open file action. </summary>
		OpenFile,
		/// <summary> In case the dialog is opened, this option would make it be in the style for the purpose of a save file action. </summary>
		SaveFile,
		/// <summary> In case the dialog is opened, this option would make it be in the style for the purpose of a browse selection action. </summary>
		SelectFolder,
		/// <summary> This option might be chosen to indicate that no file or folder browse action is relevant. </summary>
		None
	}
}
