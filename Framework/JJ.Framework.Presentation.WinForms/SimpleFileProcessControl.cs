using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace JJ.Framework.Presentation.WinForms
{
    public partial class SimpleFileProcessControl : UserControl
    {
        public event EventHandler OnRunProcess;

        public SimpleFileProcessControl()
        {
            InitializeComponent();

            _isRunning = false;

            ApplyIsRunning();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Start()
        {
            if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RunProcess(textBoxFilePath.Text);
            }
        }

        private void RunProcess(string filePath)
        {
            Async(() => RunProcessSync(filePath));
        }

        private void RunProcessSync(string filePath)
        {
            _isRunning = true;

            ApplyIsRunningAsync();

            /*try
            {*/
                if (OnRunProcess != null)
                {
                    OnRunProcess(this, EventArgs.Empty);
                }
            /*}
            catch (Exception ex)
            {
                if (MustShowExceptions)
                {
                    OnUiThread(() => MessageBox.Show(ex.Message));
                }
                else
                {
                    throw;
                }
            }*/

            _isRunning = false;

            ApplyIsRunningAsync();
        }

        public void ShowProgress(string message)
        {
            OnUiThread(() => ShowProgressSync(message));
        }

        private void ShowProgressSync(string message)
        {
            labelProgress.Text = message;
        }

        private void Cancel()
        {
            _isRunning = false;
            ApplyIsRunning();
        }

        private void OnUiThread(Action action)
        {
            this.BeginInvoke(action);
        }

        private void Async(Action action)
        {
            var thread = new Thread(new ThreadStart(action));
            thread.Start();
        }

        // IsRunning

        private volatile bool _isRunning;
        
        [Browsable(false)]
        public bool IsRunning
        {
            get { return _isRunning; }
            set 
            {
                if (_isRunning == value) return;
                _isRunning = value;
                ApplyIsRunningAsync();
            }
        }

        private void ApplyIsRunningAsync()
        {
            OnUiThread(() => ApplyIsRunning());
        }

        private void ApplyIsRunning()
        {
            buttonStart.Enabled = !_isRunning;
            buttonCancel.Enabled = _isRunning;
            textBoxFilePath.Enabled = !_isRunning;
        }

        // Other Properties

        public string FilePath
        {
            get { return textBoxFilePath.Text; ; }
            set { textBoxFilePath.Text = value; }
        }

        [EditorAttribute(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design",
            "System.Drawing.Design.UITypeEditor")]
        public string Description
        {
            get { return labelDescription.Text; ; }
            set { labelDescription.Text = value; }
        }
    }
}
