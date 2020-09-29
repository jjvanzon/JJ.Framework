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
		public event EventHandler Cancelled;

		// Initialization

		public SimpleFileProcessForm()
		{
			InitializeComponent();

			if (Assembly.GetEntryAssembly() != null)
			{
				base.Text = Assembly.GetEntryAssembly().GetName().Name;
			}

			simpleFileProcessControl.OnRunProcess += SimpleProcessControl_OnRunProcess;
			simpleFileProcessControl.Cancelled += SimpleProcessControl_Cancelled;
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

		[DefaultValue("Path: ")]
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

		[DefaultValue(true)]
		public bool TextBoxEnabled
		{
			get => simpleFileProcessControl.TextBoxEnabled;
			set => simpleFileProcessControl.TextBoxEnabled = value;
		}

		[DefaultValue(true)]
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

		[DefaultValue(true)]
		public bool MustShowExceptions
		{
			get => simpleFileProcessControl.MustShowExceptions;
			set => simpleFileProcessControl.MustShowExceptions = value;
		}

		[DefaultValue("Are you sure?")]
		public string AreYouSureMessage
		{
			get => simpleFileProcessControl.AreYouSureMessage;
			set => simpleFileProcessControl.AreYouSureMessage = value;
		}

		[DefaultValue(16)]
		public int Spacing
		{
			get => simpleFileProcessControl.Spacing;
			set => simpleFileProcessControl.Spacing = value;
		}

		/// <inheritdoc cref="SimpleFileProcessControl.TextBoxRightToLeft" />
		[DefaultValue(RightToLeft.Yes)]
		public RightToLeft TextBoxRightToLeft
		{
			get => simpleFileProcessControl.TextBoxRightToLeft;
			set => simpleFileProcessControl.TextBoxRightToLeft = value;
		}

		[DefaultValue("Start")]
		public string StartButtonText
		{
			get => simpleFileProcessControl.StartButtonText;
			set => simpleFileProcessControl.StartButtonText = value;
		}

		[DefaultValue("Cancel")]
		public string CancelButtonText
		{
			get => simpleFileProcessControl.CancelButtonText;
			set => simpleFileProcessControl.CancelButtonText = value;
		}

		[DefaultValue(true)]
		public bool BrowseButtonEnabled
		{
			get => simpleFileProcessControl.BrowseButtonEnabled;
			set => simpleFileProcessControl.BrowseButtonEnabled = false;
		}

		/// <summary>
		/// The base form seems to be as bold as to
		/// assign the entry-point assembly name
		/// as the form's title bar text.
		/// It may afterwards be assigned something custom.
		/// </summary>
		public new string Text
		{
			get => base.Text;
			set => base.Text = value;
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

		private void SimpleProcessControl_OnRunProcess(object sender, EventArgs e) => OnRunProcess?.Invoke(sender, e);

		private void SimpleProcessControl_Cancelled(object sender, EventArgs e) => Cancelled?.Invoke(sender, e);

	    private void Base_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = simpleFileProcessControl.IsRunning;

	    public void OnUiThread(Action action) => simpleFileProcessControl.OnUiThread(action);

		public void OnBackgroundThread(Action action) => simpleFileProcessControl.OnBackgroundThread(action);
	}
}
