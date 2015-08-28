using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
