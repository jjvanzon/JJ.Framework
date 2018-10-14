using System;

namespace Puzzle.NPersist.Tools.QueryAnalyzer.SyntaxBoxWrapper
{
	/// <summary>
	/// Summary description for ITextBox.
	/// </summary>
	public interface ITextBox
	{
		string Text { get; set; }

		string SelectedText { get; set; }
	}
}
