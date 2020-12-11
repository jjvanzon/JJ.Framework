using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.Logging;
using JJ.Framework.WinForms.Helpers;

namespace JJ.Framework.WinForms.Controls
{
	[PublicAPI]
	public partial class SimpleProcessControl : UserControl
	{
		private bool _isLoaded;

		public event EventHandler OnRunProcess;
		public event EventHandler Cancelled;

		// Initialization

		public SimpleProcessControl()
		{
			InitializeComponent();

			_isRunning = false;
		}

		private void SimpleProcessControl_Load(object sender, EventArgs e)
		{
			_isLoaded = true;

			ApplySpacing();
			ApplyIsRunning();
			ApplyToLabelProgressVisible();

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

		[Category("Customization")]
		[Editor(
			"System.ComponentModel.Design.MultilineStringEditor, System.Design",
			"System.Drawing.Design.UITypeEditor")]
		public string Description
		{
			get => labelDescription.Text;
			set => labelDescription.Text = value;
		}

		[Category("Customization")]
		[DefaultValue("Path: ")]
		public string TextBoxLabelText
		{
			get => filePathControl.LabelText;
			set => filePathControl.LabelText = value;
		}

		[Category("Customization")]
		public string TextBoxText
		{
			get => filePathControl.FilePath;
			set => filePathControl.FilePath = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool TextBoxEnabled
		{
			get => filePathControl.TextBoxEnabled;
			set => filePathControl.TextBoxEnabled = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool TextBoxVisible
		{
			get => filePathControl.TextBoxVisible;
			set => filePathControl.TextBoxVisible = value;
		}

		/// <inheritdoc cref="FilePathControl.FileBrowseMode" />
		[Category("Customization")]
		public FileBrowseModeEnum FileBrowseMode
		{
			get => filePathControl.FileBrowseMode;
			set => filePathControl.FileBrowseMode = value;
		}

		/// <inheritdoc cref="FilePathControl.TextBoxRightToLeft" />
		[Category("Customization")]
		[DefaultValue(RightToLeft.Yes)]
		public RightToLeft TextBoxRightToLeft
		{
			get => filePathControl.TextBoxRightToLeft;
			set => filePathControl.TextBoxRightToLeft = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool MustShowExceptions { get; set; } = true;

		/// <summary> If empty the "Are you sure?" question may not be shown. </summary>
		[Category("Customization")]
		[DefaultValue("Are you sure?")]
		public string AreYouSureQuestion { get; set; } = "Are you sure?";

		private int _spacing = 16;
		[Category("Customization")]
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

		[Category("Customization")]
		[DefaultValue("Start")]
		public string StartButtonText
		{
			get => buttonStart.Text;
			set => buttonStart.Text = value;
		}

		[Category("Customization")]
		[DefaultValue("Cancel")]
		public string CancelButtonText
		{
			get => buttonCancel.Text;
			set => buttonCancel.Text = value;
		}

		[Category("Customization")]
		[DefaultValue(true)]
		public bool BrowseButtonEnabled
		{
			get => filePathControl.BrowseButtonEnabled;
			set => filePathControl.BrowseButtonEnabled = value;
		}

		private UpDownOrientationEnum _textBoxOrientation = UpDownOrientationEnum.Down;
		/// <summary>
		/// In case TextBoxOrientation would be Up, TextBoxTop might become relevant.
		/// </summary>
		[Category("Customization")]
		[DefaultValue(UpDownOrientationEnum.Down)]
		public UpDownOrientationEnum TextBoxOrientation
		{
			get => _textBoxOrientation;
			set
			{
				_textBoxOrientation = value;
				PositionControls();
			}
		}

		private int _textBoxTop = 146;
		/// <summary>
		/// How high in (DPI-scaled) pixels the description text at the top would be.
		/// May only be relevant if TextBoxOrientation would be "Up".
		/// </summary>
		[Category("Customization")]
		[DefaultValue(146)]
		public int TextBoxTop
		{
			get => _textBoxTop;
			set
			{
				_textBoxTop = value;
				PositionControls();
			}
		}

		private bool _mustShowEmptyProgressBar = true;
		[Category("Customization")]
		[DefaultValue(true)]
		public bool MustShowEmptyProgressBar
		{
			get => _mustShowEmptyProgressBar;
			set
			{
				_mustShowEmptyProgressBar = value;
				ApplyToLabelProgressVisible();
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

		private void ApplyToLabelProgressVisible() 
			=> labelProgress.Visible = MustShowEmptyProgressBar || !string.IsNullOrWhiteSpace(labelProgress.Text);

		// Positioning

		private void SimpleProcessControl_Resize(object sender, EventArgs e) => PositionControls();

		private void PositionControls()
		{
			int y = Height;

			if (labelProgress.Visible)
			{
				y -= labelProgress.Height;

				labelProgress.Location = new Point(0, y);
				labelProgress.Width = Width;
			}

			y -= Spacing;
			y -= buttonStart.Height;

			int buttonY = y;
			buttonStart.Location = new Point(Spacing, y);
			buttonCancel.Location = new Point(Width - Spacing - buttonCancel.Width, y);

			switch (TextBoxOrientation)
			{
				case UpDownOrientationEnum.Up:
					labelDescription.Location = new Point(Spacing, Spacing);
					labelDescription.Size = new Size(Width - Spacing - Spacing, TextBoxTop - Spacing);

					filePathControl.Location = new Point(Spacing, TextBoxTop);
					filePathControl.Width = Width - Spacing - Spacing;
					break;

				case UpDownOrientationEnum.Down:
					y = buttonY;
					y -= Spacing;
					y -= filePathControl.Height;

					int filePathControlY = y;
					filePathControl.Location = new Point(Spacing, y);
					filePathControl.Width = Width - Spacing - Spacing;

					y = Spacing;

					labelDescription.Location = new Point(Spacing, y);
					labelDescription.Size = new Size(Width - Spacing - Spacing, filePathControlY - Spacing);
					break;

				default:
					throw new InvalidValueException(TextBoxOrientation);
			}
		}

		// Actions

		private void ButtonStart_Click(object sender, EventArgs e) => Start();

		private void ButtonCancel_Click(object sender, EventArgs e) => Cancel();

		private void Start()
		{
			var dialogResult = DialogResult.Yes;
			if (!string.IsNullOrWhiteSpace(AreYouSureQuestion))
			{
				dialogResult = MessageBox.Show(AreYouSureQuestion, "", MessageBoxButtons.YesNo);
			}

			if (dialogResult == DialogResult.Yes)
			{
				OnBackgroundThread(RunProcess);
			}
		}

		private void Cancel()
		{
			IsRunning = false;
			Cancelled?.Invoke(this, EventArgs.Empty);
		}

		// Processing

		private void RunProcess()
		{
			try
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
			}
			finally
			{
				IsRunning = false;
			}
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
