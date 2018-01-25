using System;
using System.Threading;
using System.Windows.Forms;
using JJ.Framework.Logging;

namespace JJ.Framework.WinForms.Helpers
{
	public static class UnhandledExceptionMessageBoxShower
	{
		private static string _applicationName;

		public static void Initialize(string applicationName)
		{
			_applicationName = applicationName;

			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			string message;
			if (e.ExceptionObject is Exception ex)
			{
				message = ExceptionHelper.FormatException(ExceptionHelper.GetInnermostException(ex), false);
			}
			else
			{
				message = Convert.ToString(e.ExceptionObject);
			}

			MessageBox.Show(message, GetMessageBoxCaption());
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Exception ex = ExceptionHelper.GetInnermostException(e.Exception);
			MessageBox.Show(ExceptionHelper.FormatException(ex, false), GetMessageBoxCaption());
		}

		private static string GetMessageBoxCaption() => $"{_applicationName} - Exception";
	}
}
