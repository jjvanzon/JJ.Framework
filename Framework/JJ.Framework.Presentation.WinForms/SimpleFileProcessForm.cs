using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.DesignerSerializationVisibility;

namespace JJ.Framework.Presentation.WinForms.Legacy
{
    public partial class SimpleFileProcessForm : Form
    {
        public SimpleFileProcessForm()
        {
            InitializeComponent();

            if (Assembly.GetEntryAssembly() != null)
            {
                base.Text = Assembly.GetEntryAssembly().GetName().Name;
            }

            simpleFileProcessControl.OnRunProcess += simpleProcessControl_OnRunProcess;
        }

        [Browsable(true)]
        [DefaultValue("")]
        public new string Text { get { return null; } set { } }

        public event EventHandler OnRunProcess;

        [Browsable(false)]
        [DesignerSerializationVisibility(Hidden)]
        public bool IsRunning
        {
            get { return simpleFileProcessControl.IsRunning; }
            set { simpleFileProcessControl.IsRunning = value; }
        }

        public void ShowProgress(string message)
        {
            simpleFileProcessControl.ShowProgress(message);
        }

        [Browsable(true)]
        [DefaultValue("")]
        public string FilePath
        {
            get { return simpleFileProcessControl.FilePath; }
            set { simpleFileProcessControl.FilePath = value; }
        }

        [Browsable(true)]
        [DefaultValue("")]
        [EditorAttribute(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design",
            "System.Drawing.Design.UITypeEditor")]
        public string Description
        {
            get { return simpleFileProcessControl.Description; }
            set { simpleFileProcessControl.Description = value; }
        }

        private void simpleProcessControl_OnRunProcess(object sender, EventArgs e)
        {
            if (OnRunProcess != null)
            {
                OnRunProcess(sender, e);
            }
        }

        private void Base_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = simpleFileProcessControl.IsRunning;
        }
    }
}
