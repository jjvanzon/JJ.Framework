using System.Windows.Forms;
using JJ.Framework.WinForms.EventArg;

namespace JJ.Framework.WinForms.TestForms
{
	public partial class FilePathControlTestForm : Form
	{
		public FilePathControlTestForm() => InitializeComponent();

		private void filePathControl1_Browsed(object sender, FilePathEventArgs e) => MessageBox.Show("Browsed event went off!");
	}
}
