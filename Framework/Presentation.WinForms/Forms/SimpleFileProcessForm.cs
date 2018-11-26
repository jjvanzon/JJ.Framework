﻿using System;
using System.ComponentModel;
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
            get { return simpleFileProcessControl.IsRunning; }
            set { simpleFileProcessControl.IsRunning = value; }
        }

        public void ShowProgress(string message)
        {
            simpleFileProcessControl.ShowProgress(message);
        }

        public string FilePath
        {
            get { return simpleFileProcessControl.FilePath; }
            set { simpleFileProcessControl.FilePath = value; }
        }

        [Editor(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design",
            "System.Drawing.Design.UITypeEditor")]
        public string Description
        {
            get { return simpleFileProcessControl.Description; ; }
            set { simpleFileProcessControl.Description = value; }
        }

        public bool MustShowExceptions
        {
            get { return simpleFileProcessControl.MustShowExceptions; }
            set { simpleFileProcessControl.MustShowExceptions = value; }
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
