using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Puzzle.NPersist.Tools.QueryAnalyzer.Startup
{
	/// <summary>
	/// Summary description for AppEntry.
	/// </summary>
	public class AppEntry
	{
		public static Puzzle.NPersist.Tools.QueryAnalyzer.Form1 frm;

		public AppEntry()
		{
		}
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();

			CustomExceptionHandler eh = new CustomExceptionHandler();

			Application.ThreadException += new ThreadExceptionEventHandler(eh.OnThreadException);

			SplashForm splash = new SplashForm() ;

			try
			{
				splash.Show();
			}
			catch (Exception)
			{				
			}

			Thread.Sleep(4000);

			splash.Close() ;

			frm = new Form1() ;
			Application.Run(frm);
		}


		// Creates a class to handle the exception event.
		private class CustomExceptionHandler
		{
			// Handles the exception event.
			public void OnThreadException(object sender, ThreadExceptionEventArgs t)
			{
				DialogResult result = System.Windows.Forms.DialogResult.Cancel;
				try
				{
					result = this.ShowThreadExceptionDialog(t.Exception);					
				}
				catch
				{
					try
					{
						MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);				
					}
					finally
					{
						Application.Exit();					
					}					
				}

				// Exits the program when the user clicks Abort.
				if (result == System.Windows.Forms.DialogResult.Abort)
				{
//					if (frm.SaveModel(true))
//					{
						Application.Exit();							
//					}
				}
			}

																									   
			// Creates the error message and displays it.
			private DialogResult ShowThreadExceptionDialog(Exception e)
			{
				StringWriter errorMsg = new StringWriter();
				errorMsg.WriteLine("An error occurred please contact the adminstrator with the following information:");
				errorMsg.WriteLine("");
				errorMsg.WriteLine(e.Message);
				errorMsg.WriteLine("");
				errorMsg.WriteLine("Stack Trace:");
				errorMsg.WriteLine(e.StackTrace);
				return MessageBox.Show(errorMsg.ToString(), "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
				
			}
			
		}

	}
}
