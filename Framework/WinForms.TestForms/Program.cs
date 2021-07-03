using System;
using System.Reflection;
using System.Windows.Forms;
using JJ.Framework.WinForms.Helpers;

namespace JJ.Framework.WinForms.TestForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UnhandledExceptionMessageBoxShower.Initialize(Assembly.GetExecutingAssembly().GetName().Name);

            Application.Run(new PickATestForm());
        }
    }
}
