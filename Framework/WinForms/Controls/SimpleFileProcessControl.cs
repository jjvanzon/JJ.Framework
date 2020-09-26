using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using JetBrains.Annotations;
using JJ.Framework.Logging;
using JJ.Framework.WinForms.Helpers;

namespace JJ.Framework.WinForms.Controls
{
	[PublicAPI]
	public partial class SimpleFileProcessControl : UserControl
	{
		private bool _isLoaded;

		public event EventHandler OnRunProcess;

		// Initialization

		public SimpleFileProcessControl()
		{
			InitializeComponent();

			_isRunning = false;
		}

		private void SimpleFileProcessControl_Load(object sender, EventArgs e)
		{
			_isLoaded = true;

			ApplyIsRunning();

			PositionControls();
		}

		// Properties

		private volatile bool _isRunning;
		[Browsable(false)]
		public bool IsRunning
		{
			get => _isRunning;
			set
			{
				_isRunning = value;
				ApplyIsRunning();
			}
		}

		[Editor(
			"System.ComponentModel.Design.MultilineStringEditor, System.Design",
			"System.Drawing.Design.UITypeEditor")]
		public string Description
		{
			get => labelDescription.Text;
			set => labelDescription.Text = value;
		}

		[DefaultValue("Path: ")]
		public string TextBoxLabelText
		{
			get => filePathControl.LabelText;
			set => filePathControl.LabelText = value;
		}

		public string TextBoxText
		{
			get => filePathControl.FilePath;
			set => filePathControl.FilePath = value;
		}

		[DefaultValue(true)]
		public bool TextBoxEnabled
		{
			get => filePathControl.TextBoxEnabled;
			set => filePathControl.TextBoxEnabled = value;
		}

		[DefaultValue(true)]
		public bool TextBoxVisible
		{
			get => filePathControl.TextBoxVisible;
			set => filePathControl.TextBoxVisible = value;
		}

		/// <inheritdoc cref="FilePathControl.FileBrowseMode" />
		public FileBrowseModeEnum FileBrowseMode
		{
			get => filePathControl.FileBrowseMode;
			set => filePathControl.FileBrowseMode = value;
		}

		[DefaultValue(true)]
		public bool MustShowExceptions { get; set; }

		[DefaultValue("Are you sure?")]
		public string AreYouSureMessage { get; set; } = "Are you sure?";

		private int _spacing = 16;
		[DefaultValue(16)]
		public int Spacing
		{
			get => _spacing;
			set
			{
				_spacing = value;
				ApplySpacing();
				PositionControls();
			}
		}

		// Applying

		private void ApplySpacing() => filePathControl.Spacing = Spacing;

		private void ApplyIsRunning()
			=> OnUiThread(
				() =>
				{
					buttonStart.Enabled = !_isRunning;
					buttonCancel.Enabled = _isRunning;
					filePathControl.Enabled = !_isRunning;
				});

		// Positioning

		private void SimpleFileProcessControl_Resize(object sender, EventArgs e) => PositionControls();

		private void PositionControls()
		{
			int y = Height;

			y -= labelProgress.Height;

			labelProgress.Location = new Point(0, y);
			labelProgress.Width = Width;

			y -= Spacing;
			y -= buttonStart.Height;

			buttonStart.Location = new Point(Spacing, y);
			buttonCancel.Location = new Point(Width - Spacing - buttonCancel.Width, y);

			y -= Spacing;
			y -= filePathControl.Height;

			int filePathControlTop = y;
			filePathControl.Location = new Point(Spacing, y);
			filePathControl.Width = Width - Spacing - Spacing;

			labelDescription.Location = new Point(Spacing, Spacing);
			labelDescription.Size = new Size(Width - Spacing - Spacing, Height - filePathControlTop - Spacing - Spacing);
		}

		// Actions

		private void ButtonStart_Click(object sender, EventArgs e) => Start();

		private void ButtonCancel_Click(object sender, EventArgs e) => Cancel();

		private void Start()
		{
			if (MessageBox.Show(AreYouSureMessage, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				OnBackgroundThread(RunProcess);
			}
		}

		private void Cancel() => IsRunning = false;

		// Processing

		private void RunProcess()
		{
			IsRunning = true;

			if (!MustShowExceptions)
			{
				OnRunProcess?.Invoke(this, EventArgs.Empty);
			}
			else
			{
				try
				{
					OnRunProcess?.Invoke(this, EventArgs.Empty);
				}
				catch (Exception ex)
				{
					string exception = ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace: false);
					OnUiThread(() => MessageBox.Show(exception));
				}
			}

			IsRunning = false;
		}

		public void ShowProgress(string message) => OnUiThread(() => labelProgress.Text = message);

		// Helpers

		public void OnUiThread(Action action)
		{
			if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
			{
				return;
			}

			if (DesignMode)
			{
				return;
			}

			if (!_isLoaded)
			{
				return;
			}

			BeginInvoke(action);
		}

		public void OnBackgroundThread(Action action) => new Thread(new ThreadStart(action)).Start();
	}
}
