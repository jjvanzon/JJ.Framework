
using JJ.Framework.Presentation.WinForms.TestForms.SvgWithFlatClone;
using JJ.Framework.Presentation.WinForms.TestForms.SvgWithoutCloning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            //Application.Run(new HelloWorldTestForm());
            Application.Run(new HierarchyTestForm());
            //Application.Run(new SvgWithFlatClone_TestForm());
            //Application.Run(new SvgWithoutCloning_TestForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
        }
    }
}
