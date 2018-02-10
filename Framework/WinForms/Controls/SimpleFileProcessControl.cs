using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using JJ.Framework.Logging;

namespace JJ.Framework.WinForms.Controls
{
	public partial class SimpleFileProcessControl : UserControl
	{
		private const int SPACING = 16;

		private bool _isLoaded;

		public event EventHandler OnRunProcess;

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

		private void buttonStart_Click(object sender, EventArgs e) => Start();

		private void buttonCancel_Click(object sender, EventArgs e) => Cancel();

		private void SimpleFileProcessControl_Resize(object sender, EventArgs e) => PositionControls();

		private void PositionControls()
		{
			int y = Height;

			y -= labelProgress.Height;

			labelProgress.Location = new Point(0, y);
			labelProgress.Width = Width;

			y -= SPACING;
			y -= buttonStart.Height;

			buttonStart.Location = new Point(SPACING, y);
			buttonCancel.Location = new Point(Width - SPACING - buttonCancel.Width, y);

			y -= SPACING;
			y -= textBoxFilePath.Height;

			labelFilePath.Location = new Point(SPACING, y);

			int textBoxFilePathWidth = SPACING + labelFilePath.Width + SPACING;
			textBoxFilePath.Location = new Point(textBoxFilePathWidth, y);
			textBoxFilePath.Width = Width - SPACING - textBoxFilePathWidth;

			labelDescription.Location = new Point(SPACING, SPACING);
			labelDescription.Size = new Size(Width - SPACING - SPACING, Height - textBoxFilePath.Top - SPACING - SPACING);
		}

		private void Start()
		{
			if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Async(RunProcess);
			}
		}

		private void Cancel() => IsRunning = false;

		// Processing

		private void RunProcess()
		{
			IsRunning = true;

			try
			{
				OnRunProcess?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				if (MustShowExceptions)
				{
					string exception = ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace: false);
					OnUiThread(() => MessageBox.Show(exception));
				}
				else
				{
					throw;
				}
			}

			IsRunning = false;
		}

		// Progress Label

		public void ShowProgress(string message) => OnUiThread(() => labelProgress.Text = message);

		// IsRunning

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

		public string FilePath
		{
			get => textBoxFilePath.Text;
			set => textBoxFilePath.Text = value;
		}

		[Editor(
			"System.ComponentModel.Design.MultilineStringEditor, System.Design",
			"System.Drawing.Design.UITypeEditor")]
		public string Description
		{
			get => labelDescription.Text;
			set => labelDescription.Text = value;
		}

		[DefaultValue(true)]
		public bool MustShowExceptions { get; set; }

		// Helpers

		private void OnUiThread(Action action)
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

		private void Async(Action action)
		{
			var thread = new Thread(new ThreadStart(action));
			thread.Start();
		}
	}
}
