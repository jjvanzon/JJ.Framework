using System;

namespace JJ.Framework.WinForms.EventArg
{
	public class OnRunProcessEventArgs : EventArgs
	{
		public string FilePath { get; set; }

		public OnRunProcessEventArgs()
		{ }

		public OnRunProcessEventArgs(string filePath) => FilePath = filePath;
	}
}
