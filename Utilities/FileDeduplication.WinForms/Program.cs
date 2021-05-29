using System;
using System.Windows.Forms;
using JJ.Framework.Common;
using JJ.Framework.Configuration;
using JJ.Framework.WinForms.Helpers;

namespace JJ.Utilities.FileDeduplication.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Message box for unhandled exceptions.
            UnhandledExceptionMessageBoxShower.Initialize(ResourceFormatter.ApplicationName);

            // Culture from config.
            string fixedCultureName = AppSettingsReader<IAppSettings>.Get(x => x.FixedCultureName);
            if (!string.IsNullOrWhiteSpace(fixedCultureName))
            {
                CultureHelper.SetCurrentCultureName(fixedCultureName);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FileDeduplicationForm());
        }
    }
}
