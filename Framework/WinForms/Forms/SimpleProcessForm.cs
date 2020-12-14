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
	public partial class SimpleProcessForm : Form
	{
		public event EventHandler OnRunProcess;
		public event EventHandler Cancelled;

		// Initialization

		public SimpleProcessForm()
		{
			InitializeComponent();

			if (Assembly.GetEntryAssembly() != null)
			{
				base.Text = Assembly.GetEntryAssembly().GetName().Name;
			}

			simpleProcessControl.OnRunProcess += SimpleProcessControl_OnRunProcess;
			simpleProcessControl.Cancelled += SimpleProcessControl_Cancelled;
		}

		private void SimpleProcessForm_Load(object sender, EventArgs e) => PositionControls();

		// Properties

		[Browsable(false)]
		public bool IsRunning
		{
			get => simpleProcessControl.IsRunning;
			set => simpleProcessControl.IsRunning = value;
		}

		[Category("Customization")]
		[Editor(
			"System.ComponentModel.Design.MultilineStringEditor, System.Design",
			"System.Drawing.Design.UITypeEditor")]
		public string Description
		{
			get => simpleProcessControl.Description;
			set => simpleProcessControl.Description = value;
		}

		[Category("Customization")]
		[DefaultValue("Path: ")]
		public string TextBoxLabelText
		{
			get => simpleProcessControl.TextBoxLabelText;
			set => simpleProcessControl.TextBoxLabelText = value;
		}

		[Category("Customization")]
		public string TextBoxText
		{
			get => simpleProcessControl.TextBoxText;
			set => simpleProcessControl.TextBoxText = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool TextBoxEnabled
		{
			get => simpleProcessControl.TextBoxEnabled;
			set => simpleProcessControl.TextBoxEnabled = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool TextBoxVisible
		{
			get => simpleProcessControl.TextBoxVisible;
			set => simpleProcessControl.TextBoxVisible = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.FileBrowseMode" />
		[Category("Customization")]
		public FileBrowseModeEnum FileBrowseMode
		{
			get => simpleProcessControl.FileBrowseMode;
			set => simpleProcessControl.FileBrowseMode = value;
		}

		[DefaultValue(true)]
		[Category("Customization")]
		public bool MustShowExceptions
		{
			get => simpleProcessControl.MustShowExceptions;
			set => simpleProcessControl.MustShowExceptions = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.AreYouSureQuestion" />
		[Category("Customization")]
		[DefaultValue("Are you sure?")]
		public string AreYouSureQuestion
		{
			get => simpleProcessControl.AreYouSureQuestion;
			set => simpleProcessControl.AreYouSureQuestion = value;
		}

		[Category("Customization")]
		[DefaultValue(16)]
		public int Spacing
		{
			get => simpleProcessControl.Spacing;
			set => simpleProcessControl.Spacing = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.TextBoxRightToLeft" />
		[Category("Customization")]
		[DefaultValue(RightToLeft.Yes)]
		public RightToLeft TextBoxRightToLeft
		{
			get => simpleProcessControl.TextBoxRightToLeft;
			set => simpleProcessControl.TextBoxRightToLeft = value;
		}

		[Category("Customization")]
		[DefaultValue("Start")]
		public string StartButtonText
		{
			get => simpleProcessControl.StartButtonText;
			set => simpleProcessControl.StartButtonText = value;
		}

		[Category("Customization")]
		[DefaultValue("Cancel")]
		public string CancelButtonText
		{
			get => simpleProcessControl.CancelButtonText;
			set => simpleProcessControl.CancelButtonText = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool BrowseButtonEnabled
		{
			get => simpleProcessControl.BrowseButtonEnabled;
			set => simpleProcessControl.BrowseButtonEnabled = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.TextBoxOrientation" />
		[Category("Customization")]
		[DefaultValue(UpDownOrientationEnum.Down)]
		public UpDownOrientationEnum TextBoxOrientation
		{
			get => simpleProcessControl.TextBoxOrientation;
			set => simpleProcessControl.TextBoxOrientation = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.TextBoxTop" />
		[Category("Customization")]
		[DefaultValue(146)]
		public int TextBoxTop
		{
			get => simpleProcessControl.TextBoxTop;
			set => simpleProcessControl.TextBoxTop = value;
		}

		/// <inheritdoc cref="SimpleProcessControl.MustShowEmptyProgressBar" />
		[Category("Customization")]
		[DefaultValue(146)]
		public bool MustShowEmptyProgressBar
		{
			get => simpleProcessControl.MustShowEmptyProgressBar;
			set => simpleProcessControl.MustShowEmptyProgressBar = value;
		}

		/// <summary>
		/// The base form seems to be as bold as to
		/// assign the entry-point assembly name
		/// as the form's title bar text.
		/// It may afterwards be assigned something custom.
		/// </summary>
		[Category("Customization")]
		public new string Text
		{
			get => base.Text;
			set => base.Text = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool CancelButtonVisible
		{
			get => simpleProcessControl.CancelButtonVisible;
			set => simpleProcessControl.CancelButtonVisible = value;
		}

		public int ButtonHeight => simpleProcessControl.ButtonHeight;

		// Positioning

		private void SimpleProcessForm_Resize(object sender, EventArgs e) => PositionControls();

		private void PositionControls()
		{
			simpleProcessControl.Location = new Point(0, 0);
			simpleProcessControl.Size = new Size(ClientRectangle.Width, ClientRectangle.Height);
		}

		// Processing

		public void ShowProgress(string message) => simpleProcessControl.ShowProgress(message);

		private void SimpleProcessControl_OnRunProcess(object sender, EventArgs e) => OnRunProcess?.Invoke(sender, e);

		private void SimpleProcessControl_Cancelled(object sender, EventArgs e) => Cancelled?.Invoke(sender, e);

	    private void Base_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = simpleProcessControl.IsRunning;

	    public void OnUiThread(Action action) => simpleProcessControl.OnUiThread(action);

		public void OnBackgroundThread(Action action) => simpleProcessControl.OnBackgroundThread(action);

	}
}
