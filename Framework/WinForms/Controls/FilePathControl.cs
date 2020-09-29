using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.WinForms.EventArg;
using JJ.Framework.WinForms.Extensions;
using JJ.Framework.WinForms.Helpers;
// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault

namespace JJ.Framework.WinForms.Controls
{
	/// <summary>
	/// Would show a label, a text box and a browse button,
	/// that might show a dialog to open or save a file or select a folder.
	/// Might also be used if a text box would optionally
	/// sometimes have a file browse function.
	/// </summary>
	[PublicAPI]
	public partial class FilePathControl : UserControl
	{
		// TODO: Tooltip only works when TextBoxEnabled = true;

		public event EventHandler<FilePathEventArgs> Browsed;

		private CommonDialog _commonDialog;
		private readonly Graphics _graphics;

		// Initialization

		public FilePathControl()
		{
			_graphics = CreateGraphics();

			InitializeComponent();

			textBox.RightToLeft = RightToLeft.Yes;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			RequestPositionControls();
		}

		// Properties

		/// <summary> Would get or set the FilePath in the TextBox. </summary>
		public override string Text
		{
			get => FilePath;
			set => FilePath = value;
		}

		/// <summary> In case of no label text, this would hide the label. </summary>
		[DefaultValue("Path: ")]
		public string LabelText 
		{
			get => label.Text;
			set
			{
				if (label.Text == value) return;
				label.Text = value;
				RequestPositionControls();
			}
		}

		/// <summary> Would get or set what's in the text box. </summary>
		public string FilePath
		{
			get => textBox.Text;
			set => textBox.Text = value;
		}

		private FileBrowseModeEnum _fileBrowseMode;
		/// <inheritdoc cref="FileBrowseModeEnum" />
		public FileBrowseModeEnum FileBrowseMode
		{
			get => _fileBrowseMode;
			set => SetFileBrowseMode(value);
		}

		private int _spacing;
		[DefaultValue(4)]
		public int Spacing
		{
			get => _spacing;
			set
			{
				if (_spacing == value) return;
				_spacing = value;
				RequestPositionControls();
			}
		}

		private bool _textBoxEnabled = true;
		[DefaultValue(true)]
		public bool TextBoxEnabled
		{
			get => _textBoxEnabled;
			set
			{
				_textBoxEnabled = value;
				ApplyEnabled();
			}
		}

		[DefaultValue(true)]
		public bool TextBoxVisible
		{
			get => textBox.Visible;
			set => textBox.Visible = value;
		}

		/// <summary>
		/// Tip: To be able to see the of the file name when a long file path would not fit in the text box,
		/// RightToLeft may be set to Yes.
		/// (Other options were considered. TextAlign = Right might sounded like a solution,
		/// but then if the text is too long to fit,
		/// that still seems to still show the beginning of the path instead of the end.
		/// Showing the full path as a tool tip seemed another option,
		/// but then the tool tip did not seem to be shown if the control was disabled.)
		/// </summary>
		[DefaultValue(RightToLeft.Yes)]
		public RightToLeft TextBoxRightToLeft
		{
			get => textBox.RightToLeft;
			set => textBox.RightToLeft = value;
		}

		// Applying

		private void SetFileBrowseMode(FileBrowseModeEnum value)
		{
			_commonDialog = value switch
			{
				FileBrowseModeEnum.None => null,
				FileBrowseModeEnum.OpenFile => new OpenFileDialog(),
				FileBrowseModeEnum.SaveFile => new SaveFileDialog(),
				FileBrowseModeEnum.SelectFolder => new FolderBrowserDialog(),
				_ => throw new InvalidValueException(value)
			};

			buttonBrowse.Visible = value != FileBrowseModeEnum.None;

			_fileBrowseMode = value;

			RequestPositionControls();
		}

		private void FilePathControl_EnabledChanged(object sender, EventArgs e) => ApplyEnabled();

		private void ApplyEnabled()
		{
			textBox.Enabled = Enabled && TextBoxEnabled;
			label.Enabled = Enabled;
			buttonBrowse.Enabled = Enabled;
		}
		
		// Positioning

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			RequestPositionControls();
		}

		private void RequestPositionControls()
		{
			if (timerPositionControls == null) return;
			timerPositionControls.Enabled = true;
		}

		private void TimerPositionControls_Tick(object sender, EventArgs e) => PositionControls();

	    private void PositionControls()
		{
			try
			{
				SuspendLayout();

				timerPositionControls.Enabled = false;

				// TODO: Label and TextBox text does not line up.
				// TODO:
				// I chose not to use label auto-sizing, because WinForms often does not do a good job positioning (see comment above),
				// so I decided to take matters into my own hands. But The measure text solution here also gave me all sorts of trouble.
				// Perhaps it would have been a better plan to use WinForms in a standard way and build solutions to its problems
				// on top of this.

				const int y = 0;
				var x = 0;
				int height = textBox.Height; // We cannot size a TextBox's height, so we're stuck with it.

				// label
				if (!string.IsNullOrEmpty(label.Text))
				{
					float textWidth = ControlHelper.MeasureStringWithFontScaling(_graphics, label).Width;
					var labelWidth = (int)Math.Ceiling(textWidth);
					labelWidth += 2; // MeasureText and Label.Width do not seem to want to work together...
					label.Location = new Point(x, y);
					label.Size = new Size(labelWidth, height);

					x += label.Width + _spacing;
				}


				// textBox
				textBox.Location = new Point(x, y);

				int textBoxWidth = Width - x;
				if (FileBrowseMode != FileBrowseModeEnum.None) textBoxWidth = textBoxWidth - buttonBrowse.Width - _spacing;
				if (textBoxWidth < 1) textBoxWidth = 1;
				textBox.Width = textBoxWidth;

				x += textBox.Width + _spacing;

				// buttonBrowse
				if (FileBrowseMode != FileBrowseModeEnum.None)
				{
					buttonBrowse.Location = new Point(x, y);
					buttonBrowse.Height = height;
				}
			}
			finally
			{
				ResumeLayout();
			}
		}

		// Actions

		private void ButtonBrowse_Click(object sender, EventArgs e)
		{
			_commonDialog.SetPath_OrException(textBox.Text);

			if (_commonDialog.ShowDialog() == DialogResult.OK)
			{
				textBox.Text = _commonDialog.GetPath_OrException();

				if (Browsed != null)
				{
					var e2 = new FilePathEventArgs(textBox.Text);
					Browsed(this, e2);
				}
			}
		}

		private void TextBox_TextChanged(object sender, EventArgs e) => toolTip.SetToolTip(textBox, textBox.Text);
	}
}
