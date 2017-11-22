using System;
using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.ThreadException += Application_ThreadException;

			Application.Run(new PickATestForm());
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			// Just the fact that I have this handler makes my dev environment stop at thread exceptions (with VS Express 2012 for Web).
		}
	}
}
