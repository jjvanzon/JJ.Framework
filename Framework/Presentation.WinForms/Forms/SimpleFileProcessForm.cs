using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.Forms
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

        public new string Text { get { return null; } set { } }

        public event EventHandler OnRunProcess;

        [Browsable(false)]
        public bool IsRunning
        {
            get => simpleFileProcessControl.IsRunning;
            set => simpleFileProcessControl.IsRunning = value;
        }

        public void ShowProgress(string message)
        {
            simpleFileProcessControl.ShowProgress(message);
        }

        public string FilePath
        {
            get => simpleFileProcessControl.FilePath;
            set => simpleFileProcessControl.FilePath = value;
        }

        [Editor(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design",
            "System.Drawing.Design.UITypeEditor")]
        public string Description
        {
            get => simpleFileProcessControl.Description;
            set => simpleFileProcessControl.Description = value;
        }

        public bool MustShowExceptions
        {
            get => simpleFileProcessControl.MustShowExceptions;
            set => simpleFileProcessControl.MustShowExceptions = value;
        }

        private void SimpleFileProcessForm_Load(object sender, EventArgs e) => PositionControls();
        private void SimpleFileProcessForm_SizeChanged(object sender, EventArgs e) => PositionControls();

        private void PositionControls()
        {
            simpleFileProcessControl.Location = new Point(0, 0);
            simpleFileProcessControl.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);
        }

        private void simpleProcessControl_OnRunProcess(object sender, EventArgs e)
        {
            OnRunProcess?.Invoke(sender, e);
        }

        private void Base_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = simpleFileProcessControl.IsRunning;
        }
    }
}
