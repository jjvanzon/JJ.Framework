using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;
using JJ.Framework.WinForms.Controls;
using JJ.Framework.WinForms.Helpers;
// ReSharper disable once ValueParameterNotUsed

namespace JJ.Framework.WinForms.Forms
{
	[PublicAPI]
	public partial class SimpleFileProcessForm : Form
	{
		public event EventHandler OnRunProcess;

		// Initialization

		public SimpleFileProcessForm()
		{
			InitializeComponent();

			if (Assembly.GetEntryAssembly() != null)
			{
				base.Text = Assembly.GetEntryAssembly().GetName().Name;
			}

			simpleFileProcessControl.OnRunProcess += simpleProcessControl_OnRunProcess;
		}

		private void SimpleFileProcessForm_Load(object sender, EventArgs e) => PositionControls();

		// Properties

		[Browsable(false)]
		public bool IsRunning
		{
			get => simpleFileProcessControl.IsRunning;
			set => simpleFileProcessControl.IsRunning = value;
		}

		[Editor(
			"System.ComponentModel.Design.MultilineStringEditor, System.Design",
			"System.Drawing.Design.UITypeEditor")]
		public string Description
		{
			get => simpleFileProcessControl.Description;
			set => simpleFileProcessControl.Description = value;
		}

		public string TextBoxLabelText
		{
			get => simpleFileProcessControl.TextBoxLabelText;
			set => simpleFileProcessControl.TextBoxLabelText = value;
		}

		public string TextBoxText
		{
			get => simpleFileProcessControl.TextBoxText;
			set => simpleFileProcessControl.TextBoxText = value;
		}

		public bool TextBoxEnabled
		{
			get => simpleFileProcessControl.TextBoxEnabled;
			set => simpleFileProcessControl.TextBoxEnabled = value;
		}

		public bool TextBoxVisible
		{
			get => simpleFileProcessControl.TextBoxVisible;
			set => simpleFileProcessControl.TextBoxVisible = value;
		}

		/// <inheritdoc cref="SimpleFileProcessControl.FileBrowseMode" />
		public FileBrowseModeEnum FileBrowseMode
		{
			get => simpleFileProcessControl.FileBrowseMode;
			set => simpleFileProcessControl.FileBrowseMode = value;
		}

		public bool MustShowExceptions
		{
			get => simpleFileProcessControl.MustShowExceptions;
			set => simpleFileProcessControl.MustShowExceptions = value;
		}

		/// <summary>
		/// Does nothing.
		/// The base form seems to be as bold as to
		/// assign the entry-point assembly name
		/// as the form's title bar text.
		/// </summary>
		public new string Text
		{
			get => null;
			set { }
		}

		// Positioning

		private void SimpleFileProcessForm_SizeChanged(object sender, EventArgs e) => PositionControls();

		private void PositionControls()
		{
			simpleFileProcessControl.Location = new Point(0, 0);
			simpleFileProcessControl.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);
		}

		// Processing

		public void ShowProgress(string message) => simpleFileProcessControl.ShowProgress(message);

		private void simpleProcessControl_OnRunProcess(object sender, EventArgs e) => OnRunProcess?.Invoke(sender, e);

	    private void Base_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = simpleFileProcessControl.IsRunning;
	}
}
