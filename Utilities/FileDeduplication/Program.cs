using System;
using System.Windows.Forms;
using JJ.Framework.WinForms.Helpers;
using JJ.Utilities.FileDeduplication.Properties;

namespace JJ.Utilities.FileDeduplication
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			UnhandledExceptionMessageBoxShower.Initialize(Resources.ApplicationName);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
