using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class FilePathControlTestForm : Form
    {
        public FilePathControlTestForm()
        {
            InitializeComponent();
        }

        private void filePathControl1_Browsed(object sender, EventArg.FilePathEventArgs e)
        {
            MessageBox.Show("Browsed event went off!");
        }
    }
}
