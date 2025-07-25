﻿// ReSharper disable UnusedParameter.Local
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using static System.ComponentModel.DesignerSerializationVisibility;

namespace JJ.Framework.Presentation.WinForms.Legacy
{
    public partial class SimpleFileProcessControl : UserControl
    {
        public event EventHandler OnRunProcess;

        public SimpleFileProcessControl()
        {
            InitializeComponent();

            _isRunning = false;
        }

        private void SimpleFileProcessControl_Load(object sender, EventArgs e)
        {
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
                // you cannot use the property on another thread.
                string filePath = FilePath;

                Async(() => RunProcess(filePath));
            }
        }

        private void Cancel()
        {
            IsRunning = false;
        }

        // Processing
        
        private void RunProcess(string filePath)
        {
            IsRunning = true;

            // try-catch outcommented because the Microsoft Visual Studio 2012 Express for Web only breaks on non-user-handled exceptions.
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

            IsRunning = false;
        }

        // Progress Label

        public void ShowProgress(string message)
        {
            OnUiThread(() => labelProgress.Text = message);
        }

        // IsRunning

        private volatile bool _isRunning;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(Hidden)]
        public bool IsRunning
        {
            get { return _isRunning; }
            set 
            {
                _isRunning = value;
                ApplyIsRunning();
            }
        }

        private void ApplyIsRunning()
        {
            OnUiThread(() =>
            {
                buttonStart.Enabled = !_isRunning;
                buttonCancel.Enabled = _isRunning;
                textBoxFilePath.Enabled = !_isRunning;
            });
        }

        // Other Properties

        [Browsable(true)]
        [DefaultValue("")]
        public string FilePath
        {
            get { return textBoxFilePath.Text; }
            set { textBoxFilePath.Text = value; }
        }

        
        [Browsable(true)]
        [DefaultValue("")]
        [EditorAttribute(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design",
            "System.Drawing.Design.UITypeEditor")]
        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        }

        // Helpers

        private void OnUiThread(Action action)
        {
            this.BeginInvoke(action);
        }

        private void Async(Action action)
        {
            var thread = new Thread(new ThreadStart(action));
            thread.Start();
        }
    }
}
